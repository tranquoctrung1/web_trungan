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
    public class GetComplexDataByUidController : ApiController
    {
        // GET: GetComplexDataByUid
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public List<DataComplexViewModel> GetDataComplexByUid(string uid)
        {
            GetDataComplexByUidAction action = new GetDataComplexByUidAction();

            return action.GetDataComplexByUid(uid);
        }
    }
}