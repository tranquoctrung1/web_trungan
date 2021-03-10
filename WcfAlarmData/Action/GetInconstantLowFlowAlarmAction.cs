using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfAlarmData.Model;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetInconstantLowFlowAlarmAction
    {
        public ReturnValueViewModel GetInconstantLowFlowAlarm(string channelid)
        {
            string result = "";
            Nullable<double> currentValue = null;
            Nullable<double> prevValue = null;

            GetCurrentTimeAction getCurrentTimeAction = new GetCurrentTimeAction();
            GetLevelAlarmAction getLevelAlarmAction = new GetLevelAlarmAction();
            GetQitAction getQitAction = new GetQitAction();
            DateTime? currentDate = getCurrentTimeAction.GetCurrentTime(channelid);

            if(currentDate != null)
            {
                DateTime preCurrentDate = currentDate.Value.AddDays(-1);

                List<LevelAlarmViewModel> listLevelAlarm = getLevelAlarmAction.GetLevelAlarm();

                // Qit currnet date
                double? Qit = getQitAction.GetQit(channelid, currentDate.Value);

                // Qit prev current date
                double? prevQit = getQitAction.GetQit(channelid, preCurrentDate);
                if (Qit != null && prevQit != null)
                {
                    if (Qit < prevQit)
                    {
                        double percent = (prevQit ?? 0 - Qit ?? 0) / 100;
                        for (int i = 0; i < listLevelAlarm.Count; i++)
                        {

                            if (i == 0)
                            {
                                if (percent >= listLevelAlarm[i].Value)
                                {
                                    result = listLevelAlarm[i].Level;
                                    currentValue = Qit;
                                    prevValue = prevQit;
                                    break;
                                }
                            }
                            else if (i == listLevelAlarm.Count - 1)
                            {
                                if (percent > 0 && percent <= listLevelAlarm[i].Value)
                                {
                                    result = listLevelAlarm[i].Level;
                                    currentValue = Qit;
                                    prevValue = prevQit;
                                    break;
                                }
                            }
                            else
                            {
                                if (percent > listLevelAlarm[i + 1].Value && percent <= listLevelAlarm[i].Value)
                                {
                                    result = listLevelAlarm[i].Level;
                                    currentValue = Qit;
                                    prevValue = prevQit;
                                    break;
                                }
                            }
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