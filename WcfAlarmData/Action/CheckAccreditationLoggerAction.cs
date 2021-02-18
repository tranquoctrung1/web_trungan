using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfAlarmData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class CheckAccreditationLoggerAction
    {
        public int CheckAccreditationLogger(DateTime dateAccreditation)
        {
            int result = 0;
            
            if(dateAccreditation != null)
            {
                if((dateAccreditation - DateTime.Now).TotalDays >=  0 && (dateAccreditation - DateTime.Now).TotalDays <= 7)
                {
                    result = 1;
                }
                else if((DateTime.Now - dateAccreditation).TotalDays > 7)
                {
                    result  = 2;
                }
            }
            else
            {
                result = 0;
            }

            // return 0 is update, 1 is insert for almost check accreditation and 2 is insert for  out of date check accreditation

           return result;
        }

    }

}