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

    public bool CheckExistsChannel(string channelid, string loggerid)
    {

        bool result = false;
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select * from t_Devices_ChannelsConfigs where Id = '" + channelid + "' and loggerId = '" + loggerid + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                result = true;
            }
            else
            {
                result = false;
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

    public int Insert(string loggerid, string channelid, string channelname, string unit)
    {
        int nRows = 0;

        Connect connect = new Connect();

        try
        {

            string sqlQuery = "insert into t_Devices_ChannelsConfigs (Id, LoggerId, Name, Unit, GroupChannel) values('"+channelid+"', '"+loggerid+"', '" + channelname + "', '" + unit + "', 'Pressure')";

            connect.Connected();

            nRows += connect.ExcuteNonQuery(sqlQuery);
        }
        catch(SqlException ex)
        {
            throw ex;
        }
        finally

        {
            connect.DisConnected();
        }

        try
        {
            string store = "p_Data_Logger_CreateTable";

            connect.Connected();

            SqlCommand command = connect.ExcuteStoreProceduce(store);
            command.Parameters.Add(new SqlParameter("@channelId", channelid));

            nRows += command.ExecuteNonQuery();
        }
        catch(SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connect.DisConnected();
        }

        return nRows;
    }

    public int Update(string loggerid, string channelid, string channelname, string unit)
    {
        int nRows = 0;

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "update t_Devices_ChannelsConfigs set Id = '" + channelid + "', Name = '" + channelname + "', Unit = '" + unit + "' where LoggerId = '" + loggerid + "'";

            connect.Connected();

            nRows = connect.ExcuteNonQuery(sqlQuery);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally

        {
            connect.DisConnected();
        }

        return nRows;
    }

    public int Delete (string loggerid, string channelid)
    {
        int nRows = 0;

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "delete from t_Devices_ChannelsConfigs where Id = '" + channelid + "' and LoggerId = '" + loggerid + "'";

            connect.Connected();

            nRows = connect.ExcuteNonQuery(sqlQuery);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally

        {
            connect.DisConnected();
        }

        return nRows;
    }
}