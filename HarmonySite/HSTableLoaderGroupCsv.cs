using System.Threading;

namespace RustyBoffin.HarmonySite
{
    internal class HSTableLoaderGroupCsv : HSTableLoaderGroup
    {
        public HSTableLoaderGroupCsv(HSSession session, CancellationToken cancellationToken) 
            : base(session, cancellationToken)
        {
        }

        public override void Load()
        {
            base.Load();

            foreach (HSTableLoader tl in LoaderList)
            {
                ITableLoaderCsv tlw = (ITableLoaderCsv)tl;
                tlw.Load();
            }
        }
    }
}
