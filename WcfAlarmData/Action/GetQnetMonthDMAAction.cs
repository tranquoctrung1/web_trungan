using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAlarmData.Action
{
    public class GetQnetMonthDMAAction
    {
        public double? GetQnetMonth(string dma, DateTime start, DateTime end)
        {
            GetQinMonthDMAAction getQinMonthDMAAction = new GetQinMonthDMAAction();
            GetQoutMonthDMAAction getQoutMonthDMAAction = new GetQoutMonthDMAAction();

            double? Qin = getQinMonthDMAAction.GetQinMonth(dma, start, end);
            double? Qout = getQoutMonthDMAAction.GetQoutMonth(dma, start, end);

            double? result = Qin ?? 0 - Qout ?? 0;

            return result;
        }
    }
}
