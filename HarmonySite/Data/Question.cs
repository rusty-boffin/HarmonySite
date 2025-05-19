using RustyBoffin.HarmonySite;

namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("questions")]
    public class Question : HSObject
    {
        public string Name => GetValue(() => Name);   //	Question	text	any value
        public string Required => GetValue(() => Required);   //	Active?	An answer is required?	
        public string Scope => GetValue(() => Scope);   //	One answer per single option	
        public string Description => GetValue(() => Description);   //	Description	WYSIWYG (HTML) multi-line text box	any value
        public string Type => GetValue(() => Type);   //	Type of response required	
        public string Responses => GetValue(() => Responses);   //	Possible responses	
        public string Level => GetValue(() => Level);   //	Shown to	
        public string AdminNotes => GetValue(() => AdminNotes);   //	Admin notes	e
        internal Question(HSSession session)
            : base(session)
        {
        }
    }

}
