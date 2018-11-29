using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataConverter
{
    public class InitFile
    {
        public static string IniPath = Path.Combine(Application.StartupPath, "config.ini");

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        //li iniFile 1
        public static int in_columns;
        public static int in_rows;
        public static string in_reader;
        public static int in_start_row;
        public static int in_start_column;
        public static List<string> in_data;
        public static List<string> in_types;
        public static List<string> in_padding;


        //iniFile 7
        public static long out_index = 0;
        public static string out_state;
        public static string out_batch_id;
        public static string out_timestamp;
        public static int out_columns = 0;
        public static int out_op = 0;

        public static string strIniFile = "";

        //output for SWTEncoding
        public static List<int>[] out_data_index;

        public InitFile(string path)
        {
            // iniFile 2

            in_data = new List<string>();
            in_types = new List<string>();
            in_padding = new List<string>();

            ProcessInput();
            ProcessOutput();
            CreateFormular();
        }

        public static string ReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, IniPath);
            return temp.ToString();
        }

        // iniFile 3
        public static void ProcessInput()
        {
            string in_data_temp = InitFile.ReadValue("Input", "Names");//in_data_temp = "url,hmac,password,pack,authen"
            in_data = in_data_temp.Split(',', ';').ToList();
            string in_types_temp = InitFile.ReadValue("Input", "Types");//in_types_temp = "combo_normal"
            in_types = in_types_temp.Split(',', ';').ToList();
            string in_padding_temp = InitFile.ReadValue("Input", "Padding");//in_padding_temp = "y,y,y,n,n"
            in_padding = in_padding_temp.Split(',', ';').ToList();
            in_columns = System.Convert.ToInt32(InitFile.ReadValue("Input", "Num_columns"));//in_columns = 5
            in_rows = System.Convert.ToInt32(InitFile.ReadValue("Input", "Num_rows"));//in_rows = -1
            in_start_row = System.Convert.ToInt32(InitFile.ReadValue("Input", "Start_row"));//in_start_row = 1
            in_start_column = System.Convert.ToInt32(InitFile.ReadValue("Input", "Start_column"));//in_start_column = 1
            in_reader = InitFile.ReadValue("Input", "Reader");//in_reader = "FEIG"

            strIniFile= ($"[Input]\n" +
                $"Reader: '{in_reader}'\n" +
                $"Start_row: '{in_start_row}'\n" +
                $"Start_column: '{in_start_column}'\n" +
                $"Num_columns: '{in_columns}'\n" +
                $"Num_rows: '{in_rows}'\n" +
                $"Names: '{in_data_temp}'\n" +
                $"Types: '{in_types_temp}'\n" +
                $"Padding: '{in_padding_temp}'");
        }


        // iniFile 4
        public static void ProcessOutput()
        {
            out_state = InitFile.ReadValue("Output", "State");//out_state = "0"
            out_batch_id = InitFile.ReadValue("Output", "BatchID");//out_batch_id = ""
            out_timestamp = InitFile.ReadValue("Output", "Timestamp");//out_timestamp = ""

            string dat = "Data";
            int num = 1;
            string da = dat + num.ToString();
            while (InitFile.ReadValue("Output", da) != "")
            {
                out_columns++;
                num++;
                da = dat + num.ToString();
            }

            out_data_index = new List<int>[out_columns];
            for (int i = 0; i < out_columns; i++)
            {
                string tmp = "Data" + System.Convert.ToString(i + 1);
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
            strIniFile += ($"\n\n[Output]\n" +
            $"State: '{out_state}'\n" +
            $"BatchID: '{out_batch_id}'\n" +
            $"Timestamp: '{out_timestamp}'\n");

        }


        // iniFile 5
        // Find index of out_data[] in in_data[] 
        public static int GetInDataIndex(string out_str)
        {
            for (int i = 0; i < in_data.Count; i++)
            {
                if (out_str == in_data[i]) return i;
            }
            return -1;
        }

        // iniFile 6
        // Find index of out_data[] in in_data[]
        public static void CreateFormular()
        {


        }


    }
}
