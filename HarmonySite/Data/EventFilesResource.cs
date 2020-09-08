using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("comfiles")]
    public class EventFilesResource : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer
        public string Name => GetValue(() => Name); //	Name	text
        public Event Event => GetValue(() => Event);	//	Event	single option from database table

        internal EventFilesResource(HSSession session)
            : base(session)
        {
        }
    }

}
