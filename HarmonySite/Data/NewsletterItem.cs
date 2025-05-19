using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("newsletteritems")]
    public class NewsletterItem : HSObject
    {
        public Newsletter Newsletter => GetValue(() => Newsletter); //	Newsletter	single option from database table	values from newsletters table
        public string Type => GetValue(() => Type); //	Section Type	single option from hard-coded set of choices	one of these values
        public int KeyValue => GetValue(() => KeyValue);    //	Item	integer	any number
        public string Title => GetValue(() => Title);   //	Title	text	any value
        public string Description => GetValue(() => Description);   //	Description	WYSIWYG (HTML) multi-line text box	any value
        public int Ranking => GetValue(() => Ranking);	//	Display ranking	integer	any number

        internal NewsletterItem(HSSession session)
            : base(session)
        {
        }
    }

}
