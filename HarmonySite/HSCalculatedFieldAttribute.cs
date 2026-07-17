using System;

namespace RustyBoffin.HarmonySite
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HSCalculatedFieldAttribute : Attribute
    {
        public HSCalculatedFieldAttribute()
        {
        }
    }
}
