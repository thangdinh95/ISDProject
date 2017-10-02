using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISD.Areas.LogManagement.Models
{
    public class Logs
    {
        public int logInt { get; set; }
        public LOGTYPE type { get; set; }
        public string content { get; set; }
        public int createdBy { get; set; }
        public string createdByAccount { get; set; }
        public DateTime createdDate { get; set; }
    }
}