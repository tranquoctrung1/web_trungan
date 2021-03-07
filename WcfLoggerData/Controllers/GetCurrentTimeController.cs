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
    public class GetCurrentTimeController : ApiController
    {
        // GET: GetCurrentTime
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public DateTime GetCurrentTime(string channelid)
        {
            GetCurrentTimeAction action = new GetCurrentTimeAction();

            return action.GetCurrentTime(channelid);
        }
    }
}