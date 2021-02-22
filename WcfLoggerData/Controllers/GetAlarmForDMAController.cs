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
    public class GetAlarmForDMAController : ApiController
    {
        // GET: GetAlarmForDMA
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public  List<AlarmForDMAViewModel> GetAlarmForDMA(string start, string end)
        {
            GetAlarmForDMAAction action = new GetAlarmForDMAAction();

            return action.GetAllAlarmForDMA(start, end);
        }
    }
}   