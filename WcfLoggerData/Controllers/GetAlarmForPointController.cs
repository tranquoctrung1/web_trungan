﻿using System;
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
    public class GetAlarmForPointController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetAlarmForPoint
        public List<AlarmForPointViewModel> GetAlarmForPoint(string start, string end)
        {
            GetAlarmForPointAction action = new GetAlarmForPointAction();

            return action.GetHistoryAlarm(start, end);
            
        }
    }
}