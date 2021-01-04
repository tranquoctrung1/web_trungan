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
    public class GetDataStatisticSiteController : ApiController
    {
        // GET: GetDataStatisticSite
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<StatisticSiteViewModel> GetDataStatisticSite(string level, string group, string group2s, string meterModel, string companies, string status, string availability, string calc, string property, string takeover, string usingLogger, string modelLogger, string accre, string approve)
        {
            GetDataStatisticSiteAction action = new GetDataStatisticSiteAction();

            return action.GetStatisticSite(level, group, group2s, meterModel, companies, status, availability, calc, property, takeover, usingLogger, modelLogger, accre, approve);
        }
    }
}