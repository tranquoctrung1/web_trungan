using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class GetTimeOfFirstChannel
    {
        public Nullable<DateTime> GetTime(string channelID)
        {
            Nullable<DateTime> current = null;
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select top(1) TimeStamp from t_Data_{channelID} order by TimeStamp desc";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        try
                        {
                            current = DateTime.Parse(reader["TimeStamp"].ToString());
                        }
                        catch (Exception ex)
                        {
                            current = null;
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

            return current;
        }
    }
}