using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("events")]
    public class Event : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number						
        public string Title => GetValue(() => Title);   //	Title	text	any value						
        //public string Production => GetValue(() => Production); //	Production	single option from database table	Cannot be used, not configured correctly						
        public HSCollection<Ensemble> Ensembles => GetValues(() => Ensembles);   //	Ensemble(s)	multiple options from database table	values from ensembles table						
        public string Organiser => GetValue(() => Organiser);   //	Organisers	text	any value						
        public string ForGroup => GetValue(() => ForGroup); //	For	text	any value						
        public Club PeakBody => GetValue(() => PeakBody); //	Also show on website	single option from database table	filtered values from clubs table						
        public DateTime start => GetValue(() => start); //	Start date	date	any value						
        public string Time => GetValue(() => Time); //	Start time	time	any value						
        public string MemberTime => GetValue(() => MemberTime); //	Performers meeting time	time	any value						
        public DateTime Until => GetValue(() => Until); //	Finish date	date	any value						
        public string Duration => GetValue(() => Duration); //	Duration	text	any value						
        public string MemberDuration => GetValue(() => MemberDuration); //	Performers duration	text	any value						
        public int Ranking => GetValue(() => Ranking);  //	Display ranking	integer	any number						
        public EventCategory Category => GetValue(() => Category); //	Type of event	single option from database table	values from eventcats table						
        public string PeakCategory => GetValue(() => PeakCategory); //	Type of BHA event	single option from hard-coded set of choices	one of these values						
        public Member PostedBy => GetValue(() => PostedBy); //	Posted By	single option from database table	values from members table						
        public string Level => GetValue(() => Level);   //	Access Level required	single option from hard-coded set of choices	one of these values						
        public string ProgramStart => GetValue(() => ProgramStart); //	Program start	single option from hard-coded set of choices	one of these values						
        public string ProgramLevel => GetValue(() => ProgramLevel); //	Program visibility	single option from hard-coded set of choices	one of these values						
        public string Location => GetValue(() => Location); //	General Location	text	any value						
        public string Link => GetValue(() => Link); //	Web page	web (HTTP) link	any value						
        public string Meet => GetValue(() => Meet); //	Where to meet	text	any value						
        public HSCollection<ListItem> Uniform => GetValues(() => Uniform);   //	Uniform Required	multiple options from database (dropdowns)	one of these values | Administer						
        public HSCollection<ListItem> Bring => GetValues(() => Bring);   //	Bring with you	multiple options from database (dropdowns)	one of these values | Administer						
        public HSCollection<Team> Team => GetValues(() => Team); //	Committee(s)/Team(s)	multiple options from database table	filtered values from committees table						
        public string Food => GetValue(() => Food); //	Food	multi-line text box	any value						
        public string Parking => GetValue(() => Parking);   //	Parking	multi-line text box	any value						
        public string Description => GetValue(() => Description);   //	Other details for members	WYSIWYG (HTML) multi-line text box	any value						
        public HSCollection<RiserStack> Stack => GetValues(() => Stack);   //	Riser stack(s)	multiple options from database table	values from stacks table						
        public HSCollection<Member> Roster => GetValues(() => Roster); //	Roster/Members on Duty	multiple options from database table	values from members table						
        public string Attendance => GetValue(() => Attendance); //	Attendance/availability tracking	single option from hard-coded set of choices	one of these values						
        public MemberGrouping Grouping => GetValue(() => Grouping); //	Member grouping used for attendance	single option from database table	values from groupings table						
        public bool FutureAtt => GetValue(() => FutureAtt); //	Request members to indicate availability ASAP?	boolean (yes/no)	Yes or No						
        public string EmailAtt => GetValue(() => EmailAtt); //	Email all availability changes to	single option from database table	values from members table						
        public bool SMSAtt => GetValue(() => SMSAtt);   //	Also send a text message (SMS)	boolean (yes/no)	Yes or No						
        public HSCollection<Member> RequiredAtt => GetValues(() => RequiredAtt);   //	Members required to attend (past event)	multiple options from database table	values from members table						
        public bool RosterAttenders => GetValue(() => RosterAttenders); //	Members who indicate they are available get automatically added to the event's Roster/Members on Duty (above)	boolean (yes/no)	Yes or No																
        public int MaxAttendees => GetValue(() => MaxAttendees);    //	Limit the number of members that can attend	integer	any number						
        public HSCollection<Music> Songs => GetValues(() => Songs);   //	Songs to be sung	multiple options from database table	filtered values from rep table						
        public DateTime Emailed => GetValue(() => Emailed); //	Event details emailed to members	date	any value						
        public bool SendEmail => GetValue(() => SendEmail);  //	Send email to members now?	boolean (yes/no)	Yes or No						
        public int Fee => GetValue(() => Fee);  //	How much did we get paid?	integer	any currency value (in cents/pence/etc)						
        public int MDFee => GetValue(() => MDFee);  //	How much did we pay our Director?	integer	any currency value (in cents/pence/etc)						
        public Member Coordinator => GetValue(() => Coordinator);   //	Coordinator of this event	single option from database table	values from members table						
        public Member Through => GetValue(() => Through);   //	Which member got us the booking?	single option from database table	values from members table						
        public string Contact => GetValue(() => Contact);   //	Contact person(s)	text	any value						
        public string Phone => GetValue(() => Phone);   //	Telephone(s)	text	any value						
        public string Email => GetValue(() => Email);   //	Email Address	email link	any value						
        public bool MemVisible => GetValue(() => MemVisible);   //	Make the information below visible to	boolean (yes/no)	Yes (All members), or No (Event Admins only)						
        public string AdminNotes => GetValue(() => AdminNotes); //	Admin notes	WYSIWYG (HTML) multi-line text box	any value						
        public int ExtraPerformers => GetValue(() => ExtraPerformers);  //	Extra performers (not counted in attendance)	integer	any number						
        public int Audience => GetValue(() => Audience);    //	Audience size	integer	any number						
        public string Spare1 => GetValue(() => Spare1); //	Spare field 1	text	any value						
        public string Spare2 => GetValue(() => Spare2); //	Spare field 2	text	any value						
        public int Minlead => GetValue(() => Minlead);  //	Minimum leads	integer	any number						
        public int Minbass => GetValue(() => Minbass);  //	Minimum basses	integer	any number						
        public int Minbari => GetValue(() => Minbari);  //	Minimum baritones	integer	any number						
        public int Mintenor => GetValue(() => Mintenor);    //	Minimum tenors	integer	any number						
        public int Mininum => GetValue(() => Mininum);  //	Minimum size	integer	any number						
        public string Double => GetValue(() => Double); //	Choir	single option from hard-coded set of choices	one of these values						
        public string Semi => GetValue(() => Semi); //	Semi-Chorus	single option from hard-coded set of choices	one of these values						
        public int Sopranos => GetValue(() => Sopranos);    //	Sopranos	integer	any number						
        public int Altos => GetValue(() => Altos);  //	Altos	integer	any number						
        public int Tenors => GetValue(() => Tenors);    //	Tenors	integer	any number						
        public int Basses => GetValue(() => Basses);    //	Basses	integer	any number						
        public string Strings => GetValue(() => Strings);   //	Strings	multi-line text box	any value						
        public string Woodwind => GetValue(() => Woodwind); //	Woodwind	multi-line text box	any value						
        public string Brass => GetValue(() => Brass);   //	Brass	multi-line text box	any value						
        public string Percussion => GetValue(() => Percussion); //	Percussion	multi-line text box	any value						
        public string OtherOrch => GetValue(() => OtherOrch);   //	Other	multi-line text box	any value						
        public string Soloists => GetValue(() => Soloists); //	Soloists	multi-line text box	any value						
        public string Equipment => GetValue(() => Equipment);   //	Equipment	multi-line text box	any value						
        public Member NotifyTickets => GetValue(() => NotifyTickets);   //	Send ticket purchase notifications to	single option from database table	values from members table						
        public bool TicketLinks => GetValue(() => TicketLinks); //	Tickets purchased through this website should contain a link for the purchaser to print their own tickets?	boolean (yes/no)	Yes or No						
        public string URLAlias => GetValue(() => URLAlias); //	Custom URL	text	any value						
        public string Pricing => GetValue(() => Pricing);   //	Ticket pricing/options	multi-line text box	any value						
        public string BookLink => GetValue(() => BookLink); //	Bookings webpage	web (HTTP) link	any value						
        public string Tickets => GetValue(() => Tickets);   //	Other booking methods	multi-line text box	any value						
        public string PubDesc => GetValue(() => PubDesc);   //	Description for public	WYSIWYG (HTML) multi-line text box	any value						
        public bool Upcoming => GetValue(() => Upcoming);   //	Show in Upcoming Events section on home page?	boolean (yes/no)	Yes or No						
        public string Image => GetValue(() => Image);   //	Image for homepage footer	file	files with this specification						
        public string Thumbnail => GetValue(() => Thumbnail);   //	Small Photo	file	files with this specification						
        public bool ShowPast => GetValue(() => ShowPast);   //	Show on Past Performances page?	boolean (yes/no)	Yes or No						
        public string PastDesc => GetValue(() => PastDesc); //	Description	WYSIWYG (HTML) multi-line text box	any value						
        public PhotoGallery Photos => GetValue(() => Photos); //	Photo gallery	single option from database table	values from albums table						
        public Location VenueRec => GetValue(() => VenueRec); //	Predefined venue	single option from database table	values from venues table						
        public string Venue => GetValue(() => Venue);   //	Venue	multi-line text box	any value						
        public string Address => GetValue(() => Address);   //	Address for Google Map	text	any value						
        public string Latitude => GetValue(() => Latitude); //	Latitude	text	any value						
        public string Longitude => GetValue(() => Longitude);   //	Longitude	text	any value						
        public string MapZoom => GetValue(() => MapZoom);	//	Zoom level	single option from hard-coded set of choices	one of these values						

        [HSFilter(nameof(AttendanceAvailability.Event))]
        public HSCollection<AttendanceAvailability> Attendances => GetValues(() => Attendances);
        [HSFilter(nameof(EventFilesResource.Event))]
        public HSCollection<EventFilesResource> Resources => GetValues(() => Resources);
        [HSFilter(nameof(EventProgramItem.Event))]
        public HSCollection<EventProgramItem> ProgramItems => GetValues(() => ProgramItems);

        internal Event(HSSession session)
            : base(session)
        {
        }
    }

}
