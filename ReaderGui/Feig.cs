using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderGui
{
    public struct Command
    {
        public string icName;
        public string content;
    }
    class Feig
    {
        public string model;
        public string[] protocols;
        public string ICs;
        public Command command;

        public Feig(string model_name,string protocols_name,string ICs_name,string command_icName,string command_content)
        {
            this.model = model_name;
            //this.protocols = protocols_name;
            this.protocols = getProtocols(protocols_name);
            this.ICs = ICs_name;
            this.command.icName = command_icName;
            this.command.content = command_content;
        }
        private string[] getProtocols(string protocols)
        {

            //string phrase = "The quick brown fox jumps over the lazy dog.";
            //string[] words = phrase.Split(' ');
            string[] strList=protocols.Split(',');
            return strList;
        }
        public string showinfo()
        {
            string str_protocols="";
            foreach(var item in protocols)
            {
                str_protocols += item+ ",";

            }
            string info = model + "\n" + str_protocols + "\n" + ICs + "\n" + command.icName + "\n" + command.content;
            return info;
        }
    }
}
