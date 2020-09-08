using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("updates")]
    public class UpdateLog : HSObject
    {
        public DateTime TimeStamp => GetValue(() => TimeStamp); //
        public Member Who => GetValue(() => Who);   //
        public string TableName => GetValue(() => TableName);   //
        public string RecordID => GetValue(() => RecordID); //
        public string RecordName => GetValue(() => RecordName); //
        public string Changes => GetValue(() => Changes);	//

        internal UpdateLog(HSSession session)
            : base(session)
        {
        }
    }

}
