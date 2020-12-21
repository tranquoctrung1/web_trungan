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
    public class GetGroupChannelByLoggerController : ApiController
    {
        // GET: GetGroupChannelByLogger
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<GroupChannelByLoggerViewModel> GetGroupChannelByLogger(string loggerid)
        {
            GetGroupChannelByLoggerAction action = new GetGroupChannelByLoggerAction();

            return action.GetGroupChannelByLogger(loggerid);
        }
    }
}