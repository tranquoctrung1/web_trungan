using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetChannelByGroupChannelAction
    {
        public List<ChannelByGroupChannelViewModel> GetChannelByGroupChannel(string loggerid, string groupChannel)
        {
            List<ChannelByGroupChannelViewModel> list = new List<ChannelByGroupChannelViewModel>();
            Connect connect = new Connect();

            try
            {
                string sqlQuery = "";
                if (groupChannel != "NULL")
                {
                    sqlQuery= $"select Id, Name, LoggerId, LastTimeStamp, GroupChannel from t_Devices_ChannelsConfigs where LoggerId = '{loggerid}' and GroupChannel = '{groupChannel}'";
                }
                else
                {
                    sqlQuery = $"select Id, Name, LoggerId, LastTimeStamp, GroupChannel from t_Devices_ChannelsConfigs where LoggerId = '{loggerid}' and GroupChannel is null ";
                }
                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        ChannelByGroupChannelViewModel el = new ChannelByGroupChannelViewModel();
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
                            el.LoggerId = reader["LoggerId"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.LoggerId = "";
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
                            el.TimeStamp = DateTime.Parse(reader["LastTimeStamp"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.TimeStamp = null;
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
}