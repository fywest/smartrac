using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace smartrac
{
    public class HF_FEIG:HF_Reader
    {
        public List<Test_Command> test_commands;//= new List<Test_Command>();
        public HF_FEIG(string manufacturer, string model, double txPower) : base(manufacturer, model, txPower)
        {
            this.test_commands = new List<Test_Command>();
        }

        public void ReadCFGFile(string filename)
        {
            //string msg = "";
            



            using (var sr = new StreamReader(filename))
            {

                
                string line;
                char[] delimiterChars = { '\t' };
                string[] manufacture = new string[15];
                string[] type = new string[15];
                string[] commands = new string[15];
                int index = 0;
                while (sr.Peek() > 0)
                {
                    line = sr.ReadLine();
                    // process the file line by line
                    string[] words = line.Split(delimiterChars);
                    manufacture[index] = words[0];
                    type[index] = words[1];
                    commands[index] = words[4];

                    test_commands.Add(new Test_Command(words[0], words[1], words[4]));


                    //msg += line+"\n";
                    //msg += manufacture[index] + "\t" + type[index] + "\t" + commands[index] + "\n";

                    index++;
                }

            }

        }

        public void SelectCommand()
        {

            //throw new System.NotImplementedException();
        }
    }
}