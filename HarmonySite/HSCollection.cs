using Syncfusion.XlsIO.Implementation.XmlSerialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite
{
    public class HSCollection<T> : HSBase, IEnumerable<T> where T: HSObject
    {
        protected string _Table;
        private bool isLocal = false;
        protected List<T> _Members = new List<T>();

        public HSCollection(HSSession session)
            : base(session)
        {
            HSTableAttribute? attr = typeof(T).GetCustomAttribute<HSTableAttribute>();
            if (attr == null)
                _Table = typeof(T).Name;
            else
            {
                _Table = attr.TableName;
                isLocal = attr.IsLocal;
            }
        }

        internal void Load(T obj)
        {
            if (!_Members.Contains(obj))
                _Members.Add(obj);
        }

        internal void Load(string values)
        {
            foreach (string value in values.Split(' '))
            {
                T val = (T)ConvertToType(value, typeof(T));
                if (val != null)
                    Load(val);
            }
        }

        internal void Load(string filter, int id)
        {
            if (_Table == null)
                throw new Exception(string.Format("No table defined for {0}", typeof(T).Name));
            if (isLocal)
            { 
                foreach (T obj in _Session.LoadLocalData<T>(_Table, filter, id))
                    Load(obj);
            } 
            else
            {
                var records = _Session.LoadData(_Table, filter, id);
                foreach (var kvp in records)
                {
                    T record = _Members.Where(r => { if (r is HSObject o) return (o.id == kvp.Key); return false; }).SingleOrDefault();
                    if (record == null)
                    {
                        record = (T)_Session.GetValue(typeof(T), kvp.Key);
                        Load(record);
                    }
                    if (record is HSObject o)
                        o.Load(kvp.Value);
                }
            }
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
