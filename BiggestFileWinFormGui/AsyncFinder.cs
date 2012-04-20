using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using BiggestFiles;

namespace BiggestFileWinFormGui
{
    class AsyncFinder
    {
        private readonly SynchronizationContext _synchronizationContext;
        private readonly String _startingPath;
        private Finder _finder;
        public event Action<IEnumerable<FileInfo>> FinalResult;
        
        public AsyncFinder(String startingPath)
        {
            _startingPath = startingPath;
            _synchronizationContext = SynchronizationContext.Current ?? new SynchronizationContext();
        }

        public void Find()
        {
            _finder = new Finder(_startingPath);
            _finder.FinalResult += HandleTaskFinished;
            new Thread(_finder.EventBasedFind).Start();
        }

        public void Abort()
        {
            _finder.AbortSearch();
        }

        private void HandleTaskFinished(IEnumerable<FileInfo> biggestFiles)
        {
            _synchronizationContext.Send(callback => FinalResult(biggestFiles), null);
            _finder.FinalResult -= HandleTaskFinished;
        }
    }
}
