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
    public class GetDataDashBoardDailySiteController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataDashBoardDailySite
        public List<DataReportDailySiteViewModel> GetDataReportDailySite(string siteid, string start, string end)
        {
            GetDataDashBoardDailySiteAction action = new GetDataDashBoardDailySiteAction();
            return action.GetDataReportDailySite(siteid, start, end);
        }
    }
}