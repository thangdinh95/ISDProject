using ISD.Areas.AccountManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISD.Areas.AccountManagement.Controllers
{
    public class AccountController : Controller
    {
        // GET: AccountManagement/Home
        public ActionResult Index()
        {
            if(Session["Admin"] == null)
            {
                return RedirectToAction("Index", "Login", new { area = ""});
            }else
            {
                // nếu là quyền admin -> về trang đăng nhập/ nếu là quyền 
                //supper admin thì sẽ vào trang view của ql account
                Admins admin = (Admins)Session["Admin"];
                if (admin.role == ROLES.ADMIN)
                {
                    return RedirectToAction("Index", "Login", new { area = "" });
                }
                return View();
            }
            
        }
    }
}