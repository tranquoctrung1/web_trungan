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
    public class GetDataDashBoardMonthlySiteController : ApiController
    {
        // GET: GetDataDashBoardMonthlySite
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<DataReportMonthlySiteViewModel> GetDataReportMonthlySite(string siteid, string start, string end)
        {
            GetDataDashBoardMonthlyAction action = new GetDataDashBoardMonthlyAction();

            return action.GetDataReportMonthlySite(siteid, start, end);
        }
    }
}