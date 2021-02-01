using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class AlarmForPointViewModel
    {
        string channelId;
        string location;
        DateTime? startDateAlarm;
        DateTime? endDateAlarm;
        string typeAlarm;
        string level;
        bool? isFinish;

        public string ChannelId { get => channelId; set => channelId = value; }
        public string Location { get => location; set => location = value; }    
        public DateTime? StartDateAlarm { get => startDateAlarm; set => startDateAlarm = value; }
        public DateTime? EndDateAlarm { get => endDateAlarm; set => endDateAlarm = value; }
        public string TypeAlarm { get => typeAlarm; set => typeAlarm = value; }
        public string Level { get => level; set => level = value; }
        public bool? IsFinish { get => isFinish; set => isFinish = value; }
    }
}