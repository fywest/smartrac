namespace ReaderGui
{
    partial class Form1
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkedListBoxSelectIC = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxSelectReader = new System.Windows.Forms.CheckedListBox();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.labelSelectIC = new System.Windows.Forms.Label();
            this.labelSelectReader = new System.Windows.Forms.Label();
            this.labelCommand = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openReadJsonFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelReadConfigFile = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveAsReaderConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 426);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(51, 22);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonCommand_Click);
            // 
            // checkedListBoxSelectIC
            // 
            this.checkedListBoxSelectIC.FormattingEnabled = true;
            this.checkedListBoxSelectIC.Location = new System.Drawing.Point(12, 67);
            this.checkedListBoxSelectIC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkedListBoxSelectIC.Name = "checkedListBoxSelectIC";
            this.checkedListBoxSelectIC.Size = new System.Drawing.Size(278, 124);
            this.checkedListBoxSelectIC.TabIndex = 1;
            this.checkedListBoxSelectIC.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxSelectIC_ItemCheck);
            // 
            // checkedListBoxSelectReader
            // 
            this.checkedListBoxSelectReader.FormattingEnabled = true;
            this.checkedListBoxSelectReader.Location = new System.Drawing.Point(296, 67);
            this.checkedListBoxSelectReader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkedListBoxSelectReader.Name = "checkedListBoxSelectReader";
            this.checkedListBoxSelectReader.Size = new System.Drawing.Size(278, 124);
            this.checkedListBoxSelectReader.TabIndex = 2;
            this.checkedListBoxSelectReader.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxSelectReader_ItemCheck);
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(12, 227);
            this.textBoxCommand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCommand.Multiline = true;
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCommand.Size = new System.Drawing.Size(562, 191);
            this.textBoxCommand.TabIndex = 4;
            this.textBoxCommand.WordWrap = false;
            this.textBoxCommand.TextChanged += new System.EventHandler(this.textBoxCommand_TextChanged);
            // 
            // labelSelectIC
            // 
            this.labelSelectIC.AutoSize = true;
            this.labelSelectIC.Location = new System.Drawing.Point(14, 52);
            this.labelSelectIC.Name = "labelSelectIC";
            this.labelSelectIC.Size = new System.Drawing.Size(50, 13);
            this.labelSelectIC.TabIndex = 5;
            this.labelSelectIC.Text = "Select IC";
            // 
            // labelSelectReader
            // 
            this.labelSelectReader.AutoSize = true;
            this.labelSelectReader.Location = new System.Drawing.Point(294, 52);
            this.labelSelectReader.Name = "labelSelectReader";
            this.labelSelectReader.Size = new System.Drawing.Size(75, 13);
            this.labelSelectReader.TabIndex = 6;
            this.labelSelectReader.Text = "Select Reader";
            // 
            // labelCommand
            // 
            this.labelCommand.AutoSize = true;
            this.labelCommand.Location = new System.Drawing.Point(12, 213);
            this.labelCommand.Name = "labelCommand";
            this.labelCommand.Size = new System.Drawing.Size(54, 13);
            this.labelCommand.TabIndex = 8;
            this.labelCommand.Text = "Command";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(94, 431);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(37, 13);
            this.labelStatus.TabIndex = 9;
            this.labelStatus.Text = "Status";
            this.labelStatus.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.componentToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(592, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openReadJsonFileToolStripMenuItem,
            this.saveAsReaderConfigToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openReadJsonFileToolStripMenuItem
            // 
            this.openReadJsonFileToolStripMenuItem.Name = "openReadJsonFileToolStripMenuItem";
            this.openReadJsonFileToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openReadJsonFileToolStripMenuItem.Text = "Open Reader config ";
            this.openReadJsonFileToolStripMenuItem.Click += new System.EventHandler(this.openReadJsonFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // componentToolStripMenuItem
            // 
            this.componentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readerToolStripMenuItem});
            this.componentToolStripMenuItem.Name = "componentToolStripMenuItem";
            this.componentToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.componentToolStripMenuItem.Text = "Component";
            // 
            // readerToolStripMenuItem
            // 
            this.readerToolStripMenuItem.Name = "readerToolStripMenuItem";
            this.readerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.readerToolStripMenuItem.Text = "Reader";
            this.readerToolStripMenuItem.Click += new System.EventHandler(this.readerToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelReadConfigFile
            // 
            this.labelReadConfigFile.AutoSize = true;
            this.labelReadConfigFile.Location = new System.Drawing.Point(13, 28);
            this.labelReadConfigFile.Name = "labelReadConfigFile";
            this.labelReadConfigFile.Size = new System.Drawing.Size(100, 13);
            this.labelReadConfigFile.TabIndex = 11;
            this.labelReadConfigFile.Text = "Reader Config File :";
            this.labelReadConfigFile.Visible = false;
            // 
            // saveAsReaderConfigToolStripMenuItem
            // 
            this.saveAsReaderConfigToolStripMenuItem.Name = "saveAsReaderConfigToolStripMenuItem";
            this.saveAsReaderConfigToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveAsReaderConfigToolStripMenuItem.Text = "Save As Reader config";
            this.saveAsReaderConfigToolStripMenuItem.Click += new System.EventHandler(this.saveAsReaderConfigToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 457);
            this.Controls.Add(this.labelReadConfigFile);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelCommand);
            this.Controls.Add(this.labelSelectReader);
            this.Controls.Add(this.labelSelectIC);
            this.Controls.Add(this.textBoxCommand);
            this.Controls.Add(this.checkedListBoxSelectReader);
            this.Controls.Add(this.checkedListBoxSelectIC);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Reader Gui";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckedListBox checkedListBoxSelectIC;
        private System.Windows.Forms.CheckedListBox checkedListBoxSelectReader;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.Label labelSelectIC;
        private System.Windows.Forms.Label labelSelectReader;
        private System.Windows.Forms.Label labelCommand;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openReadJsonFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelReadConfigFile;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem componentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsReaderConfigToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

