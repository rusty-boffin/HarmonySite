using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("details")]
    public class OrderItem : HSObject
    {
        public Order OrderID => GetValue(() => OrderID);   //	Order/Invoice/Booking/Donation	single option from database table	values from orders table
        public string Dbase => GetValue(() => Dbase);   //	Table name	single option from hard-coded set of choices	one of these values
        public string KeyVal => GetValue(() => KeyVal); //	Record ID in table	text	any value
        public int Qty => GetValue(() => Qty);  //	Quantity ordered	integer	any number
        public int Price => GetValue(() => Price);  //	Price each	integer	any currency value (in cents/pence/etc)
        public int Weight => GetValue(() => Weight);    //	Weight	integer	any number
        public string Options => GetValue(() => Options);   //	Options	multi-line text box	any value
        public string Sender => GetValue(() => Sender); //	From (sender)	text	any value
        public string Recipient => GetValue(() => Recipient);   //	Recipient's name	text	any value
        public string Relationship => GetValue(() => Relationship); //	Recipient's relationship to sender	text	any value
        public DateTime PrefDate => GetValue(() => PrefDate);   //	Preferred date	date	any value
        public string PrefTime => GetValue(() => PrefTime); //	Preferred time	time	any value
        public HSCollection<Ensemble> Quartets => GetValues(() => Quartets); //	Preferred quartet(s)	multiple options from database table	filtered values from ensembles table
        public string Delivery => GetValue(() => Delivery); //	Delivery location	multi-line text box	any value
        public string DelTown => GetValue(() => DelTown);   //	Delivery city/town/suburb	text	any value
        public string DelPostcode => GetValue(() => DelPostcode);   //	Delivery postcode	text	any value
        public string Contact => GetValue(() => Contact);   //	Contact person at delivery location	text	any value
        public string ContactTel => GetValue(() => ContactTel); //	Contact person's telephone number	text	any value
        public string ContactEmail => GetValue(() => ContactEmail); //	Contact person's email address	email link	any value
        public string CardMessage => GetValue(() => CardMessage);   //	Message/sentiment for card	multi-line text box	any value
        public string Instructions => GetValue(() => Instructions); //	Special instructions	multi-line text box	any value
        public DateTime Collected => GetValue(() => Collected); //	Collected	date	any value
        public Ensemble Quartet => GetValue(() => Quartet);   //	Assigned quartet	single option from database table	values from ensembles table
        public DateTime Date => GetValue(() => Date);   //	Assigned date	date	any value
        public string Time => GetValue(() => Time); //	Assigned time	time	any value
        public string Status => GetValue(() => Status); //	Status	single option from hard-coded set of choices	one of these values
        public DateTime FeePaid => GetValue(() => FeePaid); //	Fee paid to quartet	date	any value
        public DateTime Archived => GetValue(() => Archived);   //	Archived	date	any value
        public string AdminNotes => GetValue(() => AdminNotes);	//	Admin notes	WYSIWYG (HTML) multi-line text box	any value

        internal OrderItem(HSSession session)
            : base(session)
        {
        }
    }

}
