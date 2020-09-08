using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("albums")]
    public class PhotoGallery : HSObject
    {
        public string Name => GetValue(() => Name); //	Album name	text	any value
        public ListItem Category => GetValue(() => Category); //	Type of gallery	single option from database (dropdowns)	one of these values | Administer
        public string Description => GetValue(() => Description);   //	Description	multi-line text box	any value
        public Photograph Feature => GetValue(() => Feature);   //	Feature image	single option from database table	filtered values from scrapbook table
        public string Level => GetValue(() => Level);   //	Visible to	single option from hard-coded set of choices	one of these values
        public string Link => GetValue(() => Link); //	External gallery address	web (HTTP) link	any value
        public string Photo => GetValue(() => Photo);   //	Cover image	file	files with this specification
        public string Thumbnail => GetValue(() => Thumbnail);   //	Small Photo	file	files with this specification
        public int Ranking => GetValue(() => Ranking);	//	Display ranking	integer	any number

        [HSFilter(nameof(Photograph.Category))]
        public HSCollection<Photograph> Photographs => GetValues(() => Photographs);

        internal PhotoGallery(HSSession session)
            : base(session)
        {
        }
    }

}
