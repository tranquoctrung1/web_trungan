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

    public List<LoggerData> GetLoggerData(string channelid, DateTime start, DateTime end)
    {
        List<LoggerData> list = new List<LoggerData>();

        Connect connect = new Connect();
        try
        {
            string sqlQuery = "select TimeStamp, Value from t_Data_" + channelid + "where TimeStamp between convert(nvarchar, '" + start + "', 120) and convert(nvarchar, '" + end + "', 120)";

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