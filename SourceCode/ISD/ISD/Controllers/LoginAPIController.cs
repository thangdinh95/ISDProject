using ISD.Areas.AccountManagement.Models;
using ISD.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ISD.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginAPIController : ApiController
    {
        private AdminRepository adminRepository = new AdminRepositoryImpl();
        [HttpPost]
        [Route("")]
        public RespondingRequest login(LoginInfo loginInfo)
        {
            RespondingRequest respondingRequest = new RespondingRequest();
            Admins admin = adminRepository.getDataByAccount(loginInfo.account, loginInfo.password);
            if (admin == null)
            {
                respondingRequest.status = false;
                respondingRequest.message = "Account is not exist. Please check again!";
            }
            else
            {
                respondingRequest.status = true;
                respondingRequest.message = admin.adminId.ToString();
            }
            return respondingRequest;
        }
        public class LoginInfo
        {
            public string account { get; set; }
            public string password { get; set; }
        }
    }
   
}
