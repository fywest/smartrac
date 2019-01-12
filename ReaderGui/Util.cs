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
        //public static string str_feigJsonList;

        public static List<string> strToList(string protocols)
        {
            string protocols_new = protocols.Replace("\"", "");
            List<string> protocols_List = new List<string>();
            protocols_List = protocols_new.Split(',', ';').ToList();

            return protocols_List;
        }

        public static List<string> strTrimToList(string str)
        {

            List<string> parts = str.Split(',').Select(p => p.Trim()).ToList();
            return parts;
        }
        public static List<string> strTrimToList(string str,char separate)
        {

            List<string> parts = str.Split(separate).Select(p => p.Trim()).ToList();
            return parts;
        }

        public static string[] ListToStrArray(List<string> str_list)
        {
            string[] str_array = str_list.Select(i => i.ToString()).ToArray();
            return str_array;
        }

        public static string[] strTrimToArray(string str,char separate)
        {
            string[] array = str.Split(separate).Select(p => p.Trim()).ToArray();
            return array;
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
        public static string StrArrayToStr(string[] str_array, string separator)
        {
            string str_in_data = string.Join(separator, str_array);
            return str_in_data;
        }
        public static string ListToStr(List<string> str_list,string separator)
        {
            string str_in_data = string.Join(separator, str_list.ToArray());
            return str_in_data;
        }
        public static List<string> strArrayToList(string[] strArray)
        {
            List<string> list = new List<string>(strArray);
            return list;
        }

        public static string[] strArrToStrArr(string[] strArr, string str)
        {
            List<string> list = new List<string>(strArr);
            list.Add(str);
            return list.ToArray();
        }
        public static string str_NewFeig { get; set; } = @"{
              'ReaderManufacturer': 'FEIG',
              'AvailableModels': [
                'Model'
              ],
              'AvailableProtocols': [
                'Protocol'
              ],
             'AvailableICs': [
                'IC'
              ],
              'ReaderConfig': [
                {
                  'Model': 'Model',
                  'SupportedProtocols': [
                    'Protocols'
                  ],
                  'SupportedICs': [
                    'ICs'
                  ],
                  'SetupCommands': [
                    {
                      'icName': [
                        'ICs'
                      ],
                      'icCommand': [
                        'ICsCommand'
                      ]
                    }
                  ]
                }
              ]
            }";
    }

}
