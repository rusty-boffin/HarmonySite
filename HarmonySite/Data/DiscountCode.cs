using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("codes")]
    public class DiscountCode : HSObject
    {
        public string Code => GetValue(() => Code); //	Code	text	any value
        public bool Active => GetValue(() => Active);   //	Available to	single option from hard-coded set of choices	one of these values
        public string Discount => GetValue(() => Discount); //	Discount	text	any value
        public bool Dollars => GetValue(() => Dollars); //	Discount type	boolean (yes/no)	Yes (AUD), or No (Percent)
        public DateTime Entered => GetValue(() => Entered);	//	Date Created	date	any value

        internal DiscountCode(HSSession session)
            : base(session)
        {
        }
    }

}
