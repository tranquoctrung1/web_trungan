using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetListSitesAction
    {
        public List<DataComplexViewModel> getListSites()
        {
            List<DataComplexViewModel> list = new List<DataComplexViewModel>();
            Connect connect = new Connect();
            try
            {

                string sqlQuery = "select s.Id, s.Location, s.OldId, dc.Id as LoggerID from t_Site_Sites s join t_Devices_SitesConfigs dc on dc.SiteId = s.Id ";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        DataComplexViewModel el = new DataComplexViewModel();
                        try
                        {
                            el.SiteID = reader["Id"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.SiteID = "";
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
                            el.OdlID = reader["OldId"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.OdlID = "";
                        }
                        try
                        {
                            el.LoggerID = reader["LoggerID"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.OdlID = "";
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

        public List<DataComplexViewModel> getListSiteByUid(string uid)
        {
            GetUserByUidAction action = new GetUserByUidAction();

            UserViewModel u = action.GetUser(uid);

            string sqlQuery = $"";

            if (u.Role == "supervisor")
            {
                sqlQuery = $"select s.Id, s.Location, s.OldId, dc.Id as LoggerID from t_Site_Sites s join t_Devices_SitesConfigs dc on dc.SiteId = s.Id  join [t_Supervisor_District] sd on sd.IdDistrict = s.District where sd.IdStaff = '{u.StaffId}'";
            }
            else if (u.Role == "DMA")
            {
                sqlQuery = $"select s.Id, s.Location, s.OldId, dc.Id as LoggerID from t_Site_Sites s join t_Devices_SitesConfigs dc on dc.SiteId = s.Id  join [t_DMA_DMA] dd on dd.IdDMA = s.Company where dd.IdStaff = '{u.StaffId}'";
            }
            else if (u.Role == "staff")
            {
                sqlQuery = $"select s.Id, s.Location, s.OldId, dc.Id as LoggerID from t_Site_Sites s join t_Devices_SitesConfigs dc on dc.SiteId = s.Id   join [t_Staff_Site] ts on ts.IdSite = s.Id where ts.IdStaff = '{u.StaffId}'";
            }
            else if (u.Role == "consumer")
            {
                sqlQuery = $"select s.Id, s.Location, s.OldId, dc.Id as LoggerID from t_Site_Sites s join t_Devices_SitesConfigs dc on dc.SiteId = s.Id  join [t_Site_Consumer] sc on sc.SiteId = s.Id where sc.ConsumerId = '{u.StaffId}'";
            }
            else
            {
                sqlQuery = $"select s.Id, s.Location, s.OldId, dc.Id as LoggerID from t_Site_Sites s join t_Devices_SitesConfigs dc on dc.SiteId = s.Id "; //where exists (select * from t_Devices_ChannelsConfigs dc where dc.LoggerId = t.Id)
            }

            List<DataComplexViewModel> list = new List<DataComplexViewModel>();
            Connect connect = new Connect();
            try
            {

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataComplexViewModel el = new DataComplexViewModel();
                        try
                        {
                            el.SiteID = reader["Id"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.SiteID = "";
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
                            el.OdlID = reader["OldId"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.OdlID = "";
                        }
                        try
                        {
                            el.LoggerID = reader["LoggerID"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.OdlID = "";
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