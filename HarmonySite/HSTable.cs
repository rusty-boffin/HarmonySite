using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RustyBoffin.HarmonySite
{
    public abstract class HSTable
    {
        public string Name { get; protected set; }
        internal abstract HSObject? GetValue(string id);
        internal abstract IEnumerable<T> GetValues<T>(string filterProperty, string id) where T : HSObject;
        internal abstract void Reset();
        internal abstract void Load(HSObject obj);

        internal abstract int Count { get; }
        public HSTable(string name)
        {
            Name = name;
        }
    }

    public class HSTable<T> : HSTable where T : HSObject
    {
        private static Logger _Logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly HSSession _Site;
        private readonly Type _Type;
        private readonly Dictionary<string, T> _Objects = new Dictionary<string, T>();

        internal override int Count => _Objects.Count;
        internal override void Reset()
        {
            _Objects.Clear();
        }
        public HSTable(HSSession site)
            : base(typeof(T).Name)
        {
            _Site = site;
            _Type = typeof(T);
        }
        internal override HSObject? GetValue(string id)
        {
            T? hs = null;
            _Objects.TryGetValue(id, out hs);
            return hs;
        }

        internal override IEnumerable<T1> GetValues<T1>(string filterProperty, string id)
        {
            if (string.IsNullOrEmpty(filterProperty))
                return (IEnumerable<T1>)_Objects.Values.ToList();
            else
                return (IEnumerable<T1>)_Objects.Values.Where(r => r.GetValue<string>(filterProperty) == id);
        }

        internal override void Load(HSObject obj)
        {
            _Objects.Add(obj.id, (T)obj);
        }
    }
}
