using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using WcfLoggerData.Action;

namespace WcfLoggerData.Controllers
{
    public class GetDisplayGroupByUidController : ApiController
    {
        // GET: GetDisplayGroupByUid
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public List<string> GetDisplayGroupByUid(string uid)
        {
            GetDisplayGroupByUidAction action = new GetDisplayGroupByUidAction();
            return action.GetDisplayGroupByUid(uid);
        }
    }
}