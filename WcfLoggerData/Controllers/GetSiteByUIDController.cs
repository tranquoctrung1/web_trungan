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
    public class GetSiteByUIDController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetSiteByUID
        public List<SiteResultByUIDViewModel> GetSiteResultByUID(string uid)
        {
            GetSiteByUIDAction action = new GetSiteByUIDAction();

            return action.GetSiteResultByUID(uid);
        }
    }
}