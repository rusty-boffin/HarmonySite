using System;
using System.Collections.Generic;
using System.Threading;

namespace RustyBoffin.HarmonySite
{
    internal abstract class HSTableLoaderGroup
    {
        protected HSSession Session { get; }
        protected CancellationToken CancellationToken { get; }
        protected HSTableLoaderGroup(HSSession session, CancellationToken cancellationToken)
        {
            Session = session;
            CancellationToken = cancellationToken;
        }

        protected List<HSTableLoader> LoaderList { get; } = new List<HSTableLoader>();
        public int Count => LoaderList.Count;
        public void Add(HSTableLoader loader)
        {
            loader.Loaded += Loader_Loaded;
            LoaderList.Add(loader); 
        }

        protected virtual void Loader_Loaded(object? sender, EventArgs e)
        {
        }

        public virtual void Load()
        {
            foreach (HSTableLoader tl in LoaderList)
                tl.Reset();
        }
    }
}
