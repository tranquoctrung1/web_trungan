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
    public class GetDistrictController : ApiController
    {
        // GET: GetDistrict
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<DistrictViewModel> GetDistrict()
        {
            GetDistrictAction action = new GetDistrictAction();

            return action.GetDistrict();
        }
    }
}