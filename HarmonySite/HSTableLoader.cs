using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading;

namespace RustyBoffin.HarmonySite
{
    public abstract class HSTableLoader : INotifyPropertyChanged
    {
        protected HSSession Session { get; }
        public string TableName { get; }
        protected CancellationToken CancellationToken { get; }
        protected HSTable Table { get; }
        public int Count => Table.Count;
        public int LoadProgress 
        { 
            get; 
            set; 
        }

        public event ProgressChangedEventHandler? ProgressChanged;
        public event EventHandler? Loaded;
        public event PropertyChangedEventHandler? PropertyChanged;

        protected HSTableLoader(HSSession session, string tableName, CancellationToken cancellationToken, HSTable table)
        {
            Session = session;
            TableName = tableName;
            CancellationToken = cancellationToken;
            Table = table;
        }

        protected void RaiseProgressChanged(int value, int total)
        {
            if (total == 0)
            {
                total = 1;
                value = 1;
            }
            RaiseProgressChanged(100 * value / total);
        }
        protected void RaiseProgressChanged(int value)
        {
            LoadProgress = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoadProgress)));
            ProgressChanged?.Invoke(this, new ProgressChangedEventArgs(LoadProgress, TableName));
        }
        protected void RaiseLoaded()
        {
            Loaded?.Invoke(this, EventArgs.Empty);
        }

        public void Reset()
        {
            Table.Reset();
            RaiseProgressChanged(0);
        }
    }

    internal abstract class HSTableLoader<T> : HSTableLoader where T : HSObject
    {
        protected static Logger _Logger = NLog.LogManager.GetCurrentClassLogger();

        private ConstructorInfo? _Constructor;
        protected HSTableLoader(HSSession session, string tableName, CancellationToken cancellationToken, HSTable table)
            : base(session, tableName, cancellationToken, table)
        {
            Type type = typeof(T);
            _Constructor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, [typeof(HSSession)], null);
        }
        protected void CreateObject(Dictionary<string, string> values)
        {
            if (_Constructor == null)
                return;
            T obj = (T)_Constructor.Invoke(new object[] { Session });
            obj.id = values[nameof(HSObject.id)];
            values.Remove(nameof(HSObject.id));
            obj.Load(values);
            Table.Load(obj);
        }
    }
}
