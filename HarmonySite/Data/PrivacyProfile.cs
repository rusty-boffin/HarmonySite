namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("privacyprofiles", HSTableAttribute.eFeatures.Small)]
    public class PrivacyProfile : HSObject
    {

        public string Name => GetValue(() => Name); //	Spare field 1	text	any value
        public string Description => GetValue(() => Description); //	Spare field 1	text	any value
        public Member ForMember => GetValue(() => ForMember); //	Member	single option from database table	values from members table
        public string Settings => GetValue(() => Settings); //	Spare field 1	text	any value
        internal PrivacyProfile(HSSession session)
            : base(session)
        {
        }
    }
}
