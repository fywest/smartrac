namespace ReaderGui
{
    partial class Form2
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
            PresentationControls.CheckBoxProperties checkBoxProperties2 = new PresentationControls.CheckBoxProperties();
            this.listBoxSelectModel = new System.Windows.Forms.ListBox();
            this.textBoxSupportedProtocols = new System.Windows.Forms.TextBox();
            this.labelSelectModel = new System.Windows.Forms.Label();
            this.labelFeigModel = new System.Windows.Forms.Label();
            this.textBoxICsCommand1 = new System.Windows.Forms.TextBox();
            this.labelICsName1 = new System.Windows.Forms.Label();
            this.textBoxICsCommand2 = new System.Windows.Forms.TextBox();
            this.labelICsName2 = new System.Windows.Forms.Label();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxSupportedICs = new System.Windows.Forms.TextBox();
            this.textBoxICsCommand3 = new System.Windows.Forms.TextBox();
            this.textBoxFeigModel = new System.Windows.Forms.TextBox();
            this.labelSupportedProtocols = new System.Windows.Forms.Label();
            this.labelSupportedICs = new System.Windows.Forms.Label();
            this.labelICsName3 = new System.Windows.Forms.Label();
            this.textBoxICsName1 = new System.Windows.Forms.TextBox();
            this.textBoxICsName2 = new System.Windows.Forms.TextBox();
            this.textBoxICsName3 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelReaderManufacturer = new System.Windows.Forms.Label();
            this.labelAvailableModels = new System.Windows.Forms.Label();
            this.labelAvailableProtocols = new System.Windows.Forms.Label();
            this.labelAvailableICs = new System.Windows.Forms.Label();
            this.comboBoxReaderManufacturer = new System.Windows.Forms.ComboBox();
            this.comboBoxAvailableModels = new System.Windows.Forms.ComboBox();
            this.comboBoxAvailableProtocols = new System.Windows.Forms.ComboBox();
            this.comboBoxAvailableICs = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkedListBoxSupportedProtocols = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxSupportedICs = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxICsName1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxICsName2 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxICsName3 = new System.Windows.Forms.CheckedListBox();
            this.listBoxSupportedProtocols = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBoxComboBox1 = new PresentationControls.CheckBoxComboBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxSelectModel
            // 
            this.listBoxSelectModel.FormattingEnabled = true;
            this.listBoxSelectModel.ItemHeight = 24;
            this.listBoxSelectModel.Location = new System.Drawing.Point(321, 223);
            this.listBoxSelectModel.Margin = new System.Windows.Forms.Padding(6);
            this.listBoxSelectModel.Name = "listBoxSelectModel";
            this.listBoxSelectModel.Size = new System.Drawing.Size(236, 124);
            this.listBoxSelectModel.TabIndex = 0;
            this.listBoxSelectModel.SelectedIndexChanged += new System.EventHandler(this.listBoxSelectModel_SelectedIndexChanged);
            // 
            // textBoxSupportedProtocols
            // 
            this.textBoxSupportedProtocols.Location = new System.Drawing.Point(572, 365);
            this.textBoxSupportedProtocols.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxSupportedProtocols.Name = "textBoxSupportedProtocols";
            this.textBoxSupportedProtocols.Size = new System.Drawing.Size(538, 35);
            this.textBoxSupportedProtocols.TabIndex = 1;
            this.textBoxSupportedProtocols.WordWrap = false;
            this.textBoxSupportedProtocols.TextChanged += new System.EventHandler(this.textBoxSupportedProtocols_TextChanged);
            // 
            // labelSelectModel
            // 
            this.labelSelectModel.AutoSize = true;
            this.labelSelectModel.Location = new System.Drawing.Point(54, 223);
            this.labelSelectModel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSelectModel.Name = "labelSelectModel";
            this.labelSelectModel.Size = new System.Drawing.Size(154, 24);
            this.labelSelectModel.TabIndex = 2;
            this.labelSelectModel.Text = "Select Model";
            // 
            // labelFeigModel
            // 
            this.labelFeigModel.AutoSize = true;
            this.labelFeigModel.Location = new System.Drawing.Point(778, 307);
            this.labelFeigModel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelFeigModel.Name = "labelFeigModel";
            this.labelFeigModel.Size = new System.Drawing.Size(130, 24);
            this.labelFeigModel.TabIndex = 3;
            this.labelFeigModel.Text = "Feig Model";
            // 
            // textBoxICsCommand1
            // 
            this.textBoxICsCommand1.Location = new System.Drawing.Point(54, 635);
            this.textBoxICsCommand1.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxICsCommand1.Multiline = true;
            this.textBoxICsCommand1.Name = "textBoxICsCommand1";
            this.textBoxICsCommand1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxICsCommand1.Size = new System.Drawing.Size(1056, 159);
            this.textBoxICsCommand1.TabIndex = 4;
            this.textBoxICsCommand1.WordWrap = false;
            this.textBoxICsCommand1.TextChanged += new System.EventHandler(this.textBoxICsCommand1_TextChanged);
            // 
            // labelICsName1
            // 
            this.labelICsName1.AutoSize = true;
            this.labelICsName1.Location = new System.Drawing.Point(50, 598);
            this.labelICsName1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelICsName1.Name = "labelICsName1";
            this.labelICsName1.Size = new System.Drawing.Size(106, 24);
            this.labelICsName1.TabIndex = 5;
            this.labelICsName1.Text = "ICsName1";
            // 
            // textBoxICsCommand2
            // 
            this.textBoxICsCommand2.Location = new System.Drawing.Point(52, 886);
            this.textBoxICsCommand2.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxICsCommand2.Multiline = true;
            this.textBoxICsCommand2.Name = "textBoxICsCommand2";
            this.textBoxICsCommand2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxICsCommand2.Size = new System.Drawing.Size(1056, 146);
            this.textBoxICsCommand2.TabIndex = 6;
            this.textBoxICsCommand2.WordWrap = false;
            this.textBoxICsCommand2.TextChanged += new System.EventHandler(this.textBoxICsCommand2_TextChanged);
            // 
            // labelICsName2
            // 
            this.labelICsName2.AutoSize = true;
            this.labelICsName2.Location = new System.Drawing.Point(48, 838);
            this.labelICsName2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelICsName2.Name = "labelICsName2";
            this.labelICsName2.Size = new System.Drawing.Size(106, 24);
            this.labelICsName2.TabIndex = 7;
            this.labelICsName2.Text = "ICsName2";
            // 
            // buttonModify
            // 
            this.buttonModify.Location = new System.Drawing.Point(568, 265);
            this.buttonModify.Margin = new System.Windows.Forms.Padding(6);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(150, 42);
            this.buttonModify.TabIndex = 8;
            this.buttonModify.Text = "Modify";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(568, 223);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(6);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(150, 42);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(568, 307);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(6);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(150, 42);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxSupportedICs
            // 
            this.textBoxSupportedICs.Location = new System.Drawing.Point(572, 479);
            this.textBoxSupportedICs.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxSupportedICs.Name = "textBoxSupportedICs";
            this.textBoxSupportedICs.Size = new System.Drawing.Size(538, 35);
            this.textBoxSupportedICs.TabIndex = 11;
            this.textBoxSupportedICs.WordWrap = false;
            this.textBoxSupportedICs.TextChanged += new System.EventHandler(this.textBoxSupportedICs_TextChanged);
            // 
            // textBoxICsCommand3
            // 
            this.textBoxICsCommand3.Location = new System.Drawing.Point(54, 1126);
            this.textBoxICsCommand3.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxICsCommand3.Multiline = true;
            this.textBoxICsCommand3.Name = "textBoxICsCommand3";
            this.textBoxICsCommand3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxICsCommand3.Size = new System.Drawing.Size(1056, 146);
            this.textBoxICsCommand3.TabIndex = 12;
            this.textBoxICsCommand3.WordWrap = false;
            this.textBoxICsCommand3.TextChanged += new System.EventHandler(this.textBoxICsCommand3_TextChanged);
            // 
            // textBoxFeigModel
            // 
            this.textBoxFeigModel.Location = new System.Drawing.Point(920, 307);
            this.textBoxFeigModel.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxFeigModel.Name = "textBoxFeigModel";
            this.textBoxFeigModel.Size = new System.Drawing.Size(102, 35);
            this.textBoxFeigModel.TabIndex = 13;
            this.textBoxFeigModel.WordWrap = false;
            this.textBoxFeigModel.TextChanged += new System.EventHandler(this.textBoxFeigModel_TextChanged);
            this.textBoxFeigModel.Validated += new System.EventHandler(this.textBoxFeigModel_Validated);
            // 
            // labelSupportedProtocols
            // 
            this.labelSupportedProtocols.AutoSize = true;
            this.labelSupportedProtocols.Location = new System.Drawing.Point(54, 362);
            this.labelSupportedProtocols.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSupportedProtocols.Name = "labelSupportedProtocols";
            this.labelSupportedProtocols.Size = new System.Drawing.Size(238, 24);
            this.labelSupportedProtocols.TabIndex = 14;
            this.labelSupportedProtocols.Text = "Supported Protocols";
            // 
            // labelSupportedICs
            // 
            this.labelSupportedICs.AutoSize = true;
            this.labelSupportedICs.Location = new System.Drawing.Point(48, 468);
            this.labelSupportedICs.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSupportedICs.Name = "labelSupportedICs";
            this.labelSupportedICs.Size = new System.Drawing.Size(166, 24);
            this.labelSupportedICs.TabIndex = 15;
            this.labelSupportedICs.Text = "Supported ICs";
            // 
            // labelICsName3
            // 
            this.labelICsName3.AutoSize = true;
            this.labelICsName3.Location = new System.Drawing.Point(56, 1078);
            this.labelICsName3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelICsName3.Name = "labelICsName3";
            this.labelICsName3.Size = new System.Drawing.Size(106, 24);
            this.labelICsName3.TabIndex = 18;
            this.labelICsName3.Text = "ICsName3";
            // 
            // textBoxICsName1
            // 
            this.textBoxICsName1.Location = new System.Drawing.Point(570, 588);
            this.textBoxICsName1.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxICsName1.Name = "textBoxICsName1";
            this.textBoxICsName1.Size = new System.Drawing.Size(338, 35);
            this.textBoxICsName1.TabIndex = 19;
            this.textBoxICsName1.WordWrap = false;
            this.textBoxICsName1.TextChanged += new System.EventHandler(this.textBoxICsName1_TextChanged);
            // 
            // textBoxICsName2
            // 
            this.textBoxICsName2.Location = new System.Drawing.Point(572, 835);
            this.textBoxICsName2.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxICsName2.Name = "textBoxICsName2";
            this.textBoxICsName2.Size = new System.Drawing.Size(338, 35);
            this.textBoxICsName2.TabIndex = 20;
            this.textBoxICsName2.WordWrap = false;
            this.textBoxICsName2.TextChanged += new System.EventHandler(this.textBoxICsName2_TextChanged);
            // 
            // textBoxICsName3
            // 
            this.textBoxICsName3.Location = new System.Drawing.Point(572, 1075);
            this.textBoxICsName3.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxICsName3.Name = "textBoxICsName3";
            this.textBoxICsName3.Size = new System.Drawing.Size(338, 35);
            this.textBoxICsName3.TabIndex = 21;
            this.textBoxICsName3.WordWrap = false;
            this.textBoxICsName3.TextChanged += new System.EventHandler(this.textBoxICsName3_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1302);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1162, 37);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1132, 32);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // labelReaderManufacturer
            // 
            this.labelReaderManufacturer.AutoSize = true;
            this.labelReaderManufacturer.Location = new System.Drawing.Point(54, 29);
            this.labelReaderManufacturer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelReaderManufacturer.Name = "labelReaderManufacturer";
            this.labelReaderManufacturer.Size = new System.Drawing.Size(226, 24);
            this.labelReaderManufacturer.TabIndex = 26;
            this.labelReaderManufacturer.Text = "ReaderManufacturer";
            // 
            // labelAvailableModels
            // 
            this.labelAvailableModels.AutoSize = true;
            this.labelAvailableModels.Location = new System.Drawing.Point(54, 66);
            this.labelAvailableModels.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelAvailableModels.Name = "labelAvailableModels";
            this.labelAvailableModels.Size = new System.Drawing.Size(190, 24);
            this.labelAvailableModels.TabIndex = 27;
            this.labelAvailableModels.Text = "AvailableModels";
            // 
            // labelAvailableProtocols
            // 
            this.labelAvailableProtocols.AutoSize = true;
            this.labelAvailableProtocols.Location = new System.Drawing.Point(54, 104);
            this.labelAvailableProtocols.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelAvailableProtocols.Name = "labelAvailableProtocols";
            this.labelAvailableProtocols.Size = new System.Drawing.Size(226, 24);
            this.labelAvailableProtocols.TabIndex = 28;
            this.labelAvailableProtocols.Text = "AvailableProtocols";
            // 
            // labelAvailableICs
            // 
            this.labelAvailableICs.AutoSize = true;
            this.labelAvailableICs.Location = new System.Drawing.Point(54, 145);
            this.labelAvailableICs.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelAvailableICs.Name = "labelAvailableICs";
            this.labelAvailableICs.Size = new System.Drawing.Size(154, 24);
            this.labelAvailableICs.TabIndex = 29;
            this.labelAvailableICs.Text = "AvailableICs";
            // 
            // comboBoxReaderManufacturer
            // 
            this.comboBoxReaderManufacturer.FormattingEnabled = true;
            this.comboBoxReaderManufacturer.Location = new System.Drawing.Point(317, 26);
            this.comboBoxReaderManufacturer.Name = "comboBoxReaderManufacturer";
            this.comboBoxReaderManufacturer.Size = new System.Drawing.Size(214, 32);
            this.comboBoxReaderManufacturer.TabIndex = 30;
            // 
            // comboBoxAvailableModels
            // 
            this.comboBoxAvailableModels.FormattingEnabled = true;
            this.comboBoxAvailableModels.Location = new System.Drawing.Point(319, 66);
            this.comboBoxAvailableModels.Name = "comboBoxAvailableModels";
            this.comboBoxAvailableModels.Size = new System.Drawing.Size(214, 32);
            this.comboBoxAvailableModels.TabIndex = 31;
            // 
            // comboBoxAvailableProtocols
            // 
            this.comboBoxAvailableProtocols.FormattingEnabled = true;
            this.comboBoxAvailableProtocols.Location = new System.Drawing.Point(317, 104);
            this.comboBoxAvailableProtocols.Name = "comboBoxAvailableProtocols";
            this.comboBoxAvailableProtocols.Size = new System.Drawing.Size(214, 32);
            this.comboBoxAvailableProtocols.TabIndex = 32;
            // 
            // comboBoxAvailableICs
            // 
            this.comboBoxAvailableICs.FormattingEnabled = true;
            this.comboBoxAvailableICs.Location = new System.Drawing.Point(317, 142);
            this.comboBoxAvailableICs.Name = "comboBoxAvailableICs";
            this.comboBoxAvailableICs.Size = new System.Drawing.Size(214, 32);
            this.comboBoxAvailableICs.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(563, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 35);
            this.button1.TabIndex = 34;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(637, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 35);
            this.button2.TabIndex = 35;
            this.button2.Text = "Del";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxSupportedProtocols
            // 
            this.checkedListBoxSupportedProtocols.FormattingEnabled = true;
            this.checkedListBoxSupportedProtocols.Items.AddRange(new object[] {
            "item1",
            "item2",
            "item3"});
            this.checkedListBoxSupportedProtocols.Location = new System.Drawing.Point(837, 26);
            this.checkedListBoxSupportedProtocols.Name = "checkedListBoxSupportedProtocols";
            this.checkedListBoxSupportedProtocols.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.checkedListBoxSupportedProtocols.Size = new System.Drawing.Size(238, 94);
            this.checkedListBoxSupportedProtocols.TabIndex = 37;
            // 
            // checkedListBoxSupportedICs
            // 
            this.checkedListBoxSupportedICs.FormattingEnabled = true;
            this.checkedListBoxSupportedICs.Location = new System.Drawing.Point(317, 480);
            this.checkedListBoxSupportedICs.Name = "checkedListBoxSupportedICs";
            this.checkedListBoxSupportedICs.Size = new System.Drawing.Size(240, 34);
            this.checkedListBoxSupportedICs.TabIndex = 38;
            // 
            // checkedListBoxICsName1
            // 
            this.checkedListBoxICsName1.FormattingEnabled = true;
            this.checkedListBoxICsName1.Location = new System.Drawing.Point(319, 588);
            this.checkedListBoxICsName1.Name = "checkedListBoxICsName1";
            this.checkedListBoxICsName1.Size = new System.Drawing.Size(240, 34);
            this.checkedListBoxICsName1.TabIndex = 39;
            // 
            // checkedListBoxICsName2
            // 
            this.checkedListBoxICsName2.FormattingEnabled = true;
            this.checkedListBoxICsName2.Location = new System.Drawing.Point(319, 828);
            this.checkedListBoxICsName2.Name = "checkedListBoxICsName2";
            this.checkedListBoxICsName2.Size = new System.Drawing.Size(240, 34);
            this.checkedListBoxICsName2.TabIndex = 40;
            // 
            // checkedListBoxICsName3
            // 
            this.checkedListBoxICsName3.FormattingEnabled = true;
            this.checkedListBoxICsName3.Location = new System.Drawing.Point(319, 1068);
            this.checkedListBoxICsName3.Name = "checkedListBoxICsName3";
            this.checkedListBoxICsName3.Size = new System.Drawing.Size(240, 34);
            this.checkedListBoxICsName3.TabIndex = 41;
            // 
            // listBoxSupportedProtocols
            // 
            this.listBoxSupportedProtocols.FormattingEnabled = true;
            this.listBoxSupportedProtocols.ItemHeight = 24;
            this.listBoxSupportedProtocols.Items.AddRange(new object[] {
            "item1",
            "item2",
            "item3"});
            this.listBoxSupportedProtocols.Location = new System.Drawing.Point(805, 234);
            this.listBoxSupportedProtocols.Name = "listBoxSupportedProtocols";
            this.listBoxSupportedProtocols.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSupportedProtocols.Size = new System.Drawing.Size(237, 52);
            this.listBoxSupportedProtocols.TabIndex = 42;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "item1",
            "item2",
            "item3"});
            this.comboBox1.Location = new System.Drawing.Point(817, 166);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(225, 32);
            this.comboBox1.TabIndex = 43;
            // 
            // checkBoxComboBox1
            // 
            checkBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxComboBox1.CheckBoxProperties = checkBoxProperties2;
            this.checkBoxComboBox1.DisplayMemberSingleItem = "";
            this.checkBoxComboBox1.FormattingEnabled = true;
            this.checkBoxComboBox1.Items.AddRange(new object[] {
            "item1",
            "item2",
            "item3",
            "item4",
            "item5",
            "item6",
            "item7",
            "item8"});
            this.checkBoxComboBox1.Location = new System.Drawing.Point(331, 426);
            this.checkBoxComboBox1.Name = "checkBoxComboBox1";
            this.checkBoxComboBox1.Size = new System.Drawing.Size(777, 32);
            this.checkBoxComboBox1.TabIndex = 44;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 1339);
            this.Controls.Add(this.checkBoxComboBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBoxSupportedProtocols);
            this.Controls.Add(this.checkedListBoxICsName3);
            this.Controls.Add(this.checkedListBoxICsName2);
            this.Controls.Add(this.checkedListBoxICsName1);
            this.Controls.Add(this.checkedListBoxSupportedICs);
            this.Controls.Add(this.checkedListBoxSupportedProtocols);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxAvailableICs);
            this.Controls.Add(this.comboBoxAvailableProtocols);
            this.Controls.Add(this.comboBoxAvailableModels);
            this.Controls.Add(this.comboBoxReaderManufacturer);
            this.Controls.Add(this.labelAvailableICs);
            this.Controls.Add(this.labelAvailableProtocols);
            this.Controls.Add(this.labelAvailableModels);
            this.Controls.Add(this.labelReaderManufacturer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBoxICsName3);
            this.Controls.Add(this.textBoxICsName2);
            this.Controls.Add(this.textBoxICsName1);
            this.Controls.Add(this.labelICsName3);
            this.Controls.Add(this.labelSupportedICs);
            this.Controls.Add(this.labelSupportedProtocols);
            this.Controls.Add(this.textBoxFeigModel);
            this.Controls.Add(this.textBoxICsCommand3);
            this.Controls.Add(this.textBoxSupportedICs);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.labelICsName2);
            this.Controls.Add(this.textBoxICsCommand2);
            this.Controls.Add(this.labelICsName1);
            this.Controls.Add(this.textBoxICsCommand1);
            this.Controls.Add(this.labelFeigModel);
            this.Controls.Add(this.labelSelectModel);
            this.Controls.Add(this.textBoxSupportedProtocols);
            this.Controls.Add(this.listBoxSelectModel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form2";
            this.Text = "Reader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSelectModel;
        private System.Windows.Forms.TextBox textBoxSupportedProtocols;
        private System.Windows.Forms.Label labelSelectModel;
        private System.Windows.Forms.Label labelFeigModel;
        private System.Windows.Forms.TextBox textBoxICsCommand1;
        private System.Windows.Forms.Label labelICsName1;
        private System.Windows.Forms.TextBox textBoxICsCommand2;
        private System.Windows.Forms.Label labelICsName2;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxSupportedICs;
        private System.Windows.Forms.TextBox textBoxICsCommand3;
        private System.Windows.Forms.TextBox textBoxFeigModel;
        private System.Windows.Forms.Label labelSupportedProtocols;
        private System.Windows.Forms.Label labelSupportedICs;
        private System.Windows.Forms.Label labelICsName3;
        private System.Windows.Forms.TextBox textBoxICsName1;
        private System.Windows.Forms.TextBox textBoxICsName2;
        private System.Windows.Forms.TextBox textBoxICsName3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label labelReaderManufacturer;
        private System.Windows.Forms.Label labelAvailableModels;
        private System.Windows.Forms.Label labelAvailableProtocols;
        private System.Windows.Forms.Label labelAvailableICs;
        private System.Windows.Forms.ComboBox comboBoxReaderManufacturer;
        private System.Windows.Forms.ComboBox comboBoxAvailableModels;
        private System.Windows.Forms.ComboBox comboBoxAvailableProtocols;
        private System.Windows.Forms.ComboBox comboBoxAvailableICs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox checkedListBoxSupportedProtocols;
        private System.Windows.Forms.CheckedListBox checkedListBoxSupportedICs;
        private System.Windows.Forms.CheckedListBox checkedListBoxICsName1;
        private System.Windows.Forms.CheckedListBox checkedListBoxICsName2;
        private System.Windows.Forms.CheckedListBox checkedListBoxICsName3;
        private System.Windows.Forms.ListBox listBoxSupportedProtocols;
        private System.Windows.Forms.ComboBox comboBox1;
        private PresentationControls.CheckBoxComboBox checkBoxComboBox1;
    }
}