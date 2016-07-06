namespace BiggestFileWinFormGui
{
    partial class BigFilesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pathSelectionTextBox = new System.Windows.Forms.TextBox();
            this.pathSelectionButton = new System.Windows.Forms.Button();
            this.biggestFilesListBox = new System.Windows.Forms.ListBox();
            this.actionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pathSelectionTextBox
            // 
            this.pathSelectionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathSelectionTextBox.Location = new System.Drawing.Point(13, 13);
            this.pathSelectionTextBox.Name = "pathSelectionTextBox";
            this.pathSelectionTextBox.Size = new System.Drawing.Size(437, 20);
            this.pathSelectionTextBox.TabIndex = 0;
            // 
            // pathSelectionButton
            // 
            this.pathSelectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pathSelectionButton.Location = new System.Drawing.Point(456, 10);
            this.pathSelectionButton.Name = "pathSelectionButton";
            this.pathSelectionButton.Size = new System.Drawing.Size(75, 23);
            this.pathSelectionButton.TabIndex = 1;
            this.pathSelectionButton.Text = "select Path";
            this.pathSelectionButton.UseVisualStyleBackColor = true;
            this.pathSelectionButton.Click += new System.EventHandler(this.pathSelectionButton_Click);
            // 
            // biggestFilesListBox
            // 
            this.biggestFilesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.biggestFilesListBox.FormattingEnabled = true;
            this.biggestFilesListBox.Location = new System.Drawing.Point(13, 40);
            this.biggestFilesListBox.Name = "biggestFilesListBox";
            this.biggestFilesListBox.Size = new System.Drawing.Size(599, 316);
            this.biggestFilesListBox.TabIndex = 2;
            // 
            // actionButton
            // 
            this.actionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.actionButton.Location = new System.Drawing.Point(537, 10);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(75, 23);
            this.actionButton.TabIndex = 3;
            this.actionButton.Text = "search";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.ActionButtonClick);
            // 
            // BigFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 362);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.biggestFilesListBox);
            this.Controls.Add(this.pathSelectionButton);
            this.Controls.Add(this.pathSelectionTextBox);
            this.Name = "BigFilesForm";
            this.Text = "Big Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathSelectionTextBox;
        private System.Windows.Forms.Button pathSelectionButton;
        private System.Windows.Forms.ListBox biggestFilesListBox;
        private System.Windows.Forms.Button actionButton;
    }
}

