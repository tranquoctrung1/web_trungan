using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using WcfLoggerData.Action;

namespace WcfLoggerData.Controllers
{
    public class GetTimeController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetTime
        public Nullable<DateTime> GetTime(string siteid)
        {
            Nullable<DateTime> current = null;

            GetLoggerAction getLoggerAction = new GetLoggerAction();

            string loggerID = getLoggerAction.GetLogger(siteid);

            if (loggerID != null && loggerID.Trim() != "")
            {
                GetChannelConfigAction getChannelConfigAction = new GetChannelConfigAction();

                var listChannels = getChannelConfigAction.GetChannelConfig(loggerID);

                if (listChannels.Count > 0)
                {
                    string channelID = "";

                    GetDataHistoryAction getDataHistoryAction = new GetDataHistoryAction();

                    foreach(var channel in listChannels )
                    {
                        if(getDataHistoryAction.GetCountDataHistory(channel.ChannelId) > 0)
                        {
                            channelID = channel.ChannelId;
                            break;
                        }
                    }

                    if(channelID.Trim() != "" && channelID != null)
                    {
                        GetTimeOfFirstChannel getTimeOfFirstChannel = new GetTimeOfFirstChannel();

                        current = getTimeOfFirstChannel.GetTime(channelID);
                    }
                }
            }

            return current;
        }
    }
}