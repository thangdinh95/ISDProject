using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISD.Areas.ProductManagement.Models
{
    public class Images
    {
        public int imageId { get; set; }
        public int productId { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }
}