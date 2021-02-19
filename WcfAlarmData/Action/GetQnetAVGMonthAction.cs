using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAlarmData.Action
{
    public class GetQnetAVGMonthAction
    {
        public double? GetQnetAVGMonth(string dma, DateTime start, DateTime end, int months)
        {
            GetQinMultipleMonthDMAAction getQinMultipleMonthDMAAction = new GetQinMultipleMonthDMAAction();
            GetQoutMultipleMonthDMAAction getQoutMultipleMonthDMAAction = new GetQoutMultipleMonthDMAAction();

            List<double?> Qin = getQinMultipleMonthDMAAction.GetQinMultipleMonth(dma, start, end);
            List<double?> Qout = getQoutMultipleMonthDMAAction.GetQoutMultipleMonth(dma, start, end);

            double? result = Qin.Sum() - Qout.Sum();

            if (result != null)
                return result / months;
            return null;
        }
    }
}
