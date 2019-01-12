using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ReaderGui
{
    //setupCommands structure
    public struct CommandJson
    {
        public string[] icName;
        public string[] icCommand;
    }

    public class FeigJson
    {
        //public string ReadManufacturer;
        public string Model { get; set; }
        public string[] SupportedProtocols { get; set; }
        public string[] SupportedICs { get; set; }
        public List<CommandJson> SetupCommands { get; set; }

        public FeigJson()
        { }

        public FeigJson(string model, string[] protocols, string[] ics, List<CommandJson> commandJsonList)
        {
            Model = model.Trim();
            SupportedProtocols = protocols;
            SupportedICs = ics;
            SetupCommands = commandJsonList;

        }
    }

    public class FeigJsonList
    {
        public string ReaderManufacturer { get; set; }
        public string[] AvailableModels { get; set; }
        public string[] AvailableProtocols { get; set; }
        public string[] AvailableICs { get; set; }
        public List<FeigJson> ReaderConfig { get; set; }

        public FeigJsonList()
        {

        }

        public List<string> getModels()
        {
            List<string> ModelList = new List<string>();
            foreach (FeigJson feigJson in ReaderConfig)
            {

                if (!ModelList.Contains(feigJson.Model))
                {
                    ModelList.Add(feigJson.Model);
                }
            }
            return ModelList;
        }

        public List<string> getProtocols()
        {
            List<string> protocolList = new List<string>();
            foreach (FeigJson feigJson in ReaderConfig)
            {
                foreach (string protocol in feigJson.SupportedProtocols)
                {
                    if (!protocolList.Contains(protocol))
                    {
                        protocolList.Add(protocol);
                    }
                }

            }
            return protocolList;
        }

        public List<string> getICs()
        {
            List<string> ICList = new List<string>();
            foreach (FeigJson feigJson in ReaderConfig)
            {
                foreach (string IC in feigJson.SupportedICs)
                    if (!ICList.Contains(IC))
                    {
                        ICList.Add(IC);
                    }
            }
            return ICList;
        }
    }

    class ReadFeigJson
    {
        public FeigJsonList feigJsonList { get; set; }
        public ReadFeigJson()
        {
            feigJsonList = new FeigJsonList();
        }

        public void readFromFile(string path)
        {
            string jsonFile_in = path;
            feigJsonList = JsonConvert.DeserializeObject<FeigJsonList>(File.ReadAllText(jsonFile_in));

        }

        public void writeToFile(string path)
        {
            string jsonFile_out = path;
            File.WriteAllText(jsonFile_out, JsonConvert.SerializeObject(feigJsonList, Formatting.Indented));
        }

        public void createNewJson(string path)
        {
            string str_feigJsonList = Util.str_NewFeig;
            feigJsonList = JsonConvert.DeserializeObject<FeigJsonList>(str_feigJsonList);
            File.WriteAllText(path, JsonConvert.SerializeObject(feigJsonList, Formatting.Indented));
        }
    }
}
