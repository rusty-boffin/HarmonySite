using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable(null)]
    public class Club : HSObject
    {
        [HSFilter(nameof(Convention.Club))]
        public HSCollection<Convention> Conventions => GetValues(() => Conventions);
        [HSFilter(nameof(Ensemble.Club))]
        public HSCollection<Ensemble> Ensembles => GetValues(() => Ensembles);
        [HSFilter(nameof(Event.PeakBody))]
        public HSCollection<Event> Events => GetValues(() => Events);
        [HSFilter(nameof(FeeSchedule.Club))]
        public HSCollection<FeeSchedule> FeeSchedules => GetValues(() => FeeSchedules);
        [HSFilter(nameof(Location.Club))]
        public HSCollection<Location> Locations => GetValues(() => Locations);
        [HSFilter(nameof(MemberAward.Club))]
        public HSCollection<MemberAward> Awards => GetValues(() => Awards);
        [HSFilter(nameof(Membership.Club))]
        public HSCollection<Membership> Memberships => GetValues(() => Memberships);
        [HSFilter(nameof(Position.Club))]
        public HSCollection<Position> Positions => GetValues(() => Positions);
        [HSFilter(nameof(Upload.PeakBody))]
        public HSCollection<Upload> Uploads => GetValues(() => Uploads);

        internal Club(HSSession session)
            : base(session)
        {
        }
    }
}
