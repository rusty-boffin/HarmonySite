using System.Drawing;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable(null)]
    public class Website : HSObject
    {
        public string WebsiteName => GetValue(() => WebsiteName);
        public Color colour1 => GetValue(() => colour1);
        public Color colour2 => GetValue(() => colour2);
        public string ChapterName => GetValue(() => ChapterName);

        [HSFilter]
        public HSCollection<BannersHomepage> Banners => GetValues(() => Banners);
        [HSFilter]
        public HSCollection<Event> Events => GetValues(() => Events);
        [HSFilter]
        public HSCollection<Member> Members => GetValues(() => Members);
        [HSFilter]
        public HSCollection<Ensemble> Ensembles => GetValues(() => Ensembles);
        [HSFilter]
        public HSCollection<HitLog> HitLogs => GetValues(() => HitLogs);
        [HSFilter]
        public HSCollection<LibraryItem> LibraryItems => GetValues(() => LibraryItems);
        [HSFilter]
        public HSCollection<LibraryLoan> LibraryLoans => GetValues(() => LibraryLoans);
        [HSFilter]
        public HSCollection<Position> Positions => GetValues(() => Positions);
        [HSFilter]
        public HSCollection<Music> Songs => GetValues(() => Songs);
        [HSFilter]
        public HSCollection<Order> Orders => GetValues(() => Orders);
        [HSFilter]
        public HSCollection<PhotoGallery> PhotoGalleries => GetValues(() => PhotoGalleries);
        [HSFilter]
        public HSCollection<WebLink> WebLinks => GetValues(() => WebLinks);
        [HSFilter]
        public HSCollection<WebsitePage> WebsitePages => GetValues(() => WebsitePages);
        [HSFilter]
        public HSCollection<WebsiteParameter> WebsiteParameters => GetValues(() => WebsiteParameters);

        internal Website(HSSession session)
            : base(session)
        {
        }
    }
}
