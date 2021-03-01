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
    public class GetStatisticDeviceLoggerController : ApiController
    {
        // GET: GetStatisticDeviceLogger
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<DeviceLoggerViewModel> GetStatisticDeviceLogger()
        {
            GetStatisticDeviceLoggerAction action = new GetStatisticDeviceLoggerAction();

            return action.GetDeviceLogger();
        }
    }
}