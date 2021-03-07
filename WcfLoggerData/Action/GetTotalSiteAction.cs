using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class GetTotalSiteAction
    {
        public int GetTotalSite()
        {
            int count = 0;

            Connect connect = new Connect();

            try
            {
                string sqlQuery = "select Count(*) as Amount from t_Site_Sites";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            count = int.Parse(reader["Amount"].ToString());
                        }
                        catch(Exception ex)
                        {
                            count = 0;
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
                connect.DisConnected();
            }

            return count;
        }
    }
}