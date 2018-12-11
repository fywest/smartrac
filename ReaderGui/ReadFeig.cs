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

        public ReadFeig(string inipath)
        {
            ini = new Ini(inipath);
            feigList = getAllFeig();
            
        }

        public Feig addFeig(string section, string keyProtocols, string keyICs, string keyCommand1, string keyCommand2)
        {
            Feig feig = new Feig(section,keyProtocols,keyICs,keyCommand1,keyCommand2);
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
                    string protocols="", ICs="", commands="", commands1=null;
                    foreach (var key in itemKeys)
                    {
                        string value = ini.INIGetStringValue(section, key, null);
                        if(key.Contains("Protocols"))
                        { protocols = value; }
                        else if (key.Contains("ICs"))
                        { ICs = value; }
                        else if (key.Contains("Commands1"))
                        { commands1 = value; }
                        else if (key.Contains("Commands"))
                        { commands = value; }


                    }
                    Feig temp = new Feig(section,protocols, ICs, commands, commands1);

                    feigList_temp.Add(temp);
                }

            }

            //addFeig to List
            return feigList_temp;
        }
    }
}
