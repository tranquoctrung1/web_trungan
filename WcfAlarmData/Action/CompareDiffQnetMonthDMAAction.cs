using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.Model;
using WcfLoggerData.Action;
using WcfLoggerData.Models;

namespace WcfAlarmData.Action
{
    class CompareDiffQnetMonthDMAAction
    {
        public ReturnValueViewModel Compare(string dma)
        {
            string result = "";
            Nullable<double> currentValue  = null;
            Nullable<double> prevValue = null;

            DateTime toDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            DateTime prev3Day = toDay.AddMonths(-3);

            GetLevelAlarmAction getLevelAlarmAction = new GetLevelAlarmAction();
            List<LevelAlarmViewModel> listLevelAlarm = getLevelAlarmAction.GetLevelAlarm();

            GetQnetMonthDMAAction getQnetMonthDMAAction = new GetQnetMonthDMAAction();
            GetQnetAVGMonthAction getQnetAVGMonthAction = new GetQnetAVGMonthAction();

            double? QnetD = getQnetMonthDMAAction.GetQnetMonth(dma, toDay, toDay);
            double? QnetMD = getQnetAVGMonthAction.GetQnetAVGMonth(dma, prev3Day, toDay, 3);

            if (QnetD != null && QnetMD != null)
            {
                double percent = (Math.Abs(QnetD ?? 0 - QnetMD ?? 0)) / 100;

                for (int i = 0; i < listLevelAlarm.Count; i++)
                {

                    if (i == 0)
                    {
                        if (percent >= listLevelAlarm[i].Value)
                        {
                            result = listLevelAlarm[i].Level;
                            currentValue = QnetD;
                            prevValue = QnetMD;
                            break;
                        }
                    }
                    else if (i == listLevelAlarm.Count - 1)
                    {
                        if ( percent == listLevelAlarm[i].Value)
                        {
                            result = listLevelAlarm[i].Level;
                            currentValue = QnetD;
                            prevValue = QnetMD;
                            break;
                        }
                    }
                    else
                    {
                        if (percent < listLevelAlarm[i - 1].Value && percent >= listLevelAlarm[i].Value)
                        {
                            result = listLevelAlarm[i].Level;
                            currentValue = QnetD;
                            prevValue = QnetMD;
                            break;
                        }
                    }
                }
            }

            ReturnValueViewModel returnValue = new ReturnValueViewModel();
            returnValue.Result = result;
            returnValue.CurrentValue = currentValue;
            returnValue.PrevValue = prevValue;

            return returnValue;
        }
    }
}
