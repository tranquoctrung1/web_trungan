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
    public class GetStatisticDMAByUidController : ApiController
    {
        // GET: GetStatisticDMAByUid
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public List<StatisticDMAViewModel> GetStatisticDMAByUid(string uid)
        {
            GetStatisticDMAByUidAction action = new GetStatisticDMAByUidAction();
            return action.GetStatisticDMAByUid(uid);
        }
    }
}