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
using System.Security.Cryptography;

namespace DataConverter
{
    public class SWTEncoding 
    {
        public static int in_columns;
        public static int in_rows;
        public static string in_reader;
        public static int in_start_row;
        public static int in_start_column;
        public static List<string> in_data;
        public static List<string> in_types;
        public static List<string> in_padding;
        public static List<string> converted_in_data;
        public static List<string> converted_out_data;
        public static List<string> ref_data;


        /* SWT */
        public static bool cSwtRecipeCreation;
        public static int cReaderModel;

        /* Application modes */
        public static int cApplicationMode; // Predefined configuration: Counter solution, Fixed URL

        /* Parser */
        public static bool cParserFirstLineParsed;
        public static int cColumnToParse;
        public static UrlType cUrlType;
        public static NDEF.NdefRecordID cRecordType;

        /* NDEF configuration */
        public static bool cLockTLV;
        public static bool cMirrorCounter;
        public static bool cMirrorUID;
        public static string cNdefTemplate;

        /* Memory configuration */
        public static bool cPasswordProtection;
        public static int cPasswordStartAddress;
        public static int cMemoryLockStatus;
        public static int cMemoryLockStartPage;
        public static int cMemoryLockStopPage;

        /* HMAC */
        public static bool cHmacEnabled;
        public static bool cHmacRandom;
        public static bool cPasswordRandom;
        public static bool cPackRandom;

        public static long out_index=0;
        public static string out_state;
        public static string out_batch_id;
        public static string out_timestamp;
        public static List<int>[] out_data_index;
        public static int out_columns = 0;

        public static int out_op = 0;

        public static bool b_uid_mirror, b_cnt_mirror, b_lock_control;

        public enum UrlType
        {
            StaticURL = 0,
            DynamicURL
           
        }

        public SWTEncoding()
        {
            cParserFirstLineParsed = false;
            in_data  = new List<string>();
            in_types = new List<string>();
            in_padding = new List<string>();
            converted_in_data = new List<string>();
            ref_data = new List<string>();
            ProcessInput();
            ProcessOutput();
            CreateFormular();
        }

        public static string StringToHex(string hexstring)
        {
            var sb = new StringBuilder();
            foreach (char t in hexstring)
                sb.Append(System.Convert.ToInt32(t).ToString("X2"));
            return sb.ToString();
        }

