using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderGui
{
    class Util
    {

        public static List<string> strToList(string protocols)
        {
            string protocols_new = protocols.Replace("\"", "");
            List<string> protocols_List = new List<string>();
            protocols_List = protocols_new.Split(',', ';').ToList();
            //string str_in_data = string.Join("\n", protocols_List.ToArray());
            //MessageBox.Show(str_in_data);
            return protocols_List;
        }

        public static List<string> strTrimToList(string str_array)
        {

            List<string> parts = str_array.Split(',').Select(p => p.Trim()).ToList();
            return parts;
        }

        public static string[] ListToStrArray(List<string> str_list)
        {
            string[] str_array = str_list.Select(i => i.ToString()).ToArray();
            return str_array;
        }

        public static string ListToStr(List<string> str_list)
        {
            string str_in_data = string.Join("\n", str_list.ToArray());
            return str_in_data;
        }
        public static string StrArrayToStr(string[] str_array)
        {
            string str_in_data = string.Join("\n", str_array);
            return str_in_data;
        }
    }

}
