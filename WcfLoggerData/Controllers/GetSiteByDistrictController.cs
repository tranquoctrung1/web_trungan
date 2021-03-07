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
    public class GetSiteByDistrictController : ApiController
    {
        // GET: GetSiteByDistrict
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<SiteByDisplayGroupViewModel> GetSiteByDisplayGroup(string district)
        {
            GetSiteByDistrictAction action = new GetSiteByDistrictAction();

            return action.GetSiteByDistrict(district);
        }
    }
}