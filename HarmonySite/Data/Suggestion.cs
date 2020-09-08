using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("suggestions")]
    public class Suggestion : HSObject
    {
        public string Title => GetValue(() => Title);   //	Title	text	any value
        public ListItem Category => GetValue(() => Category); //	This suggestion is about	single option from database (dropdowns)	one of these values | Administer
        public string Details => GetValue(() => Details);   //	Details	multi-line text box	any value
        public string Filename => GetValue(() => Filename); //	Attachment	file (with title)	files with this specification
        public string FollowUp => GetValue(() => FollowUp); //	Response	multi-line text box	any value
        public DateTime Uploaded => GetValue(() => Uploaded);   //	Date	date	any value
        public string Status => GetValue(() => Status); //	Status	single option from hard-coded set of choices	one of these values
        public DateTime Responded => GetValue(() => Responded); //	Response Date	date	any value
        public Member PostedBy => GetValue(() => PostedBy); //	Posted By	single option from database table	values from members table
        public Member ResponseBy => GetValue(() => ResponseBy); //	Response By	single option from database table	values from members table
        public bool Anonymous => GetValue(() => Anonymous);	//	Anonymous?	boolean (yes/no)	Yes or No

        internal Suggestion(HSSession session)
            : base(session)
        {
        }
    }

}
