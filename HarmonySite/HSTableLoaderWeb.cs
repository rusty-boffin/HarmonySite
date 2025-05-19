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
        Task<bool> Load(HttpClient client, string token);
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
                    {"n", "1000" },
                    { "startrec", "1" }
                };
        }

        public async Task<bool> Load(HttpClient client, string token)
        {
            _BrowsePayload["token"] = token;

            Dictionary<int, Dictionary<string, string>> result = new Dictionary<int, Dictionary<string, string>>();
            int start = 1;
            int available = 0;
            bool loop = false;
            do
            {
                if (token == null)
                    return false;

                _BrowsePayload["startrec"] = start.ToString();

                var content = new FormUrlEncodedContent(_BrowsePayload);

                _Logger.Debug(await content.ReadAsStringAsync());
                HttpResponseMessage reply = await client.PostAsync(_Uri, content, CancellationToken);
                if (!reply.IsSuccessStatusCode)
                    return false;

                string XML = await reply.Content.ReadAsStringAsync();
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(XML);
                if (xDoc.DocumentElement != null)
                {
                    string? s = xDoc.DocumentElement.Attributes["status"]?.Value;
                    switch (s)
                    {
                        case "okay":
                            XmlNode? records = xDoc.DocumentElement.SelectSingleNode("//records");
                            available = Convert.ToInt32(records.Attributes["available"].Value);
                            start += Convert.ToInt32(records.Attributes["count"].Value);
                            _Logger.Trace("{0} : {1}/{2}", TableName, start-1, available);

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
                            loop = start <= available;
                            break;
                        case "error":
                            _Logger.Debug(XML);
                            return false;
                        default:
                            _Logger.Debug(XML);
                            throw new Exception(string.Format("Unknown status {0}", s));
                    }
                }
            }
            while (loop && !CancellationToken.IsCancellationRequested);
            RaiseLoaded();
            return true;
        }
    }
}
