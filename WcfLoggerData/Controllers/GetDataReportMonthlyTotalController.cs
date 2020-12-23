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
    public class GetDataReportMonthlyTotalController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataReportMonthlyTotal
        public List<DataReportMonthlyTotalViewModel> GetDataReportMonthlyTotal(string start, string end)
        {
            GetDataReportMonthlyTotalAction action = new GetDataReportMonthlyTotalAction();

            return action.GetDataReportMonthlyTotal(start, end);
        }
    }
}