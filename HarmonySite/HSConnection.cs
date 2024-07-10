using System;
using NLog;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;
using System.Text.Json;
using System.IO;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite
{
    public class HSConnection: IConnection
    {
        private static Logger _Logger = NLog.LogManager.GetCurrentClassLogger();

        private class HSResponseAttributes
        {
            public string status { get; set; }
        }
        private class HSTokenResponse
        {
            public HSResponseAttributes @attributes { get; set; }
            public string token { get; set; }
            public string error { get; set; }
        }

        public Uri Uri { get; private set; }

        private HttpClient _Client;
        private string _Username;
        private string _Password;
        private string _Token;

        public HSConnection(string url, string username, string password)
            : this(new Uri(url), username, password)
        {
        }

        public HSConnection(Uri uri, string username, string password)
        {
            Uri = uri;
            _Username = username;
            _Password = password;
            _Client = new HttpClient() { BaseAddress = uri };
            _Client.DefaultRequestHeaders.Accept.Clear();
        }

        private async Task GetToken()
        {
            string request = string.Format("api?endpoint=authorise&output=json&username={0}&password={1}", _Username, _Password);
            _Logger.Debug(request);
            HttpResponseMessage reply = await _Client.GetAsync(request);
            if (reply.IsSuccessStatusCode)
            {
                string json = await reply.Content.ReadAsStringAsync();
                _Logger.Debug(json);
                HSTokenResponse response = JsonSerializer.Deserialize<HSTokenResponse>(json);
                _Token = response.token;
                if (response.error != null)
                    throw new Exception(response.error);
            }
            else
                _Token = null;
        }

        private int retries = 10;
        public async Task<Dictionary<int, Dictionary<string, string>>> QueryAsync(string table, string filter, int id)
        {
            if (_Token == null)
                await GetToken();

            Dictionary<int, Dictionary<string, string>> result = new Dictionary<int, Dictionary<string, string>>();
            int start = 1;
            int available = 0;
            bool loop = false;
            do
            {
                string request;
                if (string.IsNullOrEmpty(table))
                    throw new Exception("No table name specified");
                else if (string.IsNullOrEmpty(filter))
                    request = string.Format("api?endpoint=browse&output=xml&token={0}&table={1}&n=1000&startrec={2}", _Token, table, start);
                else
                    request = string.Format("api?endpoint=browse&output=xml&token={0}&table={1}&{2}={3}&n=1000&startrec={4}", _Token, table, filter, id, start);
                _Logger.Debug(request);
                HttpResponseMessage reply = await _Client.GetAsync(request);
                if (!reply.IsSuccessStatusCode)
                    return null;

                string XML = await reply.Content.ReadAsStringAsync();
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(XML);

                string s = xDoc.DocumentElement.Attributes["status"].Value;
                switch (s)
                {
                    case "okay":
                        _Logger.Trace(XML);
                        XmlNode records;
                        if (table == null)
                        {
                            records = xDoc.DocumentElement;
                            available = 1;
                            start++;
                        }
                        else
                        {
                            records = xDoc.DocumentElement.SelectSingleNode("//records");
                            available = Convert.ToInt32(records.Attributes["available"].Value);
                            start += Convert.ToInt32(records.Attributes["count"].Value);
                        }

                        foreach (XmlNode record in records.ChildNodes)
                        {
                            Dictionary<string, string> values = new Dictionary<string, string>();
                            if (table == null)
                            {
                                values.Add("id", id.ToString());
                                values.Add("stamp", DateTime.Now.ToString());
                            }
                            int recId = 0;
                            foreach (XmlNode value in record.ChildNodes)
                            {
                                if (!values.ContainsKey(value.Name))
                                    values.Add(value.Name, value.InnerText);
                                if (value.Name == "id")
                                    recId = Convert.ToInt32(value.InnerText);
                            }
                            result.Add(recId, values);
                        }
                        loop = start <= available;
                        break;
                    case "error":
                        _Logger.Debug(XML);
                        if (retries-- <= 0)
                        {
                            XmlNode error = xDoc.DocumentElement.SelectSingleNode("error");
                            throw new Exception(error.InnerText);
                        }
                        await GetToken();
                        loop = true;
                        break;
                    default:
                        _Logger.Debug(XML);
                        throw new Exception(string.Format("Unknown status {0}", s));
                }
            }
            while (loop);

            return result;
        }

        public Dictionary<int, Dictionary<string, string>> Query(string table, string filter, int id)
        {
            return QueryAsync(table, filter, id).GetAwaiter().GetResult();
        }
    }

}
