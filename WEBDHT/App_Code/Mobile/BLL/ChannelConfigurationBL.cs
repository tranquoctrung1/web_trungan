using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChannelConfigurationBL
/// </summary>
public class ChannelConfigurationBL
{
    public List<t_Channel_Configurations> GetChannelConfigurationsByLoggerID(string loggerid)
    {
        List<t_Channel_Configurations> list = new List<t_Channel_Configurations>();

        GetLastTimeStampIndex getLastTimeStampIndex = new GetLastTimeStampIndex();
        GetLastIndexValue getLastIndexValue = new GetLastIndexValue();
        GetLastValue getLastValue = new GetLastValue();
        GetLastTimeStamp getLastTimeStamp = new GetLastTimeStamp();

        Connect connect = new Connect();
        
        try
        {
            string sqlQuery = "select t.[Id], t.[LoggerId], t.[Name], t.[Unit], t.[Description], t.[GroupChannel], t.[StatusViewAlarm], ds.[Pressure], ds.[Pressure1], ds.[Forward], ds.[Reverse] from [t_Devices_ChannelsConfigs] t join t_Devices_SitesConfigs ds on t.LoggerId = ds.Id ";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            
            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    t_Channel_Configurations el = new t_Channel_Configurations();
                    int? pressure1 = null;
                    int? pressure2 = null;
                    int? forward = null;
                    int? reverse = null;

                    try
                    {
                        el.ChannelId = reader["Id"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.ChannelId = "";
                    }
                    try
                    {
                        el.LoggerId = reader["LoggerId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LoggerId = "";
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
                    try
                    {
                        el.Description = reader["Description"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Description = "";
                    }
                    try
                    {
                        el.GroupChannel = reader["GroupChannel"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.GroupChannel = "";
                    }
                    try
                    {
                        el.StatusViewAlarm = bool.Parse(reader["StatusViewAlarm"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.StatusViewAlarm = null;
                    }
                    try
                    {
                        pressure1 = int.Parse(reader["Pressure1"].ToString());
                    }
                    catch (Exception ex)
                    {
                        pressure1 = null;
                    }
                    try
                    {
                        pressure2 = int.Parse(reader["Pressure"].ToString());
                    }
                    catch (Exception ex)
                    {
                        pressure2 = null;
                    }
                    try
                    {
                        forward = int.Parse(reader["Forward"].ToString());
                    }
                    catch (Exception ex)
                    {
                        forward = null;
                    }
                    try
                    {
                        reverse = int.Parse(reader["Reverse"].ToString());
                    }
                    catch (Exception ex)
                    {
                        reverse = null;
                    }
                    char numberChannel = ' ';
                    if (el.ChannelId != "")
                    {
                        numberChannel = el.ChannelId[el.ChannelId.Length - 1];
                        int temp = int.Parse(numberChannel.ToString());

                        if (temp == pressure1)
                        {
                            el.Pressure1 = true;
                        }
                        else if (temp == pressure2)
                        {
                            el.Pressure2 = true;
                        }
                        else if (temp == forward)
                        {
                            el.ForwardFlow = true;
                        }
                        else if (temp == reverse)
                        {
                            el.ReverseFlow = true;
                        }
                    }
                    // calc for this channel
                    if(el.ChannelId != null && el.ChannelId.Trim() != "")
                    {
                        el.LastIndex = getLastIndexValue.GetLastIndexValueAction(el.ChannelId);
                        el.IndexTimeStamp = getLastTimeStampIndex.GetlastTimeStampIndexAction(el.ChannelId);
                        el.LastValue = getLastValue.GetLastValueActon(el.ChannelId);
                        el.TimeStamp = getLastTimeStamp.GetLastTimeStampAction(el.ChannelId);
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