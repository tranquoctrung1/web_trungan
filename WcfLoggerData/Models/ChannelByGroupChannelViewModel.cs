using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class ChannelByGroupChannelViewModel
    {
        string loggerid;
        string channelname;
        string channelid;
        string groupchannel;
        DateTime? timestamp;

        public string LoggerId { get => loggerid; set => loggerid = value; }
        public string ChannelName { get => channelname; set => channelname = value; }
        public string ChannelId { get => channelid; set => channelid = value; }
        public string GroupChannel { get => groupchannel; set => groupchannel = value; }
        public DateTime? TimeStamp { get => timestamp; set => timestamp = value; }
    }
}