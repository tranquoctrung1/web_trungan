using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetValueAlarmAction
    {
        public List<ValueAlarmViewModel> GetValueAlarm(string uid)
        {
            List<ValueAlarmViewModel> list = new List<ValueAlarmViewModel>();

            try
            {
                string sqlQuery = $"select t.Id as ChannelName, t.LastValue, t.LastTimeStamp as TimeStamp, s.Location as SiteAliasName, ds.Interval, ds.DelayTime,t.BaseMin, t.BaseMax, t.BaseLine from t_Devices_ChannelsConfigs t left join t_Devices_SitesConfigs ds on ds.Id = t.LoggerId left join t_Site_Sites s on s.Id = ds.SiteId ";
                Connect.ConnectToDataBase();

                SqlDataReader reader = Connect.Select(sqlQuery);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ValueAlarmViewModel el = new ValueAlarmViewModel();
                        bool isStatus = false;
                        try
                        {
                            el.Namepath = reader["ChannelName"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Namepath = "";
                        }
                        try
                        {
                            el.AliasName = reader["SiteAliasName"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.AliasName = "";
                        }
                        try
                        {
                            el.LasValue = double.Parse(reader["LastValue"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.LasValue = null;
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
                            el.InterVal = int.Parse(reader["Interval"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.InterVal = null;
                        }
                        try
                        {
                            el.DelayTime = int.Parse(reader["DelayTime"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.DelayTime = null;
                        }
                        try
                        {
                            el.BaseMin = double.Parse(reader["BaseMin"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.BaseMin = null;
                        }
                        try
                        {
                            el.BaseMax = double.Parse(reader["BaseMax"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.BaseMax = null;
                        }

                        try
                        {
                            el.BaseLine = double.Parse(reader["BaseLine"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.BaseLine = null;
                        }

                        if (el.InterVal == null)
                        {
                            el.InterVal = 15;
                        }
                        if (el.DelayTime == null)
                        {
                            el.DelayTime = 60;
                        }

                        if (isStatus == false)
                        {
                            if (el.DelayTime != null)
                            {
                                if (el.TimeStamp != null)
                                {
                                    if ((DateTime.Now - (DateTime)el.TimeStamp).TotalMinutes >= el.DelayTime)
                                    {
                                        el.Status = "Delay";
                                        isStatus = true;
                                    }
                                }
                            }
                        }
                        if (isStatus == false)
                        {
                            if (el.BaseMin != null)
                            {
                                if (el.LasValue != null)
                                {
                                    if (el.LasValue < el.BaseMin)
                                    {
                                        el.Status = "Low";
                                        isStatus = true;
                                    }
                                }
                            }

                        }
                        if (isStatus == false)
                        {
                            if (el.BaseMax != null)
                            {
                                if (el.LasValue != null)
                                {
                                    if (el.LasValue > el.BaseMax)
                                    {
                                        el.Status = "High";
                                        isStatus = true;
                                    }
                                }
                            }
                        }
                        if (isStatus == false)
                        {
                            if (el.BaseLine != null)
                            {
                                if (el.LasValue != null)
                                {
                                    if (el.LasValue > el.BaseLine)
                                    {
                                        el.Status = "BaseLine";
                                        isStatus = true;
                                    }
                                }
                            }
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
                //Connect.DisconnectToDataBase();
            }

            return list;
        }
    }
}