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
    public class GetDataReportDailyManagerController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataDailyManager
        public List<DataReportDailyManagerViewModel> GetDataReportDailyManager(string manager, string start, string end)
        {
            GetDataReportDailyManagerAction action = new GetDataReportDailyManagerAction();

            return action.GetDataReportDailyManager(manager, start, end);
        }
    }
}