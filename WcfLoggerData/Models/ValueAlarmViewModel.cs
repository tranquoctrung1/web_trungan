using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class ValueAlarmViewModel
    {
        DateTime? timeStamp;
        string namepath;
        string aliasName;
        double? lasValue;
        double? baseLine;
        double? baseMax;
        double? baseMin;
        double? interVal;
        int? delayTime;
        string status;

        public DateTime? TimeStamp { get => timeStamp; set => timeStamp = value; }
        public string Namepath { get => namepath; set => namepath = value; }
        public string AliasName { get => aliasName; set => aliasName = value; }
        public double? LasValue { get => lasValue; set => lasValue = value; }
        public double? BaseLine { get => baseLine; set => baseLine = value; }
        public double? BaseMax { get => baseMax; set => baseMax = value; }
        public double? BaseMin { get => baseMin; set => baseMin = value; }
        public double? InterVal { get => interVal; set => interVal = value; }
        public int? DelayTime { get => delayTime; set => delayTime = value; }
        public string Status { get => status; set => status = value; }
    }
}