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
    public class GetChannelByGroupChannelController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetChannelByGroupChannel
        public List<ChannelByGroupChannelViewModel> GetChannelByGroupChannel(string loggerid, string groupChannel)
        {
            GetChannelByGroupChannelAction action = new GetChannelByGroupChannelAction();

            return action.GetChannelByGroupChannel(loggerid, groupChannel);
        }
    }
}