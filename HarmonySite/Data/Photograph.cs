using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("scrapbook")]
    public class Photograph : HSObject
    {
        public string Title => GetValue(() => Title);   //	Title	text	any value
        public PhotoGallery Category => GetValue(() => Category); //	Gallery name	single option from database table	values from albums table
        public Member PostedBy => GetValue(() => PostedBy); //	Posted By	single option from database table	values from members table
        public DateTime Uploaded => GetValue(() => Uploaded);   //	Date Posted	date	any value
        public string Photo => GetValue(() => Photo);   //	Image	file	files with this specification
        public string Thumbnail => GetValue(() => Thumbnail);   //	Small Photo	file	files with this specification
        public string Description => GetValue(() => Description);   //	Description	multi-line text box	any value
        public bool Slideshow => GetValue(() => Slideshow); //	Show in page footer/slideshow?	boolean (yes/no)	Yes or No
        public int Ranking => GetValue(() => Ranking);	//	Display ranking	integer	any number

        internal Photograph(HSSession session)
            : base(session)
        {
        }
    }

}
