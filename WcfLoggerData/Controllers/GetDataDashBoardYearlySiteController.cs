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
    public class GetDataDashBoardYearlySiteController : ApiController
    {
        // GET: GetDataDashBoardYearlySite
        [EnableCors(origins: "*", headers: "*", methods: "*")]
       
        public List<DataReportYearlySiteViewModel> GetDataReportYearlySite(string siteid, string start, string end)
        {
            GetDataDashBoardYearlySiteAction action = new GetDataDashBoardYearlySiteAction();

            return action.GetDataReportYearlySite(siteid, start, end);
        }
    }
}