using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DMAMobileBLL
/// </summary>
public class DMAMobileBLL
{
    public List<DMAMobileViewModel> GetDMAMobileByUid(string uid)
    {
        List<DMAMobileViewModel> list = new List<DMAMobileViewModel>();

        UserBL userBL = new UserBL();

        t_Users u = userBL.GetUser(uid);


        string sqlQuery = "";

        if (u.Role == "DMA")
        {
            sqlQuery = "select tc.Company, tc.Production, tc.Description, tc.Status, tc.District, tc.Ward, tc.AmountDHTKH, tc.AmountValve, tc.AmountPool, tc.AmountTCH, tc.NRW from t_Site_Companies tc join t_DMA_DMA dd on dd.IdDMA = tc.Company where dd.IdStaff = '" + u.StaffId+"' order by tc.Company";
        }
        else if(u.Role == "admin")
        {
            sqlQuery = "select tc.Company, tc.Production, tc.Description, tc.Status, tc.District, tc.Ward, tc.AmountDHTKH, tc.AmountValve, tc.AmountPool, tc.AmountTCH, tc.NRW from t_Site_Companies tc  order by tc.Company";
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
                    DMAMobileViewModel el = new DMAMobileViewModel();
                    try
                    {
                        el.DMA = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.DMA = "";
                    }
                    try
                    {
                        el.Production = bool.Parse(reader["Production"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Production = null;
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
                        el.Status = reader["Status"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Status = "";
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
                        el.Ward = reader["Ward"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Ward = "";
                    }
                    try
                    {
                        el.AmountDHTKH = int.Parse(reader["AmountDHTKH"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.AmountDHTKH = null;
                    }
                    try
                    {
                        el.AmountValve = int.Parse(reader["AmountValve"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.AmountValve = null;
                    }
                    try
                    {
                        el.AmountPool = int.Parse(reader["AmountPool"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.AmountPool = null;
                    }
                    try
                    {
                        el.AmountTCH = int.Parse(reader["AmountTCH"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.AmountTCH = null;
                    }
                    try
                    {
                        el.NRW = double.Parse(reader["NRW"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.NRW = null;
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