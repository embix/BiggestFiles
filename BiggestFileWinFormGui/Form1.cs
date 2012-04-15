using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BiggestFiles;

namespace BiggestFileWinFormGui
{
    public partial class BigFilesForm : Form
    {
        public BigFilesForm()
        {
            InitializeComponent();
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
