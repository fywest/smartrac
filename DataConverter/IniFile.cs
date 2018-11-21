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

        public InitFile(string path)
        {
            // iniFile 2

            in_data = new List<string>();
            in_types = new List<string>();
            in_padding = new List<string>();
            converted_in_data = new List<string>();
            ref_data = new List<string>();
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

        //li iniFile 1
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

        //iniFile 7
        public static long out_index = 0;
        public static string out_state;
        public static string out_batch_id;
        public static string out_timestamp;
        public static List<int>[] out_data_index;
        public static int out_columns = 0;

        public static int out_op = 0;

        // iniFile 3
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


        // iniFile 4
        public static void ProcessOutput()
        {
            out_state = InitFile.ReadValue("Output", "State");
            out_batch_id = InitFile.ReadValue("Output", "BatchID");
            out_timestamp = InitFile.ReadValue("Output", "Timestamp");

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
