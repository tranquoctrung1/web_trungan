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
    public class GetDataStatisticLoggerController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataStatisticLogger
        public List<StatisticLoggerViewModel>  GetStatisticLogger(string provider, string mark, string model, string status, string install, string siteStatus, string company)
        {
            GetDataStatisticLoggerAction action = new GetDataStatisticLoggerAction();

            return action.GetStatisticLogger(provider, mark, model, status, install, siteStatus, company);
        }
    }
}