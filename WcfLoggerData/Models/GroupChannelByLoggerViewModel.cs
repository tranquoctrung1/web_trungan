using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class GroupChannelByLoggerViewModel
    {
        string loggerid;
        string channelname;
        string channelid;
        string groupchannel;
        DateTime? timestamp;

        public string Loggerid { get => loggerid; set => loggerid = value; }
        public string Channelname { get => channelname; set => channelname = value; }
        public string Channelid { get => channelid; set => channelid = value; }
        public string Groupchannel { get => groupchannel; set => groupchannel = value; }
        public DateTime? Timestamp { get => timestamp; set => timestamp = value; }
    }
}