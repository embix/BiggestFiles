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
    }
}
