using System;

namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("auth")]
    public class Login : HSObject
    {
        public Member Member => GetValue(() => Member); //	Member	single option from database table	values from members table
        public string Access => GetValue(() => Access);
        public string DBs => GetValue(() => DBs);
        public DateTime LastPasswdChange => GetValue(() => LastPasswdChange);
        public string ResetCode => GetValue(() => ResetCode);
        public DateTime ResetExpire => GetValue(() => ResetExpire);

        public HSCollection<Club> Club => GetValues(() => Club);

        internal Login(HSSession session)
            : base(session)
        {
        }
    }

}
