using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GetLastTimeStamp
/// </summary>
public class GetLastTimeStamp
{
   public DateTime? GetLastTimeStampAction(string channelid)
    {
        DateTime? date = null;
        Connect connect = new Connect();
        try
        {
            string sqlQuery = "select top(1) TimeStamp from t_Data_" + channelid + " order by TimeStamp desc";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try
                    {
                        date = DateTime.Parse(reader["TimeStamp"].ToString());
                    }
                    catch (Exception ex)
                    {
                        date = null;
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

        return date;
    }
}