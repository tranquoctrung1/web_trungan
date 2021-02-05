using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class CheckAccreditationLoggerAction
    {
        public bool CheckAccreditationLogger(string id)
        {
            bool isUpdate = false;
            Nullable<DateTime> dateAccreditation = null;

            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"select DateAccreditation from t_Devices_Loggers where Serial = '{id}'";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            dateAccreditation = DateTime.Parse(reader["DateAccreditation"].ToString());
                        }
                        catch(Exception ex)
                        {
                            dateAccreditation = null;
                        }
                    }
                }
                else
                {
                    isUpdate = false;
                }

                if(dateAccreditation != null)
                {
                    if(Math.Abs((dateAccreditation.Value - DateTime.Now).TotalDays ) > 7)
                    {
                        isUpdate = true;
                    }
                    else
                    {
                        isUpdate = false;
                    }
                }
                else
                {
                    isUpdate = false;
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connect.DisConnected();
            }

            return isUpdate;
        }

    }

}