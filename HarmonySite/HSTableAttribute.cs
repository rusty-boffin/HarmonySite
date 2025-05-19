using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HSTableAttribute : Attribute
    {
        public enum eFeatures { Local, Small, Large }
        public string TableName { get; }
        public eFeatures Features { get; }

        public HSTableAttribute(string tableName, eFeatures features = eFeatures.Small)
        {
            TableName = tableName;
            Features = features;
        }
    }
}
