using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("feesperiods")]
    public class FeeSchedulePeriod : HSObject
    {
        public string Adverb => GetValue(() => Adverb); //	Adverb	text	any value
        public string Noun => GetValue(() => Noun); //	Noun	text	any value
        public int PeriodN => GetValue(() => PeriodN);  //	Duration	integer	any number
        public string PeriodU => GetValue(() => PeriodU);   //	Units	single option from hard-coded set of choices	one of these values
        public int Ranking => GetValue(() => Ranking);	//	Display ranking	integer	any number

        internal FeeSchedulePeriod(HSSession session)
            : base(session)
        {
        }
    }

}
