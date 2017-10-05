using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISD.Areas.ProductManagement.Models.ProductBusinessRepository
{
    public class ProductBusinessObject
    {
        public Products product { get; set; }
        public List<Images> lstImages { get; set; }
    }
}