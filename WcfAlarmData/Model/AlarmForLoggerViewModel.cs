using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAlarmData.Model
{
    public class AlarmForLoggerViewModel
    {
        string serial;
        Nullable<int> type;
        Nullable<DateTime> startDate;
        Nullable<DateTime> endDate;
        Nullable<bool> isFinish;
        string content;

        public string Serial { get => serial; set => serial = value; }
        public Nullable<int> Type { get => type; set => type = value; }
        public DateTime? StartDate { get => startDate; set => startDate = value; }
        public DateTime? EndDate { get => endDate; set => endDate = value; }
        public bool? IsFinish { get => isFinish; set => isFinish = value; }
        public string Content { get => content; set => content = value; }
    }
}
