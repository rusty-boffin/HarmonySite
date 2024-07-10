using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("positions")]
    public class Position : HSObject
    {
        public string Name => GetValue(() => Name); //	Position name	text	any value
        public HSCollection<ListItem> Category => GetValues(() => Category); //	Category	multiple options from database (dropdowns)	one of these values | Administer
        public bool Active => GetValue(() => Active);   //	Active?	boolean (yes/no)	Yes or No
        public string Level => GetValue(() => Level);   //	Access Level required	single option from hard-coded set of choices	one of these values
        public HSCollection<Member> Members => GetValues(() => Members);   //	Members	multiple options from database table	values from members table
        public int Ranking => GetValue(() => Ranking);  //	Display ranking	integer	any number
        public string EmailType => GetValue(() => EmailType);   //	Email address associated with this position	single option from hard-coded set of choices	one of these values
        public string Email => GetValue(() => Email);   //	Email address	text	any value
        public string Password => GetValue(() => Password); //	Password	text	any value
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number
        public Club Club => GetValue(() => Club); //	Club	single option from database table	filtered values from clubs table
//        public HSCollection<string> DBs => GetValues(() => DBs);   //	Administration areas	multiple options from hard-coded set of choices	one of these values
        public string FullDuties => GetValue(() => FullDuties);	//	Full description of this position	WYSIWYG (HTML) multi-line text box	any value

        [HSFilter(nameof(Team.Positions))]
        public HSCollection<Team> Teams => GetValues(() => Teams);

        internal Position(HSSession session)
            : base(session)
        {
        }
    }

}
