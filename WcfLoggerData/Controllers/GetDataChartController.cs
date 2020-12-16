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
    public class GetDataChartController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataChart
        public List<List<DataGraphViewModel>> GetListDataGraph(string siteid, string start, string end)
        {
            List<List<DataGraphViewModel>> matrix = new List<List<DataGraphViewModel>>();

            GetLoggerAction getLoggerAction = new GetLoggerAction();

            string loggerID = getLoggerAction.GetLogger(siteid);

            if(loggerID != null && loggerID.Trim() != "")
            {
                GetChannelConfigAction getChannelConfigAction = new GetChannelConfigAction();

                var listChannels = getChannelConfigAction.GetChannelConfig(loggerID);

                if(listChannels.Count > 0)
                {

                    foreach(var item in listChannels)
                    {
                        GetDataHistoryAction getDataHistoryAction = new GetDataHistoryAction();

                        List<DataGraphViewModel> list = getDataHistoryAction.GetDataHistory(item.ChannelId, start, end);

                        matrix.Add(list);
                    }
                }
            }

            return matrix;
        }
    }
}