using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("awards")]
    public class MemberAward : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number
        public string Name => GetValue(() => Name); //	Award name	text	any value
        public ListItem Type => GetValue(() => Type); //	Award type	single option from database (dropdowns)	one of these values | Administer
        public Club Club => GetValue(() => Club); //	Club	single option from database table	filtered values from clubs table
        public HSCollection<Member> Members => GetValues(() => Members);   //	Awarded to	multiple options from database table	values from members table
        public DateTime Awarded => GetValue(() => Awarded); //	Date Awarded	date	any value
        public string Level => GetValue(() => Level);   //	Access Level required	single option from hard-coded set of choices	one of these values
        public string Comments => GetValue(() => Comments);	//	Comments	WYSIWYG (HTML) multi-line text box	any value

        internal MemberAward(HSSession session)
            : base(session)
        {
        }
    }

}
