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
    public class GetChannelDataChartController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetChannelDataChart
        public List<DataChannelChartViewModel> GetDataChannelChart(string channelid, string start, string end)
        {
            DataChannelChartAction action = new DataChannelChartAction();

            return action.GetDataChannelChart(channelid, start, end);
        }
    }
}