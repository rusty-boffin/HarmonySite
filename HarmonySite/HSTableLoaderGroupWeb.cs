using NLog;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Syncfusion.XlsIO.Implementation.XmlSerialization;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace RustyBoffin.HarmonySite
{
    public sealed record DeadLetterItem(
        string TableName,
        string Stage,
        string RequestDescription,
        string ErrorMessage,
        DateTimeOffset Timestamp);

    public static class PipelineFactory
    {
        private static readonly Random _rng = new();

        private static TimeSpan Jitter(int attempt)
        {
            var exp = Math.Pow(2, attempt - 1);
            var jitter = _rng.NextDouble();
            return TimeSpan.FromSeconds(exp + jitter);
        }

        public static ResiliencePipeline<HttpResponseMessage> CreateDataPipeline(
            Func<Task> refreshToken,
            Action<string> log)
        {
            var builder = new ResiliencePipelineBuilder<HttpResponseMessage>();

            // Retry with jitter
            builder.AddRetry(new RetryStrategyOptions<HttpResponseMessage>
            {
                MaxRetryAttempts = 5,
                DelayGenerator = args =>
                {
                    var delay = Jitter(args.AttemptNumber);
                    log($"Data Retry {args.AttemptNumber}, delay {delay.TotalSeconds:F1}s");
                    return new ValueTask<TimeSpan?>(delay);
                },
                ShouldHandle = args =>
                {
                    if (args.Outcome.Exception is HttpRequestException)
                        return PredicateResult.True();

                    if (args.Outcome.Result is { StatusCode: HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden })
                        return PredicateResult.True();

                    if (args.Outcome.Result is { StatusCode: >= HttpStatusCode.InternalServerError })
                        return PredicateResult.True();

                    return PredicateResult.False();
                },
                OnRetry = async args =>
                {
                    if (args.Outcome.Result?.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
                    {
                        log($"Data Refreshing cancellationToken due to {args.Outcome.Result.StatusCode}");
                        await refreshToken();
                    }
                }
            });

            // Circuit breaker
            builder.AddCircuitBreaker(new CircuitBreakerStrategyOptions<HttpResponseMessage>
            {
                FailureRatio = 0.5,
                MinimumThroughput = 10,
                BreakDuration = TimeSpan.FromSeconds(30),
                ShouldHandle = args =>
                {
                    if (args.Outcome.Exception is HttpRequestException)
                        return PredicateResult.True();

                    if (args.Outcome.Result is { StatusCode: >= HttpStatusCode.InternalServerError })
                        return PredicateResult.True();

                    return PredicateResult.False();
                },
                OnOpened = args =>
                {
                    log($"Data CIRCUIT OPEN for {args.BreakDuration.TotalSeconds:F1}s");
                    return default;
                },
                OnClosed = args =>
                {
                    log($"Data CIRCUIT CLOSED");
                    return default;
                },
                OnHalfOpened = args =>
                {
                    log($"Data CIRCUIT HALF-OPEN");
                    return default;
                }
            });

            return builder.Build();
        }

        public static ResiliencePipeline<HttpResponseMessage> CreateTokenPipeline(
            Action<string> log)
        {
            var builder = new ResiliencePipelineBuilder<HttpResponseMessage>();

            builder.AddRetry(new RetryStrategyOptions<HttpResponseMessage>
            {
                MaxRetryAttempts = 5,
                DelayGenerator = args =>
                {
                    var delay = Jitter(args.AttemptNumber);
                    log($"Auth Token retry {args.AttemptNumber}, delay {delay.TotalSeconds:F1}s");
                    return new ValueTask<TimeSpan?>(delay);
                },
                ShouldHandle = args =>
                {
                    if (args.Outcome.Exception is HttpRequestException)
                        return PredicateResult.True();

                    if (args.Outcome.Result is { IsSuccessStatusCode: false })
                        return PredicateResult.True();

                    return PredicateResult.False();
                }
            });

            return builder.Build();
        }
    }

    internal sealed class HSTableLoaderGroupWeb : HSTableLoaderGroup
    {
        protected static Logger _Logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly HttpClient _Client;
        private readonly List<Task> _running = new();
        private string _AuthenticationToken = "";
        private HttpContent _AuthoriseContent;
        private Uri _Uri;
        private static int _IDCounter = 0;
        internal string _ID = $"HSTableLoaderGroupWeb-{Interlocked.Increment(ref _IDCounter)}";

        private readonly ResiliencePipeline<HttpResponseMessage> _tokenPipeline;
        private readonly ResiliencePipeline<HttpResponseMessage> _dataPipeline;

        private readonly ConcurrentBag<DeadLetterItem> _deadLetters = new();
        public IEnumerable<DeadLetterItem> DeadLetters => _deadLetters;

        public HSTableLoaderGroupWeb(HSSession session, CancellationToken cancellationToken, HttpClient client)
            : base(session, cancellationToken)
        {
            _Client = client;
            _Uri = new Uri(session.Uri, "/api");

            var data = new Dictionary<string, string>
            {
                { "endpoint", "authorise" },
                { "output", "xml" },
                { "username", session.Username },
                { "password", session.Password }
            };

            _AuthoriseContent = new FormUrlEncodedContent(data);

            void Log(string msg) => _Logger.Debug($"{_ID} {msg}");

            _tokenPipeline = PipelineFactory.CreateTokenPipeline(Log);
            _dataPipeline = PipelineFactory.CreateDataPipeline(RefreshTokenNoCancel, Log);
        }

        public override async Task Load()
        {
            await base.Load();
            await RunAsync(CancellationToken);
        }
        public void Start()
        {
            _running.Add(Task.Run(() => RunAsync(CancellationToken)));
        }

        private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private async Task RunAsync(CancellationToken token)
        {
            bool notLoaded = false;
            do
            {
                await _semaphore.WaitAsync();
                try
                {
                    await RefreshTokenAsync(CancellationToken);
                }
                finally 
                {
                    _semaphore.Release(); 
                }

                if (string.IsNullOrEmpty(_AuthenticationToken))
                {
                    _Logger.Error(@"{0} : Unable to obtain authentication token", _ID);
                    return;
                }

                notLoaded = false;
                foreach (var loader in LoaderList)
                {
                    if (!notLoaded && loader is ITableLoaderWeb loaderWebX)
                    {
                        if (!loaderWebX.IsLoaded)
                        {
                            await loaderWebX.RunAsync(this, _AuthenticationToken);
                            notLoaded = !loaderWebX.IsLoaded;
                        }
                    }
                }
                if (notLoaded && !CancellationToken.IsCancellationRequested)
                {
                    _Logger.Debug(@"{0} : loaders not loaded, retrying in 5 seconds", _ID);
                    await Task.Delay(5000, token);
                }
            }
            while (notLoaded && !CancellationToken.IsCancellationRequested);

            foreach (var deadLetter in _deadLetters)
            {
                _Logger.Error(@"{0} DeadLetter: Table={1}, Stage={2}, Request={3}, Error={4}, Timestamp={5}",
                    _ID, deadLetter.TableName, deadLetter.Stage, deadLetter.RequestDescription, deadLetter.ErrorMessage, deadLetter.Timestamp);
            }
        }

        internal async Task<HttpResponseMessage> SendDataRequestAsync(Uri uri, HttpContent content, CancellationToken token)
        {
            return await _dataPipeline.ExecuteAsync(
                async ct => await _Client.PostAsync(uri, content, ct),
                token);
        }

        private async Task RefreshTokenAsync(CancellationToken token)
        {
            _Logger.Trace(@"{0} RefreshTokenAsync", _ID);
            var response = await _tokenPipeline.ExecuteAsync(
                async ct => await _Client.PostAsync(_Uri, _AuthoriseContent, ct),
                token);

            if (response.IsSuccessStatusCode)
            {
                await ExtractToken(response.Content);
            }
        }

        private Task RefreshTokenNoCancel()
            => RefreshTokenAsync(CancellationToken);

        private async Task ExtractToken(HttpContent content)
        {
            string XML = await content.ReadAsStringAsync();
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(XML);
            if (xDoc.DocumentElement == null)
            {
                _Logger.Error(@"{0} {1} : Null DocElement, '{2}'", _ID, _AuthoriseContent, XML);
            }
            else
            {
                string? s = xDoc.DocumentElement.Attributes["status"]?.Value;
                switch (s)
                {
                    case "okay":
                        XmlNode? records = xDoc.DocumentElement.SelectSingleNode("token");
                        _AuthenticationToken = Uri.UnescapeDataString(records?.InnerText);
                        _Logger.Trace("{0} Token = {1}", _ID, _AuthenticationToken);
                        break;
                    case "error":
                        _Logger.Error(@"{0} {1} : status=error, '{2}'", _ID, _AuthoriseContent, XML);
                        break;
                    default:
                        _Logger.Error(@"{0} {1} : status=???, '{2}'", _ID, _AuthoriseContent, XML);
                        throw new Exception(string.Format("Unknown status {0}", s));
                }
            }
        }

        internal void AddDeadLetter(string table, string request, Exception ex)
        {
            _deadLetters.Add(new DeadLetterItem(
                TableName: table,
                Stage: $"{table}-page",
                RequestDescription: request,
                ErrorMessage: ex.ToString(),
                Timestamp: DateTimeOffset.Now));
        }
    }

}
