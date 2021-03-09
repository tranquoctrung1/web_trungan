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
    public class GetDistrictBySupervisorController : ApiController
    {
        // GET: GetDistrictBySupervisor
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public List<DistrictViewModel> GetDistrictNySupervisorId(string id)
        {
            GetDistrictBySupervisorIdAction action = new GetDistrictBySupervisorIdAction();

            return action.GetDistrictBySupervisorId(id);
        }
    }
}