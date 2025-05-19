using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite
{
    public class HSCollection<T> : HSBase, IEnumerable<T> where T: HSObject
    {
        protected string _HSTableName;
        protected List<T> _Members = new List<T>();

        public HSCollection(HSSession session)
            : base(session)
        {
            HSTableAttribute? attr = typeof(T).GetCustomAttribute<HSTableAttribute>();
            if (attr == null)
                _HSTableName = typeof(T).Name;
            else
            {
                _HSTableName = attr.TableName;
            }
        }

        internal void Load(T obj)
        {
            if (!_Members.Contains(obj))
                _Members.Add(obj);
            RaiseObjectChanged();
        }

        internal void Load(string values)
        {
            foreach (string value in values.Split(' '))
            {
                object? val = ConvertToType(value, typeof(T));
                if (val != null)
                    Load((T)val);
            }
        }

        internal void Load(string filterProperty, string id)
        {
            if (_HSTableName == null)
                throw new Exception(string.Format("No table defined for {0}", typeof(T).Name));

            var records = _Session.GetValues<T>(filterProperty, id);
            foreach (var record in records)
                Load(record);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Members.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _Members.GetEnumerator();
        }
    }
}
