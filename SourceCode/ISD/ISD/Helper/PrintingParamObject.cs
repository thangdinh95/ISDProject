using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISD.Helper
{
    public class PrintingParamObject
    {
        public List<string[]> lstObj { get; set; }
        public string sheetName { get; set; }
        public string title { get; set; }
        public int[] headerWith { get; set; }//width
        public string[] headerName { get; set; }
        public PrintingParamObject() {
            this.lstObj = new List<string[]>();
        }
    }
}