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

        protected object? ConvertToType(string s, Type type)
        {
            object? result;

            if (type.IsSubclassOf(typeof(HSObject)))
            {
                if (string.IsNullOrEmpty(s))
                    result = null;
                else
                {
                    int id = Convert.ToInt32(s);
                    result = _Session.GetValue(type, id);
                }
            }
            else if (type == typeof(Color))
            {
                result = ColorConverter.FromHtml(s);
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
    public static class ColorConverter
    {
        public static System.Drawing.Color FromHtml(string htmlColor)
        {
            if (htmlColor.StartsWith("#") && htmlColor.Length == 7)
            {
                int r = int.Parse(htmlColor.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
                int g = int.Parse(htmlColor.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
                int b = int.Parse(htmlColor.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);
                return System.Drawing.Color.FromArgb(r, g, b);
            }
            // Handle invalid input or default color
            return System.Drawing.Color.Black;
        }
    }
}
