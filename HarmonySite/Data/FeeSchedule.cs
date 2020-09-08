using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("feeschedules")]
    public class FeeSchedule : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number
        public string Name => GetValue(() => Name); //	Name	text	any value
        public Member Member => GetValue(() => Member); //	Member	single option from database table	values from members table
        public Club Club => GetValue(() => Club); //	Club	single option from database table	filtered values from clubs table
        public bool Active => GetValue(() => Active);   //	Active?	boolean (yes/no)	Yes or No
        public ListItem DuesType => GetValue(() => DuesType); //	Fees payable	single option from database (dropdowns)	one of these values | Administer
        public FeeSchedulePeriod DuesSchedule => GetValue(() => DuesSchedule); //	Payment frequency	single option from database table	values from feesperiods table
        public int Amount => GetValue(() => Amount);    //	Amount	integer	any currency value (in cents/pence/etc)
        public DateTime Expires => GetValue(() => Expires); //	Expiry date	date	any value
        public DateTime LastPaid => GetValue(() => LastPaid);   //	Last payment	date	any value
        public Member Invoices => GetValue(() => Invoices); //	Send invoices to	single option from database table	values from members table
        public string AdminNotes => GetValue(() => AdminNotes);	//	Admin Notes	WYSIWYG (HTML) multi-line text box	any value

        internal FeeSchedule(HSSession session)
            : base(session)
        {
        }
    }

}
