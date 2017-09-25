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

        public ActionResult AdminPage(int id)
        {
            Session["Admin"] = adminRepository.getDataById(id);
            return View();
        }
    }
}