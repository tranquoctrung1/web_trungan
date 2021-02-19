using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetAlarmForDMAAction
    {
        public List<AlarmForDMAViewModel> GetAllAlarmForDMA()
        {
            List<AlarmForDMAViewModel> list = new List<AlarmForDMAViewModel>();
            Connect connect = new Connect();

            try
            {
                string sqlQuery = $"select DMAId, Description, StartDate, EndDate, Type, Content, [Level], IsFinish from t_Histoty_Alarm_DMA";

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

            return list;
        }
    }
}