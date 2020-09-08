using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite
{
    public abstract class HSObject: HSBase, IEquatable<HSObject>
    {
        private static Logger _Logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly string _Table;
        private readonly string _ClassName;
        internal int id { get; set; }
        internal DateTime stamp { get; set; }
        private Dictionary<string, string> _Values;

        internal HSObject(HSSession session)
            : base(session)
        {
            _ClassName = GetType().Name;
            _Table = GetType().GetCustomAttribute<HSTableAttribute>().TableName;
        }

        private Dictionary<string, object> _Collections = new Dictionary<string, object>();
        protected HSCollection<T> GetValues<T>(Expression<Func<HSCollection<T>>> expression)
        {
            if (_Values == null)
                Load();

            string propertyName = GetPropertyName(expression);
            Type propertyType = typeof(T);
            HSFilterAttribute attr = GetType().GetProperty(propertyName).GetCustomAttribute<HSFilterAttribute>();

            HSCollection<T> result;
            object temp;
            if (_Collections.TryGetValue(propertyName, out temp))
                result = (HSCollection<T>)temp;
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

                string filterTable = attr.FilterName;
                if (!string.IsNullOrEmpty(filterTable))
                {
                    PropertyInfo pi = propertyType.GetProperty(filterTable);
                    if (pi == null)
                        throw new Exception(string.Format("{0}.{1} - HSFilter {2}.{3} does not exist", _ClassName, propertyName, propertyType.Name, filterTable));
                    if (!pi.PropertyType.IsSubclassOf(typeof(HSBase)))
                        throw new Exception(string.Format("{0}.{1} - HSFilter {2}.{3} is not a HarmonySite object", _ClassName, propertyName, propertyType.Name, filterTable));
                    if (pi.PropertyType.GetCustomAttribute<HSFilterAttribute>() != null)
                        throw new Exception(string.Format("{0}.{1} - HSFilter {2}.{3} cannot be a collection that is already filtered", _ClassName, propertyName, propertyType.Name, filterTable));
                }
                result.Load(filterTable, id);
            }
            else if (_Values.TryGetValue(propertyName, out s))
                result.Load(s);
            else
                throw new Exception(string.Format("{0}.{1} - Property does not exist", _ClassName, propertyName));

            return result;
        }

        protected T GetValue<T>(Expression<Func<T>> expression)
        {
            if (_Values == null)
                Load();

            string propertyName = GetPropertyName(expression);
            Type propertyType = typeof(T);

            string s;
            if (!_Values.TryGetValue(propertyName, out s))
                throw new Exception(string.Format("{0}.{1} - Property does not exist", _ClassName, propertyName));

            object result = ConvertToType(s, propertyType);
            return (T)result;
        }

        internal void Load(Dictionary<string, string> values = null)
        {
            _Values = values;
            if (_Values == null)
                _Values = _Session.LoadData(_Table, "id", id)[id];
            stamp = Convert.ToDateTime(_Values["stamp"]);
            foreach (var prop in GetType().GetProperties())
            {
                if (!_Values.ContainsKey(prop.Name) && (prop.GetCustomAttribute<HSFilterAttribute>() == null))
                    _Logger.Error("Remove {0}.{1}", GetType().Name, prop.Name);
            }
        }

        private static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            MemberExpression memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("MemberExpression is expected in expression.Body", "expression");
            }
            return memberExpression.Member.Name;
        }

        public bool Equals([AllowNull] HSObject other)
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
