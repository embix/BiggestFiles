using System;
using System.IO;
using BiggestFiles;

namespace BiggestFileWinFormGui.Views
{
    class FileInfoView
    {
        private readonly FileInfo _file;

        public override String ToString()
        {
            return String.Format(Finder.StandardOutputFormat, _file.Length, _file.FullName);
        }

        public FileInfo Info
        {
            get { return _file; }
        }

        public FileInfoView(FileInfo file)
        {
            _file = file;
        }
    }
}
