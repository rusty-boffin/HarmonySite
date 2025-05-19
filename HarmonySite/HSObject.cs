using NLog;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite
{
    public abstract class HSObject : HSBase, IEquatable<HSObject>
    {
        protected static Logger _Logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly string _Table;
        private readonly string _ClassName;
        public string id { get; internal set; }
        public DateTime stamp { get; private set; }

        private Dictionary<string, string> _Values;

        internal HSObject(HSSession session)
            : base(session)
        {
            _ClassName = GetType().Name;
            _Table = GetType().GetCustomAttribute<HSTableAttribute>().TableName;
        }

        private Dictionary<string, object> _Collections = new Dictionary<string, object>();
        protected HSCollection<T> GetValues<T>(Expression<Func<HSCollection<T>>> expression) where T : HSObject
        {
            string propertyName = GetPropertyName(expression);
            Type propertyType = typeof(T);
            HSFilterAttribute attr = GetType().GetProperty(propertyName).GetCustomAttribute<HSFilterAttribute>();

            HSCollection<T> result;
            object temp;
            if (_Collections.TryGetValue(propertyName, out temp))
            {
                result = (HSCollection<T>)temp;
                return result;
            }
            else
            {
                result = new HSCollection<T>(_Session);
                _Collections.Add(propertyName, result);
            }

            string s;
            if (attr != null)
            {
                if (!typeof(T).IsSubclassOf(typeof(HSObject)))
                    throw new Exception(string.Format("{0}.{1} - HSFilter attribute applied to non HarmonySite object collection", _ClassName, propertyName));

                string filterProperty = attr.FilterName;
                if (!string.IsNullOrEmpty(filterProperty))
                {
                    PropertyInfo pi = propertyType.GetProperty(filterProperty);
                    if (pi == null)
                        throw new Exception(string.Format("{0}.{1} - HSFilter {2}.{3} does not exist", _ClassName, propertyName, propertyType.Name, filterProperty));
                    if (!pi.PropertyType.IsSubclassOf(typeof(HSBase)))
                        throw new Exception(string.Format("{0}.{1} - HSFilter {2}.{3} is not a HarmonySite object", _ClassName, propertyName, propertyType.Name, filterProperty));
                    if (pi.PropertyType.GetCustomAttribute<HSFilterAttribute>() != null)
                        throw new Exception(string.Format("{0}.{1} - HSFilter {2}.{3} cannot be a collection that is already filtered", _ClassName, propertyName, propertyType.Name, filterProperty));
                }
                result.Load(filterProperty, id);
            }
            else if (_Values.TryGetValue(propertyName, out s))
                result.Load(s);
            else
                throw new Exception(string.Format("{0}.{1} - Property does not exist", _ClassName, propertyName));

            return result;
        }

        internal T GetValue<T>(Expression<Func<T>> expression)
        {
            string propertyName = GetPropertyName(expression);
            return GetValue<T>(propertyName);
        }

        internal T GetValue<T>(string propertyName)
        {
            Type propertyType = typeof(T);

            string s;
            if (!_Values.TryGetValue(propertyName, out s))
                return default;

            object result = ConvertToType(s, propertyType);
            return (T)result;
        }

        internal string[] GetList<T>(Expression<Func<T>> expression)
        {
            string propertyName = GetPropertyName(expression);
            return GetList(propertyName);
        }

        internal string[] GetList(string propertyName)
        {
            string values = GetValue<string>(propertyName);
            return values.Split(' ');
        }

        private static List<string> _MissingFields = new List<string>();
        private static List<string> _ExtraFields = new List<string>();

        internal void Load(Dictionary<string, string> values)
        {
            _Values = values;
        }
        /*
        internal void Load(tRecord record)
        {
            _Values = new Dictionary<string, string>();
            foreach(tValue t in record.Values)
                _Values.Add(t.FieldName, t.Value);

            id = record.RecordID;
            stamp = Convert.ToDateTime(_Values[nameof(stamp)]);

            PropertyInfo[] props = GetType().GetProperties();
            foreach (var prop in props)
            {
                string name = string.Format("{0}.{1}", GetType().Name, prop.Name);
                if (!_Values.ContainsKey(prop.Name) && !_ExtraFields.Contains(name) && (prop.GetCustomAttribute<HSFilterAttribute>() == null))
                {
                    _Logger.Error("Remove {0}", name);
                    _ExtraFields.Add(name);
                }
            }
            foreach(var kvp in _Values)
            {
                string name = string.Format("{0}.{1}", GetType().Name, kvp.Key);
                if (!props.Any(r => r.Name == kvp.Key) && !_MissingFields.Contains(name) && (kvp.Key != nameof(id)) && (kvp.Key != nameof(stamp)))
                {
                    _Logger.Error("Add {0}", name);
                    _MissingFields.Add(name);
                }
            }

            RaiseObjectChanged();
        }
        */
        private static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            MemberExpression memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("MemberExpression is expected in expression.Body", "expression");
            }
            return memberExpression.Member.Name;
        }

        public bool Equals(HSObject other)
        {
            return (id == other.id) && (_Table == other._Table);
        }

        public override bool Equals(object obj)
        {
            return Equals((HSObject)obj);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}
