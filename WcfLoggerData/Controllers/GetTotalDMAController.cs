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
    public class GetTotalDMAController : ApiController
    {
        // GET: GetTotalDMA
        [EnableCors(origins: "*", headers: "*", methods: "*")]
       
        public int GetTotalDMA()
        {
            GetTotalDMAAction action = new GetTotalDMAAction();
            return action.GetTotalDMA();
        }
    }
}