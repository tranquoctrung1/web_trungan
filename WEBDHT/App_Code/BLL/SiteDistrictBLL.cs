using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SiteDistrict
/// </summary>
public class SiteDistrictBLL
{
    public List<SiteDistrict> GetSiteDistricts()
    {
        List<SiteDistrict> list = new List<SiteDistrict>();
        Connect connect = new Connect();
        try
        {
            string sqlQuery = "select [IdDistrict], [IdSite] from [t_Site_District]";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SiteDistrict el = new SiteDistrict();
                    try
                    {
                        el.IdDistrict = reader["IdDistrict"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.IdDistrict = "";
                    }
                    try
                    {
                        el.SiteId = reader["IdSite"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteId = "";
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

    public List<SiteDistrict> GetSiteDistrictsById(string id)
    {
        List<SiteDistrict> list = new List<SiteDistrict>();
        Connect connect = new Connect();
        try
        {
            string sqlQuery = "select [IdDistrict], [IdSite] from [t_Site_District] where IdDistrict = '" + id + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SiteDistrict el = new SiteDistrict();
                    try
                    {
                        el.IdDistrict = reader["IdDistrict"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.IdDistrict = "";
                    }
                    try
                    {
                        el.SiteId = reader["IdSite"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.SiteId = "";
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

    public int Insert(List<SiteDistrict> sd)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            if (sd.Count > 0)
            {
                string sqlQuery = "insert into t_Site_District values";

                for (int i = 0; i < sd.Count - 1; i++)
                {
                    sqlQuery += "('" + sd[0].IdDistrict + "', '" + sd[i].SiteId + "'),";
                }
                sqlQuery += "('" + sd[sd.Count - 1].IdDistrict + "', '" + sd[sd.Count - 1].SiteId + "')";

                connect.Connected();
                nRows = connect.ExcuteNonQuery(sqlQuery);
            }
            else
            {
                nRows = 0;
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

        return nRows;
    }

    public int Update(SiteDistrict sd)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            string sqlQuery = "update t_Site_District set IdSite = '" + sd.SiteId + "' where IdDistrict = '" + sd.IdDistrict + "'";

            connect.Connected();
            nRows = connect.ExcuteNonQuery(sqlQuery);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connect.DisConnected();
        }

        return nRows;
    }

    public int Delete(string id)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            string sqlQuery = "delete from t_Site_District where IdDistrict = '" + id + "'";
            connect.Connected();

            nRows = connect.ExcuteNonQuery(sqlQuery);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connect.DisConnected();
        }

        return nRows;
    }
}