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
    public class GetDataReportYearlySiteController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataReportYearlySite
        public List<DataReportYearlySiteViewModel> GetDataReportYearlySite(string siteid, string start, string end)
        {
            GetDataReportYearlySiteAction action = new GetDataReportYearlySiteAction();
            return action.GetDataReportYearlySite(siteid, start, end);
        }
    }
}