using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class UserViewModel
    {
        public string Uid { get; set; }
        public string Pwd { get; set; }
        public string Salt { get; set; }
        public string StaffId { get; set; }
        public string Role { get; set; }
        public bool? Active { get; set; }
        public string Ip { get; set; }
        public DateTime? TimeStamp { get; set; }
        public int? LogCount { get; set; }
        public int? Zoom { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}