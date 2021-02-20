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
    public class InsertAndUpdateAlarmLoggerController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpGet]
        public int InsertAndUpdateAlarmLogger()
        {
            //InsertAndUpdateHistoryAlarmLoggerAction action = new InsertAndUpdateHistoryAlarmLoggerAction();

            //return action.InsertAndUpdateHistoryAlarmLogger();
            return 0;
        }
    }
}