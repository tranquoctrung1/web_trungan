using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetAlarmForPointAction
    {
        public List<AlarmForPointViewModel> GetHistoryAlarm(string start, string end)
        {
            List<AlarmForPointViewModel> list = new List<AlarmForPointViewModel>();
            GetTurnHistoryAlarmAction getTurnHistoryAlarmAction = new GetTurnHistoryAlarmAction();

            if (getTurnHistoryAlarmAction.GetTurnHistoryAlarm("Point") != false)
            {
                DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
                DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);

                Connect connect = new Connect();

                try
                {
                    string sqlQuery = $"select ChannelId, Location, StartDateAlarm, EndDateAlarm, TypeAlarm, [Level], IsFinish, [Content] from t_History_Alarm where StartDateAlarm between convert(nvarchar, '{timeStart}', 120) and convert(nvarchar, '{timeEnd}', 120) order by StartDateAlarm desc";
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