using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISD.Areas.CategoryManagement.Models
{
    public class Categories
    {
        public int categoryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int createdBy { get; set; }
        public string createdByAccount { get; set; }
        public DateTime createdDate { get; set; }
        public int modifiedBy { get; set; }
        public string modifiedByAccount { get; set; }
        public DateTime modifiedDate{get;set;}

    }
}