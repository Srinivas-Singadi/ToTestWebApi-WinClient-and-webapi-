using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApi.Models
{
    public class UserActivityModel
    {
        public int UserActivityId { get; set; }
        public string DeviceID { get; set; }
        public string ActivityID { get; set; }
        public string Remark { get; set; }
        public DateTime DateCreate { get; set; }
    }
}