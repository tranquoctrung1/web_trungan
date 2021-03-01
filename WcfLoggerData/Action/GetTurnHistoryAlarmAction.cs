using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class GetTurnHistoryAlarmAction
    {
        public bool? GetTurnHistoryAlarm(string type)
        {
            bool? result = null;

            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"select [IsOn] from [t_Turn_History_Alarm] where [Type]  = '{type}'";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            result = bool.Parse(reader["IsOn"].ToString());
                        }
                        catch (Exception ex)
                        {
                            result = null;
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

            return result;
        }

    }
}