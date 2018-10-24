using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartrac
{
    public struct Test_Command
    {
        private string _manufacture, _type, _commands;

        public Test_Command(string manufacture, string type, string commands)
        {
            _manufacture = manufacture;
            _type = type;
            _commands = commands;
            //throw new System.NotImplementedException();
        }
        public string Manufacture
        {
            get
            {
                return _manufacture;
            }
            set
            {
                _manufacture = value;
            }
        }
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        public string Commands
        {
            get
            {
                return _commands;
            }
            set
            {
                _commands = value;
            }
        }

    }
}