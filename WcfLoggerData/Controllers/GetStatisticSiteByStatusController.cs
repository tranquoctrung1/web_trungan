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
    public class GetStatisticSiteByStatusController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetStatisticSiteByStatus
        public List<StatisticSiteViewModel> GetStatisticSiteByStatus()
        {
            GetStatisticSiteByStatusAction action = new GetStatisticSiteByStatusAction();
            return action.GetAll();
        }

    }
}