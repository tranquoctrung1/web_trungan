using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfAlarmData.ConnectDB;
using WcfAlarmData.Model;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class CheckYearBatteryAction
    {
        public ReturnValueLoggerViewModel  CheckYearBattery(DateTime dateInstallBattery, int yearBattery)
        {
            // comparing time now is not into 7 days alarm of battery year
            int result = 0;
            int dayRemain = 0;
           
            if(dateInstallBattery != null && yearBattery != null)
            {
                if((dateInstallBattery.AddMonths(yearBattery) - DateTime.Now).TotalDays >= 0 && (dateInstallBattery.AddMonths(yearBattery)  -  DateTime.Now).TotalDays <= 7)
                {
                    result = 1;
                    dayRemain = int.Parse(Math.Ceiling((dateInstallBattery.AddMonths(yearBattery) - DateTime.Now).TotalDays).ToString());
                }
                else if((DateTime.Now  - dateInstallBattery.AddMonths(yearBattery)).TotalDays > 7)
                {
                    result = 2;
                    dayRemain = int.Parse(Math.Ceiling((DateTime.Now - dateInstallBattery.AddMonths(yearBattery)).TotalDays).ToString());
                }
            }
            else
            {
                result = 0;
            }

            // return 0 is update check battery year alarm, 1 is insert almost check year battery and 2 is insert out of date check year battery

            ReturnValueLoggerViewModel returnValue = new ReturnValueLoggerViewModel();
            returnValue.Result = result;
            returnValue.DayRemain = dayRemain;

            return returnValue;
        }
    }
}