using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartrac
{
    public class UHF_Voyantic:UHF_Reader
    {
        public UHF_Voyantic(string manufacture, string mode, double txPower) : base(manufacture, mode, txPower)
        {

        }
    }

}