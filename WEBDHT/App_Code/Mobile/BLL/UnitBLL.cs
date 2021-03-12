using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UnitBLL
/// </summary>
public class UnitBLL
{
    public List<UnitViewModel> GetUnits()
    {
        List<UnitViewModel> list = new List<UnitViewModel>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select Unit, Description from t_Devices_Units";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UnitViewModel el = new UnitViewModel();

                    try
                    {
                        el.Unit = reader["Unit"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Unit = "";
                    }
                    try
                    {
                        el.Description = reader["Description"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Description = "";
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