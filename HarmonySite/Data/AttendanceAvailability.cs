using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("attendance")]
    public class AttendanceAvailability : HSObject
    {
        public Member Member => GetValue(() => Member);    //	Member	single option from database table	values from members table
        public Event Event => GetValue(() => Event);  //	Event	single option from database table	values from events table
        public string Part => GetValue(() => Part); //	Section	single option from hard-coded set of choices	one of these values
        public AvailabilityOption Availability => GetValue(() => Availability); //	Intended availability	single option from database table	values from availoptions table
        public AttendanceOption Attendance => GetValue(() => Attendance); //	Actual attendance	single option from database table	values from attendoptions table
        public string VisComments => GetValue(() => VisComments);	//	Vistor's comments	multi-line text box	any value

        internal AttendanceAvailability(HSSession session)
            : base(session)
        {
        }
    }

}
