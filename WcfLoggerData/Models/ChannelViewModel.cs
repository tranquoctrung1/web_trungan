using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class ChannelViewModel
    {
        private string channelId;
        private Nullable<DateTime> timeStamp;
        private Nullable<double> value;
        private string unit;

        public string ChannelId { get => channelId; set => channelId = value; }
        public double? Value { get => value; set => this.value = value; }
        public DateTime? TimeStamp { get => timeStamp; set => timeStamp = value; }
        public string Unit { get => unit; set => unit = value; }
    }
}