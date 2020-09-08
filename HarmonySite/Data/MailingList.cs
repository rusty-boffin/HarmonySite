using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("mailinglists")]
    public class MailingList : HSObject
    {
        public string Name => GetValue(() => Name); //	Name	text	any value
        public string Email => GetValue(() => Email);   //	Email address	text	any value
        public string Password => GetValue(() => Password); //	Password	text	any value
        public HSCollection<string> Type => GetValues(() => Type); //	Notifications	multiple options from hard-coded set of choices	one of these values
        public MemberGrouping Grouping => GetValue(() => Grouping); //	Member grouping	single option from database table	values from groupings table
        public Team Committee => GetValue(() => Committee);   //	Committee/team	single option from database table	values from committees table
        public bool Forwarders => GetValue(() => Forwarders);   //	Type	single option from hard-coded set of choices	one of these values
        public string Level => GetValue(() => Level);   //	Regular member access	single option from hard-coded set of choices	one of these values
        public bool Public => GetValue(() => Public);   //	The list contains (or will contain) NON-members of the club (friends, supporters, past members, etc)?	boolean (yes/no)	Yes or No
        public int Ranking => GetValue(() => Ranking);	//	Display ranking	integer	any number

        internal MailingList(HSSession session)
            : base(session)
        {
        }
    }

}
