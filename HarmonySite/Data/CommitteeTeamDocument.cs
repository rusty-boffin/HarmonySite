using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("documents")]
    public class CommitteeTeamDocument : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number
        public string Title => GetValue(() => Title);   //	Title	text	any value
        public ListItem Category => GetValue(() => Category); //	Type of document	single option from database (dropdowns)	one of these values | Administer
        public ListItem SubCategory => GetValue(() => SubCategory);  //	Sub-category	single option from database (dropdowns)	one of these values | Administer
        public string PeakCategory => GetValue(() => PeakCategory); //	Type of BHA post	single option from hard-coded set of choices	one of these values
        public bool HidePeak => GetValue(() => HidePeak);    //	Hide from this website?	boolean (yes/no)	Yes or No
        public Member PostedBy => GetValue(() => PostedBy); //	Posted By	single option from database table	values from members table
        public DateTime Uploaded => GetValue(() => Uploaded);   //	Date Posted	date	any value
        public string Description => GetValue(() => Description);   //	Description	WYSIWYG (HTML) multi-line text box	any value
        public string Video => GetValue(() => Video);   //	YouTube Video URL	YouTube video ID	any value
        public string Filename => GetValue(() => Filename); //	Attachment	file (with title)	files with this specification
        public string Link => GetValue(() => Link); //	For more information, see	web (HTTP) link	any value
        public DateTime Emailed => GetValue(() => Emailed); //	Details emailed to members	date	any value
        public bool SendEmail => GetValue(() => SendEmail);  //	Send email to members now?	boolean (yes/no)	Yes or No
        public Team Team => GetValue(() => Team);	//	Committee/team	single option from database table	values from committees table

        internal CommitteeTeamDocument(HSSession session)
            : base(session)
        {
        }
    }

}
