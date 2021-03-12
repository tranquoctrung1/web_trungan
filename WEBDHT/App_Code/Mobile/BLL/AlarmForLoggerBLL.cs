using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AlarmForLoggerBLL
/// </summary>
public class AlarmForLoggerBLL
{
   public List<AlarmForLoggerViewModel> GetAlarmForLogger(string uid)
    {
        List<AlarmForLoggerViewModel> list = new List<AlarmForLoggerViewModel>();

        UserBL userBL = new UserBL();

        t_Users u = userBL.GetUser(uid);

        string sqlQuery = "";


        if (u.Role == "supervisor")
        {
            sqlQuery = "select h.Serial, h.Type, h.StartDate, h.EndDate, h.IsFinish, h.[Content] from t_History_Alarm_Logger h join t_Devices_SitesConfigs ds on ds.Id = h.Serial join t_Site_Sites s on s.Id = ds.SiteId join t_Supervisor_District sd on sd.IdDistrict = s.District where sd.IdStaff = '"+u.StaffId+"' and h.IsFinish = 0 order by h.StartDate desc";
        }
        else if (u.Role == "DMA")
        {
            sqlQuery = "select h.Serial, h.Type, h.StartDate, h.EndDate, h.IsFinish, h.[Content] from t_History_Alarm_Logger h join t_Devices_SitesConfigs ds on ds.Id = h.Serial join t_Site_Sites s on s.Id = ds.SiteId join t_DMA_DMA dd on dd.IdDMA = s.Company where dd.IdStaff = '"+u.StaffId+"' and h.IsFinish = 0 order by h.StartDate desc";
        }
        else if (u.Role == "staff")
        {
            sqlQuery = "select h.Serial, h.Type, h.StartDate, h.EndDate, h.IsFinish, h.[Content] from t_History_Alarm_Logger h join t_Devices_SitesConfigs ds on ds.Id = h.Serial join t_Site_Sites s on s.Id = ds.SiteId join t_Staff_Site ts on ts.IdSite = s.Id where ts.IdStaff = '"+u.StaffId+"' and h.IsFinish = 0 order by h.StartDate desc";
        }
        else if (u.Role == "consumer")
        {
            sqlQuery = "select h.Serial, h.Type, h.StartDate, h.EndDate, h.IsFinish, h.[Content] from t_History_Alarm_Logger h join t_Devices_SitesConfigs ds on ds.Id = h.Serial join t_Site_Sites s on s.Id = ds.SiteId join t_Site_Consumer tc on tc.SiteId = s.Id where tc.ConsumerId = '"+u.StaffId+"' and h.IsFinish = 0 order by h.StartDate desc";
        }
        else
        {
            sqlQuery = "select h.Serial, h.Type, h.StartDate, h.EndDate, h.IsFinish, h.[Content] from t_History_Alarm_Logger h where h.IsFinish = 0 order by h.StartDate desc "; //where exists (select * from t_Devices_ChannelsConfigs dc where dc.LoggerId = t.Id)
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

        return list;
    }
}