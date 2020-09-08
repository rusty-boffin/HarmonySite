using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("repfiles")]
    public class SongFilesResource : HSObject
    {
        public string Name => GetValue(() => Name); //	Name	text	any value								
        public Music Song => GetValue(() => Song); //	Song	single option from database table	values from rep table								
        public string Category => GetValue(() => Category); //	Type	single option from hard-coded set of choices	one of these values								
        public string Level => GetValue(() => Level);   //	Access Level required	single option from hard-coded set of choices	one of these values								
        public string Recording => GetValue(() => Recording);   //	Recording Type	single option from hard-coded set of choices	one of these values								
        public string Other => GetValue(() => Other);   //	Other type	text	any value								
        public string TrackSinger => GetValue(() => TrackSinger);   //	Sung by	text	any value								
        public DateTime Recorded => GetValue(() => Recorded);   //	Date recorded	date	any value								
        public string Dropbox => GetValue(() => Dropbox);   //	File from Dropbox	file	any file								
        public string Widget => GetValue(() => Widget); //	Embed code (HTML)	multi-line text box	any value								
        public bool TrackDownloads => GetValue(() => TrackDownloads);   //	Track member downloads?	boolean (yes/no)	Yes or No								
        public int Copies => GetValue(() => Copies);    //	Copies purchased	integer	any number								
        public int WarningLevel => GetValue(() => WarningLevel);    //	Warn when downloads reach	integer	any number								
        public string Supplier => GetValue(() => Supplier); //	Purchased from	text	any value								
        public DateTime Purchased => GetValue(() => Purchased); //	Date purchased	date	any value								
        public Member PostedBy => GetValue(() => PostedBy); //	Uploaded by	single option from database table	values from members table								
        public DateTime Uploaded => GetValue(() => Uploaded);   //	Date uploaded	date	any value								
        public string Description => GetValue(() => Description);   //	Notes	WYSIWYG (HTML) multi-line text box	any value								
        public string Video => GetValue(() => Video);   //	YouTube Video URL	YouTube video ID	any value								
        public string Filename => GetValue(() => Filename); //	File	file	files with this specification								
        public string Link => GetValue(() => Link); //	Link to external file	web (HTTP) link	any value								
        public DateTime Emailed => GetValue(() => Emailed); //	Details emailed to members	date	any value								
        public bool SendEmail => GetValue(() => SendEmail);	//	Send email to members now?	boolean (yes/no)	Yes or No								

        [HSFilter(nameof(SongFileDownload.Repfile))]
        public HSCollection<SongFileDownload> Downloads => GetValues(() => Downloads);

        internal SongFilesResource(HSSession session)
            : base(session)
        {
        }
    }

}
