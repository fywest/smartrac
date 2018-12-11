using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderGui
{
    
    class ReadFeig
    {
        public List<Feig> feigList;
        public Ini ini;
        public List<string> ICsNameList;

        public ReadFeig(string inipath)
        {
            ini = new Ini(inipath);
            ICsNameList = new List<string>();
            feigList = getAllFeig();
            
        }

        public Feig addFeig(string section, string keyProtocols, string keyICs, string keyCommand)
        {
            Feig feig = new Feig(section,keyProtocols,keyICs,keyCommand);
            return feig;
        }

        public List<Feig> getAllFeig()
        {
            List<Feig> feigList_temp = new List<Feig>();

            string[] allSectionNames = ini.INIGetAllSectionNames();
            foreach(var section in allSectionNames)
            {
                if(section.Contains("CPR"))
                {
                    string[] itemKeys = ini.INIGetAllItemKeys(section);
                    string protocols="", ICs="", commands="";
                    foreach (var key in itemKeys)
                    {
                        string value = ini.INIGetStringValue(section, key, null);
                        if(key.Contains("Protocols"))
                        { protocols = value; }
                        else if (key.Contains("ICs"))
                        {
                            ICs = value;
                            string[] strList = ICs.Split(',');
                            foreach(var item in strList)
                            {
                                string strTemp= item.Trim();

                                if(!ICsNameList.Contains(strTemp))
                                {
                                    ICsNameList.Add(strTemp);
                                }
                            }
                        }
                        else if (key.Contains("Commands"))
                        { commands = value; }

                    }
                    Feig temp = new Feig(section,protocols, ICs, commands);

                    feigList_temp.Add(temp);
                }

            }

            //addFeig to List
            return feigList_temp;
        }

        public string[] getICsList()
        {
            string[] str_array = ICsNameList.Select(i => i.ToString()).ToArray();
            return str_array;
        }
    }
}
