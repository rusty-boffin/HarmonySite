using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("regions")]
    public class Region : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number			
        public string Name => GetValue(() => Name);
        public int PeakBody => GetValue(() => PeakBody);
        public bool Competition => GetValue(() => Competition);
        public int Ranking => GetValue(() => Ranking);
        public string AdminNotes => GetValue(() => AdminNotes);
        public Member MemChairman => GetValue(() => MemChairman);
        public Member MemVChairman => GetValue(() => MemVChairman);
        public Member MemSecretary => GetValue(() => MemSecretary);
        public Member MemTreasurer => GetValue(() => MemTreasurer);

        [HSFilter(nameof(Ensemble.Region))]
        public HSCollection<Ensemble> Ensembles => GetValues(() => Ensembles);
        [HSFilter(nameof(Membership.Region))]
        public HSCollection<Membership> Memberships => GetValues(() => Memberships);

        internal Region(HSSession session)
            : base(session)
        {
        }
    }

}
