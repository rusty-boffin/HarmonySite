using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("comfiles")]
    public class EventFilesResource : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    //	ID from imported table	integer
        public string Name => GetValue(() => Name); //	Name	text
        public Event Event => GetValue(() => Event);	//	Event	single option from database table

        public string Production => GetValue(() => Production); //	Production	any value						
        public string Level => GetValue(() => Level); //	Level	any value						
        public Upload Post => GetValue(() => Post); //	Riser stack	any value						
        public string DropboxFile => GetValue(() => DropboxFile); //	Riser stack	any value						
        public string Widget => GetValue(() => Widget); //	Riser stack	any value						
        public string EvShow => GetValue(() => EvShow); //	Riser stack	any value						
        public string RawLink => GetValue(() => RawLink); //	Riser stack	any value						
        public Member PostedBy => GetValue(() => PostedBy); //	Uploaded By	single option from database table	values from members table							
        public string Uploaded => GetValue(() => Uploaded); //	Riser stack	any value						
        public string Description => GetValue(() => Description); //	Riser stack	any value						
        public string Video => GetValue(() => Video); //	Riser stack	any value						
        public string Filename => GetValue(() => Filename); //	Riser stack	any value						
        public string Link => GetValue(() => Link); //	Riser stack	any value						
        public DateTime Emailed => GetValue(() => Emailed); //	Details emailed to members	date	any value			

        internal EventFilesResource(HSSession session)
            : base(session)
        {
        }
    }

}
