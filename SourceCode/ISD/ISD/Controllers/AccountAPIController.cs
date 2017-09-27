using ISD.Areas.AccountManagement.Models;
using ISD.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISD.Controllers
{
    [RoutePrefix("api/admin/accountMN")]
    public class AccountAPIController : ApiController
    {
        private AdminRepository adminRepository = new AdminRepositoryImpl();
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
        [Route("command/create")]
        public RespondingRequest create(Admins admin)
        {
            return adminRepository.create(admin);
        }

        [HttpPost]
        [Route("command/update")]
        public RespondingRequest update(Admins admin)
        {
            return adminRepository.update(admin);
        }

        [HttpPost]
        [Route("command/remove")]
        public RespondingRequest remove(int id)
        {
            return adminRepository.remove(id);
        }
    }
}
