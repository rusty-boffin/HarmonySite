using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("progtemplates")]
    public class EventProgramTemplate : HSObject
    {
        public string Name => GetValue(() => Name); //	Template name	text
        public Member PostedBy => GetValue(() => PostedBy); //	Created By	single option from database table
        public DateTime Uploaded => GetValue(() => Uploaded);	//	Date Created	date

        internal EventProgramTemplate(HSSession session)
            : base(session)
        {
        }
    }

}
