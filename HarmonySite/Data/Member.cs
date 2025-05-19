using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("members", HSTableAttribute.eFeatures.Large)]
    public class Member : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number			
        public string Pronoun => GetValue(() => Pronoun);   //	Pronoun	single option from database (dropdowns)	one of these values | Administer			
        public string Surname => GetValue(() => Surname);   //	Surname	text	any value			
        public string FirstName => GetValue(() => FirstName);   //	Given Names	text	any value			
        public string Greeting => GetValue(() => Greeting); //	First name	text	any value			
        public string Title => GetValue(() => Title);   //	Title	single option from database (dropdowns)	one of these values | Administer			
        public string Occupation => GetValue(() => Occupation); //	Occupation	text	any value			
        public string Gender => GetValue(() => Gender); //	Gender	single option from database (dropdowns)	one of these values | Administer			
        public string Height => GetValue(() => Height); //	Height	text	any value			
        public DateTime Birthday => GetValue(() => Birthday);   //	Date of birth	date	any value			
        public string BirthDate => GetValue(() => BirthDate); //	Birthday	text	any value			
        public string Partner => GetValue(() => Partner);   //	Spouse/Partner	text	any value			
        public DateTime Anniversary => GetValue(() => Anniversary); //	Anniversary	date	any value			
        public string AnniversaryText => GetValue(() => AnniversaryText);   //	Anniversary	text	any value			
        public string Children => GetValue(() => Children); //	Children	text	any value			
        public string Emergency => GetValue(() => Emergency);   //	Emergency contact	multi-line text box	any value			
        public bool Searchable => GetValue(() => Searchable);   //	Allow my details to be searchable in the wider HarmonySite database	boolean (yes/no)	Yes or No			
        public string GoogleAddress => GetValue(() => GoogleAddress);   //	Street address	text	any value			
        public string Address => GetValue(() => Address);   //	Street address	text	any value			
        public string Address2 => GetValue(() => Address2); //	Street address line 2	text	any value			
        public string Suburb => GetValue(() => Suburb); //	Town/Suburb	text	any value			
        public string State => GetValue(() => State);   //	State	single option from hard-coded set of choices	one of these values			
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
        public string Provider => GetValue(() => Provider); //	Email provider	single option from hard-coded set of choices	one of these values			
        public string EPass => GetValue(() => EPass);   //	Email address password	text	any value			
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
        public string COVIDVaccine => GetValue(() => COVIDVaccine);   // Vaccine received multiple options from database(dropdowns)  varchar(192)    -	one of these values | Administer
        public int COVIDShots => GetValue(() => COVIDShots);    // Number of shots integer int (11)	-	any number
        public DateTime COVIDDate => GetValue(() => COVIDDate); // Date of last shot date    date	-	any value
        public string COVIDFile => GetValue(() => COVIDFile);   // Vaccination certificate file    varchar(192)    -	files with this specification

        [HSFilter(nameof(AnnouncementsReminder.PostedBy))]
        public HSCollection<CommitteeTeamDocument> Documents => GetValues(() => Documents);
        [HSFilter(nameof(EmailsSavedSent.Member))]
        public HSCollection<EmailsSavedSent> Emails => GetValues(() => Emails);
        [HSFilter(nameof(FeeSchedule.Member))]
        public HSCollection<FeeSchedule> FeeSchedules => GetValues(() => FeeSchedules);
        [HSFilter(nameof(LibraryLoan.Member))]
        public HSCollection<LibraryLoan> LibraryLoans => GetValues(() => LibraryLoans);
        [HSFilter(nameof(MemberAward.Members))]
        public HSCollection<MemberAward> Awards => GetValues(() => Awards);
        [HSFilter(nameof(Membership.Member))]
        public HSCollection<Membership> Memberships => GetValues(() => Memberships);
        [HSFilter(nameof(Order.Member))]
        public HSCollection<Order> Orders => GetValues(() => Orders);
        [HSFilter(nameof(Position.Members))]
        public HSCollection<Position> Positions => GetValues(() => Positions);
        [HSFilter(nameof(Participation.Member))]
        public HSCollection<Participation> Participations => GetValues(() => Participations);

        internal Member(HSSession session)
            : base(session)
        {
        }

        public string FullName =>$"{Greeting} {Surname}".Trim();
    }

}
