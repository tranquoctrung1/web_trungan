using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDataComplexByUidAction
    {
        public List<DataComplexViewModel> GetDataComplexByUid(string uid)
        {
            GetListSitesAction getListSitesAction = new GetListSitesAction();

            List<DataComplexViewModel> list = getListSitesAction.getListSiteByUid(uid);

            foreach (var item in list)
            {
                if (item.LoggerID != null && item.LoggerID.Trim() != "")
                {
                    GetChannelConfigAction getChannelConfigAction = new GetChannelConfigAction();
                    item.ListChannel = getChannelConfigAction.GetChannelConfig(item.LoggerID);
                }
            }

            return list;
        }
    }
}