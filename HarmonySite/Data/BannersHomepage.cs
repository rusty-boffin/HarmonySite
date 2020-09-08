using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("banners")]
    public class BannersHomepage : HSObject
    {
        public string Name => GetValue(() => Name); //	Name	text	any value
        public bool Active => GetValue(() => Active);   //	Active?	boolean (yes/no)	Yes or No
        public string Photo => GetValue(() => Photo);   //	Photo	file	files with this specification
        public string Website => GetValue(() => Website);   //	URL	web (HTTP) link	any value
        public string Quote => GetValue(() => Quote);   //	Quote	WYSIWYG (HTML) multi-line text box	any value
        public string Alignment => GetValue(() => Alignment);   //	Quote text alignment	single option from hard-coded set of choices	one of these values
        public string Attribution => GetValue(() => Attribution);   //	Attribution	text	any value
        public int Top => GetValue(() => Top);  //	Top	integer	any number
        public int Left => GetValue(() => Left);    //	Left	integer	any number
        public int Width => GetValue(() => Width);  //	Width	integer	any number
        public int Height => GetValue(() => Height);    //	Height	integer	any number
        public int Ranking => GetValue(() => Ranking);	//	Display ranking	integer	any number

        internal BannersHomepage(HSSession session)
            : base(session)
        {
        }
    }

}
