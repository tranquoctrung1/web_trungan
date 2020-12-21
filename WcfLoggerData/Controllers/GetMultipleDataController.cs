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
    public class GetMultipleDataController : ApiController
    {
        // GET: GetMultipleData
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<ChannelMultipleDataViewModel> GetChannelMultipleData(string listChannelId, string start, string end)
        {
            GetMultipleDataAction action = new GetMultipleDataAction();

            return action.GetChannelMultipleData(listChannelId, start, end);    
        }
    }
}