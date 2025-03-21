﻿using System;
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
    public class GetSitesByDisplayGroupController : ApiController
    {
        // GET: GetSitesByDisplayGroup
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<SiteByDisplayGroupViewModel> GetSiteByDisplayGroup(string displayGroup)
        {
            GetSitesByDisplayGroupAction action = new GetSitesByDisplayGroupAction();

            return action.GetSiteByDisplayGroup(displayGroup);
        }
    }
}