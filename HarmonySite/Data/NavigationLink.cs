using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("navlinks")]
    public class NavigationLink : HSObject
    {
        public string Title => GetValue(() => Title);   //	Text to display	text	any value
        public string Page => GetValue(() => Page); //	URL	text	any value
        public WebsitePage PageID => GetValue(() => PageID); //	Page from this website	single option from database table	values from pages table
        public string Level => GetValue(() => Level);   //	Access Level required	single option from hard-coded set of choices	one of these values
        public string Dbase => GetValue(() => Dbase);   //	Database	single option from hard-coded set of choices	one of these values
        public string MaxLevel => GetValue(() => MaxLevel); //	Only display up to	single option from hard-coded set of choices	one of these values
        public string Category => GetValue(() => Category); //	Link Section	single option from hard-coded set of choices	one of these values
        public NavigationLink Menu => GetValue(() => Menu); //	Parent	single option from database table	filtered values from navlinks table
        public bool Image => GetValue(() => Image);   //	Do not include in menus	boolean (yes/no)	Yes or No
        public string Image_Over => GetValue(() => Image_Over); //	Members page icon	text	any value
        public string Image_Sel => GetValue(() => Image_Sel);   //	Image (page selected)	file	files with this specification
        public string Width => GetValue(() => Width);   //	Members page text	text	any value
        public int Height => GetValue(() => Height);    //	Display ranking in footer	text	any value
        public int Ranking => GetValue(() => Ranking);	//	Display ranking	integer	any number

        [HSFilter(nameof(NavigationLink.Menu))]
        public HSCollection<NavigationLink> MenuItems => GetValues(() => MenuItems);

        internal NavigationLink(HSSession session)
            : base(session)
        {
        }
    }

}
