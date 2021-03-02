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
    public class GetStatisticDMAController : ApiController
    {
        // GET: GetStatisticDMA
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<StatisticDMAViewModel> GetStatisticDMA()
        {
            GetStatisticDMAAction action = new GetStatisticDMAAction();

            return action.GetStatisticDMA();
        }
    }
}