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
    public class GetDisplayGroupController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDisplayGroup
        public List<string> GetDisplayGroup()
        {
            GetDisplayGroupAction action = new GetDisplayGroupAction();

            return action.GetDisplayGroup();
        }
    }
}