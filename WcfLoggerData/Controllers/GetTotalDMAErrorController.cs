﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using WcfLoggerData.Action;

namespace WcfLoggerData.Controllers
{
    public class GetTotalDMAErrorController : ApiController
    {
        // GET: GetTotalDMAError
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public int GetTotalDMAError()
        {
            GetTotalDMAErrorAction action = new GetTotalDMAErrorAction();
            return action.GetTotalDMAError();
        }
    }
}