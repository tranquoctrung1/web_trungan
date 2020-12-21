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
    public class GetValueAlarmController : ApiController
    {
        // GET: GetValueAlarm
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<ValueAlarmViewModel> GetValueAlarm(string uid)
        {
            GetValueAlarmAction action = new GetValueAlarmAction();

            return action.GetValueAlarm(uid);
        }
    }
}