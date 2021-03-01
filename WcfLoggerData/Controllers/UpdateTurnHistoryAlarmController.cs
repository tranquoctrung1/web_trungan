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
    public class UpdateTurnHistoryAlarmController : ApiController
    {
        // GET: UpdateTurnHistoryAlarm
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public int UpdateTurnHistoryAlarm(string isOn, string type)
        {
            UpdateTurnHistoryAlarmAction action = new UpdateTurnHistoryAlarmAction();

            TurnHistoryAlarmViewModel t = new TurnHistoryAlarmViewModel();

            t.IsOn = bool.Parse(isOn);
            t.Type = type;

            return action.UpdateTurnHistoryAlarm(t);
        }
    }
}