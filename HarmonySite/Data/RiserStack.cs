using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("stacks")]
    public class RiserStack : HSObject
    {
        public string Name => GetValue(() => Name); //	Name	text	any value
        public Ensemble Ensemble => GetValue(() => Ensemble); //	Ensemble	single option from database table	filtered values from ensembles table
        public string Status => GetValue(() => Status); //	Status	single option from hard-coded set of choices	one of these values
        public string Level => GetValue(() => Level);   //	Access Level required	single option from hard-coded set of choices	one of these values
        public DateTime Created => GetValue(() => Created); //	Date Created	date	any value
        public string Attends => GetValue(() => Attends);   //	When used with events that track attendance, how should members that have not indicated they are attending be displayed?	single option from hard-coded set of choices	one of these values
        public string Stack => GetValue(() => Stack);   //	Stack	multi-line text box	any value
        public string Notes => GetValue(() => Notes);   //	Member Notes	WYSIWYG (HTML) multi-line text box	any value
        public string AdminNotes => GetValue(() => AdminNotes);	//	Admin Notes	WYSIWYG (HTML) multi-line text box	any value

        internal RiserStack(HSSession session)
            : base(session)
        {
        }
    }

}
