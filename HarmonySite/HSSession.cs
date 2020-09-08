using RustyBoffin.HarmonySite.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite
{
    public class HSSession
    {
        public HSSession(IConnection connection)
        {
            Connection = connection;
            Website = new Website(this);
        }
        private Dictionary<Type, Dictionary<int, HSObject>> _DataStore = new Dictionary<Type, Dictionary<int, HSObject>>();

        public IConnection Connection { get; }

        public Website Website { get; private set; }

        public T GetValue<T>(int id) where T: HSObject
        {
            return (T)GetValue(typeof(T), id);
        }

        internal object GetValue(Type type, int id)
        {
            Dictionary<int, HSObject> dataTable = null;
            if (!_DataStore.TryGetValue(type, out dataTable))
            {
                dataTable = new Dictionary<int, HSObject>();
                _DataStore.Add(type, dataTable);
            }
            HSObject result = null;
            if (!dataTable.TryGetValue(id, out result))
            {
                ConstructorInfo ctor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(HSSession) }, null);
                result = (HSObject)ctor.Invoke(new object[]{this});
                result.id = id;
                dataTable.Add(id, result);
            }
            return result;
        }

        internal Task<Dictionary<int, Dictionary<string, string>>> LoadDataAsync(string table, string filter, int id)
        {
            return Connection.QueryAsync(table, filter, id);
        }

        internal Dictionary<int,Dictionary<string,string>> LoadData(string table, string filter, int id)
        {
            return Connection.Query(table, filter, id);
        }
    }

}
