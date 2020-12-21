using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class GroupChannelViewModel
    {
        string groupChannel;
        string description;
        bool status;

        public string GroupChannel { get => groupChannel; set => groupChannel = value; }
        public string Description { get => description; set => description = value; }
        public bool Status { get => status; set => status = value; }
    }
}