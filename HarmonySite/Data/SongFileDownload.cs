using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("rpfdownloads")]
    public class SongFileDownload : HSObject
    {
        public SongFilesResource Repfile => GetValue(() => Repfile);   //	Song file	single option from database table	values from repfiles table
        public Member Member => GetValue(() => Member); //	Member	single option from database table	values from members table
        public DateTime Downloaded => GetValue(() => Downloaded);   //	First downloaded	date	any value
        public int Downloads => GetValue(() => Downloads);	//	Total downloads	integer	any number

        internal SongFileDownload(HSSession session)
            : base(session)
        {
        }
    }

}
