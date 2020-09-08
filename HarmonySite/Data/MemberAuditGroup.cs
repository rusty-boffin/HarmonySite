using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("auditgroups")]
    public class MemberAuditGroup : HSObject
    {
        public string Name => GetValue(() => Name); //	Name	text	any value
        public string Type => GetValue(() => Type); //	Type	single option from hard-coded set of choices	one of these values
        public bool Active => GetValue(() => Active);   //	Active?	boolean (yes/no)	Yes or No
        public string EltName => GetValue(() => EltName);   //	Name of each audit	text	any value
        public string EltsName => GetValue(() => EltsName); //	Name of several audits	text	any value
        public MemberGrouping Grouping => GetValue(() => Grouping); //	Restrict to just members of this member grouping	single option from database table	values from groupings table
        public string Description => GetValue(() => Description);   //	Description	WYSIWYG (HTML) multi-line text box	any value
        public DateTime Emailed => GetValue(() => Emailed);	//	Details emailed to members	date	any value

        [HSFilter(nameof(MemberAudit.Group))]
        public HSCollection<MemberAudit> Audits => GetValues(() => Audits);

        internal MemberAuditGroup(HSSession session)
            : base(session)
        {
        }
    }

}
