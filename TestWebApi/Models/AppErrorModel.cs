using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApi.Models
{
    public class AppErrorModel
    {
        public int ErrorId { get; set; }
        public string DeviceID { get; set; }
        public string AppID { get; set; }
        public System.DateTime DateTime { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public string ErrMessage { get; set; }
        public string StackTrace { get; set; }
    }
}