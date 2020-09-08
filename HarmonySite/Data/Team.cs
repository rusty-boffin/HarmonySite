using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("committees")]
    public class Team : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer	any number
        public string Name => GetValue(() => Name); //	Name	text	any value
        public Club Club => GetValue(() => Club); //	Club	single option from database table	filtered values from clubs table
        public string Description => GetValue(() => Description);   //	Contents of committee/team page	WYSIWYG (HTML) multi-line text box	any value
        public bool Active => GetValue(() => Active);   //	Active?	boolean (yes/no)	Yes or No
        public bool Private => GetValue(() => Private); //	Documents are private?	boolean (yes/no)	Yes or No
        public HSCollection<Member> Members => GetValues(() => Members);   //	Committee/team members	multiple options from database table	values from members table
        public HSCollection<Position> Positions => GetValues(() => Positions);   //	Positions	multiple options from database table	values from positions table
        public HSCollection<Member> Leaders => GetValues(() => Leaders);	//	Leaders/Captains/Chairpersons	multiple options from database table	values from members table

        [HSFilter(nameof(CommitteeTeamDocument.Team))]
        public HSCollection<CommitteeTeamDocument> Documents => GetValues(() => Documents);
        [HSFilter(nameof(MailingList.Committee))]
        public HSCollection<MailingList> MailingLists => GetValues(() => MailingLists);

        internal Team(HSSession session)
            : base(session)
        {
        }
    }

}
