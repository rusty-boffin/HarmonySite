using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("conventions")]
    public class Convention : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number			
        public Club Club => GetValue(() => Club);
        public Region Competition => GetValue(() => Competition);
        public string Scope => GetValue(() => Scope);
        public int Year => GetValue(() => Year);
        public int Month => GetValue(() => Month);
        public string Instance => GetValue(() => Instance);
        public string City => GetValue(() => City);
        public string Notes => GetValue(() => Notes);

        internal Convention(HSSession session)
            : base(session)
        {
        }
    }
}
