using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("targets")]
    public class DonationTarget : HSObject
    {
        public string Title => GetValue(() => Title);   //	Title	text	any value
        public bool Active => GetValue(() => Active);   //	Active?	boolean (yes/no)	Yes or No
        public string Description => GetValue(() => Description);   //	Description	WYSIWYG (HTML) multi-line text box	any value
        public int Donation => GetValue(() => Donation);    //	Suggested donation	integer	any currency value (in cents/pence/etc)
        public int Ranking => GetValue(() => Ranking);	//	Display ranking	integer	any number

        internal DonationTarget(HSSession session)
            : base(session)
        {
        }
    }

}
