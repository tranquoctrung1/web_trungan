using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetInconstantPressureAlarmAction
    {
        public string GetInconstantPressureAlarm(string channelid)
        {
            string result = "";

            GetMinPressureAction getMinPressureAction = new GetMinPressureAction();
            GetMaxPressureAction getMaxPressureAction = new GetMaxPressureAction();
            GetCurrentTimeAction getCurrentTimeAction = new GetCurrentTimeAction();
            GetLevelAlarmAction getLevelAlarmAction = new GetLevelAlarmAction();

            DateTime? current = getCurrentTimeAction.GetCurrentTime(channelid);

            if(current != null)
            {
                DateTime start = new DateTime(current.Value.Year, current.Value.Month, current.Value.Day, 0,0,0);
                DateTime end = new DateTime(current.Value.Year, current.Value.Month, current.Value.Day, 23, 59, 59);
                DateTime prevStart = start.AddDays(-1);
                DateTime prevEnd = end.AddDays(-1);

                List<LevelAlarmViewModel> listLevelAlarm = getLevelAlarmAction.GetLevelAlarm();

                // min press current date
                double? minPress = getMinPressureAction.GetMinPressure(channelid, start, end);
                // max press current date
                double? maxPress = getMaxPressureAction.GetMaxPressure(channelid, start, end);
                // min press prev current date
                double? preMinPress = getMinPressureAction.GetMinPressure(channelid, prevStart, prevEnd);
                // max press prev current date
                double? preMaxPress = getMaxPressureAction.GetMaxPressure(channelid, prevStart, prevEnd);

                if (minPress != null && maxPress != null && preMinPress != null && preMaxPress != null)
                {
                    if(minPress != preMinPress )
                    {
                        double percent = Math.Abs(minPress?? 0 - preMinPress??0) / 100;

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
                    else if(maxPress != preMaxPress)
                    {
                        double percent = Math.Abs(minPress ?? 0 - preMinPress ?? 0) / 100;

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
                        
                }
                else
                {
                    result = "";
                }
            }
            
            return result;
        }
    }
}