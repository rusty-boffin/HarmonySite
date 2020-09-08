using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("newsletters")]
    public class Newsletter : HSObject
    {
        public DateTime Date => GetValue(() => Date);   //	Date	date	any value
        public string Subject => GetValue(() => Subject);   //	Title/Subject	text	any value
        public bool TOC => GetValue(() => TOC); //	Include a table of contents?	boolean (yes/no)	Yes or No
        public string Intro => GetValue(() => Intro);   //	Introductory text	WYSIWYG (HTML) multi-line text box	any value
        public ListItem Status => GetValue(() => Status); //	Status	single option from database (dropdowns)	one of these values | Administer
        public string Photo => GetValue(() => Photo);   //	Icon/image	file	files with this specification
        public string Thumbnail => GetValue(() => Thumbnail);   //	Small icon/image	file	files with this specification
        public string Level => GetValue(() => Level);   //	Access Level required	single option from hard-coded set of choices	one of these values
        public Position Position => GetValue(() => Position);	//	Send "from"	single option from database table	values from positions table

        [HSFilter(nameof(NewsletterItem.Newsletter))]
        public HSCollection<NewsletterItem> Items => GetValues(() => Items);

        internal Newsletter(HSSession session)
            : base(session)
        {
        }
    }

}
