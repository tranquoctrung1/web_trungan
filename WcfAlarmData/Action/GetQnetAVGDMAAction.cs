using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAlarmData.Action
{
    public class GetQnetAVGDMAAction
    {
        public double? GetQnetAVG(string dma, DateTime start , DateTime end, int days)
        {
            double? result = null;
            GetQinMultipleDayAction getQinMultipleDayAction = new GetQinMultipleDayAction();
            GetQoutMultipleDayAction getQoutMultipleDayAction = new GetQoutMultipleDayAction();

            List<double?> Qin = getQinMultipleDayAction.GetQinMultipleDay(dma, start, end);
            List<double?> Qout = getQoutMultipleDayAction.GetQoutMultipleDay(dma, start, end);

            result = Qin.Sum() - Qout.Sum();
            if(result != null)
                return result / days;
            return null;
        }
    }
}
