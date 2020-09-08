using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("pages")]
    public class WebsitePage : HSObject
    {
        public string Description => GetValue(() => Description);   //	Page name	text	any value
        public string Dbase => GetValue(() => Dbase);  //	Table to open	single option from hard-coded set of choices	one of these values
        public string EltName => GetValue(() => EltName);   //	Name of one element	text	any value
        public string EltsName => GetValue(() => EltsName); //	Plural name of several elements	text	any value
        public string Title => GetValue(() => Title);   //	Title for browser	text	any value
        public string Image => GetValue(() => Image);  //	Image for top of page	file	files with this specification
        public string Heading => GetValue(() => Heading);   //	Heading for top of page	text	any value
        public string SubHeading => GetValue(() => SubHeading); //	Sub-heading for top of page	text	any value
        public string Template => GetValue(() => Template); //	Overall Page Template	single option from hard-coded set of choices	one of these values
        public char LoadAll => GetValue(() => LoadAll); //	Load records from table?	boolean (yes/no)	Yes or No
        public string LoadUser => GetValue(() => LoadUser);    //	Current user records only - choose field	name of a field from this table	depends on page's database
        public string Keywords => GetValue(() => Keywords); //	Search engine keywords	multi-line text box	any value
        public string WhereClause => GetValue(() => WhereClause);   //	Filter options	multi-line text box	any value
        public string Listpage_pub => GetValue(() => Listpage_pub); //	List Template (Public)	text	any value
        public string Listpage_rest => GetValue(() => Listpage_rest);   //	List Template (Restricted)	text	any value
        public string Listpage_gen => GetValue(() => Listpage_gen); //	List Template (General)	text	any value
        public string Listpage_data => GetValue(() => Listpage_data);   //	List Template (Administrator)	text	any value
        public string Listpage_web => GetValue(() => Listpage_web); //	List Template (Webmaster)	text	any value
        public char FullDetails => GetValue(() => FullDetails); //	List displays FULL details?	boolean (yes/no)	Yes or No
        public string Groupby => GetValue(() => Groupby);  //	Group by	name of a field from this table	depends on page's database
        public char Group_desc => GetValue(() => Group_desc);   //	Group in descending order?	boolean (yes/no)	Yes or No
        public string Sortby => GetValue(() => Sortby);    //	Sort by	name of a field from this table	depends on page's database
        public char Sort_desc => GetValue(() => Sort_desc); //	Sort in descending order?	boolean (yes/no)	Yes or No
        public string Filters => GetValue(() => Filters);  //	Show filters to the user	name of a field from this table	depends on page's database
        public string AuthLevel => GetValue(() => AuthLevel);  //	Level required to view page	single option from hard-coded set of choices	one of these values
        public string Validation => GetValue(() => Validation); //	Validation Code	text	any value
        public int RecsPerPage => GetValue(() => RecsPerPage);  //	Records per page	integer	any number
        public string MetaDesc => GetValue(() => MetaDesc); //	Search engine description	multi-line text box	any value
        public string URLAlias => GetValue(() => URLAlias); //	Custom URL	text	any value
        public string Page => GetValue(() => Page);	//	Page contents	WYSIWYG (HTML) multi-line text box	any value

        internal WebsitePage(HSSession session)
            : base(session)
        {
        }
    }

}
