using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;

namespace WcfLoggerData.Action
{
    public class GetCurrentTimeStampPressureChannelBySiteAction
    {
        public DateTime? GetCurrentTimeStampPressureChannelBySite(string siteid)
        {
            DateTime? timestamp = null;

            Connect connect = new Connect();

            try
            {
                string store = "p_Get_Current_TimeStamp_Pressrue_Chanel";

                connect.Connected();

                SqlCommand command = connect.ExcuteStoreProceduce(store);
                command.Parameters.Add(new SqlParameter("@siteid", siteid));

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            timestamp = DateTime.Parse(reader["TimeStamp"].ToString());
                        }
                        catch(Exception ex)
                        {
                            timestamp = null;
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

            if(timestamp == null )
            {
                return null;
            }
            else
            {
                return new DateTime(timestamp.Value.Year, timestamp.Value.Month, timestamp.Value.Day,0,0,0);
            }
        }
    }
}