using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataLoggerGetBL
/// </summary>
public class DataLoggerGetBL
{
   public double? GetValuePrevDay(DateTime start, string channelid)
    {
        double? result = null;

        Connect connect = new Connect();
        try
        {
            string sqlQuery = "select Value from t_Data_" + channelid + "where TimeStamp = convert(nvarchar, '" + start + "', 120)";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    try
                    {
                        result = double.Parse(reader["Value"].ToString());
                    }
                    catch(Exception ex)
                    {
                        result = null;
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

    public List<LoggerData> GetLoggerData(string channelid, string start, string end)
    {
        List<LoggerData> list = new List<LoggerData>();

        DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
        DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);

        Connect connect = new Connect();
        try
        {
            string sqlQuery = "select TimeStamp, Value from t_Data_" + channelid + " where TimeStamp between convert(nvarchar, '" + timeStart + "', 120) and convert(nvarchar, '" + timeEnd + "', 120)";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LoggerData el = new LoggerData();

                    try
                    {
                        el.TimeStamp = DateTime.Parse(reader["TimeStamp"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.TimeStamp = null;
                    }
                    try
                    {
                        el.Value = double.Parse(reader["Value"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Value = null;
                    }

                    list.Add(el);
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

        return list;
    }
}