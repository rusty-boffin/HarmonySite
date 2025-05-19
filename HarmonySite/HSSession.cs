using NLog;
using RustyBoffin.HarmonySite.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace RustyBoffin.HarmonySite
{
    public class HSSession
    {
        private static Logger _Logger = NLog.LogManager.GetCurrentClassLogger();
        public string Name { get; }

        public event EventHandler? OnLoaded;

        public event ProgressChangedEventHandler? ProgressChanged;

        public HSSession(string name, string url, string username, string password)
        {
            HSTableLoaderGroupWeb? tlgw = null;
            HSTableLoaderGroupCsv? tlgc = null;
            Name = name;
            Uri = new Uri(url);
            Username = username;
            Password = password;

            // Create the token source.
            _TokenSource = new CancellationTokenSource();

            Website = new Website(this);

            Assembly hsa = Assembly.GetAssembly(typeof(HSObject));
            foreach (TypeInfo ti in hsa.DefinedTypes.Where(r => !r.IsAbstract && (r.BaseType == typeof(HSObject))))
            {
                Type tp = ti;
                Type tb = typeof(HSTable<>);
                ConstructorInfo? ci = typeof(HSTable<>).MakeGenericType(tp).GetConstructor([typeof(HSSession)]);
                HSTable t = (HSTable)ci.Invoke([this]);
                _tables.Add(tp, t);

                if (tp == typeof(Website)) 
                {
                    Website Website = new Website(this);
                    t.Load(Website);
                }
                else
                {
                    HSTableAttribute? ta = tp.GetCustomAttribute<HSTableAttribute>();
                    if (ta != null)
                    {
                        string? table = ta.TableName;

                        if (ta.Features == HSTableAttribute.eFeatures.Local)
                            ci = typeof(HSTableLoaderCsv<>).MakeGenericType(tp).GetConstructor([typeof(HSSession), typeof(string), typeof(CancellationToken), typeof(HSTable)]);
                        else
                            ci = typeof(HSTableLoaderWeb<>).MakeGenericType(tp).GetConstructor([typeof(HSSession), typeof(string), typeof(CancellationToken), typeof(HSTable)]);
                        HSTableLoader tl = (HSTableLoader)ci.Invoke([this, table, _TokenSource.Token, t]);
                        TableLoaders.Add(tl);

                        tl.ProgressChanged += TableProgressChanged;
                        tl.Loaded += Table_Loaded;
                        switch (ta.Features)
                        {
                            case HSTableAttribute.eFeatures.Local:
                                if (tlgc == null)
                                {
                                    tlgc = new HSTableLoaderGroupCsv(this, _TokenSource.Token);
                                    _loaderGroups.Add(tlgc);
                                }
                                tlgc.Add(tl);
                                break;
                            case HSTableAttribute.eFeatures.Large:
                                HSTableLoaderGroup tlg = new HSTableLoaderGroupWeb(this, _TokenSource.Token);
                                tlg.Add(tl);
                                _loaderGroups.Add(tlg);
                                break;
                            case HSTableAttribute.eFeatures.Small:
                                if ((tlgw != null) && tlgw.Count >= 15)
                                    tlgw = null;
                                if (tlgw == null)
                                {
                                    tlgw = new HSTableLoaderGroupWeb(this, _TokenSource.Token);
                                    _loaderGroups.Add(tlgw);
                                }
                                tlgw.Add(tl);
                                break;

                        }

                    }
                }
            }
        }

        private int _TableCount = 0;
        private void Table_Loaded(object? sender, EventArgs e)
        {
            if (--_TableCount == 0)
                OnLoaded?.Invoke(this, EventArgs.Empty);
        }

        int TableNumber = 0;

        private void TableProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            int pc = ((TableNumber * 100) + e?.ProgressPercentage??0) / _tables.Count;
            ProgressChanged?.Invoke(this, new ProgressChangedEventArgs(pc, e?.UserState));
        }

        private CancellationTokenSource _TokenSource;
        public void Load()
        {
            _TableCount = TableLoaders.Count;
            foreach (HSTableLoaderGroup loader in _loaderGroups)
                loader.Load();
        }

        public void Shutdown()
        {
            _TokenSource.Cancel();
            _TokenSource.Dispose();
        }

        private Dictionary<Type, HSTable> _tables = new Dictionary<Type, HSTable>();
        private List<HSTableLoaderGroup> _loaderGroups = new List<HSTableLoaderGroup>();
        public ObservableCollection<HSTableLoader> TableLoaders { get; } = new ObservableCollection<HSTableLoader>();
        public Uri Uri { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Website Website { get; private set; }

        internal HSObject? GetValue(Type type, string id)
        {
            HSTable table = _tables[type];
            return table.GetValue(id);
        }

        internal IEnumerable<T> GetValues<T>(string filterProperty, string id) where T : HSObject
        {
            HSTable table = _tables[typeof(T)];
            return table.GetValues<T>(filterProperty, id);
        }
    }
}
