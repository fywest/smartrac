using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartrac
{
    public class UHF_ThingMagic : UHF_Reader
    {
        public UHF_ThingMagic(string manufacture, string mode, double txPower) :base(manufacture, mode, txPower)
        {

        }
    }
}