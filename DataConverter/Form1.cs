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
        public static ReadCsv readCsv;

        public static SWTEncoding swt;

        public static int current_line = 0;
        public static int total_line = 0;

        public BackgroundWorker bkWorker = new BackgroundWorker();
        public int percentValue = 0;

        public string str_staticURL;
        public string str_commands;

        public Form1()
        {
            InitializeComponent();
            Ini = new InitFile(InitFile.IniPath);
            readCsv = new ReadCsv();
            swt = new SWTEncoding();

            bkWorker.WorkerReportsProgress = true;
            bkWorker.WorkerSupportsCancellation = true;
            bkWorker.DoWork += new DoWorkEventHandler(DoWork);
            bkWorker.ProgressChanged += new ProgressChangedEventHandler(ProgessChanged);
            bkWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompleteWork);

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
                label8.Visible = true;
                progressBar1.Visible = true;

                percentValue = 10;
                this.progressBar1.Maximum = total_line;
                bkWorker.RunWorkerAsync();

                //readCsv.ReadFile();//FileName = 20170123_SMT_mTAG_ID_10K.csv"
                //TB_staticURL.Text = readCsv.str_staticURL;//readCsv.str_staticURL = "https://parley.mtag.io/nn6r8u"
                //TB_commands.Text = readCsv.str_commands;//readCsv.str_commands = "4600B0240A040F04(Data1)(CRC:CRC:0:-1)\r\n00000590(Data3)0000(Data4)(CRC:CRC:0:-1)"


            }
            else if (SWTEncoding.cUrlType == SWTEncoding.UrlType.StaticURL)
            {

            }

        }

        private void RandomGen_Click(object sender, EventArgs e)
        {
            //ReadConfiguration();
            //readCsv.ReadFile("SLIX2_destroy_password.csv");
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


        public void DoWork(object sender, DoWorkEventArgs e)
        {
            // event handle function
            e.Result = ProcessProgress(bkWorker, e);
        }

        public void ProgessChanged(object sender, ProgressChangedEventArgs e)
        {
            // bkWorker.ReportProgress define report format
            //this.progressBar1.Value = e.ProgressPercentage;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = total_line;
            this.progressBar1.Value = current_line; //e.ProgressPercentage;
            //int percent = (int)(e.ProgressPercentage / percentValue);
            string message = e.UserState.ToString();
            int pos = message.LastIndexOf('/');
            int len = message.Length - pos-1;
            string message_sub = message.Substring(pos+1, len);
            this.label8.Text = message_sub;// "converting...";// + Convert.ToString(percent) + "%";

            TB_staticURL.Text = str_staticURL;//readCsv.str_staticURL = "https://parley.mtag.io/nn6r8u"
            TB_commands.Text = str_commands;//readCsv.str_commands = "4600B0240A040F04(Data1)(CRC:CRC:0:-1)\r\n00000590(Data3)0000(Data4)(CRC:CRC:0:-1)"
        }

        public void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        {
            this.label8.Text = "finish!";
        }

        //private int ProcessProgress(object sender, DoWorkEventArgs e)
        //{
        //    for (int i = 0; i <= 1000; i++)
        //    {
        //        if (bkWorker.CancellationPending)
        //        {
        //            e.Cancel = true;
        //            return -1;
        //        }
        //        else
        //        {

        //            bkWorker.ReportProgress(i);

        //            System.Threading.Thread.Sleep(1);
        //        }
        //    }

        //    return -1;
        //}

        //*****************************



        //public bool ReadFile()
        public bool ProcessProgress(object sender, DoWorkEventArgs e)
        {
            //lidev
            //Cursor = Cursors.WaitCursor;


            string filename = Form1.FileName;
            string[] outputFile;
            int fileNum;
            string refFile = "";
            int row_total = 1, row_current = 1;
            int ID_count;
            if (Form1.TotalID > 0)
            {
                ID_count = Form1.TotalID;//Form1.TotalID = 1
            }
            else ID_count = File.ReadAllLines(filename).Length;

            Form1.total_line = File.ReadAllLines(filename).Length;

            fileNum = ID_count / Form1.MaxIDPerFile;//fileNum = 0
            if (ID_count % Form1.MaxIDPerFile != 0) fileNum++;//fileNum = 1

            outputFile = new string[fileNum];//outputFile = {string[1]}
            if (filename.EndsWith(".csv"))
            {


                if (ID_count >= Form1.MaxIDPerFile)
                {
                    for (int i = 0; i < fileNum; i++)
                    {
                        outputFile[i] = filename.Substring(0, filename.LastIndexOf(".csv"))
                            + "_SWT__" + (i + 1).ToString() + "-" + fileNum.ToString() + "__NotStarted.csv";
                        if (File.Exists(outputFile[i]))
                        {
                            File.Delete(outputFile[i]);
                        }
                        using (StreamWriter sw = File.CreateText(outputFile[i]))
                        {
                            sw.WriteLine(SWTEncoding.WriteHeader());
                            sw.Close();

                        }
                    }
                }
                else
                {
                    //outputFile = new string[1];
                    outputFile[0] = filename.Substring(0, filename.LastIndexOf(".csv")) + "_SWT__1-1__NotStarted.csv";//[0] = "20170123_SMT_mTAG_ID_10K_SWT__1-1__NotStarted.csv"
                    if (File.Exists(outputFile[0]))
                    {
                        File.Delete(outputFile[0]);
                    }
                }
                //only for lowcase in file ext name
                refFile = filename.Substring(0, filename.LastIndexOf(".csv")) + "_REF.csv";//refFile = "20170123_SMT_mTAG_ID_10K_REF.csv"

                //refFile = "REF.csv";
            }

            //   outputFile = "SWT_" + filename;
            /*          if (File.Exists(outputFile))
                      {
                          File.Delete(outputFile);
                      }*/
            if (File.Exists(refFile))
            {
                File.Delete(refFile);
            }
            try
            {
                //dataGridView1.Rows.Clear();
                List<string> columns = new List<string>();
                int cnt = 0;

                using (var reader = new CsvFileReader(filename))//reader = {CsvFile.CsvFileReader}
                {
                    if (InitFile.in_rows < 0) // dynamic encoding from csv
                    {
                        while (reader.ReadRow(columns))//[0] = "https://parley.mtag.io/nn6r8u"
                        {
                            //dataGridView1.Rows.Add(columns.ToArray());
                            // data converting here
                            // Create a file to write to. 
                            //using (StreamWriter sw = File.CreateText(outputFile[cnt]))
                            if (!File.Exists(outputFile[cnt]))
                            {
                                // Create a file to write to. 
                                using (StreamWriter sw = File.CreateText(outputFile[cnt]))//[0] = "20170123_SMT_mTAG_ID_10K_SWT__1-1__NotStarted.csv"
                                {
                                    sw.WriteLine(SWTEncoding.WriteHeader());//Index;State;Batch-ID;TimeStamp;Data1;Data2;Data3;Data4;Data5 to excel
                                }
                            }

                            using (StreamWriter sw = File.AppendText(outputFile[cnt]))
                            {
                                //sw.WriteLine(SWTEncoding.WriteHeader());
                                //if (row_total >= SWTEncoding.in_start_row)
                                //{


                                sw.WriteLine(SWTEncoding.Convert(columns[SWTEncoding.cColumnToParse], refFile));//column[0] = "https://parley.mtag.io/nn6r8u" refFile: = "20170123_SMT_mTAG_ID_10K_REF.csv"
                                //cmd_data = "1;0;;;0CA00301D1340334045530016C7261706D2E79652E6761746E2F6F693872366E00002F750000000000000000000000000000000035000000FE334144;78C62C66C76DA3FB24CB9A59F6F9E38D;F396B40B;30BE;0BB496F3"
                                //}
                                row_total++;
                                row_current++;

                                Form1.current_line = row_current - 1;
                                //*************
                                string message = columns[SWTEncoding.cColumnToParse];
                                bkWorker.ReportProgress(row_current,message);

                                // wait for refresh UI
                                //System.Threading.Thread.Sleep(1);
                                //******************************

                                if (row_current > Form1.MaxIDPerFile)
                                {

                                    cnt++;
                                    row_current = 1;
                                    InitFile.out_index = 0;
                                }

                                if (!SWTEncoding.cParserFirstLineParsed)
                                {
                                    if (SWTEncoding.SearchForURL(columns) >= 0)//[0] = "https://parley.mtag.io/nn6r8u"
                                    {
                                        // parse first row here
                                        //TB_staticURL.Text = columns[SWTEncoding.cColumnToParse];
                                        str_staticURL = columns[SWTEncoding.cColumnToParse];//[0] = "https://parley.mtag.io/nn6r8u"
                                        SWTEncoding.cParserFirstLineParsed = true;
                                        //TB_commands.Text = FEIG.cmd1 + "\r\n" + FEIG.cmd2;
                                        str_commands = FEIG.cmd1 + "\r\n" + FEIG.cmd2;


                                        //str_commands = "4600B0240A040F04(Data1)(CRC:CRC:0:-1)\r\n6600B0240A161704(Data2)BD010007161100F400000590(Data3)0000(Data4)(CRC:CRC:0:-1)"
                                    }
                                    else continue;
                                }

                            }

                            /*
                            else
                            {
                                File.Delete(outputFile[cnt]);
                                
                                using (StreamWriter sw = File.AppendText(outputFile[cnt]))
                                {
                                    sw.WriteLine(SWTEncoding.Convert(columns, refFile));
                                }
                                
                            }*/
                        }
                    }
                    else // static encoding => no use of HMAC, only generate commands
                    {

                        // Create a file to write to. 

                        while (row_total <= Form1.TotalID)
                        {
                            using (StreamWriter sw = File.AppendText(outputFile[cnt]))
                            {
                                sw.WriteLine(SWTEncoding.Convert("", refFile));
                                row_current++;
                                row_total++;
                                if (row_current > Form1.MaxIDPerFile)
                                {

                                    cnt++;
                                    row_current = 1;
                                    InitFile.out_index = 0;
                                }


                            }

                        }

                    }


                }
                Form1.FileName = filename;
                Form1.Modified = false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error reading from {0}.\r\n\r\n{1}", filename, ex.Message));
            }
            finally
            {
                //lidev
                //Cursor = Cursors.Default;
            }
            return false;
        }

        //****************************

    }

}
