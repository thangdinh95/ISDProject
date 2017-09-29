using ISD.Areas.LogManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISD.Controllers
{
    [RoutePrefix("api/admin/logMN")]
    public class LogAPIController : ApiController
    {
        private LogRepository logRepository = new LogRepositoryImpl();
        [HttpPost]
        [Route("find/getAll")]
        public List<Logs> getData()
        {
            return logRepository.getData();
        }
    }
}
