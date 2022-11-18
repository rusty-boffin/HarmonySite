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
            _Username = username;
            _Password = password;
            _Client = new HttpClient() { BaseAddress = uri };
            _Client.DefaultRequestHeaders.Accept.Clear();
        }

        private async Task GetToken()
        {
            string request = string.Format("api?endpoint=authorise&output=json&username={0}&password={1}", _Username, _Password);
            _Logger.Trace(request);
            HttpResponseMessage reply = await _Client.GetAsync(request);
            if (reply.IsSuccessStatusCode)
            {
                string json = await reply.Content.ReadAsStringAsync();
                _Logger.Trace(json);
                HSTokenResponse response = JsonSerializer.Deserialize<HSTokenResponse>(json);
                _Token = response.token;
                if (response.error != null)
                    throw new Exception(response.error);
            }
            else
                _Token = null;
        }

        public async Task<Dictionary<int, Dictionary<string, string>>> QueryAsync(string table, string filter, int id)
        {
            if (_Token == null)
                await GetToken();

            Dictionary<int, Dictionary<string, string>> result = new Dictionary<int, Dictionary<string, string>>();
            int start = 1;
            int available = 0;
            do
            {
                string request;
                if (string.IsNullOrEmpty(table))
                    request = string.Format("api?endpoint=config&output=xml&token={0}", _Token);
                else if (string.IsNullOrEmpty(filter))
                    request = string.Format("api?endpoint=browse&output=xml&token={0}&table={1}&n=10&startrec={2}", _Token, table, start);
                else
                    request = string.Format("api?endpoint=browse&output=xml&token={0}&table={1}&{2}={3}&n=10&startrec={4}", _Token, table, filter, id, start);
                _Logger.Trace(request);
                HttpResponseMessage reply = await _Client.GetAsync(request);
                if (!reply.IsSuccessStatusCode)
                    return null;

                string XML = await reply.Content.ReadAsStringAsync();
                _Logger.Trace(XML);
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(XML);

                string s = xDoc.DocumentElement.Attributes["status"].Value;
                switch (s)
                {
                    case "okay":
                        break;
                    case "error":
                        XmlNode error = xDoc.DocumentElement.SelectSingleNode("error");
                        throw new Exception(error.InnerText);
                    default:
                        throw new Exception(string.Format("Unknown status {0}", s));
                }
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
            }
            while (start <= available);

            return result;
        }

        public Dictionary<int, Dictionary<string, string>> Query(string table, string filter, int id)
        {
            return QueryAsync(table, filter, id).GetAwaiter().GetResult();
        }
    }

}
