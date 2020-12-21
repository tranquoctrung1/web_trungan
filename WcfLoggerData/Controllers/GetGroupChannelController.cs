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
    public class GetGroupChannelController : ApiController
    {
        // GET: GetGroupChannel
        [EnableCors(origins: "*", headers: "*", methods: "*")]
       

        public List<GroupChannelViewModel> GetGroupChannel()
        {
            GetGroupChannelAction action = new GetGroupChannelAction();

            return action.GetGroupChannel();
        }
    }
}