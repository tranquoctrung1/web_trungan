using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class DataReportMonthlyManagerViewModel
    {
        Nullable<DateTime> timeStamp;
        Nullable<double> value;

        public DateTime? TimeStamp { get => timeStamp; set => timeStamp = value; }
        public double? Value { get => value; set => this.value = value; }
    }
}