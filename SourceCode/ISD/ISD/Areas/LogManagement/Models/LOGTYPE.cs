using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISD.Areas.LogManagement.Models
{
    public enum LOGTYPE
    {
        LOGIN = 1,
        CREATE = 2,
        UPDATE = 3,
        REMOVE = 4, 
        PRINT = 5
    }
}