using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReaderGui
{
    class ReadFeig
    {
        public string path; //IniPath = Path.Combine(Application.StartupPath, "HF_reader_FEIG2.ini");

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);

        //dd
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, [In, Out] char[] lpReturnedString, uint nSize, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileSection(string lpAppName, IntPtr lpReturnedString, uint nSize, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer, uint nSize, string lpFileName);



        public ReadFeig()
        {
            this.path = Path.Combine(Application.StartupPath, "HF_reader_FEIG2_noquote.ini"); ;
 

            ProcessInput();

        }

        public string ReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, path);
            return temp.ToString();
        }

        public byte[] IniReadValues(string section, string key)
        {
            byte[] temp = new byte[255];

            int i = GetPrivateProfileString(section, key, "", temp, 255, path);
            return temp;
        }


        public string[] INIGetAllSectionNames()
        {
            uint MAX_BUFFER = 32767;    //默认为32767

            string[] sections = new string[0];      //返回值

            //申请内存
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER * sizeof(char));
            uint bytesReturned = GetPrivateProfileSectionNames(pReturnedString, MAX_BUFFER, path);
            if (bytesReturned != 0)
            {
                //读取指定内存的内容
                string local = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned).ToString();

                //每个节点之间用\0分隔,末尾有一个\0
                sections = local.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }

            //释放内存
            Marshal.FreeCoTaskMem(pReturnedString);

            return sections;

        }

        public string[] INIGetAllItems(string section)
        {
            //返回值形式为 key=value,例如 Color=Red
            uint MAX_BUFFER = 32767;    //默认为32767

            string[] items = new string[0];      //返回值

            //分配内存
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER * sizeof(char));

            uint bytesReturned = GetPrivateProfileSection(section, pReturnedString, MAX_BUFFER, path);

            if (!(bytesReturned == MAX_BUFFER - 2) || (bytesReturned == 0))
            {

                string returnedString = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned);
                items = returnedString.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Marshal.FreeCoTaskMem(pReturnedString);     //释放内存

            return items;
        }


        public string[] INIGetAllItemKeys(string section)
        {
            string[] value = new string[0];
            const int SIZE = 1024 * 10;

            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }

            char[] chars = new char[SIZE];
            uint bytesReturned = GetPrivateProfileString(section, null, null, chars, SIZE, path);

            if (bytesReturned != 0)
            {
                value = new string(chars).Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }
            chars = null;

            return value;
        }
          
        
        public string[] ReadIniAllKeys(string section)
        {
            UInt32 MAX_BUFFER = 32767;

            string[] items = new string[0];

            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER * sizeof(char));

            UInt32 bytesReturned = GetPrivateProfileSection(section, pReturnedString, MAX_BUFFER, path);

            if (!(bytesReturned == MAX_BUFFER - 2) || (bytesReturned == 0))
            {
                string returnedString = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned);

                items = returnedString.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Marshal.FreeCoTaskMem(pReturnedString);

            return items;
        }
 
   

            public static void ProcessInput()
        {
            //string in_data_temp = InitFile.ReadValue("Input", "Names");//in_data_temp = "url,hmac,password,pack,authen"
            //in_data = in_data_temp.Split(',', ';').ToList();
            //string in_types_temp = InitFile.ReadValue("Input", "Types");//in_types_temp = "combo_normal"
            //in_types = in_types_temp.Split(',', ';').ToList();
            //string in_padding_temp = InitFile.ReadValue("Input", "Padding");//in_padding_temp = "y,y,y,n,n"
            //in_padding = in_padding_temp.Split(',', ';').ToList();
            //in_columns = System.Convert.ToInt32(InitFile.ReadValue("Input", "Num_columns"));//in_columns = 5
            //in_rows = System.Convert.ToInt32(InitFile.ReadValue("Input", "Num_rows"));//in_rows = -1
            //in_start_row = System.Convert.ToInt32(InitFile.ReadValue("Input", "Start_row"));//in_start_row = 1
            //in_start_column = System.Convert.ToInt32(InitFile.ReadValue("Input", "Start_column"));//in_start_column = 1
            //in_reader = InitFile.ReadValue("Input", "Reader");//in_reader = "FEIG"

            //strIniFile = ($"[Input]\n" +
            //    $"Reader: '{in_reader}'\n" +
            //    $"Start_row: '{in_start_row}'\n" +
            //    $"Start_column: '{in_start_column}'\n" +
            //    $"Num_columns: '{in_columns}'\n" +
            //    $"Num_rows: '{in_rows}'\n" +
            //    $"Names: '{in_data_temp}'\n" +
            //    $"Types: '{in_types_temp}'\n" +
            //    $"Padding: '{in_padding_temp}'");
        }
    }
}
