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

        Connect connect = new Connect();
        
        try
        {

            string store = "p_GetChannelByLoggerId";

            connect.Connected();

            SqlCommand command = connect.ExcuteStoreProceduce(store);

            command.Parameters.Add(new SqlParameter("@loggerid", loggerid));

            SqlDataReader reader = command.ExecuteReader();
            
            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    t_Channel_Configurations el = new t_Channel_Configurations();

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
                        el.Pressure1 = bool.Parse(reader["Pressure1"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Pressure1 = null;
                    }
                    try
                    {
                        el.Pressure2 = bool.Parse(reader["Pressure2"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Pressure2 = null;
                    }
                    try
                    {
                        el.ForwardFlow = bool.Parse(reader["ForwardFlow"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.ForwardFlow = null;
                    }
                    try
                    {
                        el.ReverseFlow = bool.Parse(reader["ReverseFlow"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.ReverseFlow = null;
                    }
                    try
                    {
                        el.TimeStamp = DateTime.Parse(reader["TimeStamp"].ToString());
                    }
                    catch(Exception ex)
                    {
                        el.TimeStamp = null;
                    }
                    try
                    {
                        el.LastValue = double.Parse(reader["LastValue"].ToString());
                    }
                    catch(Exception ex)
                    {
                        el.LastValue = null;
                    }
                    try
                    {
                        el.IndexTimeStamp = DateTime.Parse(reader["IndexTimeStamp"].ToString());
                    }
                    catch(Exception ex)
                    {
                        el.IndexTimeStamp = null;
                    }
                    try
                    {
                        el.LastIndex = double.Parse(reader["LastIndex"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.LastIndex = null;
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