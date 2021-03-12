using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoggerConfigurationBLL
/// </summary>
public class LoggerConfigurationBLL
{
    public LoggerConfigurations GetLoggerConfiguration(string loggerid)
    {
        LoggerConfigurations el = new LoggerConfigurations();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = " select [Id], [SiteId], [Pressure], [Forward],  [Reverse], [Pressure1], [DelayTime], [Interval] from [t_Devices_SitesConfigs] where [Id] = '" + loggerid + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {


                    try
                    {
                        el.LoggerId = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LoggerId = "";
                    }
                    try
                    {
                        el.SiteId = reader["SiteId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteId = "";
                    }
                    try
                    {
                        el.Pressure1 = byte.Parse(reader["Pressure"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Pressure1 = null;
                    }
                    try
                    {
                        el.Pressure2 = byte.Parse(reader["Pressure1"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Pressure2 = null;
                    }
                    try
                    {
                        el.ForwardFlow = byte.Parse(reader["Forward"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.ForwardFlow = null;
                    }
                    try
                    {
                        el.ReverseFlow = byte.Parse(reader["Reverse"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.ReverseFlow = null;
                    }
                    try
                    {
                        el.TimeDelayAlarm = int.Parse(reader["DelayTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.TimeDelayAlarm = null;
                    }
                    try
                    {
                        el.Interval = byte.Parse(reader["Interval"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Interval = null;
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

        return el;
    }
}