using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAlarmData.Action
{
    public class GetQnetDMAAction
    {
        public double? GetQnet(string dma, DateTime start, DateTime end)
        {
            double? result = null;
            GetQinDMAAction getQinDMAAction = new GetQinDMAAction();
            GetQoutDMAAction getQoutDMAAction = new GetQoutDMAAction();

            double? Qin = getQinDMAAction.GetQinDMA(dma, start, end);
            double? Qout = getQoutDMAAction.GetQout(dma, start, end);

            result = Qin ?? 0 - Qout ?? 0;

            return result;
        }
    }
}
