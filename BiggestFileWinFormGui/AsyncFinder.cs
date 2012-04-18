using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using BiggestFiles;

namespace BiggestFileWinFormGui
{
    class AsyncFinder
    {
        private Thread _processingThread;

        public event Action<IEnumerable<FileInfo>> FinalResult;
        
        public AsyncFinder(String startingPath)
        {
            var finder = new Finder(startingPath);
            finder.FinalResult += HandleTaskFinished;
            _processingThread = new Thread(finder.EventBasedFind);
        }

        public void Find()
        {
            _processingThread.Start();
        }

        private void HandleTaskFinished(IEnumerable<FileInfo> biggestFiles)
        {
            FinalResult(biggestFiles);
        }
    }
}
