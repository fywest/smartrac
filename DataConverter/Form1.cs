//////////////////////////////////////////////////////////////////////////////
// This source code and all associated files and resources are copyrighted by
// the author(s). This source code and all associated files and resources may
// be used as long as they are used according to the terms and conditions set
// forth in The Code Project Open License (CPOL).
//
// Copyright (c) 2012 Jonathan Wood
// http://www.blackbeltcoder.com
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CsvFile;

namespace DataConverter
{
    public partial class Form1 : Form
    {
        public const int MaxColumns = 64;
        public static int MaxIDPerFile;
        public static int TotalID;

        public static string FileName;
        public static bool Modified;

        public static InitFile Ini;
        public static SWTEncoding swt;

        public static ReadCsv csvFile;
        

        public Form1()
        {
            InitializeComponent();
            Ini = new InitFile(InitFile.IniPath);
            csvFile = new ReadCsv();
            swt = new SWTEncoding();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //InitializeGrid();
            csvFile.ClearFile();
        }

        private void ReadConfiguration()
        {
            MaxIDPerFile = Convert.ToInt32(TB_maxIDSize.Text);
            if(TB_count.Text != "") TotalID = Convert.ToInt32(TB_count.Text);
            NDEF.nLockTlv = CB_LockControl_TLV.Checked;
            NDEF.ndef2BSuffix = CB_2B_suffix.Checked;
            if (CB_Counter_mirror.Checked && CB_UID_mirror.Checked) Ntag.nMirrorConf = Ntag.MirrorConfMode.UidAndCounterMirror;
            else if (CB_Counter_mirror.Checked && !CB_UID_mirror.Checked) Ntag.nMirrorConf = Ntag.MirrorConfMode.CounterMirror;
            else if (!CB_Counter_mirror.Checked && CB_UID_mirror.Checked) Ntag.nMirrorConf = Ntag.MirrorConfMode.UidMirror;
            else Ntag.nMirrorConf = Ntag.MirrorConfMode.NoMirror;

            //SWTEncoding.cReaderModel =
            //SWTEncoding.cSwtRecipeCreation = true;
            //SWTEncoding.cUrlType = 
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
           {
                SWTEncoding.cUrlType = SWTEncoding.UrlType.DynamicURL;
                
                FileName = openFileDialog1.FileName;
                TB_filename.Text = FileName;
                //ReadFile(openFileDialog1.FileName);
           }
        }


        /// <summary>
        /// //////////////////////////////////////////////
        /// </summary>




        //private bool ReadIniFile(string filename)
        //{
        //    try
        //    {
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(String.Format("Error reading from {0}.\r\n\r\n{1}", filename, ex.Message));
        //    }
        //    finally
        //    {
        //        Cursor = Cursors.Default;
        //    }
        //    return false;
        //}

       

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BT_Convert_Click(object sender, EventArgs e)
        {
            ReadConfiguration();
            if (SWTEncoding.cUrlType == SWTEncoding.UrlType.DynamicURL)
            {
                //SWTEncoding.ParseURL();
                
                csvFile.ReadFile(FileName);
                TB_staticURL.Text = csvFile.str_staticURL;
                TB_commands.Text = csvFile.str_commands;
            }
            else if (SWTEncoding.cUrlType == SWTEncoding.UrlType.StaticURL)
            {

            }

        }

        private void RandomGen_Click(object sender, EventArgs e)
        {
            ReadConfiguration();
            csvFile.ReadFile("SLIX2_destroy_password.csv");
        }
    }
}
