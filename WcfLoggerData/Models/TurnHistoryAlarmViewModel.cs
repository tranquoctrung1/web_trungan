using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class TurnHistoryAlarmViewModel
    {
        string type;
        Nullable<bool> isOn;

        public string Type { get => type; set => type = value; }
        public bool? IsOn { get => isOn; set => isOn = value; }
    }
}