using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAlarmData.Model
{
    public class ChannelByLoggerViewModel
    {
        string channelId;
        string channelName;
        bool? press1;
        bool? press2;
        bool? flow1;
        bool? flow2;
        DateTime? timestamp;
        DateTime? indexTimestamp;
        double? val;
        double? lastIndex;
        double? baseMin;
        double? baseMax;
        string unit;
        int status;
        bool status1;
        bool status2;
        bool status3;
        bool status4;
        bool status5;
        bool status6;
        bool displayLabel;
        int groupChannelStatus;

        public string ChannelId { get => channelId; set => channelId = value; }
        public string ChannelName { get => channelName; set => channelName = value; }
        public bool? Press1 { get => press1; set => press1 = value; }
        public bool? Press2 { get => press2; set => press2 = value; }
        public bool? Flow1 { get => flow1; set => flow1 = value; }
        public bool? Flow2 { get => flow2; set => flow2 = value; }
        public DateTime? Timestamp { get => timestamp; set => timestamp = value; }
        public DateTime? IndexTimestamp { get => indexTimestamp; set => indexTimestamp = value; }
        public double? Val { get => val; set => val = value; }
        public double? LastIndex { get => lastIndex; set => lastIndex = value; }
        public double? BaseMin { get => baseMin; set => baseMin = value; }
        public double? BaseMax { get => baseMax; set => baseMax = value; }
        public string Unit { get => unit; set => unit = value; }
        public int Status { get => status; set => status = value; }
        public bool Status1 { get => status1; set => status1 = value; }
        public bool Status2 { get => status2; set => status2 = value; }
        public bool Status3 { get => status3; set => status3 = value; }
        public bool Status4 { get => status4; set => status4 = value; }
        public bool Status5 { get => status5; set => status5 = value; }
        public bool Status6 { get => status6; set => status6 = value; }
        public bool DisplayLabel { get => displayLabel; set => displayLabel = value; }
        public int GroupChannelStatus { get => groupChannelStatus; set => groupChannelStatus = value; }
    }
}
