using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetAlarmForPointByUidAction
    {
        public List<AlarmForPointViewModel> GetHistoryAlarmByUid(string uid,string start, string end)
        {
            List<AlarmForPointViewModel> list = new List<AlarmForPointViewModel>();
            GetTurnHistoryAlarmAction getTurnHistoryAlarmAction = new GetTurnHistoryAlarmAction();

            if (getTurnHistoryAlarmAction.GetTurnHistoryAlarm("Point") != false)
            {
                DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
                DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);

                GetUserByUidAction action = new GetUserByUidAction();

                UserViewModel u = action.GetUser(uid);


                string sqlQuery = $"";

                if (u.Role == "supervisor")
                {
                    sqlQuery = $"select  h.ChannelId, h.Location, h.StartDateAlarm, h.EndDateAlarm, h.TypeAlarm, h.[Level], h.IsFinish, h.[Content] from t_Site_Sites s join t_Devices_SitesConfigs t on t.SiteId = s.Id  join [t_Supervisor_District] sd on sd.IdDistrict = s.District join t_Devices_ChannelsConfigs dcc on dcc.LoggerId = t.Id join t_History_Alarm h on h.ChannelId = dcc.Id  where sd.IdStaff = '{u.StaffId}' and h.StartDateAlarm between convert(nvarchar, '{timeStart}', 120) and convert(nvarchar, '{timeEnd}', 120) order by h.StartDateAlarm desc";
                }
                else if (u.Role == "DMA")
                {
                    sqlQuery = $"select  h.ChannelId, h.Location, h.StartDateAlarm, h.EndDateAlarm, h.TypeAlarm, h.[Level], h.IsFinish, h.[Content] from t_Site_Sites s join t_Devices_SitesConfigs t on t.SiteId = s.Id  join [t_DMA_DMA] dd on dd.IdDMA = s.Company join t_Devices_ChannelsConfigs dcc on dcc.LoggerId = t.Id join t_History_Alarm h on h.ChannelId = dcc.Id where dd.IdStaff = '{u.StaffId}' and h.StartDateAlarm between convert(nvarchar, '{timeStart}', 120) and convert(nvarchar, '{timeEnd}', 120) order by h.StartDateAlarm desc";
                }
                else if (u.Role == "staff")
                {
                    sqlQuery = $"select  h.ChannelId, h.Location, h.StartDateAlarm, h.EndDateAlarm, h.TypeAlarm, h.[Level], h.IsFinish, h.[Content] from t_Site_Sites s join t_Devices_SitesConfigs t on t.SiteId = s.Id  join [t_Staff_Site] ts on ts.IdSite = s.Id join t_Devices_ChannelsConfigs dcc on dcc.LoggerId = t.Id join t_History_Alarm h on h.ChannelId = dcc.Id where ts.IdStaff = '{u.StaffId}' and h.StartDateAlarm between convert(nvarchar, '{timeStart}', 120) and convert(nvarchar, '{timeEnd}', 120) order by h.StartDateAlarm desc";
                }
                else if (u.Role == "consumer")
                {
                    sqlQuery = $"select  h.ChannelId, h.Location, h.StartDateAlarm, h.EndDateAlarm, h.TypeAlarm, h.[Level], h.IsFinish, h.[Content] from t_Site_Sites s join t_Devices_SitesConfigs t on t.SiteId = s.Id  join [t_Site_Consumer] sc on sc.SiteId = s.Id join t_Devices_ChannelsConfigs dcc on dcc.LoggerId = t.Id join t_History_Alarm h on h.ChannelId = dcc.Id where sc.ConsumerId = '{u.StaffId}' and h.StartDateAlarm between convert(nvarchar, '{timeStart}', 120) and convert(nvarchar, '{timeEnd}', 120) order by h.StartDateAlarm desc";
                }
                else
                {
                    sqlQuery = $"select ChannelId, Location, StartDateAlarm, EndDateAlarm, TypeAlarm, [Level], IsFinish, [Content] from t_History_Alarm where StartDateAlarm between convert(nvarchar, '{timeStart}', 120) and convert(nvarchar, '{timeEnd}', 120) order by StartDateAlarm desc "; //where exists (select * from t_Devices_ChannelsConfigs dc where dc.LoggerId = t.Id)
                }

                Connect connect = new Connect();

                try
                {
                    connect.Connected();

                    SqlDataReader reader = connect.Select(sqlQuery);

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AlarmForPointViewModel el = new AlarmForPointViewModel();

                            try
                            {
                                el.ChannelId = reader["ChannelId"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.ChannelId = "";
                            }
                            try
                            {
                                el.Location = reader["Location"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Location = "";
                            }
                            try
                            {
                                el.StartDateAlarm = DateTime.Parse(reader["StartDateAlarm"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.StartDateAlarm = null;
                            }
                            try
                            {
                                el.EndDateAlarm = DateTime.Parse(reader["EndDateAlarm"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.EndDateAlarm = null;
                            }
                            try
                            {
                                el.TypeAlarm = int.Parse(reader["TypeAlarm"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.TypeAlarm = null;
                            }
                            try
                            {
                                el.Level = reader["Level"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Level = "";
                            }
                            try
                            {
                                el.IsFinish = bool.Parse(reader["IsFinish"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.IsFinish = null;
                            }
                            try
                            {
                                el.Content = reader["Content"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Content = "";
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
                    connect.DisConnected();
                }
            }

            return list;
        }
    }
}