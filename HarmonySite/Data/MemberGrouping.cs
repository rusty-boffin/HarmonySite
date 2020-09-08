using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("groupings")]
    public class MemberGrouping : HSObject
    {
        public string Name => GetValue(() => Name); //	Name	text	any value		
        public int Ranking => GetValue(() => Ranking);  //	Display ranking	integer	any number		
        public string Notes => GetValue(() => Notes);   //	Notes	WYSIWYG (HTML) multi-line text box	any value		
        public string State => GetValue(() => State);   //	State	single option from hard-coded set of choices	one of these values		
        public string Postcode => GetValue(() => Postcode); //	Postcode	text	any value		
        public HSCollection<ListItem> Gender => GetValues(() => Gender); //	Gender	multiple options from database (dropdowns)	one of these values | Administer		
        public string Club => GetValue(() => Club); //	Club	single option from hard-coded set of choices	one of these values		
        public HSCollection<string> Type => GetValues(() => Type); //	Type/role	multiple options from restricted database	one of these values		
        public HSCollection<string> Level => GetValues(() => Level);   //	Level	multiple options from restricted database	one of these values		
        public HSCollection<string> Status => GetValues(() => Status); //	Status	multiple options from restricted database	one of these values		
        public HSCollection<ListItem> DuesType => GetValues(() => DuesType); //	Fees payable	multiple options from database (dropdowns)	one of these values | Administer		
        public HSCollection<FeeSchedulePeriod> DuesSchedule => GetValues(() => DuesSchedule); //	Payment frequency	multiple options from database table	values from feesperiods table		
        public string Expired => GetValue(() => Expired);   //	Expired?	single option from hard-coded set of choices	one of these values		
        public string MailList => GetValue(() => MailList); //	Mailing lists preference	single option from hard-coded set of choices	one of these values		
        public string DateField => GetValue(() => DateField);   //	Date range	single option from hard-coded set of choices	one of these values		
        public DateTime DateFrom => GetValue(() => DateFrom);   //	From	date	any value		
        public DateTime DateTo => GetValue(() => DateTo);   //	to	date	any value		
        public Ensemble Ensembles => GetValue(() => Ensembles);   //	Ensemble	single option from database table	values from ensembles table		
        public HSCollection<ListItem> Part => GetValues(() => Part); //	Section	multiple options from database (dropdowns)	one of these values | Administer		
        public HSCollection<string> EStatus => GetValues(() => EStatus);   //	Status	multiple options from restricted database	one of these values		
        public string Faculty => GetValue(() => Faculty);   //	NO LONGER USED	single option from hard-coded set of choices	one of these values		
        public string FrontRow => GetValue(() => FrontRow); //	Front Row?	single option from hard-coded set of choices	one of these values		
        public string SQL => GetValue(() => SQL);   //	SQL override	multi-line text box	any value		
        public string Function => GetValue(() => Function); //	PHP function super-override	text	any value		
        public string Spare1 => GetValue(() => Spare1); //	Spare field 1	text	any value		
        public string Sorting1 => GetValue(() => Sorting1); //	Sort by	single option from hard-coded set of choices	one of these values		
        public bool SortDesc1 => GetValue(() => SortDesc1); //	Sort descending	boolean (yes/no)	Yes or No		
        public string Sorting2 => GetValue(() => Sorting2); //	Sort by	single option from hard-coded set of choices	one of these values		
        public bool SortDesc2 => GetValue(() => SortDesc2); //	Sort descending	boolean (yes/no)	Yes or No		
        public string Sorting3 => GetValue(() => Sorting3); //	Sort by	single option from hard-coded set of choices	one of these values		
        public bool SortDesc3 => GetValue(() => SortDesc3);	//	Sort descending	boolean (yes/no)	Yes or No		

        [HSFilter(nameof(EmailsSavedSent.Grouping))]
        public HSCollection<EmailsSavedSent> Emails => GetValues(() => Emails);
        [HSFilter(nameof(MailingList.Grouping))]
        public HSCollection<MailingList> MailingLists => GetValues(() => MailingLists);
        [HSFilter(nameof(MemberAuditGroup.Grouping))]
        public HSCollection<MemberAuditGroup> AuditGroups => GetValues(() => AuditGroups);

        internal MemberGrouping(HSSession session)
            : base(session)
        {
        }
    }

}
