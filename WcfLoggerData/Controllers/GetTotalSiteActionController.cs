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
    public class GetTotalSiteActionController : ApiController
    {
        // GET: GetTotalSiteAction
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public int GetTotalSiteAction()
        {
            GetTotalSiteActionAction action = new GetTotalSiteActionAction();


            return action.GetTotalSiteAction();
        }

    }
}