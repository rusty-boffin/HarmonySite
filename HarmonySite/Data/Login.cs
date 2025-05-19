namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("auth")]
    public class Login : HSObject
    {
        public Member Member => GetValue(() => Member); //	Member	single option from database table	values from members table
        public string Access => GetValue(() => Access);

        public HSCollection<Club> Club => GetValues(() => Club);

        internal Login(HSSession session)
            : base(session)
        {
        }
    }

}
