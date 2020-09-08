using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("auditresponses")]
    public class MemberAuditResponse : HSObject
    {
        public Member Member => GetValue(() => Member); //	Member	single option from database table	values from members table
        public MemberAudit Audit => GetValue(() => Audit);   //	Audit	single option from database table	values from audits table
        public string Response => GetValue(() => Response); //	Response	WYSIWYG (HTML) multi-line text box	any value
        public DateTime Date => GetValue(() => Date);   //	Last updated	date	any value
        public Member Recorder => GetValue(() => Recorder); //	Entered by	single option from database table	values from members table
        public string Notes => GetValue(() => Notes);	//	Admin Notes	WYSIWYG (HTML) multi-line text box	any value

        internal MemberAuditResponse(HSSession session)
            : base(session)
        {
        }
    }

}
