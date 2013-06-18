using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BiggestFileWinFormGui.Views;

namespace BiggestFileWinFormGui
{
    public partial class BigFilesForm : Form
    {
        private static readonly String StardardPath = @"C:\";
        private AsyncFinder _activeFinder;
        private ActionButtonState _actionButtonState;

        public BigFilesForm()
        {
            InitializeComponent();
            pathSelectionTextBox.Text = StardardPath;
            SetActionButtonStateSearch();
        }

        private void SetActionButtonStateSearch()
        {
            _actionButtonState = ActionButtonState.Search;
            UpdateActionButtonText();
        }

        private void SetActionButtonStateAbort()
        {
            _actionButtonState = ActionButtonState.Abort;
            UpdateActionButtonText();
        }

        private void UpdateActionButtonText()
        {
            actionButton.Text = _actionButtonState.ToString();
        }

        private void actionButtonClick(object sender, EventArgs e)
        {
            if(ActionButtonState.Search == _actionButtonState)
            {
                handleSearchButtonClick();
            }else
            {
                handleAbortButtonClick();
            }   
        }

        private void handleAbortButtonClick()
        {
            _activeFinder.Abort();
            SetActionButtonStateSearch();
        }

        private void handleSearchButtonClick()
        {
            var startingWithPath = pathSelectionTextBox.Text;
            _activeFinder = new AsyncFinder(startingWithPath);
            _activeFinder.FinalResult += handleSearchFinished;
            biggestFilesListBox.DataSource = new List<FileInfoView>();
            biggestFilesListBox.DoubleClick -= biggestFilesListBox_DoubleClick;
            _activeFinder.Find();
            SetActionButtonStateAbort();
        }

        private void handleSearchFinished(IEnumerable<FileInfo> biggestFiles)
        {
            var listBoxEntries = from file in biggestFiles
                                 select new FileInfoView(file);
            biggestFilesListBox.DataSource = listBoxEntries.ToList();
            biggestFilesListBox.DoubleClick += biggestFilesListBox_DoubleClick;
            SetActionButtonStateSearch();
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
