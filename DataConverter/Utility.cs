using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DataConverter
{
    public class Utility
    {
        public static string StringToHex(string hexstring)
        {
            var sb = new StringBuilder();
            foreach (char t in hexstring)
                sb.Append(System.Convert.ToInt32(t).ToString("X2"));
            return sb.ToString();
        }

        
        public static string GetRandomHexNumber(int digits)
        {
            Random random = new Random();
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }

        
        public static string GetRandom49BNumber(int digits)
        {
            Random random2 = new Random();
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



        public static string AddZeroPadding(int digits)
        {
            string buffer = "";

            for (int i = 0; i < digits; i++)
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
            return Utility.ByteArrayToString(output);
        }

        public static ushort LittleEndian(ushort inb)
        {
            byte[] b = new byte[2];
            b[0] = (byte)(((uint)inb >> 8) & 0xFF); ;
            b[1] = (byte)inb;
            return BitConverter.ToUInt16(b, 0);
        }

        //no reference member
        //static string GetString(byte[] bytes)
        //{
        //    char[] chars = new char[bytes.Length / sizeof(char)];
        //    System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
        //    return new string(chars);
        //}

        //static byte[] GetBytes(string str)
        //{
        //    byte[] bytes = new byte[str.Length * sizeof(char)];
        //    System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        //    return bytes;
        //}

        //static void WriteStringToFile(BinaryWriter bw, string filename, string sa)
        //{
        //    //FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
        //    //BinaryWriter bw = new BinaryWriter(fs);
        //    bw.Write(sa);
        //    //bw.Close();
        //    //fs.Close();
        //}

        //static void WriteToFile(BinaryWriter bw, string filename, byte[] ba)
        //{
        //    //FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
        //    //BinaryWriter bw = new BinaryWriter(fs);
        //    bw.Write(ba);
        //    //bw.Close();
        //    //fs.Close();
        //}

        /* NDEF configuration */
        //public static bool cLockTLV;
        //public static bool cMirrorCounter;
        //public static bool cMirrorUID;
        //public static string cNdefTemplate;

        /* Memory configuration */
        //public static bool cPasswordProtection;
        //public static int cPasswordStartAddress;
        //public static int cMemoryLockStatus;
        //public static int cMemoryLockStartPage;
        //public static int cMemoryLockStopPage;

        /* HMAC */
        //public static bool cHmacEnabled;
        //public static bool cHmacRandom;
        //public static bool cPasswordRandom;
        //public static bool cPackRandom;

        //iniFile 7

        // iniFile 3


        // iniFile 4


        // iniFile 5

        // iniFile 6



        //static void ConvertFromDecimalToHex(List<string> columns)
        //{
        //    for (int i = 0; i < columns.Count; i++)
        //    {
        //        converted_in_data.Add(System.Convert.ToInt16(columns[i]).ToString("X2"));
        //    }
        //}



        // hardcode
        //public static string PrepareCMD(List<string> columns)
        //{

        //    string str_out_index = out_index.ToString();
        //    string str_out_status = out_state.ToString();
        //    string str_out_batch_id = out_batch_id.ToString();
        //    string str_out_timestamp = out_timestamp.ToString(); 
        //    string data1 = columns[0] + columns[1] + columns[2] + columns[3] + columns[4] + columns[5] + ", ";
        //    string data2 = columns[6] + columns[7] + columns[8] + columns[9] + columns[10] + columns[11];
        //    out_index++;
        //    return str_out_index + ", " + str_out_status + ", " + str_out_batch_id + ", " + str_out_timestamp + ", " + data1 + data2;
        //}

        //public void HmacGenerator(object sender, EventArgs e)
        //{
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
        //}

        //form1

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
    }
}
