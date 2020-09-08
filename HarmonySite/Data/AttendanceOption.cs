using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("attendoptions")]
    public class AttendanceOption : HSObject
    {
        public string Name => GetValue(() => Name); //	Option name on reports	text	any value
        public bool Present => GetValue(() => Present); //	Attendance represented	boolean (yes/no)	Yes (Present), or No (Absent)
        public string Abbreviation => GetValue(() => Abbreviation); //	Abbreviation letter	text	any value
        public string Colour => GetValue(() => Colour); //	Font colour	text	any value
        public int Ranking => GetValue(() => Ranking);	//	Display ranking	integer	any number

        internal AttendanceOption(HSSession session)
            : base(session)
        {
        }
    }

}
