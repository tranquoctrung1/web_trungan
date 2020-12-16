using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class GetLoggerAction
    {
        public string GetLogger (string siteid)
        {
            string loggerId = "";

            try
            {

                string sqlQuery = $" select dc.Id as LoggerID from t_Site_Sites s join t_Devices_SitesConfigs dc on dc.SiteId = s.Id where s.Id = '{siteid}'";

                Connect.ConnectToDataBase();

                SqlDataReader reader = Connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            loggerId = reader["LoggerID"].ToString();
                        }
                        catch(SqlException ex)
                        {
                            loggerId = "";
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Connect.DisconnectToDataBase();
            }

            return loggerId;
        }
    }
}