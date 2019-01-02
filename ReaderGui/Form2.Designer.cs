﻿namespace ReaderGui
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
            this.labelAdd = new System.Windows.Forms.Label();
            this.labelModify = new System.Windows.Forms.Label();
            this.labelDelete = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxSelectModel
            // 
            this.listBoxSelectModel.FormattingEnabled = true;
            this.listBoxSelectModel.Location = new System.Drawing.Point(27, 48);
            this.listBoxSelectModel.Name = "listBoxSelectModel";
            this.listBoxSelectModel.Size = new System.Drawing.Size(120, 108);
            this.listBoxSelectModel.TabIndex = 0;
            this.listBoxSelectModel.SelectedIndexChanged += new System.EventHandler(this.listBoxSelectModel_SelectedIndexChanged);
            // 
            // textBoxSupportedProtocols
            // 
            this.textBoxSupportedProtocols.Location = new System.Drawing.Point(152, 195);
            this.textBoxSupportedProtocols.Name = "textBoxSupportedProtocols";
            this.textBoxSupportedProtocols.Size = new System.Drawing.Size(404, 20);
            this.textBoxSupportedProtocols.TabIndex = 1;
            this.textBoxSupportedProtocols.WordWrap = false;
            this.textBoxSupportedProtocols.TextChanged += new System.EventHandler(this.textBoxSupportedProtocols_TextChanged);
            // 
            // labelSelectModel
            // 
            this.labelSelectModel.AutoSize = true;
            this.labelSelectModel.Location = new System.Drawing.Point(24, 17);
            this.labelSelectModel.Name = "labelSelectModel";
            this.labelSelectModel.Size = new System.Drawing.Size(69, 13);
            this.labelSelectModel.TabIndex = 2;
            this.labelSelectModel.Text = "Select Model";
            // 
            // labelFeigModel
            // 
            this.labelFeigModel.AutoSize = true;
            this.labelFeigModel.Location = new System.Drawing.Point(27, 166);
            this.labelFeigModel.Name = "labelFeigModel";
            this.labelFeigModel.Size = new System.Drawing.Size(59, 13);
            this.labelFeigModel.TabIndex = 3;
            this.labelFeigModel.Text = "Feig Model";
            // 
            // textBoxICsCommand1
            // 
            this.textBoxICsCommand1.Location = new System.Drawing.Point(26, 297);
            this.textBoxICsCommand1.Multiline = true;
            this.textBoxICsCommand1.Name = "textBoxICsCommand1";
            this.textBoxICsCommand1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxICsCommand1.Size = new System.Drawing.Size(530, 81);
            this.textBoxICsCommand1.TabIndex = 4;
            this.textBoxICsCommand1.WordWrap = false;
            this.textBoxICsCommand1.TextChanged += new System.EventHandler(this.textBoxICsCommand1_TextChanged);
            // 
            // labelICsName1
            // 
            this.labelICsName1.AutoSize = true;
            this.labelICsName1.Location = new System.Drawing.Point(24, 270);
            this.labelICsName1.Name = "labelICsName1";
            this.labelICsName1.Size = new System.Drawing.Size(56, 13);
            this.labelICsName1.TabIndex = 5;
            this.labelICsName1.Text = "ICsName1";
            // 
            // textBoxICsCommand2
            // 
            this.textBoxICsCommand2.Location = new System.Drawing.Point(25, 426);
            this.textBoxICsCommand2.Multiline = true;
            this.textBoxICsCommand2.Name = "textBoxICsCommand2";
            this.textBoxICsCommand2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxICsCommand2.Size = new System.Drawing.Size(530, 81);
            this.textBoxICsCommand2.TabIndex = 6;
            this.textBoxICsCommand2.WordWrap = false;
            this.textBoxICsCommand2.TextChanged += new System.EventHandler(this.textBoxICsCommand2_TextChanged);
            // 
            // labelICsName2
            // 
            this.labelICsName2.AutoSize = true;
            this.labelICsName2.Location = new System.Drawing.Point(23, 400);
            this.labelICsName2.Name = "labelICsName2";
            this.labelICsName2.Size = new System.Drawing.Size(56, 13);
            this.labelICsName2.TabIndex = 7;
            this.labelICsName2.Text = "ICsName2";
            // 
            // buttonModify
            // 
            this.buttonModify.Location = new System.Drawing.Point(163, 75);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(75, 23);
            this.buttonModify.TabIndex = 8;
            this.buttonModify.Text = "Modify";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(163, 48);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(163, 104);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxSupportedICs
            // 
            this.textBoxSupportedICs.Location = new System.Drawing.Point(152, 225);
            this.textBoxSupportedICs.Name = "textBoxSupportedICs";
            this.textBoxSupportedICs.Size = new System.Drawing.Size(403, 20);
            this.textBoxSupportedICs.TabIndex = 11;
            this.textBoxSupportedICs.WordWrap = false;
            this.textBoxSupportedICs.TextChanged += new System.EventHandler(this.textBoxSupportedICs_TextChanged);
            // 
            // textBoxICsCommand3
            // 
            this.textBoxICsCommand3.Location = new System.Drawing.Point(26, 556);
            this.textBoxICsCommand3.Multiline = true;
            this.textBoxICsCommand3.Name = "textBoxICsCommand3";
            this.textBoxICsCommand3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxICsCommand3.Size = new System.Drawing.Size(530, 81);
            this.textBoxICsCommand3.TabIndex = 12;
            this.textBoxICsCommand3.WordWrap = false;
            this.textBoxICsCommand3.TextChanged += new System.EventHandler(this.textBoxICsCommand3_TextChanged);
            // 
            // textBoxFeigModel
            // 
            this.textBoxFeigModel.Location = new System.Drawing.Point(152, 164);
            this.textBoxFeigModel.Name = "textBoxFeigModel";
            this.textBoxFeigModel.Size = new System.Drawing.Size(95, 20);
            this.textBoxFeigModel.TabIndex = 13;
            this.textBoxFeigModel.WordWrap = false;
            this.textBoxFeigModel.TextChanged += new System.EventHandler(this.textBoxFeigModel_TextChanged);
            this.textBoxFeigModel.Validated += new System.EventHandler(this.textBoxFeigModel_Validated);
            // 
            // labelSupportedProtocols
            // 
            this.labelSupportedProtocols.AutoSize = true;
            this.labelSupportedProtocols.Location = new System.Drawing.Point(27, 196);
            this.labelSupportedProtocols.Name = "labelSupportedProtocols";
            this.labelSupportedProtocols.Size = new System.Drawing.Size(103, 13);
            this.labelSupportedProtocols.TabIndex = 14;
            this.labelSupportedProtocols.Text = "Supported Protocols";
            // 
            // labelSupportedICs
            // 
            this.labelSupportedICs.AutoSize = true;
            this.labelSupportedICs.Location = new System.Drawing.Point(27, 226);
            this.labelSupportedICs.Name = "labelSupportedICs";
            this.labelSupportedICs.Size = new System.Drawing.Size(74, 13);
            this.labelSupportedICs.TabIndex = 15;
            this.labelSupportedICs.Text = "Supported ICs";
            // 
            // labelICsName3
            // 
            this.labelICsName3.AutoSize = true;
            this.labelICsName3.Location = new System.Drawing.Point(27, 530);
            this.labelICsName3.Name = "labelICsName3";
            this.labelICsName3.Size = new System.Drawing.Size(56, 13);
            this.labelICsName3.TabIndex = 18;
            this.labelICsName3.Text = "ICsName3";
            // 
            // textBoxICsName1
            // 
            this.textBoxICsName1.Location = new System.Drawing.Point(153, 264);
            this.textBoxICsName1.Name = "textBoxICsName1";
            this.textBoxICsName1.Size = new System.Drawing.Size(213, 20);
            this.textBoxICsName1.TabIndex = 19;
            this.textBoxICsName1.WordWrap = false;
            this.textBoxICsName1.TextChanged += new System.EventHandler(this.textBoxICsName1_TextChanged);
            // 
            // textBoxICsName2
            // 
            this.textBoxICsName2.Location = new System.Drawing.Point(153, 394);
            this.textBoxICsName2.Name = "textBoxICsName2";
            this.textBoxICsName2.Size = new System.Drawing.Size(213, 20);
            this.textBoxICsName2.TabIndex = 20;
            this.textBoxICsName2.WordWrap = false;
            this.textBoxICsName2.TextChanged += new System.EventHandler(this.textBoxICsName2_TextChanged);
            // 
            // textBoxICsName3
            // 
            this.textBoxICsName3.Location = new System.Drawing.Point(153, 524);
            this.textBoxICsName3.Name = "textBoxICsName3";
            this.textBoxICsName3.Size = new System.Drawing.Size(213, 20);
            this.textBoxICsName3.TabIndex = 21;
            this.textBoxICsName3.WordWrap = false;
            this.textBoxICsName3.TextChanged += new System.EventHandler(this.textBoxICsName3_TextChanged);
            // 
            // labelAdd
            // 
            this.labelAdd.AutoSize = true;
            this.labelAdd.Location = new System.Drawing.Point(274, 52);
            this.labelAdd.Name = "labelAdd";
            this.labelAdd.Size = new System.Drawing.Size(37, 13);
            this.labelAdd.TabIndex = 22;
            this.labelAdd.Text = "Status";
            // 
            // labelModify
            // 
            this.labelModify.AutoSize = true;
            this.labelModify.Location = new System.Drawing.Point(274, 80);
            this.labelModify.Name = "labelModify";
            this.labelModify.Size = new System.Drawing.Size(37, 13);
            this.labelModify.TabIndex = 23;
            this.labelModify.Text = "Status";
            // 
            // labelDelete
            // 
            this.labelDelete.AutoSize = true;
            this.labelDelete.Location = new System.Drawing.Point(274, 114);
            this.labelDelete.Name = "labelDelete";
            this.labelDelete.Size = new System.Drawing.Size(37, 13);
            this.labelDelete.TabIndex = 24;
            this.labelDelete.Text = "Status";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 644);
            this.Controls.Add(this.labelDelete);
            this.Controls.Add(this.labelModify);
            this.Controls.Add(this.labelAdd);
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
            this.Name = "Form2";
            this.Text = "Reader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
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
        private System.Windows.Forms.Label labelAdd;
        private System.Windows.Forms.Label labelModify;
        private System.Windows.Forms.Label labelDelete;
    }
}