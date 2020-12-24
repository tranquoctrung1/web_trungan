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
    public class GetDataDashBoardHourlySiteController : ApiController
    {
        // GET: GetDataDashBoardHourlySite
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<DataReportHourlySiteViewModel> GetDataReportHourlySite(string siteid, string start, string end)
        {
            GetDataDashBoardHourlySiteAction action = new GetDataDashBoardHourlySiteAction();
            return action.GetDataReportHourlySite(siteid, start, end);
        }
    }
}