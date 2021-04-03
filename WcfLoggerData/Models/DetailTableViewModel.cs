using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class DetailTableViewModel
    {
        Nullable<DateTime> timeStamp;
        Nullable<double> pressure;
        Nullable<double> flow;
        Nullable<double> indexForward;
        Nullable<double> indexReverse;
        Nullable<double> indexNet;

        public DateTime? TimeStamp { get => timeStamp; set => timeStamp = value; }
        public double? Pressure { get => pressure; set => pressure = value; }
        public double? Flow { get => flow; set => flow = value; }
        public double? IndexForward { get => indexForward; set => indexForward = value; }
        public double? IndexReverse { get => indexReverse; set => indexReverse = value; }
        public double? IndexNet { get => indexNet; set => indexNet = value; }
    }
}