        public static byte[] StringToByteArray(string hex)
        {
            hex = hex.Replace(" ", "");
            hex = hex.Replace("$", "");
            if (hex.Length % 2 != 0) return null;
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => System.Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string ByteArrayToString(byte[] b)
        {
            string s = "";
            for (int i = 0; i < b.Length; i++)
                s += b[i].ToString("X2");
            return s;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static void WriteStringToFile(BinaryWriter bw, string filename, string sa)
        {
            //FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            //BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(sa);
            //bw.Close();
            //fs.Close();
        }

        static void WriteToFile(BinaryWriter bw, string filename, byte[] ba)
        {
            //FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            //BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(ba);
            //bw.Close();
            //fs.Close();
        }

        public static string WriteHeader()
        {
            string ret = "Index;State;Batch-ID;TimeStamp";
            for (int i = 0; i < out_columns; i++ )
            {
                ret += ";Data" + (i + 1).ToString() ;
            }
            out_index = 0;
            return ret;
        }

        public static void ProcessInput()
        {
            string in_data_temp = InitFile.ReadValue("Input", "Names");
            in_data = in_data_temp.Split(',', ';').ToList();
            string in_types_temp = InitFile.ReadValue("Input", "Types");
            in_types = in_types_temp.Split(',', ';').ToList();
            string in_padding_temp = InitFile.ReadValue("Input", "Padding");
            in_padding = in_padding_temp.Split(',', ';').ToList();
            in_columns = System.Convert.ToInt32(InitFile.ReadValue("Input", "Num_columns"));
            in_rows = System.Convert.ToInt32(InitFile.ReadValue("Input", "Num_rows"));
            in_start_row = System.Convert.ToInt32(InitFile.ReadValue("Input", "Start_row"));
            in_start_column = System.Convert.ToInt32(InitFile.ReadValue("Input", "Start_column"));
            in_reader = InitFile.ReadValue("Input", "Reader");
        }

        public static void ProcessOutput()
        {
            out_state = InitFile.ReadValue("Output", "State");
            out_batch_id = InitFile.ReadValue("Output", "BatchID");
            out_timestamp = InitFile.ReadValue("Output", "Timestamp");

            string dat = "Data";
            int num = 1;
            string da = dat+num.ToString();
            while(InitFile.ReadValue("Output",da) != "")
            {
                out_columns++;
                num++;
                da = dat + num.ToString();
            }

            out_data_index = new List<int>[out_columns];
            for (int i = 0; i < out_columns; i++)
            {
                string tmp = "Data" + System.Convert.ToString(i+1);
                string tmp2 = InitFile.ReadValue("Output", tmp);
                out_data_index[i] = new List<int>();
                //if (tmp2.IndexOf('+') > 0)
                {
                    out_op = 1;
                    string[] tmp3 = tmp2.Split('+');
                    for (int j = 0; j < tmp3.Length; j++)
                    {
                        out_data_index[i].Add(GetInDataIndex(tmp3[j]));
                    }
                }
                /*else
                {
                    out_data_index[i].Add(GetInDataIndex(tmp2[j]));
                }*/
            }
                
        }

        // Find index of out_data[] in in_data[] 
        public static int GetInDataIndex(string out_str)
        {
            for (int i = 0; i < in_data.Count; i++)
            {
                if (out_str == in_data[i]) return i;
            }
            return -1;
        }

        // Find index of out_data[] in in_data[]
        public static void CreateFormular()
        {


        }
        
        static void ConvertFromDecimalToHex(List<string> columns)
        {
            for (int i = 0; i < columns.Count; i++)
            {
                converted_in_data.Add(System.Convert.ToInt16(columns[i]).ToString("X2"));
            }
        }

        public static string PrepareHexData(string hex, bool padding)
        {
            string little_endian = null;
            int cnt = hex.Length;

            int len_idx = hex.Length;
            for (int i = 0; i < Math.Ceiling((double)hex.Length/8); i++)
            {
                for (int j = 3; j >= 0; j-- )
                {
                    int ind = 2*j+8*i;
                    if (ind+2<=hex.Length)
                    { 
                        little_endian += hex.Substring(ind, 2);
                    }
                    else if (padding) little_endian += "00";
                   
                }
            }
            return little_endian;
        }

        static Random random = new Random();
        public static string GetRandomHexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }

        static Random random2 = new Random();
        public static string GetRandom49BNumber(int digits)
        {
            string[] base49 = { "b", "s", "J", "Y", "c", "t", "K", "Z", "d", "v", "L", "2",
            "f", "w", "M", "3", "g", "x", "N", "4", "h", "y", "P", "5", "j", "z", "Q", "6", "k", "B", "R",
            "7", "m", "C", "S", "8", "n", "D", "T", "9", "p", "F", "V", "q", "G", "W", "r", "H", "X" };

            string ou = "";
            for (int j = 0; j < digits; j++)
            {
                ou += base49[random2.Next(0, 48)];
            }

            return ou;
        }

        public static string AddZeroPadding(int digits)
        {
            string buffer ="";

            for (int i=0; i< digits; i++)
            {
                buffer += "0";
            }
            return buffer;
        }

        public static ushort ComputeCRC16(byte[] DATA)
        {
            ushort crc = 0xFFFF;
            for (int i = 0; i < DATA.Length; i++) // cnt = number of protocol bytes without CRC
            {
                crc ^= DATA[i];
                for (int j = 0; j < 8; j++)
                {
                    if (System.Convert.ToBoolean(crc & 0x0001))
                        crc = (ushort)((crc >> 1) ^ 0x8408);
                    //crc = (ushort)((crc >> 1) ^ 0x1021);
                    else
                        crc = (ushort)(crc >> 1);
                }
            }
            return crc;
        }

        public static string ComputeMD5(byte[] DATA)
        {
            byte[] output;

            using (MD5 md5Hash = MD5.Create())
            {
                output = md5Hash.ComputeHash(DATA);
            }
            return ByteArrayToString(output);
        }

        public static ushort LittleEndian(ushort inb)
        {
            byte[] b = new byte[2];
            b[0] = (byte)(((uint)inb >> 8) & 0xFF); ;
            b[1] = (byte)inb;
            return BitConverter.ToUInt16(b, 0);
        }

        public static int SearchForURL(List<string> columns)
        {
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].Contains("http") || columns[i].Contains("www"))
                {
                    cColumnToParse = i;
                    return i;
                }
            }
            return -1;
        }

        public static string GetRecordType(string column)
        {
            string ret="";

            if (column.Contains("http://www"))
            {
                cRecordType = NDEF.NdefRecordID.http_www;
                ret = column.Substring("http://www.".Length);
            }
            else if (column.Contains("https://www"))
            {
                cRecordType = NDEF.NdefRecordID.https_www;
                ret = column.Substring("https://www.".Length);
            }
            else if (column.Contains("http://"))
            {
                cRecordType = NDEF.NdefRecordID.http;
                ret = column.Substring("http://".Length);
            }
            else if (column.Contains("https://"))
            {
                cRecordType = NDEF.NdefRecordID.https;
                ret = column.Substring("https://".Length);
            }
            else cRecordType = NDEF.NdefRecordID.Entire_URL;
            NDEF.ndefRecordId = cRecordType;
            return ret;
            
        }

        public static string Convert(string column, string refFile)
        {
            string temp, ndef_h = "";
            string hmac, pass, crc_s;
            string sic = "";
            ushort crc;
            bool generate_ref = false;
           // string refFile = "";
            // Verify required argument
            if (column == null)
                throw new ArgumentNullException("columns");
            //refFile = "REF.csv";

            hmac = GetRandomHexNumber(32);
            pass = GetRandomHexNumber(8);
            column = GetRecordType(column);

            for (int i = 0; i < in_columns; i++)
            {
                if (in_types[i] == "d")
                {
                    temp = System.Convert.ToInt32(column).ToString("X2");
                    converted_in_data.Add(temp);
                }
                else if (in_types[i] == "s")
                {
                    temp = "0336D101325504" + StringToHex(column) + StringToHex("?m=");
                    converted_in_data.Add(temp);
                }
                else if (in_types[i] == "h")
                {
                    converted_in_data.Add(column);
                }
                else if (in_types[i] == "b49")
                {
                    converted_in_data.Add("abC" + GetRandom49BNumber(9));
                }
                else if (in_types[i] == "url")
                {
                    //temp = "0334D101305503" + StringToHex(columns[i].Substring(columns.IndexOf("//"))) + "FE";
                    temp = "031ED1011A5504" + StringToHex(column) + "FE";
                    converted_in_data.Add(temp);

                    converted_in_data.Add(hmac);
                    // h, password
                    converted_in_data.Add(pass);
                    string cmd1 = FEIG.SendWriteMultiplePagesNdefCommand(4, 4, column);
                    string cmd2 = FEIG.SendWriteMultiplePagesHmacCommand();
                    // crc16, pack
                    crc = ComputeCRC16(StringToByteArray(hmac));
                    crc_s = crc.ToString("X4");
                    temp = LittleEndian(crc).ToString("X4");
                    converted_in_data.Add(temp);
                    // h, authen
                    converted_in_data.Add(pass);

                    ref_data.Add(column);
                    ref_data.Add(hmac);
                    ref_data.Add(pass);
                    ref_data.Add(crc_s);
                }
                else if (in_types[i] == "url_fix2")
                {
                    temp = StringToHex(column.Substring(column.IndexOf("//"))) + StringToHex("/") + StringToHex(GetRandomHexNumber(4)) + "FE";
                    converted_in_data.Add(temp);
                }
                else if (in_types[i] == "url_uid_counter")
                {
                    temp = StringToHex(column) + StringToHex("/") + AddZeroPadding(42) + "FE";
                    converted_in_data.Add(temp);
                }
                else if (in_types[i] == "url_uid_counter_fix2")
                {
                    temp = "0334D101305504" + StringToHex(column) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    converted_in_data.Add(temp);
                }
                else if (in_types[i] == "crc16")
                {
                    temp = LittleEndian(ComputeCRC16(StringToByteArray(column))).ToString("X4");
                    converted_in_data.Add(temp);
                }
                else if (in_types[i] == "md5")
                {
                    temp = ComputeMD5(StringToByteArray(StringToHex(column)));
                    converted_in_data.Add(temp);
                }
                else if (in_types[i] == "standard")
                {
                    // url_uid_counter_fix2,h,h,crc16,h
                    // url
                    //temp = "0334D101305504" + StringToHex(columns[i]) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    generate_ref = true;
                    // for https://adidas.mtag.io/njw0jy
                    //temp = "0103A00C340334D101305504" + StringToHex(columns[i]) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    // for https://mtag.io/njw0jy
                    string ndef = "";

                    //ndef += PrepareNdefHeader(columns[i]);
                    //temp = "0103A00C34032DD101295504" + StringToHex(columns[i]) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    ndef_h = PrepareNdefHeader(column);
                    temp = ndef_h + StringToHex(column);

                    converted_in_data.Add(temp);
                    if (!SWTEncoding.cParserFirstLineParsed)
                    {
                        FEIG.cmd1 = FEIG.SendWriteMultiplePagesNdefCommand(4, 4, column);
                        FEIG.cmd2 = FEIG.SendWriteMultiplePagesHmacCommand();

                    }

                    break;
                }
                // counter solution with 2B random suffix
                else if (in_types[i] == "counter_solution")
                {
                    // url_uid_counter_fix2,h,h,crc16,h
                    // url
                    //temp = "0334D101305504" + StringToHex(columns[i]) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    generate_ref = true;
                    // for https://adidas.mtag.io/njw0jy
                    //temp = "0103A00C340334D101305504" + StringToHex(columns[i]) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    // for https://mtag.io/njw0jy
                    string ndef = "";

                    //ndef += PrepareNdefHeader(columns[i]);
                    //temp = "0103A00C34032DD101295504" + StringToHex(columns[i]) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    ndef_h = PrepareNdefHeader(column);
                    temp = ndef_h + StringToHex(column) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    
                    converted_in_data.Add(temp);
                    // h, hmac
                    converted_in_data.Add(hmac);
                    // h, password
                    converted_in_data.Add(pass);
                    if (!SWTEncoding.cParserFirstLineParsed)
                    {
                        FEIG.cmd1 = FEIG.SendWriteMultiplePagesNdefCommand(4, 4, column);
                        FEIG.cmd2 = FEIG.SendWriteMultiplePagesHmacCommand();
                        
                    }
                        
                    // crc16, pack
                    crc = ComputeCRC16(StringToByteArray(hmac));
                    crc_s = crc.ToString("X4");
                    temp = LittleEndian(crc).ToString("X4");
                    converted_in_data.Add(temp);
                    // h, authen
                    converted_in_data.Add(pass);

                    ref_data.Add(column);
                    ref_data.Add(hmac);
                    ref_data.Add(pass);
                    ref_data.Add(crc_s);
                     break;
                }
                else if (in_types[i] == "combo_normal")
                {
                    generate_ref = true;
                    // url_uid_counter_fix2,h,h,crc16,h
                    // url
                    //temp = "0334D101305504" + StringToHex(columns[i]) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    /////temp = "0103A00C340314D101105504" + StringToHex(column) + "FE";
                    //temp = "032CD101285504" + StringToHex(columns[i]) + "FE";
                    ndef_h = PrepareNdefHeader(column);
                    temp = ndef_h + StringToHex(column) + "FE";

                    converted_in_data.Add(temp);
                    // h, hmac
                    converted_in_data.Add(hmac);
                    // h, password
                    converted_in_data.Add(pass);

                    if (!SWTEncoding.cParserFirstLineParsed)
                    {
                        FEIG.cmd1 = FEIG.SendWriteMultiplePagesNdefCommand(4, 4, column);
                     
                    }
                    // crc16, pack
                    crc = ComputeCRC16(StringToByteArray(hmac));
                    crc_s = crc.ToString("X4");
                    temp = LittleEndian(crc).ToString("X4");
                    converted_in_data.Add(temp);
                    // h, authen
                    converted_in_data.Add(pass);

                    ref_data.Add(column);
                    ref_data.Add(hmac);
                    ref_data.Add(pass);
                    ref_data.Add(crc_s);
                    break;
                }
                else if (in_types[i] == "sic")
                {
                    sic = GetRandomHexNumber(8);
                    //generate_ref = true;
                    converted_in_data.Add(sic);
                    
                    ref_data.Add(sic);
                    break;
                }
            }
            if (generate_ref == true)
            {
                string out_ref;
                out_ref = ref_data[0] + "," + ref_data[1] + "," + ref_data[2] + "," + ref_data[3];

                if (!File.Exists(refFile))
                {
                    // Create a file to write to. 
                    using (StreamWriter sw = File.CreateText(refFile))
                    {
                        sw.WriteLine(out_ref);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(refFile))
                    {
                        sw.WriteLine(out_ref);
                    }

                }
                ref_data.Clear();

                

            }
            //ConvertFromDecimalToHex(columns);
            return ProcessCMD(converted_in_data);
        }

        private static string b2s(byte inb)
        {
            string tmp = inb.ToString("X2");
            return tmp;
        }

        private static string PrepareNdefHeader(string url)
        {
            string ndef = "";
            string h = "";
            if (NDEF.nLockTlv) ndef += NDEF.sLockTlv;
            NDEF.GetNdefRealLength(url);
                h = b2s(NDEF.ndefType) + b2s(NDEF.ndefSize) + b2s(NDEF.ndefOption) + b2s(NDEF.ndefTypeLen)
                 + b2s(NDEF.ndefPayloadLen) + b2s(NDEF.ndefRecordType) + b2s((byte)NDEF.ndefRecordId);
            ndef = ndef + h;
            return ndef;
    }

        public static string ProcessCMD(List<string> columns)
        {
            int i, j;
            string tmp = "";
            string cmd_data = "";
            //string str_out_index = out_index.ToString();
            string str_out_status = out_state.ToString();
            string str_out_batch_id = out_batch_id.ToString();
            string str_out_timestamp = out_timestamp.ToString();
            cmd_data = (++out_index).ToString() + ";" + out_state.ToString() + ";" + out_batch_id.ToString() + ";" + out_timestamp.ToString() + ";";
            for (i = 0; i < out_columns; i++)
            {
                for (j = 0; j < out_data_index[i].Count; j++)
                {
                    tmp += columns[out_data_index[i][j]];
                }
                if (in_padding[i] == "y") tmp = PrepareHexData(tmp, true);
                //converted_out_data.Add(tmp);
                cmd_data += tmp;
                if (i < out_columns - 1) cmd_data += ";";
                tmp = "";

            }
            /*
            if (!FEIG.hConverted)
            {
                FEIG.SendWriteMultiplePagesCommand(4, 4, converted_out_data[0]);
                FEIG.hConverted = true;
            }*/
            converted_in_data.Clear();
            return cmd_data;
        }
        // hardcode
        public static string PrepareCMD(List<string> columns)
        {
            
            string str_out_index = out_index.ToString();
            string str_out_status = out_state.ToString();
            string str_out_batch_id = out_batch_id.ToString();
            string str_out_timestamp = out_timestamp.ToString(); 
            string data1 = columns[0] + columns[1] + columns[2] + columns[3] + columns[4] + columns[5] + ", ";
            string data2 = columns[6] + columns[7] + columns[8] + columns[9] + columns[10] + columns[11];
            out_index++;
            return str_out_index + ", " + str_out_status + ", " + str_out_batch_id + ", " + str_out_timestamp + ", " + data1 + data2;
        }

        public void HmacGenerator(object sender, EventArgs e)
        {
            /*
            string hmac, pass, crc, all = "";
            int num = System.Convert.ToInt32(textBox4.Text);

            label5.Text = "Generating..";
            label5.ForeColor = Color.AliceBlue;
            for (int i = 0; i < num; i++)
            {
                hmac = GetRandomHexNumber(144);
                pass = GetRandomHexNumber(8);
                crc = LittleEndian(ComputeCRC16(StringToByteArray(hmac))).ToString("X4");
                if (checkBox1.Checked)
                {
                    textBox1.Text += hmac + System.Environment.NewLine;
                    textBox2.Text += pass + System.Environment.NewLine;
                    textBox3.Text += crc + System.Environment.NewLine;
                }

                all += hmac + "," + pass + "," + crc + System.Environment.NewLine;
            }

            SaveFile(all);
            label5.Text = "Done!";
            label5.ForeColor = Color.Green;*/
        }
    }

    public class InitFile
    {
        public static string IniPath = Path.Combine(Application.StartupPath, "config.ini");

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public InitFile(string path)
        {

        }

        public static string ReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, IniPath);
            return temp.ToString();
        }



    }

}