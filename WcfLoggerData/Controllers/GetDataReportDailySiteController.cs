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
    public class GetDataReportDailySiteController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataReportDailySite
        public List<DataReportDailySiteViewModel> GetDataReportDailySite(string siteid, string start, string end)
        {
            GetDataReportDailySiteAction action = new GetDataReportDailySiteAction();
            return action.GetDataReportDailySite(siteid, start, end);
        }
    }
}