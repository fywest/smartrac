using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartrac
{
    public class HF_Reader : Reader
    {
        private string[] _protocols;//ISO14443A,ISO14443A,ISO15693
        public HF_Reader(string manufacturer, string model, double txPower) : base(manufacturer, model, txPower)
        {
            _protocols = new string[]{ "ISO14443A","ISO14443A","ISO15693"};
           // throw new System.NotImplementedException();
        }

        public string WriteBlock()
        {
            string info_str = Manufacturer + "\n" + Model + "\n" + TxPower.ToString();
            for(int i=0;i<3; i++)
            {
                info_str += "\n"+_protocols[i];
            }
            return info_str;
            
            //throw new System.NotImplementedException();
        }

        public void ReadBlock()
        {
            throw new System.NotImplementedException();
        }

        public void Select()
        {
            throw new System.NotImplementedException();
        }

    }
}