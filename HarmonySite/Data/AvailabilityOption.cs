using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("availoptions")]
    public class AvailabilityOption : HSObject
    {
        public string Name => GetValue(() => Name); //	Option name on reports	text	any value
        public bool Present => GetValue(() => Present); //	Availability, for planning purposes	boolean (yes/no)	Yes (Definitely available), or No (Not available or maybe available)
        public string Abbreviation => GetValue(() => Abbreviation); //	Abbreviation letter	text	any value
        public string Colour => GetValue(() => Colour); //	Background colour	text	any value
        public int Ranking => GetValue(() => Ranking);	//	Display ranking	integer	any number

        internal AvailabilityOption(HSSession session)
            : base(session)
        {
        }
    }

}
