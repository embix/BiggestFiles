using System;
using System.Windows.Forms;
using BiggestFiles;

namespace BiggestFileWinFormGui
{
    public partial class BigFilesForm : Form
    {
        private static readonly String StardardPath = @"C:\";

        public BigFilesForm()
        {
            InitializeComponent();
            pathSelectionTextBox.Text = StardardPath;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var startingWithPath = pathSelectionTextBox.Text;
            var finder = new Finder(startingWithPath);
            var biggestFiles = finder.FindRecursivly();
            biggestFilesListBox.DataSource = biggestFiles;
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
