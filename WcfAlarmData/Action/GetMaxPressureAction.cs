using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfAlarmData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class GetMaxPressureAction
    {
        public double? GetMaxPressure(string channelid, DateTime start, DateTime end)
        {
            double? pressure = null;
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select max(Value) as Max from t_Data_{channelid} where TimeStamp between convert(nvarchar, '{start}', 120) and convert(nvarchar, '{end}', 120)";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            pressure = double.Parse(reader["Max"].ToString());
                        }
                        catch (Exception ex)
                        {
                            pressure = null;
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

            return pressure;
        }
    }
}