using ISD.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISD.Areas.LogManagement.Models
{
    interface LogRepository
    {
        RespondingRequest create(Logs log);
        List<Logs> getData();
        RespondingRequest print();

        string logContent(LOGTYPE type, string objName, string account);
    }
}
