using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("uploads")]
    public class Upload : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number
        public string Title => GetValue(() => Title);   //	Title	text	any value
        public HSCollection<Ensemble> Ensembles => GetValues(() => Ensembles);   //	Ensemble(s)	multiple options from database table	filtered values from ensembles table
        public Club PeakBody => GetValue(() => PeakBody); //	Also show on website	single option from database table	filtered values from clubs table
        public ListItem Category => GetValue(() => Category); //	Type of post	single option from database (dropdowns)	one of these values | Administer
        public ListItem SubCategory => GetValue(() => SubCategory);   //	Sub-category	single option from database (dropdowns)	one of these values | Administer
        public string PeakCategory => GetValue(() => PeakCategory); //	Type of BHA post	single option from hard-coded set of choices	one of these values
        public ListItem Status => GetValue(() => Status); //	Status	single option from database (dropdowns)	one of these values | Administer
        public string Level => GetValue(() => Level);   //	Access Level required	single option from hard-coded set of choices	one of these values
        public string Photo => GetValue(() => Photo);   //	Icon/image	file	files with this specification
        public string Thumbnail => GetValue(() => Thumbnail);   //	Small icon/image	file	files with this specification
        public bool HidePeak => GetValue(() => HidePeak);    //	Hide from this website?	boolean (yes/no)	Yes or No
        public Member PostedBy => GetValue(() => PostedBy); //	Posted By	single option from database table	values from members table
        public DateTime Uploaded => GetValue(() => Uploaded);   //	Date Posted	date	any value
        public string Description => GetValue(() => Description);   //	Description	WYSIWYG (HTML) multi-line text box	any value
        public string Video => GetValue(() => Video);   //	YouTube Video URL	YouTube video ID	any value
        public string Filename => GetValue(() => Filename); //	Attachment	file (with title)	files with this specification
        public string Link => GetValue(() => Link); //	For more information, see	web (HTTP) link	any value
        public DateTime Emailed => GetValue(() => Emailed); //	Details emailed to members	date	any value
        public bool SendEmail => GetValue(() => SendEmail);	//	Send email to members now?	boolean (yes/no)	Yes or No

        internal Upload(HSSession session)
            : base(session)
        {
        }
    }

}
