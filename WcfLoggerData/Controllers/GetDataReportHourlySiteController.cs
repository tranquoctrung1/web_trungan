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
    public class GetDataReportHourlySiteController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataReportHourlySite
        public List<DataReportHourlySiteViewModel> GetDataReportHourlySite(string siteid, string start, string end)
        {
            GetDataReportHourlySiteAction action = new GetDataReportHourlySiteAction();
            return action.GetDataReportHourlySite(siteid, start, end);
        }
    }
}