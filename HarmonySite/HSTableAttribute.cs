using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HSTableAttribute : Attribute
    {
        public string TableName { get; }

        public HSTableAttribute(string tableName)
        {
            TableName = tableName;
        }
    }
}
