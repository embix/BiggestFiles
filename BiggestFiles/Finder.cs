using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BiggestFiles
{
    public class Finder
    {
        private readonly Int32 _fileCount = 20;
        private readonly DirectoryInfo _startingDirectory;
        public static readonly String StandardOutputFormat = @"{0,15:### ### ### ###} Byte {1}";

        #region Public API

        public event Action<IEnumerable<FileInfo>> FinalResult;

        public Finder(String startingPath)
        {
            _startingDirectory = new DirectoryInfo(startingPath);
        }

        public IEnumerable<String> FindRecursivly()
        {
            var biggestFiles = FindFilesRecursively();
            var resultLines = new List<String>();
            foreach (var file in biggestFiles)
            {
                resultLines.Add(String.Format(StandardOutputFormat, file.Length, file.FullName));
            }
            return resultLines;
        }

        public IEnumerable<FileInfo> FindFilesRecursively()
        {
            return GetBiggestFilesInDirectoryRecursively(_startingDirectory);
        }

        public void EventBasedFind()
        {
            var result = FindFilesRecursively();
            FinalResult(result);
        }

        #endregion Public API

        private IEnumerable<FileInfo> GetBiggestFilesInDirectoryRecursively(DirectoryInfo directory)
        {
            IEnumerable<FileInfo> biggestFilesInCurrentDirectory = TryGetBiggestFilesInCurrentDirectory(directory);
            IEnumerable<DirectoryInfo> directoriesInCurrentDirectory = TryGetDirectoriesInCurrentDirectory(directory);
            foreach (var subDirectory in directoriesInCurrentDirectory)
            {
                var biggestFilesInSubDirectory = GetBiggestFilesInDirectoryRecursively(subDirectory);
                biggestFilesInCurrentDirectory = 
                    biggestFilesInCurrentDirectory.Union(biggestFilesInSubDirectory).OrderByDescending(file => file.Length).Take(_fileCount);
            }
            return biggestFilesInCurrentDirectory;
        }

        private IEnumerable<DirectoryInfo> TryGetDirectoriesInCurrentDirectory(DirectoryInfo directory)
        {
            try
            {
                return directory.EnumerateDirectories();
            }
            catch (UnauthorizedAccessException exception)
            {
                // TODO: Logging, Warning
            }
            catch(Exception exception)
            {
                // TODO: Logging, Strong Warning
            }
            return new DirectoryInfo[0];
        }

        private IEnumerable<FileInfo> TryGetBiggestFilesInCurrentDirectory(DirectoryInfo directory)
        {
            try
            {
                return GetBiggestFilesInCurrentDirectory(directory);
            }
            catch (UnauthorizedAccessException exception)
            {
                // TODO: Logging, Warning
            }
            catch(Exception exception)
            {
                // TODO: Logging, Strong Waring
            }
            return new FileInfo[0];
        }

        private IEnumerable<FileInfo> GetBiggestFilesInCurrentDirectory(DirectoryInfo directory)
        {
            var filesInDirectory = directory.EnumerateFiles();
            var byDescending = filesInDirectory.OrderByDescending(file => file.Length);
            return byDescending.Take(_fileCount);
        }
    }
}
