using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLoggerData.Action;

namespace WcfAlarmData.Action
{
    class GetDelaySendDataAction
    {
        public bool GetDelaySendData(string channelid)
        {
            bool check = false;


            GetCurrentTimeAction getCurrentTimeAction = new GetCurrentTimeAction();
            CheckExistsAlarmAction checkExistsAlarmAction = new CheckExistsAlarmAction();
            GetLoggerByChannelIdAction getLoggerByChannelIdAction = new GetLoggerByChannelIdAction();
            GetIntervalTimeAction getIntervalTimeAction = new GetIntervalTimeAction();

            DateTime now = DateTime.Now;

            DateTime? current = getCurrentTimeAction.GetCurrentTime(channelid);

            if(current != null )
            {
                string loggerid = getLoggerByChannelIdAction.GetSiteByChannelId(channelid);

                if(loggerid.Trim() != "" && loggerid != null)
                {
                    int interval =  getIntervalTimeAction.GetIntervalTime(loggerid);

                    // if null is interval = 15 minutes as default

                    double diff = (now - current.Value).TotalMinutes;

                    if(diff  > (interval * 2))
                    {
                        check = true;
                    }
                }
            }
            return check;

        }
    }
}
