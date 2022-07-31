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
    public class GetTotalSiteHasDataController : ApiController
    {
        // GET: GetTotalSiteHasData
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public List<TotalSiteHasValueModel> GetTotalSiteHasData()
        {
            GetTotalSiteHasDataAction action = new GetTotalSiteHasDataAction();

            return action.GetTotalSiteHasData();
        }
    }
}