using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using WcfLoggerData.Action;
using WcfLoggerData.Models;

namespace WcfLoggerData.Controllers
{
    public class GetAlarmForPointController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetAlarmForPoint
        public List<AlarmForPointViewModel> GetAlarmForPoint()
        {
            List<AlarmForPointViewModel> list = new List<AlarmForPointViewModel>();

            GetListSitesAction getListSitesAction = new GetListSitesAction();
            GetChannelByLoggerAction getChannelByLoggerAction = new GetChannelByLoggerAction();
            GetInconstantHighFlowAlarmAction getInconstantHighFlowAlarmAction = new GetInconstantHighFlowAlarmAction();
            GetInconstantLowFlowAlarmAction getInconstantLowFlowAlarmAction = new GetInconstantLowFlowAlarmAction();
            GetMinNightFlowAlarmAction getMinNightFlowAlarmAction = new GetMinNightFlowAlarmAction();
            GetInconstantPressureAlarmAction getInconstantPressureAlarmAction = new GetInconstantPressureAlarmAction();
            GetCurrentTimeAction getCurrentTimeAction = new GetCurrentTimeAction();

            GetAlarmForPointAction getHistoryAlarmAction = new GetAlarmForPointAction();

            //list = getHistoryAlarmAction.GetHistoryAlarm();

            var listSites = getListSitesAction.getListSites();

            foreach(var site in listSites)
            {
                var channels = getChannelByLoggerAction.GetChannelByLogger(site.LoggerID);

                foreach(var channel in channels)
                {
                    string highFlowAlarm = getInconstantHighFlowAlarmAction.GetInconstantHighFlowAlarm(channel.ChannelId);
                    string lowFlowAlarm = getInconstantLowFlowAlarmAction.GetInconstantLowFlowAlarm(channel.ChannelId);
                    string inconstantMNF = getMinNightFlowAlarmAction.GetMinNightFlowAlarm(channel.ChannelId);
                    string inconstantPress = getInconstantPressureAlarmAction.GetInconstantPressureAlarm(channel.ChannelId);

                    
                    string type = "";
                    string level = "";
                    bool check = false;
                    if(highFlowAlarm.Trim() != "")
                    {
                        type = "High Flow";
                        level = highFlowAlarm;
                        check = true;
                    }
                    else if(lowFlowAlarm.Trim() != "")
                    {
                        type = "Low Flow";
                        level = lowFlowAlarm;
                        check = true;
                    }
                    else if(inconstantMNF.Trim() != "")
                    {
                        type = "Min Night Flow";
                        level = inconstantMNF;
                        check = true;
                    }
                    else if(inconstantPress.Trim() != "")
                    {
                        type = "Inconstant Pressure";
                        level = inconstantPress;
                        check = true;
                    }

                    if(check == true)
                    {
                        AlarmForPointViewModel el = new AlarmForPointViewModel();
                        el.ChannelId = channel.ChannelId;
                        el.StartDateAlarm = getCurrentTimeAction.GetCurrentTime(channel.ChannelId);
                        el.EndDateAlarm = getCurrentTimeAction.GetCurrentTime(channel.ChannelId);
                        el.Location = site.Location;
                        el.TypeAlarm = type;
                        el.Level = level;

                        list.Add(el);
                    }
                }
            }

            return list;
        }
    }
}