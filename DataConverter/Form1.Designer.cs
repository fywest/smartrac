namespace DataConverter
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.RandomGen = new System.Windows.Forms.Button();
            this.BT_Convert = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_filename = new System.Windows.Forms.TextBox();
            this.TB_commands = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_maxIDSize = new System.Windows.Forms.TextBox();
            this.TB_staticURL = new System.Windows.Forms.TextBox();
            this.CB_2B_suffix = new System.Windows.Forms.CheckBox();
            this.CB_Counter_mirror = new System.Windows.Forms.CheckBox();
            this.CB_UID_mirror = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.CB_LockControl_TLV = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_count = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.RandomGen);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.BT_Convert);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label4);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.TB_filename);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.TB_commands);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label3);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.TB_maxIDSize);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.TB_staticURL);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.CB_2B_suffix);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.CB_Counter_mirror);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.CB_UID_mirror);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.checkBox2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.CB_LockControl_TLV);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.TB_count);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(761, 337);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(761, 361);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // RandomGen
            // 
            this.RandomGen.Location = new System.Drawing.Point(630, 177);
            this.RandomGen.Name = "RandomGen";
            this.RandomGen.Size = new System.Drawing.Size(120, 39);
            this.RandomGen.TabIndex = 18;
            this.RandomGen.Text = "Gen Random Hex";
            this.RandomGen.UseVisualStyleBackColor = true;
            this.RandomGen.Click += new System.EventHandler(this.RandomGen_Click);
            // 
            // BT_Convert
            // 
            this.BT_Convert.Location = new System.Drawing.Point(629, 119);
            this.BT_Convert.Name = "BT_Convert";
            this.BT_Convert.Size = new System.Drawing.Size(120, 39);
            this.BT_Convert.TabIndex = 17;
            this.BT_Convert.Text = "Convert";
            this.BT_Convert.UseVisualStyleBackColor = true;
            this.BT_Convert.Click += new System.EventHandler(this.BT_Convert_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "File name";
            // 
            // TB_filename
            // 
            this.TB_filename.Location = new System.Drawing.Point(86, 138);
            this.TB_filename.Name = "TB_filename";
            this.TB_filename.Size = new System.Drawing.Size(337, 20);
            this.TB_filename.TabIndex = 15;
            // 
            // TB_commands
            // 
            this.TB_commands.Location = new System.Drawing.Point(86, 213);
            this.TB_commands.Multiline = true;
            this.TB_commands.Name = "TB_commands";
            this.TB_commands.Size = new System.Drawing.Size(503, 104);
            this.TB_commands.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Static URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(576, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Max size";
            // 
            // TB_maxIDSize
            // 
            this.TB_maxIDSize.Location = new System.Drawing.Point(630, 13);
            this.TB_maxIDSize.Name = "TB_maxIDSize";
            this.TB_maxIDSize.Size = new System.Drawing.Size(63, 20);
            this.TB_maxIDSize.TabIndex = 10;
            this.TB_maxIDSize.Text = "10000";
            // 
            // TB_staticURL
            // 
            this.TB_staticURL.Location = new System.Drawing.Point(86, 164);
            this.TB_staticURL.Name = "TB_staticURL";
            this.TB_staticURL.Size = new System.Drawing.Size(337, 20);
            this.TB_staticURL.TabIndex = 8;
            // 
            // CB_2B_suffix
            // 
            this.CB_2B_suffix.AutoSize = true;
            this.CB_2B_suffix.Checked = true;
            this.CB_2B_suffix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_2B_suffix.Location = new System.Drawing.Point(200, 82);
            this.CB_2B_suffix.Name = "CB_2B_suffix";
            this.CB_2B_suffix.Size = new System.Drawing.Size(88, 17);
            this.CB_2B_suffix.TabIndex = 6;
            this.CB_2B_suffix.Text = "2B Fix2 suffix";
            this.CB_2B_suffix.UseVisualStyleBackColor = true;
            // 
            // CB_Counter_mirror
            // 
            this.CB_Counter_mirror.AutoSize = true;
            this.CB_Counter_mirror.Checked = true;
            this.CB_Counter_mirror.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Counter_mirror.Location = new System.Drawing.Point(200, 59);
            this.CB_Counter_mirror.Name = "CB_Counter_mirror";
            this.CB_Counter_mirror.Size = new System.Drawing.Size(91, 17);
            this.CB_Counter_mirror.TabIndex = 5;
            this.CB_Counter_mirror.Text = "Counter mirror";
            this.CB_Counter_mirror.UseVisualStyleBackColor = true;
            // 
            // CB_UID_mirror
            // 
            this.CB_UID_mirror.AutoSize = true;
            this.CB_UID_mirror.Checked = true;
            this.CB_UID_mirror.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_UID_mirror.Location = new System.Drawing.Point(200, 36);
            this.CB_UID_mirror.Name = "CB_UID_mirror";
            this.CB_UID_mirror.Size = new System.Drawing.Size(73, 17);
            this.CB_UID_mirror.TabIndex = 4;
            this.CB_UID_mirror.Text = "UID mirror";
            this.CB_UID_mirror.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(335, 13);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(74, 17);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "NTAG213";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // CB_LockControl_TLV
            // 
            this.CB_LockControl_TLV.AutoSize = true;
            this.CB_LockControl_TLV.Checked = true;
            this.CB_LockControl_TLV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_LockControl_TLV.Location = new System.Drawing.Point(200, 13);
            this.CB_LockControl_TLV.Name = "CB_LockControl_TLV";
            this.CB_LockControl_TLV.Size = new System.Drawing.Size(109, 17);
            this.CB_LockControl_TLV.TabIndex = 2;
            this.CB_LockControl_TLV.Text = "Lock Control TLV";
            this.CB_LockControl_TLV.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(588, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Count";
            // 
            // TB_count
            // 
            this.TB_count.Location = new System.Drawing.Point(630, 44);
            this.TB_count.Name = "TB_count";
            this.TB_count.Size = new System.Drawing.Size(63, 20);
            this.TB_count.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(761, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "csv";
            this.openFileDialog1.Filter = "CSV files|*.csv|All files|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "CSV files|*.csv|All files|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 361);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Data Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_count;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox CB_2B_suffix;
        private System.Windows.Forms.CheckBox CB_Counter_mirror;
        private System.Windows.Forms.CheckBox CB_UID_mirror;
        private System.Windows.Forms.CheckBox CB_LockControl_TLV;
        private System.Windows.Forms.TextBox TB_staticURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_maxIDSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_commands;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_filename;
        private System.Windows.Forms.Button BT_Convert;
        private System.Windows.Forms.Button RandomGen;
    }
}

