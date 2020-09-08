using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("dropdowns")]
    public class ListItem : HSObject
    {
        public string KeyVal => GetValue(() => KeyVal); //	Internal identifier	text	any value
        public string Text => GetValue(() => Text); //	List item	text	any value
        public string UsedIn => GetValue(() => UsedIn); //	List	single option from hard-coded set of choices	one of these values
        public int Ranking => GetValue(() => Ranking);  //	Display ranking	integer	any number
        public string Notes => GetValue(() => Notes);	//	Notes	multi-line text box	any value

        internal ListItem(HSSession session)
            : base(session)
        {
        }
    }

}
