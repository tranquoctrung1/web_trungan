using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetStatisticSiteByStatusAction
    {
        public List<StatisticSiteViewModel> GetAll()
        {

            List<StatisticSiteViewModel> list = new List<StatisticSiteViewModel>();
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select Id, OldId, Location, Meter, Transmitter, Logger, Company, DMAOut, District, Status from [t_Site_Sites] order by Id";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        StatisticSiteViewModel el = new StatisticSiteViewModel();
                        try
                        {
                            el.Id = reader["Id"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.Id = "";
                        }
                        try
                        {
                            el.OldId = reader["OldId"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.OldId = "";
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
                            el.Meter = reader["Meter"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Meter = "";
                        }
                        try
                        {
                            el.Transmitter = reader["Transmitter"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Transmitter = "";
                        }
                        try
                        {
                            el.Logger = reader["Logger"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Logger = "";
                        }
                        try
                        {
                            el.Company = reader["Company"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Company = "";
                        }
                        try
                        {
                            el.DMAOut = reader["DMAOut"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.DMAOut = "";
                        }
                        try
                        {
                            el.District = reader["District"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.District = "";
                        }
                        try
                        {
                            el.Status = reader["Status"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Status = "";
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
    }
}