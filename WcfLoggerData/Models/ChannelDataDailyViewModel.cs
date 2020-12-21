using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class ChannelDataDailyViewModel
    {

        DateTime? timestamp;
        double? value;

        public DateTime? Timestamp { get => timestamp; set => timestamp = value; }
        public double? Value { get => value; set => this.value = value; }
    }
}