using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISD.Areas.LogManagement.Controllers
{
    public class LogController : Controller
    {
        // GET: LogManagement/Home
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Index", "Login", new { area = "" });
            else return View();
        }
    }
}