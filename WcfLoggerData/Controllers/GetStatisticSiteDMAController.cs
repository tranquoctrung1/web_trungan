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
    public class GetStatisticSiteDMAController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetStatisticSiteDMA
        public List<StatisticSiteDMAViewModel> GetStatisticSiteDMA()
        {
            GetStatisticSiteDMAAction action = new GetStatisticSiteDMAAction();

            return action.GetStatisticSiteDMA();
        }
    }
}