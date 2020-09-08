using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("ensembles")]
    public class Ensemble : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number
        public string Name => GetValue(() => Name); //	Name	text	any value
        public Club Club => GetValue(() => Club); //	Club	single option from database table	filtered values from clubs table
        public Region Region => GetValue(() => Region); //	Region	single option from database table	filtered values from regions table
        public string Type => GetValue(() => Type); //	Type	single option from hard-coded set of choices	one of these values
        public string TypeName => GetValue(() => TypeName); //	Name of group type	text	any value
        public string MapHTML => GetValue(() => MapHTML);   //	Map balloon layout	WYSIWYG (HTML) multi-line text box	any value
        public string Level => GetValue(() => Level);   //	Access Level required	single option from hard-coded set of choices	one of these values
        public bool Full => GetValue(() => Full);   //	Full/Wait-list	boolean (yes/no)	Yes or No
        public int Ranking => GetValue(() => Ranking);  //	Display ranking	integer	any number
        public string RehearsalTime => GetValue(() => RehearsalTime);   //	Rehearsal day and time	text	any value
        public string RehearsalVenue => GetValue(() => RehearsalVenue); //	Rehearsal venue	multi-line text box	any value
        public string Address => GetValue(() => Address);   //	Address for Google Map	text	any value
        public string Latitude => GetValue(() => Latitude); //	Latitude	text	any value
        public string Longitude => GetValue(() => Longitude);   //	Longitude	text	any value
        public string MapZoom => GetValue(() => MapZoom);   //	Zoom level	single option from hard-coded set of choices	one of these values
        public string FacebookPage => GetValue(() => FacebookPage); //	Facebook page	web (HTTP) link	any value
        public string InstagramPage => GetValue(() => InstagramPage);   //	Instagram page	web (HTTP) link	any value
        public string YouTubePage => GetValue(() => YouTubePage);   //	YouTube page	web (HTTP) link	any value
        public string MeetupPage => GetValue(() => MeetupPage); //	Meetup page	web (HTTP) link	any value
        public string TwitterWidget => GetValue(() => TwitterWidget);   //	Spotify page	web (HTTP) link	any value
        public string MySpacePage => GetValue(() => MySpacePage);   //	Myspace page	text	any value
        public string TwitterAccnt => GetValue(() => TwitterAccnt); //	Twitter account	text	any value
        public string Logo => GetValue(() => Logo); //	Logo	file	files with this specification
        public string LogoLight => GetValue(() => LogoLight);   //	Logo for dark backgrounds	file	files with this specification
        public string Headline => GetValue(() => Headline); //	Headline	text	any value
        public string Phone => GetValue(() => Phone);   //	Phone number(s)	text	any value
        public string Link => GetValue(() => Link); //	Web site	web (HTTP) link	any value
        public string Photo => GetValue(() => Photo);   //	Photo	file	files with this specification
        public string Sample => GetValue(() => Sample); //	Sample recording	file	files with this specification
        public string Video => GetValue(() => Video);   //	YouTube Video URL	YouTube video ID	any value
        public string Blurb => GetValue(() => Blurb);   //	Promotional blurb	WYSIWYG (HTML) multi-line text box	any value
        public string PostalAddress => GetValue(() => PostalAddress);   //	Postal address	multi-line text box	any value
        public HSCollection<int> TypeQ => GetValues(() => TypeQ);   //	Category	multiple options from restricted database	one of these values
        public string Grade => GetValue(() => Grade);   //	Grade	single option from hard-coded set of choices	one of these values
        public HSCollection<string> Medals => GetValues(() => Medals); //	Medals won	multiple options from hard-coded set of choices	one of these values
        public string Results => GetValue(() => Results);   //	Historical competition results	WYSIWYG (HTML) multi-line text box	any value
        public string AdminNotes => GetValue(() => AdminNotes); //	Admin Notes	WYSIWYG (HTML) multi-line text box	any value
        public DateTime Registration => GetValue(() => Registration);   //	Registration date	date	any value
        public DateTime LastPaid => GetValue(() => LastPaid);   //	Date of last payment	date	any value
        public DateTime Expires => GetValue(() => Expires); //	Expiry date	date	any value
        public DateTime Resigned => GetValue(() => Resigned);   //	Date left	date	any value
        public DateTime Rejoined => GetValue(() => Rejoined);   //	Date re-joined	date	any value
        public DateTime TimeStamp => GetValue(() => TimeStamp); //	Last updated	date	any value
        public Position PosDirectorPos => GetValue(() => PosDirectorPos); //	Music Director	single option from database table	values from positions table
        public Member PosDirectorMem => GetValue(() => PosDirectorMem); //	Music Director member	single option from database table	values from members table
        public string PosDirectorEmail => GetValue(() => PosDirectorEmail); //	Music Director email	email link	any value
        public Position PosDrumMajorPos => GetValue(() => PosDrumMajorPos);   //	Drum Major	single option from database table	values from positions table
        public Member PosDrumMajorMem => GetValue(() => PosDrumMajorMem);   //	Drum Major member	single option from database table	values from members table
        public string PosDrumMajorEmail => GetValue(() => PosDrumMajorEmail);   //	Drum Major email	email link	any value
        public Position PosContactPos => GetValue(() => PosContactPos);   //	General public contact	single option from database table	values from positions table
        public Member PosContactMem => GetValue(() => PosContactMem);   //	General public contact member	single option from database table	values from members table
        public string PosContactEmail => GetValue(() => PosContactEmail);   //	General public contact email	email link	any value
        public Position PosMembershipPos => GetValue(() => PosMembershipPos); //	Membership Manager	single option from database table	values from positions table
        public Member PosMembershipMem => GetValue(() => PosMembershipMem); //	Membership Manager member	single option from database table	values from members table
        public string PosMembershipEmail => GetValue(() => PosMembershipEmail); //	Membership Manager email	email link	any value
        public Position PosMarketingPos => GetValue(() => PosMarketingPos);   //	Marketing Manager	single option from database table	values from positions table
        public Member PosMarketingMem => GetValue(() => PosMarketingMem);   //	Marketing Manager member	single option from database table	values from members table
        public string PosMarketingEmail => GetValue(() => PosMarketingEmail);	//	Marketing Manager email	email link	any value

        [HSFilter(nameof(MemberGrouping.Ensembles))]
        public HSCollection<MemberGrouping> MemberGroups => GetValues(() => MemberGroups);
        [HSFilter(nameof(Membership.Ensemble))]
        public HSCollection<Membership> Memberships => GetValues(() => Memberships);
        [HSFilter(nameof(Music.Ensembles))]
        public HSCollection<Music> Songs => GetValues(() => Songs);
        [HSFilter(nameof(Participation.Ensemble))]
        public HSCollection<Participation> Participations => GetValues(() => Participations);

        internal Ensemble(HSSession session)
            : base(session)
        {
        }
    }
}
