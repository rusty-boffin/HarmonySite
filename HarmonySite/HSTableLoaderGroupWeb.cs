using NLog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace RustyBoffin.HarmonySite
{
    internal class HSTableLoaderGroupWeb : HSTableLoaderGroup
    {
        protected static Logger _Logger = NLog.LogManager.GetCurrentClassLogger();
        private HttpClient _Client;
        private HttpContent _AuthoriseContent;
        private string? _Token = null;
        private Uri _Uri;

        public HSTableLoaderGroupWeb(HSSession session, CancellationToken cancellationToken)
            : base(session, cancellationToken)
        {
            _Uri = new Uri(session.Uri, "/api");
            _Client = new HttpClient();
            _Client.DefaultRequestHeaders.Accept.Clear();

            var data = new Dictionary<string, string>
            {
                { "endpoint", "authorise" },
                { "output", "xml" },
                { "username", session.Username },
                { "password", session.Password }
            };

            _AuthoriseContent = new FormUrlEncodedContent(data);
        }

        public override async Task Load()
        {
            await base.Load();

            try
            {
                int retries = 10;
                while ((retries-- == 10)
                    || (string.IsNullOrEmpty(_Token) && !CancellationToken.IsCancellationRequested && retries > 0))
                {
                    if (string.IsNullOrEmpty(_Token))
                    {
                        _Logger.Debug(await _AuthoriseContent.ReadAsStringAsync());
                        HttpResponseMessage reply = await _Client.PostAsync(_Uri, _AuthoriseContent, CancellationToken);
                        if (reply.IsSuccessStatusCode)
                        {
                            string XML = await reply.Content.ReadAsStringAsync();
                            XmlDocument xDoc = new XmlDocument();
                            xDoc.LoadXml(XML);
                            if (xDoc.DocumentElement != null)
                            {
                                string? s = xDoc.DocumentElement.Attributes["status"]?.Value;
                                switch (s)
                                {
                                    case "okay":
                                        XmlNode? records = xDoc.DocumentElement.SelectSingleNode("token");
                                        _Token = Uri.UnescapeDataString(records?.InnerText);
                                        _Logger.Trace("Token = {0}", _Token);
                                        break;
                                    case "error":
                                        _Logger.Debug(XML);
                                        break;
                                    default:
                                        _Logger.Debug(XML);
                                        throw new Exception(string.Format("Unknown status {0}", s));
                                }
                            }
                        }
                    }
                    foreach (HSTableLoader tl in LoaderList)
                    {
                        if (_Token == null) continue;
                        ITableLoaderWeb tlw = (ITableLoaderWeb)tl;
                        if (!await tlw.Load(_Client, _Token))
                            _Token = null;
                    }
                }
            }
            catch (Exception ex)
            {
                _Logger.Debug(ex.Message);
            }
        }
    }
}
