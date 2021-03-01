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
    public class GetStatisticDateExpireBatteryLoggerController : ApiController
    {
        // GET: GetStatisticDateExpireBatteryLogger
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public List<DeviceLoggerViewModel> GetStatisticDateExpireBatteryLogger(string start, string end)
        {
            GetStatisticDateExpireBatteryLoggerAction action = new GetStatisticDateExpireBatteryLoggerAction();

            return action.GetDeviceLogger(start, end);
        }

    }
}