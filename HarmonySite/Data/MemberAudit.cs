using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("audits")]
    public class MemberAudit : HSObject
    {
        public string Name => GetValue(() => Name); //	Name/Question	text	any value
        public MemberAuditGroup Group => GetValue(() => Group);   //	Group	single option from database table	values from auditgroups table
        public Event Event => GetValue(() => Event);   //	Event	single option from database table	values from events table
        public string Description => GetValue(() => Description);   //	Full description	WYSIWYG (HTML) multi-line text box	any value
        public string File => GetValue(() => File); //	Attachment	file (with title)	files with this specification
        public string Link => GetValue(() => Link); //	Web page	web (HTTP) link	any value
        public string Video => GetValue(() => Video);   //	YouTube Video URL	YouTube video ID	any value
        public string Type => GetValue(() => Type); //	Type of response required	single option from hard-coded set of choices	one of these values
        public string Responses => GetValue(() => Responses);   //	Possible responses	multi-line text box	any value
        public Member PostedBy => GetValue(() => PostedBy); //	Posted By	single option from database table	values from members table
        public DateTime Date => GetValue(() => Date);   //	Date posted	date	any value
        public DateTime Closed => GetValue(() => Closed);   //	Last day for responses	date	any value
        public string Level => GetValue(() => Level);   //	Access Level required	single option from hard-coded set of choices	one of these values
        public string Visible => GetValue(() => Visible);   //	Visibility of responses	single option from hard-coded set of choices	one of these values
        public int Ranking => GetValue(() => Ranking);  //	Display ranking	integer	any number
        public bool Summary => GetValue(() => Summary); //	Show a collated summary of responses?	boolean (yes/no)	Yes or No
        public bool AnswersReqd => GetValue(() => AnswersReqd);	//	Members are required to respond ASAP?	boolean (yes/no)	Yes or No

        [HSFilter(nameof(MemberAuditResponse.Audit))]
        public HSCollection<MemberAuditResponse> MemberResponses => GetValues(() => MemberResponses);

        internal MemberAudit(HSSession session)
            : base(session)
        {
        }
    }

}
