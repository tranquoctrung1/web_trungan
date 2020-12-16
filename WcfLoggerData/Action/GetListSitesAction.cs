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

            try
            {

                string sqlQuery = "select s.Id, s.Location, s.OldId, dc.Id as LoggerID from t_Site_Sites s join t_Devices_SitesConfigs dc on dc.SiteId = s.Id ";

                Connect.ConnectToDataBase();

                SqlDataReader reader = Connect.Select(sqlQuery);

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
                Connect.DisconnectToDataBase();
            }

            return list;
        }
    }
}