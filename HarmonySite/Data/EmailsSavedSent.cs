using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("emails")]
    public class EmailsSavedSent : HSObject
    {
        public string FromName => GetValue(() => FromName); //	From name	text	any value
        public string FromEmail => GetValue(() => FromEmail);   //	From email	text	any value
        public MemberGrouping Grouping => GetValue(() => Grouping); //	Select recipients from	single option from database table	values from groupings table
        public HSCollection<Member> Members => GetValues(() => Members);   //	Recipients - members	multiple options from database table	values from members table
        public string MembersIn => GetValue(() => MembersIn);   //	Put the selected members' email addresses above into	text	any value
        public HSCollection<MailingList> MailingLists => GetValues(() => MailingLists); //	Recipients - mailing lists	multiple options from database table	values from mailinglists table
        public string To => GetValue(() => To); //	To	multi-line text box	any value
        public string CC => GetValue(() => CC); //	CC	multi-line text box	any value
        public string BCC => GetValue(() => BCC);   //	BCC	multi-line text box	any value
        public string Subject => GetValue(() => Subject);   //	Subject	text	any value
        public string Message => GetValue(() => Message);   //	Message	WYSIWYG (HTML) multi-line text box	any value
        public bool BCCme => GetValue(() => BCCme); //	BCC sender?	boolean (yes/no)	Yes or No
        public Member Member => GetValue(() => Member); //	Composed by	single option from database table	values from members table
        public string Created => GetValue(() => Created);   //	Created	text	any value
        public string Saved => GetValue(() => Saved);   //	Saved	text	any value
        public string Sent => GetValue(() => Sent); //	Sent	text	any value
        public string Attachment1 => GetValue(() => Attachment1);   //	Attachment 1	file	files with this specification
        public string Attachment2 => GetValue(() => Attachment2);   //	Attachment 2	file	files with this specification
        public string Attachment3 => GetValue(() => Attachment3);   //	Attachment 3	file	files with this specification
        public string Attachment4 => GetValue(() => Attachment4);	//	Attachment 4	file	files with this specification

        internal EmailsSavedSent(HSSession session)
            : base(session)
        {
        }
    }

}
