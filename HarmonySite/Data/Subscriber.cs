using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("subscribers")]
    public class Subscriber : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number
        public string Surname => GetValue(() => Surname);   //	Surname	text	any value
        public string FirstName => GetValue(() => FirstName);   //	Given Names	text	any value
        public string Greeting => GetValue(() => Greeting); //	Given name	text	any value
        public ListItem Title => GetValue(() => Title);   //	Title	single option from database (dropdowns)	one of these values | Administer
        public string Occupation => GetValue(() => Occupation); //	Occupation	text	any value
        public ListItem Gender => GetValue(() => Gender); //	Gender	single option from database (dropdowns)	one of these values | Administer
        public string Height => GetValue(() => Height); //	Height	text	any value
        public DateTime Birthday => GetValue(() => Birthday);   //	Date of birth	date	any value
        public string BirthdayText => GetValue(() => BirthdayText); //	Birthday	text	any value
        public string Partner => GetValue(() => Partner);   //	Spouse/Partner	text	any value
        public DateTime PBirthday => GetValue(() => PBirthday); //	Date of birth	date	any value
        public string PBirthdayText => GetValue(() => PBirthdayText);   //	Date of birth	text	any value
        public DateTime Anniversary => GetValue(() => Anniversary); //	Anniversary	date	any value
        public string AnniversaryText => GetValue(() => AnniversaryText);   //	Anniversary	text	any value
        public string SpousePhoto => GetValue(() => SpousePhoto);   //	Spouse Photograph	file	files with this specification
        public string SpouseThumbnail => GetValue(() => SpouseThumbnail);   //	Spouse Small Photo	file	files with this specification
        public string Children => GetValue(() => Children); //	Children	text	any value
        public string Emergency => GetValue(() => Emergency);   //	Emergency contact	multi-line text box	any value
        public bool Searchable => GetValue(() => Searchable);   //	Allow my details to be searchable in the wider HarmonySite database	boolean (yes/no)	Yes or No
        public string Address => GetValue(() => Address);   //	Street address	text	any value
        public string Address2 => GetValue(() => Address2); //	Street address line 2	text	any value
        public string Suburb => GetValue(() => Suburb); //	Town/Suburb	text	any value
        public string State => GetValue(() => State);   //	State	text	any value
        public string Postcode => GetValue(() => Postcode); //	Postcode	text	any value
        public string Country => GetValue(() => Country);   //	Country	text	any value
        public string Latitude => GetValue(() => Latitude); //	Latitude	text	any value
        public string Longitude => GetValue(() => Longitude);   //	Longitude	text	any value
        public string Address21 => GetValue(() => Address21);   //	Street address	text	any value
        public string Address22 => GetValue(() => Address22);   //	Street 2	text	any value
        public string Suburb2 => GetValue(() => Suburb2);   //	Suburb	text	any value
        public string State2 => GetValue(() => State2); //	State	text	any value
        public string Postcode2 => GetValue(() => Postcode2);   //	Postal code	text	any value
        public string Country2 => GetValue(() => Country2); //	Country	text	any value
        public string HomePhone => GetValue(() => HomePhone);   //	Home Phone	text	any value
        public string WorkPhone => GetValue(() => WorkPhone);   //	Work Phone	text	any value
        public string MobilePhone => GetValue(() => MobilePhone);   //	Mobile Phone	text	any value
        public string Fax => GetValue(() => Fax);   //	Work/Home Fax	text	any value
        public string Email => GetValue(() => Email);   //	Email Address	email link	any value
        public string FacebookPage => GetValue(() => FacebookPage); //	Facebook profile page	web (HTTP) link	any value
        public string Company => GetValue(() => Company);   //	Company/organisation name	text	any value
        public string Service => GetValue(() => Service);   //	Products/services offered	multi-line text box	any value
        public string Blurb => GetValue(() => Blurb);   //	About the organisation	WYSIWYG (HTML) multi-line text box	any value
        public string Contact => GetValue(() => Contact);   //	Contact details	multi-line text box	any value
        public string Website => GetValue(() => Website);   //	Website	web (HTTP) link	any value
        public string Logo => GetValue(() => Logo); //	Logo	file	files with this specification
        public string MemSpare1 => GetValue(() => MemSpare1);   //	Spare field 1	text	any value
        public string MemSpare2 => GetValue(() => MemSpare2);   //	Spare field 2	text	any value
        public string MemSpare3 => GetValue(() => MemSpare3);   //	Spare field 3	text	any value
        public string MemSpare4 => GetValue(() => MemSpare4);   //	Spare field 4	text	any value
        public string Profile => GetValue(() => Profile);   //	Bio/Profile	WYSIWYG (HTML) multi-line text box	any value
        public string Application => GetValue(() => Application);   //	Application comments	WYSIWYG (HTML) multi-line text box	any value
        public ListItem How => GetValue(() => How);   //	How did you first hear about The Baden Street Singers?	single option from database (dropdowns)	one of these values | Administer
        public string Which => GetValue(() => Which);   //	Which friend / radio / newspaper / search engine / etc?	text	any value
        public string VisComments => GetValue(() => VisComments);   //	Comments/feedback	multi-line text box	any value
        public Event Event => GetValue(() => Event);   //	Event	single option from database table	values from events table
        public bool FriendsList => GetValue(() => FriendsList); //	Please add me to your friends/supporters mailing list	boolean (yes/no)	Yes or No
        public Ensemble Ensemble => GetValue(() => Ensemble); //	Ensemble	single option from database table	values from ensembles table
        public ListItem Part => GetValue(() => Part); //	Section	single option from database (dropdowns)	one of these values | Administer
        public string Spare1 => GetValue(() => Spare1); //	Spare field 1	text	any value
        public string Spare2 => GetValue(() => Spare2); //	Spare field 2	text	any value
        public string Spare3 => GetValue(() => Spare3); //	Spare field 3	text	any value
        public string Spare4 => GetValue(() => Spare4); //	Spare field 4	text	any value
        public DateTime SpareDate1 => GetValue(() => SpareDate1);   //	Spare date field 1	date	any value
        public bool AgreedWaiver => GetValue(() => AgreedWaiver);   //	Agreed to Waiver?	boolean (yes/no)	Yes or No
        public bool AgreedRules => GetValue(() => AgreedRules); //	Agreed to Rules?	boolean (yes/no)	Yes or No
        public bool PublicEntries => GetValue(() => PublicEntries);  //	I am happy for my competition entry photos to be shown to the general public	boolean (yes/no)	Yes or No
        public bool Agree => GetValue(() => Agree); //	Terms and conditions agreed to	boolean (yes/no)	Yes or No
        public DateTime Uploaded => GetValue(() => Uploaded);	//	Date	date	any value

        internal Subscriber(HSSession session)
            : base(session)
        {
        }
    }

}
