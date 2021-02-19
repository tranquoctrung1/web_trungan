using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLoggerData.Action;
using WcfLoggerData.Models;

namespace WcfAlarmData.Action
{
    class CompareDiffQnetDMAAction
    {
        public string Compare(string dma)
        {
            string result = "";

            DateTime toDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0,0,0);
            DateTime prev3Day = toDay.AddDays(-3);

            GetLevelAlarmAction getLevelAlarmAction = new GetLevelAlarmAction();
            List<LevelAlarmViewModel> listLevelAlarm = getLevelAlarmAction.GetLevelAlarm();

            GetQnetDMAAction getQnetDMAAction = new GetQnetDMAAction();
            GetQnetAVGDMAAction getQnetAVGDMAAction = new GetQnetAVGDMAAction();

            double? QnetD = getQnetDMAAction.GetQnet(dma, toDay, toDay);
            double? QnetMD = getQnetAVGDMAAction.GetQnetAVG(dma, prev3Day, toDay, 3);
            if(QnetD != null && QnetMD  != null)
            {
                double percent = (Math.Abs(QnetD ?? 0 - QnetMD ?? 0)) / 100;

                for (int i = 0; i < listLevelAlarm.Count; i++)
                {

                    if (i == 0)
                    {
                        if (percent >= listLevelAlarm[i].Value)
                        {
                            result = listLevelAlarm[i].Level;
                            break;
                        }
                    }
                    else if (i == listLevelAlarm.Count - 1)
                    {
                        if (percent > 0 && percent <= listLevelAlarm[i].Value)
                        {
                            result = listLevelAlarm[i].Level;
                            break;
                        }
                    }
                    else
                    {
                        if (percent < listLevelAlarm[i - 1].Value && percent >= listLevelAlarm[i].Value)
                        {
                            result = listLevelAlarm[i].Level;
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
