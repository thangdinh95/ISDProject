using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISD.Areas.AccountManagement.Models
{
    public class Admins
    {
        public int adminId { get; set; }
        public string account { get; set; } 
        public string password { get; set; }
        public string name { get; set; }
        public DateTime birthday { get; set; }
        public string phone { get; set; }
        public string mail { get; set; }
        public string address { get; set; }
        public ROLES role { get; set; }
        public int createdBy { get; set; }
        public string createdByAccount { get; set; }
        public DateTime createdDate { get; set; }
        public int modifiedBy { get; set; }
        public string modifiedByAccount { get; set; }
        public DateTime modifiedDate { get; set; }
    }
}