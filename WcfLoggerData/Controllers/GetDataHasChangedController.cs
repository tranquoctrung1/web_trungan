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
    public class GetDataHasChangedController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: GetDataHasChanged
        public List<StatisticSiteViewModel> GetDataHasChanged(string eventToCreate, string start)
        {
            int temp = int.Parse(eventToCreate);
            List<StatisticSiteViewModel> list = new List<StatisticSiteViewModel>();

            if (temp == 0)
            {
                GetDataAccreditedMeterAction action = new GetDataAccreditedMeterAction();
                list = action.GetDataAccreditedMeter(start);
            }
            else if(temp == 1)
            {
                GetDataMeterChangedAction action = new GetDataMeterChangedAction();
                list = action.GetDataMeterChanged(start);
            }
            else if (temp == 2)
            {
                GetDataTransmitterChangedAction action = new GetDataTransmitterChangedAction();
                list = action.GetDataTransmittersChanged(start);
            }
            else if (temp == 3)
            {
                GetDataLoggerChangedAction action = new GetDataLoggerChangedAction();
                list = action.GetDataLoggerChanged(start);
            }
            else if (temp == 4)
            {
                GetDataBatterryChangedAciton action = new GetDataBatterryChangedAciton();
                list= action.GetDataBatteryChanged(start);
            }
            else if (temp == 5)
            {
                GetDataBatteryTransmitterChangedAction action = new GetDataBatteryTransmitterChangedAction();
                list = action.GetDataBatteryTransmitterChanged(start);
            }
            else if (temp == 6)
            {
                GetDataBatteryLoggerChangedAction action = new GetDataBatteryLoggerChangedAction();
                list = action.GetDataBatteryLoggerChanged(start);
            }

            return list;
        }
    }
}