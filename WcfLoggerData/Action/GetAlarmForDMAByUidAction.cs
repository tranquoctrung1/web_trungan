﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetAlarmForDMAByUidAction
    {
        public List<AlarmForDMAViewModel> GetAllAlarmForDMAByUid(string uid, string start, string end)
        {
            List<AlarmForDMAViewModel> list = new List<AlarmForDMAViewModel>();
            GetTurnHistoryAlarmAction getTurnHistoryAlarmAction = new GetTurnHistoryAlarmAction();

            if (getTurnHistoryAlarmAction.GetTurnHistoryAlarm("DMA") != false)
            {
                DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
                DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7).AddDays(1);

                GetUserByUidAction action = new GetUserByUidAction();

                UserViewModel u = action.GetUser(uid);


                string sqlQuery = $"";

                if (u.Role == "DMA")
                {
                    sqlQuery = $"select h.DMAId, h.Description, h.StartDate, h.EndDate, h.Type, h.Content, h.[Level], h.IsFinish from t_Histoty_Alarm_DMA h join t_DMA_DMA dd on dd.IdDMA = h.DMAId where StartDate between convert(nvarchar, '{timeStart}', 120) and convert(nvarchar, '{timeEnd}',  120) and dd.IdStaff = '{u.StaffId}' order by h.StartDate desc";
                }
                else if (u.Role == "admin")
                {
                    sqlQuery = $"select DMAId, Description, StartDate, EndDate, Type, Content, [Level], IsFinish from t_Histoty_Alarm_DMA where StartDate between convert(nvarchar, '{timeStart}', 120) and convert(nvarchar, '{timeEnd}',  120) order by StartDate desc";
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
                            AlarmForDMAViewModel el = new AlarmForDMAViewModel();

                            try
                            {
                                el.Company = reader["DMAId"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Company = "";
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
                                el.Type = int.Parse(reader["Type"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.Type = null;
                            }
                            try
                            {
                                el.Content = reader["Content"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Content = "";
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