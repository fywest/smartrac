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
    public struct CommandJson
    {
        public string icName;
        public string[] content;
    }

    public class Student
    {
        //[DataMember]
        public int ID { get; set; }

        //[DataMember]
        public string Name { get; set; }

        //[DataMember]
        public int Age { get; set; }

        //[DataMember]
        public string Sex { get; set; }
    }

    public class FeigJson
    {
        public string ReadManufacturer;
        public string model;
        public string[] SupportedProtocols;
        public List<Command> SupportedICs;
       
    }

    class ReadFeigJson
    {
        public ReadFeigJson()
        {

        }

        public string showInfo()
        {
            string json = @"{ 'Name':'C#','Age':'3000','ID':'1','Sex':'女'}";
            
            Student descJsonStu = JsonConvert.DeserializeObject<Student>(json);//反序列化
            string info=(string.Format("反序列化： ID={0},Name={1},Sex={2},Sex={3}", descJsonStu.ID, descJsonStu.Name, descJsonStu.Age, descJsonStu.Sex));
         

            string jsonfile = "HF_reader_FEIG2_configuration_ver2_1.json";

            using (System.IO.StreamReader file = System.IO.File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    string ReadManufacturer = o["ReadManufacturer"].ToString();
                    var SupportedModels = o["SupportedModels"];
                    //var c = b["lotaddress"];
                    //var d = o["devices"];
                    foreach (JObject item in SupportedModels)
                    {
                        string model = item["model"].ToString();
                        var config = item["config"];
                        foreach (JObject item1 in config)
                        {
                            var SupportedProtocols = item1["SupportedProtocols"].ToString();
                            var SupportedICs = item1["SupportedICs"].ToString();
                            var SetupCommands = item1["SetupCommands"].ToString();
                            foreach (JObject item11 in SetupCommands)
                            {
                                string name = item11["name"].ToString();
                                string content = item11["content"].ToString();
                            }

                        }

                    }
                }
            }

            return info;
        }

    }
}
