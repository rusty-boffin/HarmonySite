using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace RustyBoffin.HarmonySite
{

    internal interface ITableLoaderCsv
    {
        void Load();
    }

    internal class HSTableLoaderCsv<T> : HSTableLoader<T>, ITableLoaderCsv where T : HSObject
    {
        private string _Filename;

        public HSTableLoaderCsv(HSSession session, string tableName, CancellationToken cancellationToken, HSTable table)
            : base(session, tableName, cancellationToken, table)
        {
            string site;
            if (session.Uri.Host.EndsWith(".nz"))
                site = "BHNZ";
            else
                site = "BHA";

            _Filename = string.Format("{0}.{1}.csv", site, TableName);
        }

        void ITableLoaderCsv.Load()
        {
            Task.Run(() =>
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                string[] s = asm.GetManifestResourceNames();
                string? csvfile = s.SingleOrDefault(r => r.EndsWith(_Filename));
                if (csvfile != null)
                {
                    _Logger.Trace("Reading {0}", csvfile);
                    using (Stream? fileStream = asm.GetManifestResourceStream(csvfile))
                    {
                        if (fileStream != null)
                        {
                            using (StreamReader reader = new StreamReader(fileStream))
                            {
                                using (CsvReader csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                                {
                                    HasHeaderRecord = true
                                }))
                                {
                                    csvReader.Read();
                                    csvReader.ReadHeader();
                                    if (csvReader.HeaderRecord != null)
                                    {
                                        while (csvReader.Read() && !CancellationToken.IsCancellationRequested)
                                        {
                                            Dictionary<string, string> values = new Dictionary<string, string>();
                                            foreach (string heading in csvReader.HeaderRecord)
                                                values.Add(heading, csvReader.GetField<string>(heading) ?? "");

                                            CreateObject(values);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                RaiseProgressChanged(Count, Count);
                RaiseLoaded();
            }).Wait(2000);
        }
    }
}
