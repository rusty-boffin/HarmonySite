using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("logs")]
    public class HitLog : HSObject
    {
        public DateTime TimeStamp => GetValue(() => TimeStamp); //	TimeStamp	date	any value
        public Member Member => GetValue(() => Member); //	Member	single option from database table	values from members table
        public string Page => GetValue(() => Page); //	Page	text	any value
        public string Session => GetValue(() => Session); //	Session	text	any value
        public string Notes => GetValue(() => Notes); //	Notes	text	any value

        internal HitLog(HSSession session)
            : base(session)
        {
        }
    }

}
