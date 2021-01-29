using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetGroupChannelByLoggerAction
    {
        public List<GroupChannelByLoggerViewModel> GetGroupChannelByLogger(string loggerid)
        {
            List<GroupChannelByLoggerViewModel> list = new List<GroupChannelByLoggerViewModel>();
            Connect connect = new Connect();
            try
            {

                string sqlQuery = $"select GroupChannel, LastTimeStamp, LoggerId from t_Devices_ChannelsConfigs where LoggerId = '{loggerid}' group by GroupChannel, LastTimeStamp, LoggerId";
                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        GroupChannelByLoggerViewModel el = new GroupChannelByLoggerViewModel();

                        try
                        {
                            el.Groupchannel = reader["GroupChannel"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.Groupchannel = "";
                        }
                        try
                        {
                            el.Loggerid = reader["LoggerId"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Loggerid = "";
                        }
                        try
                        {
                            el.Timestamp = DateTime.Parse(reader["LastTimeStamp"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Timestamp = null;
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