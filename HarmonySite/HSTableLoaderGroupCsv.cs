using System.Threading;
using System.Threading.Tasks;

namespace RustyBoffin.HarmonySite
{
    internal class HSTableLoaderGroupCsv : HSTableLoaderGroup
    {
        public HSTableLoaderGroupCsv(HSSession session, CancellationToken cancellationToken) 
            : base(session, cancellationToken)
        {
        }

        public override async Task Load()
        {
            await base.Load();

            foreach (HSTableLoader tl in LoaderList)
            {
                ITableLoaderCsv tlw = (ITableLoaderCsv)tl;
                tlw.Load();
            }
        }
    }
}
