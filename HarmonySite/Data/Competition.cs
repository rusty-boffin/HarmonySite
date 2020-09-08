using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("competitions")]
    public class Competition : HSObject
    {
        [HSFilter(nameof(Convention.Competition))]
        public HSCollection<Convention> Conventions => GetValues(() => Conventions);

        internal Competition(HSSession session)
            : base(session)
        {
        }
    }
}
