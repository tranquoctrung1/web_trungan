using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfAlarmData.ConnectDB;
using WcfAlarmData.Model;

namespace WcfLoggerData.Action
{
    public class CheckAccreditationLoggerAction
    {
        public ReturnValueLoggerViewModel CheckAccreditationLogger(DateTime dateAccreditation)
        {
            int result = 0;
            int dayRemain = 0;
            
            if(dateAccreditation != null)
            {
                if((dateAccreditation - DateTime.Now).TotalDays >=  0 && (dateAccreditation - DateTime.Now).TotalDays <= 7)
                {
                    result = 1;
                    dayRemain = int.Parse(Math.Ceiling((dateAccreditation - DateTime.Now).TotalDays).ToString());
                }
                else if((DateTime.Now - dateAccreditation).TotalDays > 7)
                {
                    result  = 2;
                    dayRemain = int.Parse(Math.Ceiling((DateTime.Now - dateAccreditation).TotalDays).ToString());
                }
            }
            else
            {
                result = 0;
            }

            // return 0 is update, 1 is insert for almost check accreditation and 2 is insert for  out of date check accreditation

            ReturnValueLoggerViewModel returnValue = new ReturnValueLoggerViewModel();
            returnValue.Result = result;
            returnValue.DayRemain = dayRemain;

           return returnValue;
        }

    }

}