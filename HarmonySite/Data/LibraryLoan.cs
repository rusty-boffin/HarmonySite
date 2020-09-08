using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("libraryloans")]
    public class LibraryLoan : HSObject
    {
        public LibraryItem Item => GetValue(() => Item); //	Library item	single option from database table	values from libraryitems table
        public Member Member => GetValue(() => Member); //	Currently loaned to	single option from database table	values from members table
        public DateTime Loaned => GetValue(() => Loaned);   //	Date loaned	date	any value
        public DateTime Due => GetValue(() => Due); //	Date due back	date	any value
        public int Bond => GetValue(() => Bond);    //	Bond	integer	any currency value (in cents/pence/etc)
        public DateTime Returned => GetValue(() => Returned);   //	Date returned	date	any value
        public string AdminNotes => GetValue(() => AdminNotes);	//	Admin notes	WYSIWYG (HTML) multi-line text box	any value

        internal LibraryLoan(HSSession session)
            : base(session)
        {
        }
    }

}
