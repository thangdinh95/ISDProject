using ISD.Areas.AccountManagement.Models;
using ISD.Areas.LogManagement.Models;
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
        private LogRepository logRepository = new LogRepositoryImpl();
        [HttpPost]
        [Route("")]
        public RespondingRequest login(LoginInfo loginInfo)
        {
            RespondingRequest respondingRequest = new RespondingRequest();
            //vào DB lấy dữ liệu theo account và psw
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

            if (respondingRequest.status == true)
            {                
                logRepository.create(new Logs()
                {
                    type = LOGTYPE.LOGIN,
                    content = logRepository.logContent(LOGTYPE.LOGIN, " Login to system", admin.account),
                    createdBy = admin.adminId,
                    createdDate = DateTime.Now
                });
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
