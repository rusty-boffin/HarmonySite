using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("memberships", HSTableAttribute.eFeatures.Large)]
    public class Membership : HSObject
    {

        public Member Member => GetValue(() => Member); //	Member	single option from database table	values from members table
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number
        public int? MemberID => GetValue(() => MemberID); //	Member ID	text	any value
        public Club Club => GetValue(() => Club); //	Club	single option from database table	filtered values from clubs table
        public Region? Region => GetValue(() => Region); //	Region	single option from database table	values from regions table
        public string Photo => GetValue(() => Photo);   //	Photograph	file	files with this specification
        public string Thumbnail => GetValue(() => Thumbnail);   //	Small Photo	file	files with this specification
        public string[] Type => GetList(() => Type); //	Type/role	multiple options from restricted database	one of these values
        public string Level => GetValue(() => Level);   //	Level	single option from restricted database	one of these values
        public string Status => GetValue(() => Status); //	Status	single option from restricted database	one of these values
        public bool Founder => GetValue(() => Founder); //	Founding member?	boolean (yes/no)	Yes or No
        public bool Charter => GetValue(() => Charter); //	Charter member?	boolean (yes/no)	Yes or No
        public bool MailList => GetValue(() => MailList);   //	Mailing lists preference	boolean (yes/no)	Yes (Happy to be on mailing lists), or No (Prefer not to be on mailing lists)
        public HSCollection<Member> Buddy => GetValues(() => Buddy);   //	Buddies	multiple options from database table	values from members table
        public string SponLevel => GetValue(() => SponLevel);   //	Sponsorship level	single option from database (dropdowns)	one of these values | Administer
        public DateTime GiftAidFrom => GetValue(() => GiftAidFrom); //	Gift Aid start	date	any value
        public DateTime GiftAidTo => GetValue(() => GiftAidTo); //	Gift Aid end	date	any value
        public string AdminNotes => GetValue(() => AdminNotes); //	Admin Notes	WYSIWYG (HTML) multi-line text box	any value
        public string Profile => GetValue(() => Profile);   //	Bio/Profile	WYSIWYG (HTML) multi-line text box	any value
        public string How => GetValue(() => How);   //	How did you first hear about The Baden Street Singers?	single option from database (dropdowns)	one of these values | Administer
        public string Which => GetValue(() => Which);   //	Which friend / radio / newspaper / search engine / etc?	text	any value
        public string Spare1 => GetValue(() => Spare1); //	Spare field 1	text	any value
        public string Spare2 => GetValue(() => Spare2); //	Spare field 2	text	any value
        public string Spare3 => GetValue(() => Spare3); //	Spare field 3	text	any value
        public string Spare4 => GetValue(() => Spare4); //	Spare field 4	text	any value
        public DateTime SpareDate1 => GetValue(() => SpareDate1);   //	Spare date field 1	date	any value
        public bool PublicEntries => GetValue(() => PublicEntries); //	I am happy for my competition entry photos to be shown to the general public	boolean (yes/no)	Yes or No
        public DateTime Registration => GetValue(() => Registration);   //	Registration date	date	any value
        public DateTime Resigned => GetValue(() => Resigned);   //	Date left	date	any value
        public DateTime Rejoined => GetValue(() => Rejoined);   //	Date re-joined	date	any value
        public DateTime TimeStamp => GetValue(() => TimeStamp);	//	Last updated	date	any value

        internal Membership(HSSession session)
            : base(session)
        {
        }
    }

}
