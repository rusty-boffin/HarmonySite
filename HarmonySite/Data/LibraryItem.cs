using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("libraryitems")]
    public class LibraryItem : HSObject
    {
        public string Name => GetValue(() => Name); //	Item name	text	any value
        public string Library => GetValue(() => Library);   //	Library	single option from database (dropdowns)	one of these values | Administer
        public string Number => GetValue(() => Number); //	Number	text	any value
        public bool Active => GetValue(() => Active);   //	Show on Libraries page?	boolean (yes/no)	Yes or No
        public string Source => GetValue(() => Source); //	Source	single option from database (dropdowns)	one of these values | Administer
        public DateTime Purchased => GetValue(() => Purchased); //	Date sourced	date	any value
        public DateTime DueBack => GetValue(() => DueBack); //	Date due back	date	any value
        public int Price => GetValue(() => Price);  //	Original price	integer	any currency value (in cents/pence/etc)
        public string Vendor => GetValue(() => Vendor); //	Sourced from	text	any value
        public string Description => GetValue(() => Description);   //	Description	WYSIWYG (HTML) multi-line text box	any value
        public int Bond => GetValue(() => Bond);    //	Bond	integer	any currency value (in cents/pence/etc)
        public int Period => GetValue(() => Period);    //	Usual loan period	integer	any number
        public Music Song => GetValue(() => Song); //	Related song from Songs database	single option from database table	values from rep table
        public string AdminNotes => GetValue(() => AdminNotes); //	Admin notes	WYSIWYG (HTML) multi-line text box	any value
        public string MemFilename => GetValue(() => MemFilename);   //	Attachment	file (with title)	files with this specification
        public string Filename => GetValue(() => Filename); //	Admin Attachment	file (with title)	files with this specification
        public int Ranking => GetValue(() => Ranking);	//	Ranking	integer	any number

        internal LibraryItem(HSSession session)
            : base(session)
        {
        }
    }

}
