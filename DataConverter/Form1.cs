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
//using CsvFile;

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
        public static ReadCsv readCsv;

        public static SWTEncoding swt;

        public static int current_line = 0;
        public static int total_line = 0;

        public Form1()
        {
            InitializeComponent();
            Ini = new InitFile(InitFile.IniPath);
            readCsv = new ReadCsv();
            swt = new SWTEncoding();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //InitializeGrid();
            readCsv.ClearFile();
        }

        private void ReadConfiguration()
        {
            MaxIDPerFile = Convert.ToInt32(TB_maxIDSize.Text);//MaxIDPerFile = 10000
            if (TB_count.Text != "") TotalID = Convert.ToInt32(TB_count.Text);//TotalID = 1
            NDEF.nLockTlv = CB_LockControl_TLV.Checked;//CB_2B_suffix.Checked = true
            NDEF.ndef2BSuffix = CB_2B_suffix.Checked;//NDEF.ndef2BSuffix = true
            if (CB_Counter_mirror.Checked && CB_UID_mirror.Checked) Ntag.nMirrorConf = Ntag.MirrorConfMode.UidAndCounterMirror;//Ntag.nMirrorConf = UidAndCounterMirror
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
      
        private void BT_Convert_Click(object sender, EventArgs e)
        {
            ReadConfiguration();
            if (SWTEncoding.cUrlType == SWTEncoding.UrlType.DynamicURL)
            {
                //SWTEncoding.ParseURL();
                timer1.Enabled = true;

                current_line = 0;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;


                readCsv.ReadFile(FileName);//FileName = 20170123_SMT_mTAG_ID_10K.csv"
                TB_staticURL.Text = readCsv.str_staticURL;//readCsv.str_staticURL = "https://parley.mtag.io/nn6r8u"
                TB_commands.Text = readCsv.str_commands;//readCsv.str_commands = "4600B0240A040F04(Data1)(CRC:CRC:0:-1)\r\n00000590(Data3)0000(Data4)(CRC:CRC:0:-1)"
            }
            else if (SWTEncoding.cUrlType == SWTEncoding.UrlType.StaticURL)
            {

            }

        }

        private void RandomGen_Click(object sender, EventArgs e)
        {
            ReadConfiguration();
            readCsv.ReadFile("SLIX2_destroy_password.csv");
        }

        private void nTAG213ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NTAG Information");
            
        }

        private void iniFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(InitFile.strIniFile);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            //MessageBox.Show("hello");
            label5.Text = current_line.ToString();
            label7.Text = total_line.ToString();
        }
    }
}
