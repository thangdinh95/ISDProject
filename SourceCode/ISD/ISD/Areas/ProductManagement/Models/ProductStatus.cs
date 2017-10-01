using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISD.Areas.ProductManagement.Models
{
    public class ProductStatus
    {
        public int quantity { get; set; }
        public int numOfView { get; set; }
        public int numOfSold { get; set; }
    }
}