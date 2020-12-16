using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class DataGraphViewModel
    {
        private Nullable<DateTime> timeStamp;
        private Nullable<double> value;
        private string channelName;

        public DateTime? TimeStamp { get => timeStamp; set => timeStamp = value; }
        public double? Value { get => value; set => this.value = value; }
        public string ChannelName { get => channelName; set => channelName = value; }
    }
}