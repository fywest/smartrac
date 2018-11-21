using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvFile;

namespace DataConverter
{
    public class ReadCsv
    {

        public string str_staticURL;
        public string str_commands;

        public void ClearFile()
        {
            //dataGridView1.Rows.Clear();
            Form1.FileName = null;
            Form1.Modified = false;
        }

        public bool ReadFile(string filename)
        {
            //lidev
            //Cursor = Cursors.WaitCursor;
            string[] outputFile;
            int fileNum;
            string refFile = "";
            int row_total = 1, row_current = 1;
            int ID_count;
            if (Form1.TotalID > 0)
            {
                ID_count = Form1.TotalID;
            }
            else ID_count = File.ReadAllLines(filename).Length;

            fileNum = ID_count / Form1.MaxIDPerFile;
            if (ID_count % Form1.MaxIDPerFile != 0) fileNum++;

            outputFile = new string[fileNum];
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
                    outputFile[0] = filename.Substring(0, filename.LastIndexOf(".csv")) + "_SWT__1-1__NotStarted.csv";
                    if (File.Exists(outputFile[0]))
                    {
                        File.Delete(outputFile[0]);
                    }
                }
                //only for lowcase in file ext name
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
                                    sw.WriteLine(SWTEncoding.WriteHeader());
                                }
                            }

                            using (StreamWriter sw = File.AppendText(outputFile[cnt]))
                            {
                                //sw.WriteLine(SWTEncoding.WriteHeader());
                                //if (row_total >= SWTEncoding.in_start_row)
                                //{


                                sw.WriteLine(SWTEncoding.Convert(columns[SWTEncoding.cColumnToParse], refFile));//refFile: = "20170123_SMT_mTAG_ID_10K_REF.csv"
                                //}
                                row_total++;
                                row_current++;
                                if (row_current > Form1.MaxIDPerFile)
                                {

                                    cnt++;
                                    row_current = 1;
                                    InitFile.out_index = 0;
                                }

                                if (!SWTEncoding.cParserFirstLineParsed)
                                {
                                    if (SWTEncoding.SearchForURL(columns) >= 0)
                                    {
                                        // parse first row here
                                        //TB_staticURL.Text = columns[SWTEncoding.cColumnToParse];
                                        str_staticURL = columns[SWTEncoding.cColumnToParse];//[0] = "https://parley.mtag.io/nn6r8u"
                                        SWTEncoding.cParserFirstLineParsed = true;
                                        //TB_commands.Text = FEIG.cmd1 + "\r\n" + FEIG.cmd2;
                                        str_commands = FEIG.cmd1 + "\r\n" + FEIG.cmd2;//str_commands = "4600B0240A040F04(Data1)(CRC:CRC:0:-1)\r\n6600B0240A161704(Data2)BD010007161100F400000590(Data3)0000(Data4)(CRC:CRC:0:-1)"
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
    }
}
