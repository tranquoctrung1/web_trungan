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
    public class GetDataStatisticTransmitterController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataStatisticTransmitter
        public List<StatisticTransmitterViewModel> GetStatisticTransmitter(string provider, string mark, string size, string model, string status, string install, string siteStatus, string company)
        {
            GetDataStatisticTransmitterAction action = new GetDataStatisticTransmitterAction();

            return action.GetStatisticTransmitter(provider, mark, size, model, status, install, siteStatus, company);
        }
    }
}