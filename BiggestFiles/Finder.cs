using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Iteration 1: Spike Solution without any optimization for speed, maintainability or even error handling
namespace BiggestFiles
{
    public class Finder
    {
        private readonly Int32 _fileCount = 20;
        private readonly DirectoryInfo _startingDirectory;
        private static readonly String OutputFormat = @"{0,15:### ### ### ###} Byte {1}";

        public Finder(String startingPath)
        {
            _startingDirectory = new DirectoryInfo(startingPath);
        }

        public IEnumerable<String> Find()
        {
            var biggestFiles = GetBiggestFilesInDirectory(_startingDirectory);
            var resultLines = new List<String>();
            foreach (var file in biggestFiles)
            {
                resultLines.Add(String.Format(OutputFormat, file.Length, file.FullName));
            }
            return resultLines;
        }

        public IEnumerable<FileInfo> GetBiggestFilesInDirectory(DirectoryInfo directory)
        {
            var biggestFilesInCurrentDirectory = directory.EnumerateFiles().OrderByDescending(file => file.Length).Take(_fileCount);
            var directoriesInCurrentDirectory = directory.EnumerateDirectories();
            foreach (var subDirectory in directoriesInCurrentDirectory)
            {
                var biggestFilesInSubDirectory = GetBiggestFilesInDirectory(subDirectory);
                biggestFilesInCurrentDirectory = 
                    biggestFilesInCurrentDirectory.Union(biggestFilesInSubDirectory).OrderByDescending(file => file.Length).Take(_fileCount);
            }
            return biggestFilesInCurrentDirectory;
        }
    }
}
