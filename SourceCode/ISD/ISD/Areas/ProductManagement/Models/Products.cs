﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISD.Areas.ProductManagement.Models
{
    public class Products
    {
        public int productId { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string name { get; set; }
        public double inPrice { get; set; }
        public double outPrice { get; set; }
        public ProductStatus status { get; set; }
        public string description { get; set; }
        public int createdBy { get; set; }
        public string createdByAccount { get; set; }
        public DateTime createdDate { get; set; }
        public int modifiedBy { get; set; }
        public string modifiedByAccount { get; set; }
        public DateTime modifiedDate { get; set; }
    }
}