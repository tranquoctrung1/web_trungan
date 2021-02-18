using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLoggerData.Models;

namespace WcfAlarmData.ULT
{
    class BinarySearch
    {
        public int BinarySearchInterative(List<AlarmForPointViewModel> list, DateTime time)
        {
            int min = 0;
            int max = list.Count - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (time == list[mid].StartDateAlarm)
                {
                    return ++mid;
                }
                else if (time < list[mid].StartDateAlarm)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}
