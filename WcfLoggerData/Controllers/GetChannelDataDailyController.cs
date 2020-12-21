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
    public class GetChannelDataDailyController : ApiController
    {
        // GET: GetChannelDataDaily
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<ChannelDataDailyViewModel> GetChannelDataDaily(string siteid, string start, string end)
        {
            GetChannelDataDailyAction action = new GetChannelDataDailyAction();

            return action.GetChannelDataDaily(siteid, start, end);
        }
    }
}