using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("orders")]
    public class Order : HSObject
    {
        public Member Customer => GetValue(() => Customer); //	Member	single option from database table	values from members table
        public string Status => GetValue(() => Status); //	Status	single option from hard-coded set of choices	one of these values
        public int Shipping => GetValue(() => Shipping);    //	Shipping	integer	any currency value (in cents/pence/etc)
        public int Total => GetValue(() => Total);  //	Order Total	integer	any currency value (in cents/pence/etc)
        public DateTime Ordered => GetValue(() => Ordered); //	Date created	date	any value
        public DateTime Paid => GetValue(() => Paid);   //	Date paid	date	any value
        public DateTime Shipped => GetValue(() => Shipped); //	Date shipped	date	any value
        public DateTime Cancelled => GetValue(() => Cancelled); //	Date cancelled	date	any value
        public string Reference => GetValue(() => Reference);   //	Reference number	text	any value
        public string RecipientPhone => GetValue(() => RecipientPhone); //	Recipient's Phone (if not you)	text	any value
        public string Instructions => GetValue(() => Instructions); //	Special Instructions	multi-line text box	any value
        public string Reason => GetValue(() => Reason); //	Reason for order	text	any value
        public string Department => GetValue(() => Department); //	Department Code	text	any value
        public string Event => GetValue(() => Event);   //	Event Name	text	any value
        public DateTime DelDate => GetValue(() => DelDate); //	Delivery date	date	any value
        public string Method => GetValue(() => Method); //	Payment Method	single option from hard-coded set of choices	one of these values
        public string PONumber => GetValue(() => PONumber); //	Purchase Order Number	text	any value
        public string POName => GetValue(() => POName); //	Purchase Order Name	text	any value
        public string MktRefNum => GetValue(() => MktRefNum);   //	Marketing Reference Number	text	any value
        public string MktRefName => GetValue(() => MktRefName); //	Marketing Reference Name	text	any value
        public string CCname => GetValue(() => CCname); //	Name on Credit Card	text	any value
        public string CCno => GetValue(() => CCno); //	Credit Card Number	text	any value
        public string CCexp => GetValue(() => CCexp);   //	Expiration Date	text	any value
        public string CCcvn => GetValue(() => CCcvn);   //	CVN	text	any value
        public int Surcharge => GetValue(() => Surcharge);  //	Credit/debit card surcharge	integer	any currency value (in cents/pence/etc)
        public string Discount => GetValue(() => Discount); //	Discount	text	any value
        public bool Dollars => GetValue(() => Dollars); //	Discount type	boolean (yes/no)	Yes (AUD), No (Percent)
        public DiscountCode DiscountRef => GetValue(() => DiscountRef);   //	Discount Reference	single option from database table	values from codes table
        public string Notes => GetValue(() => Notes);   //	Notes	multi-line text box	any value
        public string Surname => GetValue(() => Surname);   //	Surname	text	any value
        public string Greeting => GetValue(() => Greeting); //	First Name	text	any value
        public string Company => GetValue(() => Company);   //	Company Name	text	any value
        public string Address => GetValue(() => Address);   //	Street	text	any value
        public string Address2 => GetValue(() => Address2); //	Street 2	text	any value
        public string Suburb => GetValue(() => Suburb); //	Suburb	text	any value
        public string State => GetValue(() => State);   //	State	text	any value
        public string Postcode => GetValue(() => Postcode); //	Postcode	text	any value
        public string Country => GetValue(() => Country);   //	Country	text	any value
        public string Email => GetValue(() => Email);   //	Email Confirmation to	email link	any value
        public string Phone => GetValue(() => Phone);   //	Contact Phone	text	any value
        public Member Member => GetValue(() => Member); //	Member	single option from database table	values from members table
        public string OrderType => GetValue(() => OrderType);   //	Transaction type	single option from hard-coded set of choices	one of these values
        public string GUID => GetValue(() => GUID); //	Security code	text	any value
        public string How => GetValue(() => How);   //	How did you hear about us?	single option from database (dropdowns)	one of these values | Administer
        public double GiftAid => GetValue(() => GiftAid);   //	Gift Aid allocation	decimal number	any number
        public string OrdSpare1 => GetValue(() => OrdSpare1);   //	Spare field 1	text	any value
        public string OrdSpare2 => GetValue(() => OrdSpare2);   //	Spare field 2	text	any value
        public string OrdSpare3 => GetValue(() => OrdSpare3);	//	Spare field 3	text	any value

        [HSFilter(nameof(OrderItem.OrderID))]
        public HSCollection<OrderItem> Items => GetValues(() => Items);

        internal Order(HSSession session)
            : base(session)
        {
        }
    }

}
