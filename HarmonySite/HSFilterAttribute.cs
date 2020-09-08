using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HSFilterAttribute : Attribute
    {
        public string FilterName { get; }

        public HSFilterAttribute(string filterName = "")
        {
            FilterName = filterName;
        }
    }
}
