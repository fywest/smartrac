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
        public FeigJson(string model,string protocols,string ics,List<CommandJson> commandJsonList)
        {
            Model = model.Trim();
            SupportedProtocols = Util.strTrimToArray(protocols, ';');
            SupportedICs= Util.strTrimToArray(ics, ';');
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
                foreach(string protocol in feigJson.SupportedProtocols)
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
                foreach(string IC in feigJson.SupportedICs)
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
        public FeigJsonList feigJsonList { get; set; }//Update to List if more than one ReaderManufacture

        //public List<string> ICsNameList { get; set; }
        //public List<string> ProtocolsNameList { get; set; }
        //public List<string> ModelList { get; set; }

        public ReadFeigJson()
        {
            feigJsonList = new FeigJsonList();
            //ICsNameList = new List<string>();
            //ProtocolsNameList = new List<string>();
            //ModelList = new List<string>();

        }

        public void readFromFile(string path)
        {
            //string jsonFile = "feigPR40.json";
            //FeigJson feigjson = JsonConvert.DeserializeObject<FeigJson>(File.ReadAllText(jsonFile));

            string jsonFile_in = path;
            feigJsonList = JsonConvert.DeserializeObject<FeigJsonList>(File.ReadAllText(jsonFile_in));

        }

        //public void getICsProtocolsModelList()
        //{
        //    foreach (FeigJson feigJson in feigJsonList.ReaderConfig)
        //    {
        //        if (!ModelList.Contains(feigJson.Model))
        //        {
        //            ModelList.Add(feigJson.Model);
        //        }

        //        foreach (string IC in feigJson.SupportedICs)
        //        {
        //            if (!ICsNameList.Contains(IC))
        //            {
        //                ICsNameList.Add(IC);
        //            }
        //        }
        //        foreach (string Protocol in feigJson.SupportedProtocols)
        //        {
        //            if (!ProtocolsNameList.Contains(Protocol))
        //            {
        //                ProtocolsNameList.Add(Protocol);
        //            }
        //        }

        //    }
        //}
        public void writeToFile(string path)
        {

            string jsonFile_out = path;
            
            File.WriteAllText(jsonFile_out, JsonConvert.SerializeObject(feigJsonList, Formatting.Indented));
        }

        public void createNewJson(string path)
        {
            string str_feigJsonList = @"{
              'ReaderManufacturer': 'FEIG',
              'SupportedModels': [
                'Model'
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
            feigJsonList = JsonConvert.DeserializeObject<FeigJsonList>(str_feigJsonList);
            File.WriteAllText(path, JsonConvert.SerializeObject(feigJsonList, Formatting.Indented));
        }
        //{"ReaderManufacturer":"FEIG","SupportedModels":["Model"],"ReaderConfig":[{"Model":"Model","SupportedProtocols":["Protocols"],"SupportedICs":["ICs"],"SetupCommands":[{"icName":["ICs"],"icCommand":["ICsCommand"]}]}]}



    }
}


//public class Student
//{
//    //[DataMember]
//    public int ID { get; set; }

//    //[DataMember]
//    public string Name { get; set; }

//    //[DataMember]
//    public int Age { get; set; }

//    //[DataMember]
//    public string Sex { get; set; }
//}

//string json = @"{ 'Name':'C#','Age':'3000','ID':'1','Sex':'女'}";

//Student descJsonStu = JsonConvert.DeserializeObject<Student>(json);//反序列化
//string info=(string.Format("反序列化： ID={0},Name={1},Sex={2},Sex={3}", descJsonStu.ID, descJsonStu.Name, descJsonStu.Age, descJsonStu.Sex));


//"HF_reader_FEIG2_configuration_ver2_1.json";
//   string jsonStr = @"{
//	'model': 'PR40',
//	'SupportedProtocols': [
//		'ISO14443A',
//		'ISO14443B',
//		'ISO14443A-4',
//		'SRI',
//		'Mifare Classic',
//		'MyD',
//		'ISO15693'
//	],
//	'SupportedICs': [
//		'TAG213',
//		'NTAG210',
//		'SIC43NT'
//	],
//	'SetupCommands': [
//		{
//			'icName': ['NTAG213','NTAG210','SIC43NT'],
//			'icCommand': [
//				'YYYY'
//			]
//		}
//	]
//}";
//FeigJson feigjson = JsonConvert.DeserializeObject<FeigJson>(jsonStr);



//using (System.IO.StreamReader file = System.IO.File.OpenText(jsonfile))
//{
//    using (JsonTextReader reader = new JsonTextReader(file))
//    {
//        JObject o = (JObject)JToken.ReadFrom(reader);
//        string ReadManufacturer = o["ReadManufacturer"].ToString();
//        var SupportedModels = o["SupportedModels"];
//        //var c = b["lotaddress"];
//        //var d = o["devices"];
//        foreach (JObject item in SupportedModels)
//        {
//            string model = item["model"].ToString();
//            var config = item["config"];
//            foreach (JObject item1 in config)
//            {
//                var SupportedProtocols = item1["SupportedProtocols"].ToString();
//                var SupportedICs = item1["SupportedICs"].ToString();
//                var SetupCommands = item1["SetupCommands"].ToString();
//                foreach (JObject item11 in SetupCommands)
//                {
//                    string name = item11["name"].ToString();
//                    string content = item11["content"].ToString();
//                }

//            }

//        }
//    }
//}
