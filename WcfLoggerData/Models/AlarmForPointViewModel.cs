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
        int? typeAlarm;
        string level;
        bool? isFinish;
        string content;

        public string ChannelId { get => channelId; set => channelId = value; }
        public string Location { get => location; set => location = value; }    
        public DateTime? StartDateAlarm { get => startDateAlarm; set => startDateAlarm = value; }
        public DateTime? EndDateAlarm { get => endDateAlarm; set => endDateAlarm = value; }
        public int? TypeAlarm { get => typeAlarm; set => typeAlarm = value; }
        public string Level { get => level; set => level = value; }
        public bool? IsFinish { get => isFinish; set => isFinish = value; }
        public string Content { get => content; set => content = value; }
    }
}