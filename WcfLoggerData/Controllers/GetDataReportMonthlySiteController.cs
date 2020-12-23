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
    public class GetDataReportMonthlySiteController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataReportMonthlySite
        public List<DataReportMonthlySiteViewModel> GetDataReportMonthlySite(string siteid, string start, string end)
        {
            GetDataReportMonthlySiteAction action = new GetDataReportMonthlySiteAction();

            return action.GetDataReportMonthlySite(siteid, start, end);
        }
    }
}