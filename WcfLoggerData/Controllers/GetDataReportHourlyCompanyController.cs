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
    public class GetDataReportHourlyCompanyController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataReportHourlyCompany
        public List<DataReportHourlyCompanyViewModel> GetDataReportHourlyCompany(string company, string start, string end)
        {
            GetDataReportHourlyCompanyAction action = new GetDataReportHourlyCompanyAction();

            return action.GetDataReportHourlyCompany(company, start, end);
        }
    }
}