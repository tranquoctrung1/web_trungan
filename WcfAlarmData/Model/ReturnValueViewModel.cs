using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAlarmData.Model
{
    public class ReturnValueViewModel
    {
        public string Result { get; set; }
        public Nullable<double> CurrentValue { get; set; }

        public Nullable<double> PrevValue { get; set; }
    }
}
