using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BiggestFiles;
using BiggestFileWinFormGui.Views;

namespace BiggestFileWinFormGui
{
    public partial class BigFilesForm : Form
    {
        private static readonly String StardardPath = @"C:\";

        public BigFilesForm()
        {
            InitializeComponent();
            pathSelectionTextBox.Text = StardardPath;
            biggestFilesListBox.DoubleClick += biggestFilesListBox_DoubleClick;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var startingWithPath = pathSelectionTextBox.Text;
            //var finder = new Finder(startingWithPath);
            //finder.FinalResult += handleSearchFinished;
            //finder.EventBasedFind();
            var asyncFinder = new AsyncFinder(startingWithPath);
            asyncFinder.FinalResult += handleSearchFinished;
            asyncFinder.Find();
        }

        private void handleSearchFinished(IEnumerable<FileInfo> biggestFiles)
        {
            var listBoxEntries = from file in biggestFiles
                                 select new FileInfoView(file);
            biggestFilesListBox.DataSource = listBoxEntries.ToList();            
        }

        private void biggestFilesListBox_DoubleClick(object sender, EventArgs e)
        {
            TryOpenExplorerWithPathToSelectedFile();
        }

        private void TryOpenExplorerWithPathToSelectedFile()
        {
            try
            {
                OpenExplorerWithPathToSelectedFile();
            }catch(Exception ex)
            {
                // TODO: Logging, warning (add status line in BigFilesForm)
            }
        }

        private void OpenExplorerWithPathToSelectedFile()
        {
            var selectedFile = biggestFilesListBox.SelectedItem as FileInfoView;
            if (selectedFile != null)
            {
                var filePath = selectedFile.Info.FullName;
                var argument = @"/select, " + filePath;
                var explorerPath = Path.Combine(Environment.SystemDirectory, "explorer.exe");
                Process.Start(explorerPath, argument);
            }
        }

        private void pathSelectionButton_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = pathSelectionTextBox.Text;
            var result = folderBrowserDialog.ShowDialog();
            if(DialogResult.OK == result)
            {
                pathSelectionTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
