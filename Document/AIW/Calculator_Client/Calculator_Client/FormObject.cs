using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Client
{
    class FormObject
    {
        public float no1 { get; set; }
        public float no2 { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
        public void setValue(string no1, string no2)
        {
            this.no1 = float.Parse(no1);
            this.no2 = float.Parse(no2);
        }
    }
}
