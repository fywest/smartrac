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
        public string protocols;
        public string ICs;
        public Command command;

        public Feig(string model_name,string protocols_name,string ICs_name,string command_icName,string command_content)
        {
            this.model = model_name;
            this.protocols = protocols_name;
            this.ICs = ICs_name;
            this.command.icName = command_icName;
            this.command.content = command_content;
        }
        public string showinfo()
        {
            string info = model + "\n" + protocols + "\n" + ICs + "\n" + command.icName + "\n" + command.content;
            return info;
        }
    }
}
