using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("programitems")]
    public class EventProgramItem : HSObject
    {
        public Event Event => GetValue(() => Event);   //	Event	single option from database table	values from events table
        public EventProgramTemplate Template => GetValue(() => Template); //	Template	single option from database table	values from progtemplates table
        public ListItem Activity => GetValue(() => Activity); //	Activity	single option from database (dropdowns)	one of these values | Administer
        public Music Music => GetValue(() => Music);   //	Music	single option from database table	values from rep table
        public int Minutes => GetValue(() => Minutes);  //	Minutes	integer	any number
        public Member Member => GetValue(() => Member); //	Run by	single option from database table	values from members table
        public string Notes => GetValue(() => Notes);   //	Details/Notes	text	any value
        public int Ranking => GetValue(() => Ranking);	//	Display ranking	integer	any number

        internal EventProgramItem(HSSession session)
            : base(session)
        {
        }
    }

}
