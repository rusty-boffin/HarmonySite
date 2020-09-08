using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("rep")]
    public class Music : HSObject
    {
        public string Song => GetValue(() => Song); //	Song Title	text	any value							
        public HSCollection<Ensemble> Ensembles => GetValues(() => Ensembles);   //	Ensemble(s)	multiple options from database table	values from ensembles table							
        public HSCollection<ListItem> Category => GetValues(() => Category); //	Song Category	multiple options from database (dropdowns)	one of these values | Administer							
        public ListItem Style => GetValue(() => Style);   //	Song Style	single option from database (dropdowns)	one of these values | Administer							
        public ListItem Voicing => GetValue(() => Voicing);   //	Voicing	single option from database (dropdowns)	one of these values | Administer							
        public bool Contestable => GetValue(() => Contestable); //	Contestable Barbershop?	boolean (yes/no)	Yes or No							
        public string Revision => GetValue(() => Revision); //	Sheet Music Revision	text	any value							
        public string Arranger => GetValue(() => Arranger); //	Arranger	text	any value							
        public string Composer => GetValue(() => Composer); //	Composer	text	any value							
        public string Lyricist => GetValue(() => Lyricist); //	Lyricist	text	any value							
        public string Copyright => GetValue(() => Copyright);   //	Copyright	multi-line text box	any value							
        public string WritKey => GetValue(() => WritKey);   //	Key written in	single option from hard-coded set of choices	one of these values							
        public string SungKey => GetValue(() => SungKey);   //	Key sung in	single option from hard-coded set of choices	one of these values							
        public string Pitch => GetValue(() => Pitch);   //	Pitch blown	single option from hard-coded set of choices	one of these values							
        public string TuneUp => GetValue(() => TuneUp); //	Tune-up process	text	any value							
        public string FirstWords => GetValue(() => FirstWords); //	First words	text	any value							
        public int Tempo => GetValue(() => Tempo);  //	Tempo	integer	any number							
        public int Duration => GetValue(() => Duration);    //	Duration	integer	any number							
        public string Lyrics => GetValue(() => Lyrics); //	Lyrics	WYSIWYG (HTML) multi-line text box	any value							
        public string Intro => GetValue(() => Intro);   //	Introduction	multi-line text box	any value							
        public HSCollection<Member> Soloists => GetValues(() => Soloists); //	Soloist(s)	multiple options from database table	values from members table							
        public string TagURL => GetValue(() => TagURL); //	Tag URL on BarbershopTags.com	web (HTTP) link	any value							
        public HSCollection<RiserStack> Stack => GetValues(() => Stack);   //	Riser stack(s)	multiple options from database table	values from stacks table							
        public string Comments => GetValue(() => Comments); //	Notes for members	WYSIWYG (HTML) multi-line text box	any value							
        public Member PostedBy => GetValue(() => PostedBy); //	Uploaded By	single option from database table	values from members table							
        public string Level => GetValue(() => Level);   //	Access Level required	single option from hard-coded set of choices	one of these values							
        public string Status => GetValue(() => Status); //	Status	single option from database (dropdowns)	one of these values | Administer							
        public string Public => GetValue(() => Public); //	Part of public repertoire?	boolean (yes/no)	Yes or No							
        public DateTime Available => GetValue(() => Available); //	Made available	date	any value							
        public DateTime OffBook => GetValue(() => OffBook); //	"Off-book" date	date	any value							
        public DateTime Retired => GetValue(() => Retired); //	Date retired/archived	date	any value							
        public string Assessed => GetValue(() => Assessed); //	Singing assessment	single option from hard-coded set of choices	one of these values							
        public string ChoreoAss => GetValue(() => ChoreoAss);   //	Presentation assessment	single option from hard-coded set of choices	one of these values							
        public DateTime IgnoreAss => GetValue(() => IgnoreAss); //	Ignore assessments submitted before	date	any value							
        public DateTime Emailed => GetValue(() => Emailed); //	Details emailed to members	date	any value							
        public bool SendEmail => GetValue(() => SendEmail);	//	Send email to members now?	boolean (yes/no)	Yes or No							

        [HSFilter(nameof(SongFilesResource.Song))]
        public HSCollection<SongFilesResource> Resources => GetValues(() => Resources);

        internal Music(HSSession session)
            : base(session)
        {
        }
    }

}
