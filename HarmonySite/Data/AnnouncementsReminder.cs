using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("announcements")]
    public class AnnouncementsReminder : HSObject
    {
        public string Title => GetValue(() => Title);   //	Title	text	any value
        public DateTime Expires => GetValue(() => Expires); //	Expires	date	any value
        public Member PostedBy => GetValue(() => PostedBy); //	Posted By	single option from database table	values from members table
        public DateTime Uploaded => GetValue(() => Uploaded);   //	Date Posted	date	any value
        public string Description => GetValue(() => Description);   //	Message	WYSIWYG (HTML) multi-line text box	any value
        public DateTime Emailed => GetValue(() => Emailed); //	Details emailed to members	date	any value
        public bool SendEmail => GetValue(() => SendEmail);	//	Notify members about this announcement/reminder via the members email-list now?	boolean (yes/no)	Yes or No

        internal AnnouncementsReminder(HSSession session)
            : base(session)
        {
        }
    }

}
