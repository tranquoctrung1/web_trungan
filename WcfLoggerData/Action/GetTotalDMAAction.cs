using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class GetTotalDMAAction
    {
        public int GetTotalDMA()
        {
            int result = 0;
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select count(*) as Amount from t_Site_Companies";
                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            result = int.Parse(reader["Amount"].ToString());
                        }
                        catch(Exception ex)
                        {
                            result = 0;
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

            return result;
        }
    }
}