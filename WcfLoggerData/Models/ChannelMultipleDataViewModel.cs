using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class ChannelMultipleDataViewModel
    {
        DateTime? timestamp;
        List<double?> values;

        public DateTime? Timestamp { get => timestamp; set => timestamp = value; }
        public List<double?> Values { get => values; set => values = value; }
    }
}