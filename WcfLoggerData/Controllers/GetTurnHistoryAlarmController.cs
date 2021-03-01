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
    public class GetTurnHistoryAlarmController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetTurnHistoryAlarm
        public bool? GetTurnHistoryAlarm(string type)
        {
            GetTurnHistoryAlarmAction action = new GetTurnHistoryAlarmAction();

            return action.GetTurnHistoryAlarm(type);
        }
    } 
}