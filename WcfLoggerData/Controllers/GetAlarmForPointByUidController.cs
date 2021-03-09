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
    public class GetAlarmForPointByUidController : ApiController
    {
        // GET: GetAlarmForPointByUid
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public List<AlarmForPointViewModel> GetHistoryAlarmByUid(string uid,string start, string end)
        {
            GetAlarmForPointByUidAction action = new GetAlarmForPointByUidAction();

            return action.GetHistoryAlarmByUid(uid, start, end);
        }
    }
}