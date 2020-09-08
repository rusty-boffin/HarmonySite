using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("links")]
    public class WebLink : HSObject
    {
        public string Title => GetValue(() => Title);   //	Organisation	text	any value
        public ListItem Category => GetValue(() => Category); //	Type	single option from database (dropdowns)	one of these values | Administer
        public Member PostedBy => GetValue(() => PostedBy); //	Posted By	single option from database table	values from members table
        public DateTime Uploaded => GetValue(() => Uploaded);   //	Date Posted	date	any value
        public string Description => GetValue(() => Description);   //	Full Description	multi-line text box	any value
        public string Link => GetValue(() => Link); //	Address	web (HTTP) link	any value
        public string Logo => GetValue(() => Logo); //	Logo	file	files with this specification
        public int Ranking => GetValue(() => Ranking);	//	Display ranking	integer	any number

        internal WebLink(HSSession session)
            : base(session)
        {
        }
    }

}
