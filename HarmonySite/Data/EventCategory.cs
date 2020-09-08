using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("eventcats")]
    public class EventCategory : HSObject
    {
        public string Name => GetValue(() => Name); //	Category name	text	any value
        public string Colour => GetValue(() => Colour); //	Background colour	text	any value
        public int Ranking => GetValue(() => Ranking);	//	Display ranking	integer	any number

        internal EventCategory(HSSession session)
            : base(session)
        {
        }
    }

}
