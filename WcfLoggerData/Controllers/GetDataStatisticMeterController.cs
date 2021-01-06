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
    public class GetDataStatisticMeterController : ApiController
    {
        // GET: GetDataStatisticMeter
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<StatisticMeterViewModel> GetStatisticMeter(string provider, string nation, string mark, string size, string model, string status, string install, string siteStatus, string company)
        {
            GetStatisticMeterAction action = new GetStatisticMeterAction();
            return action.GetStatisticMeter(provider, nation, mark, size, model, status, install, siteStatus, company);
        }
    }
}