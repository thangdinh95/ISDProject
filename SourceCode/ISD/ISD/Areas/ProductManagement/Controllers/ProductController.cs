using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISD.Areas.ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductManagement/Home
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Index", "Login", new { area = "" });
            else return View();
        }
    }
}