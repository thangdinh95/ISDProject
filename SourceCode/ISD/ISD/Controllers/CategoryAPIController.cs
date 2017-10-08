using ISD.Areas.AccountManagement.Models;
using ISD.Areas.CategoryManagement.Models;
using ISD.Areas.LogManagement.Models;
using ISD.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISD.Controllers
{
    [RoutePrefix("api/admin/categoryMN")]
    public class CategoryAPIController : ApiController
    {
        private CategoryRepository categoryRepository = new CategoryRepositoryImpl();
        private AdminRepository adminRepository = new AdminRepositoryImpl();
        private LogRepository logRepository = new LogRepositoryImpl();
        [HttpPost]
        [Route("find/getAll")]
        public List<Categories> getData()
        {
            return categoryRepository.getAll();
        }

        [HttpPost]
        [Route("find/getById")]
        public Categories getDataById(int id)
        {
            return categoryRepository.getDataById(id);
        }

        [HttpPost]
        [Route("find/checkCtgNameExist")]
        public RespondingRequest checkCtgNameExist(CheckCtgExistObject command)
        {
            return categoryRepository.checkCtgNameExist(command.ctgName, command.currentName);
        }

        [HttpPost]
        [Route("command/create")]
        public RespondingRequest create(Categories category)
        {
            category.createdDate = DateTime.Now;
            category.createdBy = category.modifiedBy;
            RespondingRequest respondingRequest = new RespondingRequest();

            // gọi đến model để update dữ liệu
            respondingRequest = categoryRepository.create(category);
            if (respondingRequest.status)
            {
                Admins staff = adminRepository.getDataById(category.modifiedBy);
                logRepository.create(new Logs()
                {
                    type = LOGTYPE.CREATE,
                    content = logRepository.logContent(LOGTYPE.CREATE, "Category " + category.name, staff.account),
                    createdBy = staff.adminId,
                    createdDate = DateTime.Now
                });
            }
            return respondingRequest;
        }

        [HttpPost]
        [Route("command/update")]
        public RespondingRequest update(Categories category)
        {
            category.modifiedDate = DateTime.Now;
            RespondingRequest respondingRequest = new RespondingRequest();
            respondingRequest = categoryRepository.update(category);
            if (respondingRequest.status)
            {
                Admins staff = adminRepository.getDataById(category.modifiedBy);
                logRepository.create(new Logs()
                {
                    type = LOGTYPE.UPDATE,
                    content = logRepository.logContent(LOGTYPE.UPDATE, "Category " + category.name, staff.account),
                    createdBy = staff.adminId,
                    createdDate = DateTime.Now
                });
            }
            return respondingRequest;
        }

        [HttpPost]
        [Route("command/remove")]
        public RespondingRequest remove(Categories category)
        {
            RespondingRequest respondingRequest = new RespondingRequest();
            respondingRequest = categoryRepository.remove(category.categoryId);
            if (respondingRequest.status)
            {
                Admins staff = adminRepository.getDataById(category.modifiedBy);
                logRepository.create(new Logs()
                {
                    type = LOGTYPE.REMOVE,
                    content = logRepository.logContent(LOGTYPE.REMOVE, "Category " + category.name, staff.account),
                    createdBy = staff.adminId,
                    createdDate = DateTime.Now
                });
            }
            return respondingRequest;
        }
    }
    public class CheckCtgExistObject{
        public string ctgName { get; set; }
        public string currentName { get; set; }
    }
}
