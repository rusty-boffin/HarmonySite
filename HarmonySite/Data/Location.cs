using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("venues")]
    public class Location : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number
        public string Name => GetValue(() => Name); //	Internal name	text	any value
        public Club Club => GetValue(() => Club); //	Club	single option from database table	values from clubs table
        public string Level => GetValue(() => Level);   //	Access Level required	single option from hard-coded set of choices	one of these values
        public string ConName => GetValue(() => ConName);   //	Name	text	any value
        public string Phone => GetValue(() => Phone);   //	Phone	text	any value
        public string Email => GetValue(() => Email);   //	Email Address	email link	any value
        public string Other => GetValue(() => Other);   //	Other	text	any value
        public string Access => GetValue(() => Access); //	Access Arrangements	WYSIWYG (HTML) multi-line text box	any value
        public string Description => GetValue(() => Description);   //	Description	multi-line text box	any value
        public string Acoustics => GetValue(() => Acoustics);   //	Acoustics	multi-line text box	any value
        public int Capacity => GetValue(() => Capacity);    //	Seating Capacity	integer	any number
        public string Layout => GetValue(() => Layout); //	Seating Layout	multi-line text box	any value
        public string LayoutFile => GetValue(() => LayoutFile); //	Seating Layout Diagram	file	files with this specification
        public string Staging => GetValue(() => Staging);   //	Staging	multi-line text box	any value
        public string Lighting => GetValue(() => Lighting); //	Lighting	multi-line text box	any value
        public string Sound => GetValue(() => Sound);   //	Sound	multi-line text box	any value
        public string Catering => GetValue(() => Catering); //	Catering and Party Facilities	multi-line text box	any value
        public string Changing => GetValue(() => Changing); //	Changing Facilities	multi-line text box	any value
        public string Toilets => GetValue(() => Toilets);   //	Toilets	multi-line text box	any value
        public string OtherPhys => GetValue(() => OtherPhys);   //	Other	multi-line text box	any value
        public string Price => GetValue(() => Price);   //	Price	multi-line text box	any value
        public string Contract => GetValue(() => Contract); //	Contract History	WYSIWYG (HTML) multi-line text box	any value
        public string Notes => GetValue(() => Notes);   //	General Notes	WYSIWYG (HTML) multi-line text box	any value
        public string Venue => GetValue(() => Venue);   //	Full street address	multi-line text box	any value
        public string Address => GetValue(() => Address);   //	Address for Google Map	text	any value
        public string Latitude => GetValue(() => Latitude); //	Latitude	text	any value
        public string Longitude => GetValue(() => Longitude);   //	Longitude	text	any value
        public string MapZoom => GetValue(() => MapZoom);	//	Zoom level	single option from hard-coded set of choices	one of these values

        internal Location(HSSession session)
            : base(session)
        {
        }
    }

}
