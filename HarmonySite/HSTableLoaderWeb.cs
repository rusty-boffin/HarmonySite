using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace RustyBoffin.HarmonySite
{
    internal interface ITableLoaderWeb
    {
        Task RunAsync(HSTableLoaderGroupWeb group, string authenticationToken);
        bool IsLoaded { get; }
    }
    internal class HSTableLoaderWeb<T> : HSTableLoader<T>, ITableLoaderWeb where T : HSObject
    {
        private Dictionary<string, string> _BrowsePayload;
        private Uri _Uri;

        public HSTableLoaderWeb(HSSession session, string tableName, CancellationToken cancellationToken, HSTable table)
            : base(session, tableName, cancellationToken, table)
        {
            _Uri = new Uri(session.Uri, "/api");
            _BrowsePayload = new Dictionary<string, string>
                {
                    { "endpoint", "browse" },
                    { "output","xml" },
                    { "token", "" },
                    { "table", tableName },
                    {"n", "1024" },
                    { "startrec", "1" }
                };
        }

        public async Task RunAsync(HSTableLoaderGroupWeb group, string authenticationToken)
        {
            _BrowsePayload["token"] = authenticationToken;

            Reset();
            var offset = 1;
            bool more = true;

            while (more && !CancellationToken.IsCancellationRequested)
            {
                _BrowsePayload["startrec"] = offset.ToString();

                var content = new FormUrlEncodedContent(_BrowsePayload);

                string description = await content.ReadAsStringAsync(CancellationToken);
                try
                {
                    var response = await group.SendDataRequestAsync(_Uri, content, CancellationToken);
                    response.EnsureSuccessStatusCode();

                    string XML = await response.Content.ReadAsStringAsync();
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.LoadXml(XML);
                    if (xDoc.DocumentElement == null)
                    {
                        _Logger.Error(@"{2} {0} : Null DocElement, '{1}'", TableName, XML, group._ID);
                        return;
                    }
                    else
                    {
                        string? s = xDoc.DocumentElement.Attributes["status"]?.Value;
                        switch (s)
                        {
                            case "okay":
                                XmlNode? records = xDoc.DocumentElement.SelectSingleNode("//records");
                                int available = Convert.ToInt32(records.Attributes["available"].Value);
                                offset += Convert.ToInt32(records.Attributes["count"].Value);
                                _Logger.Trace("{3} {0} : {1}/{2}", TableName, offset - 1, available, group._ID);

                                foreach (XmlNode record in records.ChildNodes)
                                {
                                    Dictionary<string, string> values = new Dictionary<string, string>();
                                    foreach (XmlNode value in record.ChildNodes)
                                    {
                                        if (!values.ContainsKey(value.Name))
                                            values.Add(value.Name, value.InnerText);
                                    }
                                    CreateObject(values);
                                }
                                RaiseProgressChanged(Count, available);
                                more = offset <= available && available > 0;
                                if (!more)
                                    RaiseLoaded();
                                break;
                            case "error":
                                _Logger.Error(@"{2} {0} : status=error, '{1}'", TableName, XML, group._ID);
                                return;
                            default:
                                _Logger.Error(@"{2} {0} : status=???, '{1}'", TableName, XML, group._ID);
                                throw new Exception(string.Format("Unknown status {0}", s));
                        }
                    }
                }
                catch (Exception ex)
                {
                    _Logger.Error(@"{0} {1} : Exception '{2}'", group._ID, TableName, ex.Message);
                    group.AddDeadLetter($"{TableName}-page", description, ex);
                    more = false;
                }
            }
        }
    }
}
