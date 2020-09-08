using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite
{
    public abstract class HSBase
    {
        protected readonly HSSession _Session;

        public HSBase(HSSession session)
        {
            _Session = session;
        }

        protected object ConvertToType(string s, Type type)
        {
            object result;

            if (type.IsSubclassOf(typeof(HSObject)))
            {
                int id = Convert.ToInt32(s);
                result = _Session.GetValue(type, id);
            }
            else if (type == typeof(Color))
            {
                result = ColorTranslator.FromHtml(s);
            }
            else if (type == typeof(bool))
            {
                result = s == "Yes";
            }
            else
            {
                TypeConverter converter = TypeDescriptor.GetConverter(type);
                result = converter.ConvertFromString(null, CultureInfo.InvariantCulture, s);
            };
            return result;
        }

    }
}
