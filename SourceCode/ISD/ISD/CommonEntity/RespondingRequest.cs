using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISD.CommonEntity
{
    public class RespondingRequest
    {
        public bool status { get; set; }// true: thao tác thực thi thành công, false: ngược lại
        public string message { get; set; }
    }
}