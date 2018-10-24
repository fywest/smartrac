using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartrac
{
    public class UHF_Reader:Reader
    {
        private string[] _protocols;
        private int timeout;
        private string CRC;

        public UHF_Reader(string manufacturer, string model, double txPower) : base(manufacturer, model, txPower)
        {
            _protocols = new string[]{ "modulation index", "BLF" };
            throw new System.NotImplementedException();
        }

        public void WriteData()
        {
            throw new System.NotImplementedException();
        }

        public void WriteEPC()
        {
            throw new System.NotImplementedException();
        }

        public void ReadData()
        {
            throw new System.NotImplementedException();
        }

        public void Lock()
        {
            throw new System.NotImplementedException();
        }

        public void BlockWrite()
        {
            throw new System.NotImplementedException();
        }
    }
}