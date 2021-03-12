using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class GetLastIndexValueAction
    {
        public double? GetLastIndexValue(string channelid)
        {
            double? value = null;
            Connect connect = new Connect();
            try
            {
                string sqlQuery = "select Sum(Value) as Sum from t_Data_" + channelid + "";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            value = double.Parse(reader["Sum"].ToString());
                        }
                        catch (Exception ex)
                        {
                            value = null;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connect.DisConnected();
            }

            return value;
        }
    }
}
