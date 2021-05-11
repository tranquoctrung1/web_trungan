using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfAlarmData.Model;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetMinNightFlowAlarmAction
    {
        public ReturnValueViewModel GetMinNightFlowAlarm(string channelid)
        {
            string result = "";
            Nullable<double> currentValue = null;
            Nullable<double> prevValue = null;

            GetMinNightFlowAction getMinNightFlowAction = new GetMinNightFlowAction();
            GetCurrentTimeAction getCurrentTimeAction = new GetCurrentTimeAction();
            GetLevelAlarmAction getLevelAlarmAction = new GetLevelAlarmAction();

            DateTime? current = getCurrentTimeAction.GetCurrentTime(channelid);

            if (current != null)
            {
                DateTime start = new DateTime(current.Value.Year, current.Value.Month, current.Value.Day, 0, 0, 0);
                DateTime end = new DateTime(current.Value.Year, current.Value.Month, current.Value.Day, 5, 0, 0);
                DateTime prevStart = start.AddDays(-1);
                DateTime prevEnd = end.AddDays(-1);

                List<LevelAlarmViewModel> listLevelAlarm = getLevelAlarmAction.GetLevelAlarm();

                // mnf current date
                double? mnf = getMinNightFlowAction.GetMinNightFlow(channelid, start, end);
                // mnf prev current date
                double? premnf = getMinNightFlowAction.GetMinNightFlow(channelid, prevStart, prevEnd);

                if(mnf != null && premnf != null)
                {
                    double percent = Math.Abs(mnf?? 0 - premnf?? 0) / 100;

                    for (int i = 0; i < listLevelAlarm.Count; i++)
                    {

                        if (i == 0)
                        {
                            if (percent >= listLevelAlarm[i].Value)
                            {
                                result = listLevelAlarm[i].Level;
                                currentValue = mnf;
                                prevValue = premnf;
                                break;
                            }
                        }
                        else if (i == listLevelAlarm.Count - 1)
                        {
                            if (percent == listLevelAlarm[i].Value)
                            {
                                result = listLevelAlarm[i].Level;
                                currentValue = mnf;
                                prevValue = premnf;
                                break;
                            }
                        }
                        else
                        {
                            if (percent > listLevelAlarm[i + 1].Value && percent <= listLevelAlarm[i].Value)
                            {
                                result = listLevelAlarm[i].Level;
                                currentValue = mnf;
                                prevValue = premnf;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    result = "";
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