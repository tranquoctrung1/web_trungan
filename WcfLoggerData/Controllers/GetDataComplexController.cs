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
    public class GetDataComplexController : ApiController
    {
        // GET: GetDataComplex
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<DataComplexViewModel> GetDataComplex()
        {
            GetListSitesAction getListSitesAction = new GetListSitesAction();

            List<DataComplexViewModel> list = getListSitesAction.getListSites();

            foreach(var item in list)
            {
                if(item.LoggerID != null && item.LoggerID.Trim() != "")
                {
                    GetChannelConfigAction getChannelConfigAction = new GetChannelConfigAction();
                    item.ListChannel = getChannelConfigAction.GetChannelConfig(item.LoggerID);
                }
            }

            return list;
        }
    }
}