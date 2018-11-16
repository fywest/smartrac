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
        private const int MaxColumns = 64;
        private int MaxIDPerFile;
        private int TotalID;
        protected string FileName;
        protected bool Modified;
        public static InitFile Ini;
        public static SWTEncoding swt;
        

        public Form1()
        {
            InitializeComponent();
            Ini = new InitFile(InitFile.IniPath);
            swt = new SWTEncoding();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //InitializeGrid();
            ClearFile();
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


        private void ClearFile()
        {
            //dataGridView1.Rows.Clear();
            FileName = null;
            Modified = false;
        }

        private bool ReadIniFile(string filename)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error reading from {0}.\r\n\r\n{1}", filename, ex.Message));
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return false;
        }

        private bool ReadFile(string filename)
        {
            Cursor = Cursors.WaitCursor;
            string[] outputFile;
            int fileNum;
            string refFile = "";
            int row_total = 1, row_current = 1;
            int ID_count;
            if (TotalID > 0)
            {
                ID_count = TotalID; 
            }
            else ID_count = File.ReadAllLines(filename).Length;

            fileNum = ID_count / MaxIDPerFile;
            if (ID_count % MaxIDPerFile != 0) fileNum++;

            outputFile = new string[fileNum];
            if (filename.EndsWith(".csv"))
            {
                

                if (ID_count >= MaxIDPerFile)
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
                else {
                    //outputFile = new string[1];
                    outputFile[0] = filename.Substring(0, filename.LastIndexOf(".csv")) + "_SWT__1-1__NotStarted.csv";
                    if (File.Exists(outputFile[0]))
                    {
                        File.Delete(outputFile[0]);
                    }
                }
                refFile = filename.Substring(0, filename.LastIndexOf(".csv")) + "_REF.csv";

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
                
                using (var reader = new CsvFileReader(filename))
                {
                    if(SWTEncoding.in_rows < 0) // dynamic encoding from csv
                    {
                        while (reader.ReadRow(columns))
                        {
                            //dataGridView1.Rows.Add(columns.ToArray());
                            // data converting here
                            // Create a file to write to. 
                            //using (StreamWriter sw = File.CreateText(outputFile[cnt]))
                            if (!File.Exists(outputFile[cnt]))
                            {
                                // Create a file to write to. 
                                using (StreamWriter sw = File.CreateText(outputFile[cnt]))
                                {
                                    sw.WriteLine(SWTEncoding.WriteHeader());
                                }
                            }
                            
                            using (StreamWriter sw = File.AppendText(outputFile[cnt]))
                            {
                                //sw.WriteLine(SWTEncoding.WriteHeader());
                                //if (row_total >= SWTEncoding.in_start_row)
                                //{

                                    
                                    sw.WriteLine(SWTEncoding.Convert(columns[SWTEncoding.cColumnToParse], refFile));
                                    //}
                                    row_total++;
                                    row_current++;
                                    if (row_current > MaxIDPerFile)
                                    {

                                        cnt++;
                                        row_current = 1;
                                        SWTEncoding.out_index = 0;
                                    }

                                if (!SWTEncoding.cParserFirstLineParsed)
                                {
                                    if (SWTEncoding.SearchForURL(columns) >= 0)
                                    {
                                        // parse first row here
                                        TB_staticURL.Text = columns[SWTEncoding.cColumnToParse];
                                        SWTEncoding.cParserFirstLineParsed = true;
                                        TB_commands.Text = FEIG.cmd1 + "\r\n" + FEIG.cmd2;
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
                            
                                while (row_total <= TotalID)
                                {
                            using (StreamWriter sw = File.AppendText(outputFile[cnt]))
                            {
                                sw.WriteLine(SWTEncoding.Convert("", refFile));
                                row_current++;
                                row_total++;
                                if (row_current > MaxIDPerFile)
                                    {

                                        cnt++;
                                        row_current = 1;
                                        SWTEncoding.out_index = 0;
                                    }
                                

                            }

                        }
                        
                    }
                    
                    
                }
                FileName = filename;
                Modified = false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error reading from {0}.\r\n\r\n{1}", filename, ex.Message));
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return false;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BT_Convert_Click(object sender, EventArgs e)
        {
            ReadConfiguration();
            if (SWTEncoding.cUrlType == SWTEncoding.UrlType.DynamicURL)
            {
                //SWTEncoding.ParseURL();
                ReadFile(FileName);
            }
            else if (SWTEncoding.cUrlType == SWTEncoding.UrlType.StaticURL)
            {

            }

        }

        private void RandomGen_Click(object sender, EventArgs e)
        {
            ReadConfiguration();
            ReadFile("SLIX2_destroy_password.csv");
        }
    }
}
