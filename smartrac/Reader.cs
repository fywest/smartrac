using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartrac
{
    public abstract class Reader
    {
        private string _manufacturer;
        private string _model;
        private double _txPower;

        public Reader(string manufacturer, string model, double txPower)
        {
            Manufacturer = manufacturer;
            Model = model;
            TxPower = txPower;
            //throw new System.NotImplementedException();
        }

        public string Manufacturer
        {
            get
            {
                return _manufacturer;
            }
            set
            {
                _manufacturer = value;
            }
        }
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }
        public double TxPower
        {
            get
            {
                return _txPower;
            }
            set
            {
                _txPower = value;
            }
        }
    }
}