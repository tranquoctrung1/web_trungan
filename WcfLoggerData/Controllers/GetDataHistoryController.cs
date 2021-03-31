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
    public class GetDataHistoryController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataHistory
        public List<DataGraphViewModel> GetDataHistory(string channelid, string start, string end)
        {
            GetDataHistoryAction getDataHistoryAction = new GetDataHistoryAction();

            return  getDataHistoryAction.GetDataHistory(channelid, start, end);
        }
    }
}