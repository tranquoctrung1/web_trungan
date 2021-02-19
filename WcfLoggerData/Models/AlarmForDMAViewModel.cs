using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class AlarmForDMAViewModel
    {
        string company;
        string description;
        Nullable<DateTime> startDate;
        Nullable<DateTime> endDate;
        Nullable<int> type;
        string content;
        string level;
        Nullable<bool> isFinish;

        public string Company { get => company; set => company = value; }
        public string Description { get => description; set => description = value; }
        public DateTime? StartDate { get => startDate; set => startDate = value; }
        public DateTime? EndDate { get => endDate; set => endDate = value; }
        public int? Type { get => type; set => type = value; }
        public string Content { get => content; set => content = value; }
        public string Level { get => level; set => level = value; }
        public bool? IsFinish { get => isFinish; set => isFinish = value; }
    }
}