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
    public class GetHistoryAlarmForLoggerController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public List<AlarmForLoggerViewModel> GetAlarmForLogger(string start, string end)
        {
            GetAlarmForLoggerAction action = new GetAlarmForLoggerAction();

            return action.GetAlarmForLogger(start, end);
        }
    }
}