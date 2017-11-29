using ISD.Areas.AccountManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISD.Controllers
{
    public class HomeController : Controller
    {
        private AdminRepository adminRepository = new AdminRepositoryImpl();
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GetSession(int id)
        {
            Session["Admin"] = adminRepository.getDataById(id);
            return RedirectToAction("ToAdminHome");
        }

        public ActionResult ToAdminHome()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View();
            }
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }
        public ActionResult NewsDetail()
        {
            return View();
        }
    }
}