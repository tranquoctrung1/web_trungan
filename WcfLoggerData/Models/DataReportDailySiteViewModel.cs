using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class DataReportDailySiteViewModel
    {
        public string SiteId { get; set; }
        public string Location { get; set; }
        public Nullable<DateTime> TimeStamp { get; set; }
        public Nullable<DateTime> StartTime { get; set; }
        public Nullable<DateTime> EndTime { get; set; }
        public Nullable<double> StartIndex { get; set; }
        public Nullable<double> EndIndex { get; set; }
        public Nullable<double> Value { get; set; }
    }
}