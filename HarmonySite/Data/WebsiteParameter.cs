using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("parameters")]
    public class WebsiteParameter : HSObject
    {
        public string Desc => GetValue(() => Desc); //	Brief Description	text	any value
        public string Value => GetValue(() => Value);   //	Parameter value	text	any value
        public string Snippet => GetValue(() => Snippet);   //	HTML snippet	WYSIWYG (HTML) multi-line text box	any value
        public string OtherParms => GetValue(() => OtherParms); //	Other parameters	multi-line text box	any value
        public string Notes => GetValue(() => Notes);	//	Notes	multi-line text box	any value

        internal WebsiteParameter(HSSession session)
            : base(session)
        {
        }
    }

}
