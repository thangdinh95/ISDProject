using ISD.Areas.AccountManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISD.Areas.CategoryManagement.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryManagement/Home
        public ActionResult Index()
        {
            Admins admin = (Admins)Session["Admin"];
            if (admin == null)
                return RedirectToAction("Index", "Login", new { area = "" });
            else return View();
        }
    }
}