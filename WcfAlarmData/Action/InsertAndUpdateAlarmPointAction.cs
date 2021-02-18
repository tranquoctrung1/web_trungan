using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.Model;
using WcfAlarmData.ULT;
using WcfLoggerData.Action;
using WcfLoggerData.Models;

namespace WcfAlarmData.Action
{
    class InsertAndUpdateAlarmPointAction
    {
        public int[] InsertAndUpdateAlarmPoint()
        {
            int nRowInsert = 0;
            int nRowUpdate = 0;

            List<AlarmForPointViewModel> list = new List<AlarmForPointViewModel>();

            GetListSitesAction getListSitesAction = new GetListSitesAction();
            GetChannelByLoggerAction getChannelByLoggerAction = new GetChannelByLoggerAction();
            GetInconstantHighFlowAlarmAction getInconstantHighFlowAlarmAction = new GetInconstantHighFlowAlarmAction();
            GetInconstantLowFlowAlarmAction getInconstantLowFlowAlarmAction = new GetInconstantLowFlowAlarmAction();
            GetMinNightFlowAlarmAction getMinNightFlowAlarmAction = new GetMinNightFlowAlarmAction();
            GetInconstantPressureAlarmAction getInconstantPressureAlarmAction = new GetInconstantPressureAlarmAction();
            GetCurrentTimeAction getCurrentTimeAction = new GetCurrentTimeAction();
            GetDelaySendDataAction getDelaySendDataAction = new GetDelaySendDataAction();
            UpdateAlarmForPointAction updateAlarmForPointAction = new UpdateAlarmForPointAction();

            GetAllAlarmForPointAction getAllAlarmForPointAction = new GetAllAlarmForPointAction();
            List<AlarmForPointViewModel> listAll = getAllAlarmForPointAction.GetAllAlarmForPoint();


            BinarySearch binarySearch = new BinarySearch();

            var listSites = getListSitesAction.getListSites();
        
            foreach (var site in listSites)
            {
                var channels = getChannelByLoggerAction.GetChannelByLogger(site.LoggerID);

                foreach (var channel in channels)
                {
                    string highFlowAlarm = getInconstantHighFlowAlarmAction.GetInconstantHighFlowAlarm(channel.ChannelId);
                    string lowFlowAlarm = getInconstantLowFlowAlarmAction.GetInconstantLowFlowAlarm(channel.ChannelId);
                    string inconstantMNF = getMinNightFlowAlarmAction.GetMinNightFlowAlarm(channel.ChannelId);
                    string inconstantPress = getInconstantPressureAlarmAction.GetInconstantPressureAlarm(channel.ChannelId);
                    bool delaySendData = getDelaySendDataAction.GetDelaySendData(channel.ChannelId);


                    string content = "";
                    int type = 0;
                    string level = "";
                    bool check = false;
                    if(delaySendData == true)
                    {
                        content = "LOST DATA";
                        type = 1;
                        level = "";
                        check = true;
                    }
                    else if (highFlowAlarm.Trim() != "")
                    {
                        content = "High Flow";
                        level = highFlowAlarm;
                        type = 2;
                        check = true;
                    }
                    else if (lowFlowAlarm.Trim() != "")
                    {
                        content = "Low Flow";
                        level = lowFlowAlarm;
                        type = 3;
                        check = true;
                    }
                    else if (inconstantMNF.Trim() != "")
                    {
                        content = "Min Night Flow";
                        level = inconstantMNF;
                        type = 5;
                        check = true;
                    }
                    else if (inconstantPress.Trim() != "")
                    {
                        content = "Inconstant Pressure";
                        level = inconstantPress;
                        type = 4;
                        check = true;
                    }

                    if (check == true)
                    {

                        AlarmForPointViewModel el = new AlarmForPointViewModel();
                        el.ChannelId = channel.ChannelId;
                        el.StartDateAlarm = getCurrentTimeAction.GetCurrentTime(channel.ChannelId);
                        el.EndDateAlarm = DateTime.Now;
                        el.Location = site.Location;
                        el.Content = content;
                        el.TypeAlarm = type;
                        el.Level = level;
                        el.IsFinish = false;

                        int isFind = -2;
                        if(el.StartDateAlarm != null)
                        {
                            isFind = binarySearch.BinarySearchInterative(listAll, el.StartDateAlarm.Value);
                            if(isFind == -1)
                            {
                                list.Add(el);
                            }
                        }

                    }
                    else
                    {
                        bool isExistsChannel = false;
                        foreach(var item in listAll)
                        {
                            if(item.ChannelId == channel.ChannelId && item.IsFinish == false)
                            {
                                isExistsChannel = true;
                                break;
                            }
                        }
                        if(isExistsChannel == true)
                        {
                            nRowUpdate += updateAlarmForPointAction.UpdateAlarmForPoint(channel.ChannelId);
                        }
                    }

                    Console.WriteLine(channel.ChannelId);
                }
            }

            InsertAlarmDBAction insertAlarmDBAction = new InsertAlarmDBAction();

            nRowInsert  = insertAlarmDBAction.InsertAlarmDB(list);

            int[] returnValue = new int[] { nRowInsert, nRowUpdate };

            return returnValue;
        }
    }
}
