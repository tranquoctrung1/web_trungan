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
    public class GetDataReportDailyTotalController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataReportDailyTotal
        public List<DataReportDailyTotalViewModel> GetDataReportDailyTotal(string start, string end)
        {
            GetDataReportDailyTotalAction action = new GetDataReportDailyTotalAction();

            return action.GetDataReportDailyTotal(start, end);
        }
    }
}