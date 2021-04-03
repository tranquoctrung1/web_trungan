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
    public class GetDetailTableController : ApiController
    {
        // GET: GetDetailTable
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<DetailTableViewModel> GetDetailTable(string siteid, string start, string end)
        {
            GetDataDetailTableAction action = new GetDataDetailTableAction();

            return action.GetDetailTable(siteid, start, end);
        }
    }
}