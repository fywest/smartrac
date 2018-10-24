using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartrac
{

    public class UHF_Thinkify : UHF_Reader
    {
        public UHF_Thinkify(string manufacture, string mode, double txPower) : base(manufacture, mode, txPower)
        {

        }
    }
}