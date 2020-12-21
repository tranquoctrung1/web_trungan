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
    public class GetChannelByLoggerController : ApiController
    {
        // GET: GetChannelByLogger
        [EnableCors(origins: "*", headers: "*", methods: "*")]
       
        public List<ChannelByLoggerViewModel> GetChannelByLogger(string loggerid)
        {
            GetChannelByLoggerAction action = new GetChannelByLoggerAction();

            return action.GetChannelByLogger(loggerid);
        }
    }
}