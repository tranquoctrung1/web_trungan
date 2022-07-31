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
    public class GetTotalSiteErrorController : ApiController
    {
        // GET: GetTotalSiteError
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<TotalSiteErrorModel> GetTotalSiteError()
        {
            GetTotalSiteErrorAction action = new GetTotalSiteErrorAction();

            return action.GetTotalSiteError();
        }
    }
}