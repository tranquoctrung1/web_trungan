using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetChannelConfigAction
    {
        public List<ChannelViewModel> GetChannelConfig(string loggerID)
        {
            List<ChannelViewModel> list = new List<ChannelViewModel>();
            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"select tc.Id as ChannelID, tc.LastTimeStamp as TimeStamp, tc.LastValue as Value, tc.Unit as Unit from t_Devices_ChannelsConfigs tc where LoggerId = '{loggerID}'";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        ChannelViewModel el = new ChannelViewModel();
                        try
                        {
                            el.ChannelId = reader["ChannelID"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.ChannelId = "";
                        }
                        try
                        {
                            el.Value = int.Parse(reader["Value"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Value = null;
                        }
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
                            el.Unit = reader["Unit"].ToString();
                        }
                        catch(Exception ex)
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
}