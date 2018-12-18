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
        public List<string> ModelList;
        //public String[] SupportedModels;

        public ReadFeig(string inipath)
        {
            ini = new Ini(inipath);
            ICsNameList = new List<string>();
            ModelList = getModelList();
            //SupportedModels = getSupportedModels();
            feigList = getAllFeig();
            
        }

        public Feig addFeig(string section, string keyProtocols, string keyICs, string keyCommand)
        {
            Feig feig = new Feig(section,keyProtocols,keyICs,keyCommand);
            return feig;
        }

        public string[] getSupportedModels()
        {
            string model_value = ini.INIGetStringValue("Base_class", "SupportedModels");//, null);
            string[] models = model_value.Split(',');
            List<string> parts = model_value.Split(',').Select(p => p.Trim()).ToList();
            return models;
        }

        public List<string> getModelList()
        {
            string model_value = ini.INIGetStringValue("Base_class", "SupportedModels");//, null);
           
            List<string> parts = model_value.Split(',').Select(p => p.Trim()).ToList();
            return  parts;
        }
        public List<Feig> getAllFeig()
        {
            List<Feig> feigList_temp = new List<Feig>();

            string[] allSectionNames = ini.INIGetAllSectionNames();
            string[] models = getSupportedModels();
            string models_class;
            models_class = string.Join("_class,", models)+"_class";
            foreach (var section in allSectionNames)
            {
             
                    if (models_class.Contains(section))
                    {
                        string[] itemKeys = ini.INIGetAllItemKeys(section);
                        string protocols = "", ICs = "", commands = "";
                        foreach (var key in itemKeys)
                        {
                        string value = ini.INIGetStringValue(section, key);//, null);
                            if (key.Contains("Protocols"))
                            { protocols = value; }
                            else if (key.Contains("ICs"))
                            {
                                ICs = value;
                                string[] strList = ICs.Split(',');
                                foreach (var item in strList)
                                {
                                    string strTemp = item.Trim();

                                    if (!ICsNameList.Contains(strTemp))
                                    {
                                        ICsNameList.Add(strTemp);
                                    }
                                }
                            }
                            else if (key.Contains("Commands"))
                            { commands = value; }

                        }
                        Feig temp = new Feig(section, protocols, ICs, commands);

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
