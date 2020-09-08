using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("participations")]
    public class Participation : HSObject
    {
        public Member Member => GetValue(() => Member); //	Member	single option from database table	values from members table
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number
        public Ensemble Ensemble => GetValue(() => Ensemble); //	Ensemble	single option from database table	values from ensembles table
        public ListItem Part => GetValue(() => Part); //	Section	single option from database (dropdowns)	one of these values | Administer
        public bool Faculty => GetValue(() => Faculty); //	NO LONGER USED	boolean (yes/no)	Yes or No
        public string FacultyRole => GetValue(() => FacultyRole);   //	Special role	text	any value
        public string Status => GetValue(() => Status); //	Status	single option from restricted database	one of these values
        public bool FrontRow => GetValue(() => FrontRow);   //	Front Row?	boolean (yes/no)	Yes or No
        public HSCollection<Convention> Conventions => GetValues(() => Conventions);   //	Conventions attended	multiple options from database table	values from conventions table
        public DateTime FirstR => GetValue(() => FirstR);   //	First Rehearsal	date	any value
        public DateTime Assess => GetValue(() => Assess);   //	Assessment passed	date	any value
        public DateTime Accepted => GetValue(() => Accepted);   //	Date accepted	date	any value
        public string AdminNotes => GetValue(() => AdminNotes); //	Admin Notes	WYSIWYG (HTML) multi-line text box	any value
        public string Spare1 => GetValue(() => Spare1); //	Spare field 1	text	any value
        public string Spare2 => GetValue(() => Spare2); //	Spare field 2	text	any value
        public string Spare3 => GetValue(() => Spare3); //	Spare field 3	text	any value
        public DateTime LastPaid => GetValue(() => LastPaid);   //	Date of last payment	date	any value
        public DateTime Resigned => GetValue(() => Resigned);   //	Date left	date	any value
        public DateTime Rejoined => GetValue(() => Rejoined);   //	Date re-joined	date	any value
        public DateTime TimeStamp => GetValue(() => TimeStamp);	//	Last updated	date	any value

        internal Participation(HSSession session)
            : base(session)
        {
        }
    }

}
