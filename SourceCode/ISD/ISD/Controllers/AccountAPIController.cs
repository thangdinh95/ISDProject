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
    [RoutePrefix("api/admin/accountMN")]
    public class AccountAPIController : ApiController
    {
        private AdminRepository adminRepository = new AdminRepositoryImpl();
        private LogRepository logRepository = new LogRepositoryImpl();
        [HttpPost]
        [Route("find/getAll")]
        public List<Admins> getData()
        {        
            return adminRepository.getData();
        }

        [HttpPost]
        [Route("find/getById")]
        public Admins getDataById(int id)
        {
            return adminRepository.getDataById(id);
        }
        [HttpPost]
        [Route("find/accountExist")]
        public RespondingRequest accountExist(string account)
        {
            RespondingRequest respondingRequest = new RespondingRequest();
            respondingRequest.status = adminRepository.checkAccountExist(account);
            if (respondingRequest.status)
                respondingRequest.message = "Account has already existed!";
            return respondingRequest;
        }

        [HttpPost]
        [Route("command/create")]
        public RespondingRequest create(Admins admin)
        {
            admin.createdDate = DateTime.Now;
            admin.createdBy = admin.modifiedBy;
            RespondingRequest respondingRequest = new RespondingRequest();
            respondingRequest = adminRepository.create(admin);
            if (respondingRequest.status)
            {
                Admins staff = adminRepository.getDataById(admin.modifiedBy);
                logRepository.create(new Logs()
                {
                    type = LOGTYPE.CREATE,
                    content = logRepository.logContent(LOGTYPE.CREATE, "Account " + admin.name, staff.account),
                    createdBy = staff.adminId,
                    createdDate = DateTime.Now
                });
            }
            return respondingRequest;
        }

        [HttpPost]
        [Route("command/update")]
        public RespondingRequest update(Admins admin)
        {           
            admin.modifiedDate = DateTime.Now;
            RespondingRequest respondingRequest = new RespondingRequest();
            respondingRequest = adminRepository.update(admin);
            if (respondingRequest.status)
            {
                Admins staff = adminRepository.getDataById(admin.modifiedBy);
                logRepository.create(new Logs()
                {
                    type = LOGTYPE.UPDATE,
                    content = logRepository.logContent(LOGTYPE.UPDATE, "Account " + admin.name, staff.account),
                    createdBy = staff.adminId,
                    createdDate = DateTime.Now
                });
            }
            return respondingRequest;
        }

        [HttpPost]
        [Route("command/remove")]
        public RespondingRequest remove(Admins admin)
        {
            RespondingRequest respondingRequest = new RespondingRequest();
            respondingRequest = adminRepository.remove(admin.adminId);
            if (respondingRequest.status)
            {
                Admins staff = adminRepository.getDataById(admin.modifiedBy);
                logRepository.create(new Logs()
                {
                    type = LOGTYPE.REMOVE,
                    content = logRepository.logContent(LOGTYPE.REMOVE, "Account "+ admin.name, staff.account),
                    createdBy = staff.adminId,
                    createdDate = DateTime.Now
                });
            }
            return respondingRequest;
        }
        
    }
}
