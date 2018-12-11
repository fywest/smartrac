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
        public string[] ICs;
        public List<Command> command;


        public Feig(string model_name,string protocols_name,string ICs_name,string command)
        {
            this.model = model_name;
            //this.protocols = protocols_name;
            this.protocols = getValues(protocols_name);
            this.ICs = getValues(ICs_name);
            this.command= getCommand(command);
            
        }

        private string[] getValues(string strValue)
        {

            //string phrase = "The quick brown fox jumps over the lazy dog.";
            //string[] words = phrase.Split(' ');
            string[] strList=strValue.Split(',');
            return strList;
        }

        private List<Command> getCommand(string command)
        {

            //string phrase = "The quick brown fox jumps over the lazy dog.";
            //string[] words = phrase.Split(' ');
            List<Command> command_list=new List<Command>();

            string[] commands = command.Split(';');
            foreach(var command_item in commands)
            {
                Command temp;
                string[] strList = command_item.Split(':');
                temp.icName = strList[0];
                temp.content = strList[1];
                command_list.Add(temp);
            }

            return command_list;
        }
        public string showinfo()
        {
            string str_protocols="";
            foreach(var item in protocols)
            {
                str_protocols += item+ ",";

            }
            string info = model + "\n" + str_protocols + "\n" + ICs + "\n";
            return info;
        }
    }
}
