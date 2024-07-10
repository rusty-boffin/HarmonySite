using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HSTableAttribute : Attribute
    {
        public string TableName { get; }
        public bool IsLocal { get; }

        public HSTableAttribute(string tableName, bool isLocal = false)
        {
            TableName = tableName;
            IsLocal = isLocal;
        }
    }
}
