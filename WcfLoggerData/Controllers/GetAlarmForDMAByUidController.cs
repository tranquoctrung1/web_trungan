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
    public class GetAlarmForDMAByUidController : ApiController
    {
        // GET: GetAlarmForDMAByUid
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public List<AlarmForDMAViewModel> GetAllAlarmForDMAByUid(string uid, string start, string end)
        {
            GetAlarmForDMAByUidAction action = new GetAlarmForDMAByUidAction();

            return action.GetAllAlarmForDMAByUid(uid, start, end);
        }
    }
}