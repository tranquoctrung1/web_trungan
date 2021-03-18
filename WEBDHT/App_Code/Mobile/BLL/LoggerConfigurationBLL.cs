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

    public bool CheckExistsLoggerPoint(string siteid)
    {
        bool check = false;

        Connect connect = new Connect();
        try
        {
            string sqlQuery = "select * from t_Devices_SitesConfigs where SiteId = '" + siteid + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                check = true;
            }
            else
            {
                check = false;
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

        return check;
    }

    public SiteConfig GetLoggerPointConfigById(string siteid)
    {
        SiteConfig site = new SiteConfig();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select Id, SiteId, Tel, Pressure, Forward, Reverse, Interval, BeginTime, Pressure1, DelayTime from t_Devices_SitesConfigs where SiteId = '" + siteid + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    try
                    {
                        site.Id = reader["Id"].ToString();
                    }
                    catch(Exception ex)
                    {
                        site.Id = "";
                    }
                    try
                    {
                        site.SiteId = reader["SiteId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        site.SiteId = "";
                    }
                    try
                    {
                        site.Pressure = byte.Parse(reader["Pressure"].ToString());
                    }
                    catch (Exception ex)
                    {
                        site.Pressure = null;
                    }
                    try
                    {
                        site.Pressure1 = byte.Parse(reader["Pressure1"].ToString());
                    }
                    catch(Exception ex)
                    {
                        site.Pressure1 = null;
                    }
                    try
                    {
                        site.Forward = byte.Parse(reader["Forward"].ToString());
                    }
                    catch (Exception ex)
                    {
                        site.Forward = null;
                    }
                    try
                    {
                        site.Reverse = byte.Parse(reader["Reverse"].ToString());
                    }
                    catch (Exception ex)
                    {
                        site.Reverse = null;
                    }
                    try
                    {
                        site.Interval = short.Parse(reader["Interval"].ToString());
                    }
                    catch (Exception ex)
                    {
                        site.Interval = null;
                    }
                    try
                    {
                        site.BeginTime = DateTime.Parse(reader["BeginTime"].ToString());
                    }
                    catch (Exception ex)
                    {
                        site.BeginTime = null;
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

        return site;
    }

    public List<string> GetListLoggerId()
    {
        List<string> list = new List<string>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select Serial from t_Devices_Loggers order by Serial";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    string el = "";

                    try
                    {
                        el = reader["Serial"].ToString();
                    }
                    catch(Exception ex)
                    {
                        el = "";
                    }

                    list.Add(el);
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

        return list;
    }

    public List<t_Channel_Configurations> GetChannelByLoggerId(string loggerid)
    {
        List<t_Channel_Configurations> list = new List<t_Channel_Configurations>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select Id, Name, Unit from t_Devices_ChannelsConfigs where LoggerId = '" + loggerid + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    t_Channel_Configurations el = new t_Channel_Configurations();

                    try
                    {
                        el.ChannelId = reader["Id"].ToString();
                    }
                    catch(Exception ex)
                    {
                        el.ChannelId = "";
                    }
                    try
                    {
                        el.ChannelName = reader["Name"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.ChannelName = "";
                    }
                    try
                    {
                        el.Unit = reader["Unit"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Unit = "";
                    }

                    list.Add(el);
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

        return list;
    }
}