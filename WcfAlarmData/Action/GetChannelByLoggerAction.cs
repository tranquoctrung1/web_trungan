using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfAlarmData.ConnectDB;
using WcfAlarmData.Model;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetChannelByLoggerAction
    {
        public List<ChannelByLoggerViewModel> GetChannelByLogger(string loggerid)
        {
            List<ChannelByLoggerViewModel> list = new List<ChannelByLoggerViewModel>();
            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"select t.Id as ChannelId, t.Name as ChannelName, ds.Pressure, ds.Pressure1, ds.Forward, ds.Reverse, t.LastTimeStamp, t.LastValue, t.Unit, gc.Status as GroupChannelStatus, ds.DelayTime, t.BaseMin, t.BaseMax from t_Devices_ChannelsConfigs t left join t_Devices_SitesConfigs ds on t.LoggerId = ds.Id join t_GroupChannel gc on gc.GroupChannel = t.GroupChannel where ds.Id = '{loggerid}'";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        ChannelByLoggerViewModel el = new ChannelByLoggerViewModel();
                        int? pressure1 = null;
                        int? pressure2 = null;
                        int? forward = null;
                        int? reverse = null;
                        int? baseMin = null;
                        int? baseMax = null;
                        int? delayTime = null;
                        try
                        {
                            el.ChannelId = reader["ChannelId"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.ChannelId = "";
                        }
                        try
                        {
                            el.ChannelName = reader["ChannelName"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.ChannelName = "";
                        }
                        try
                        {
                           pressure1 = int.Parse(reader["Pressure1"].ToString());
                        }
                        catch (Exception ex)
                        {
                            pressure1 =  null;
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
                        try
                        {
                            el.Timestamp = DateTime.Parse(reader["LastTimeStamp"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Timestamp = null;
                        }
                        try
                        {
                            el.Val = double.Parse(reader["LastValue"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Val = null;
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
                            el.GroupChannelStatus = int.Parse(reader["GroupChannelStatus"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.GroupChannelStatus = 1;
                        }
                        try
                        {
                            delayTime = int.Parse(reader["DelayTime"].ToString());
                        }
                        catch (Exception ex)
                        {
                            delayTime = 60;
                        }
                        try
                        {
                            baseMax = int.Parse(reader["BaseMax"].ToString());
                        }
                        catch(Exception ex)
                        {
                            baseMax = null;
                        }
                        try
                        {
                            baseMin = int.Parse(reader["BaseMin"].ToString());
                        }
                        catch (Exception ex)
                        {
                            baseMin = null;
                        }

                        char numberChannel = ' ';
                        if (el.ChannelId != "")
                        {
                            numberChannel = el.ChannelId[el.ChannelId.Length - 1];
                            int temp = int.Parse(numberChannel.ToString());

                            if(temp == pressure1)
                            {
                                el.Press1 = true;
                            }
                            else if(temp == pressure2)
                            {
                                el.Press2 = true;
                            }
                            else if(temp == forward)
                            {
                                el.Flow1 = true;
                            }
                            else if(temp == reverse)
                            {
                                el.Flow2 = true;
                            }
                        }

                        if(delayTime != null)
                        {
                            if (el.Timestamp != null)
                            {
                                if ((DateTime.Now - (DateTime)el.Timestamp).TotalMinutes >= delayTime)
                                {
                                    el.Status = 4;
                                }
                            }
                        }
                        if(baseMin != null)
                        {
                            if(el.Val != null)
                            {
                                if(el.Val < baseMin)
                                {
                                    el.Status = 2;
                                }
                            }
                        }
                        if(baseMax != null)
                        {
                            if(el.Val != null)
                            {
                                if(el.Val > baseMax)
                                {
                                    el.Status = 2;
                                }
                            }
                        }
                        el.DisplayLabel = true;

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