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
    public class GetDataReportMonthlyManagerController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataReportMonthlyManager
        public List<DataReportMonthlyManagerViewModel> GetDataReportMonthlyManager(string manager, string start, string end)
        {
            GetDataReportMonthlyManagerAction action = new GetDataReportMonthlyManagerAction();

            return action.GetDataReportMonthlyManager(manager, start, end);
        }
    }
}