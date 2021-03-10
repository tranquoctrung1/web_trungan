using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetAlarmForLoggerAction
    {
        public List<AlarmForLoggerViewModel> GetAlarmForLogger(string start, string end)
        {
            List<AlarmForLoggerViewModel> list = new List<AlarmForLoggerViewModel>();

            GetTurnHistoryAlarmAction getTurnHistoryAlarmAction = new GetTurnHistoryAlarmAction();

            if (getTurnHistoryAlarmAction.GetTurnHistoryAlarm("Logger") != false)
            {
                DateTime startDate = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
                DateTime endDate = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7).AddDays(1);
                Connect connect = new Connect();
                try
                {
                    string sqlQuery = $"select Serial, Type, StartDate, EndDate, IsFinish, [Content] from t_History_Alarm_Logger where  StartDate between convert(nvarchar, '{startDate}', 120) and convert(nvarchar, '{endDate}', 120) order by StartDate desc";
                    connect.Connected();

                    SqlDataReader reader = connect.Select(sqlQuery);

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AlarmForLoggerViewModel el = new AlarmForLoggerViewModel();
                            try
                            {
                                el.Serial = reader["Serial"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Serial = "";
                            }
                            try
                            {
                                el.Type = int.Parse(reader["Type"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.Type = null;
                            }
                            try
                            {
                                el.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.StartDate = null;
                            }
                            try
                            {
                                el.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.EndDate = null;
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