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
    public class GetDataReportHourlyTotalController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataReportHourlyTotal
        public List<DataReportHourlyTotalViewModel> GetDataReportHourlyTotal(string start, string end)
        {
            GetDataReportHourlyTotalAction action = new GetDataReportHourlyTotalAction();

            return action.GetDataReportHourlyTotal(start, end);
        }
    }
}