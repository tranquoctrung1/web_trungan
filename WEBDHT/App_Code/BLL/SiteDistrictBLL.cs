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
                    catch(Exception ex)
                    {
                        el.IdDistrict = "";
                    }
                    try
                    {
                        el.SiteId = reader["IdSite"].ToString();
                    }
                    catch(Exception ex)
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
            string sqlQuery = "select [IdDistrict], [IdSite] from [t_Site_District] where IdDistrict = '"+id+"'";

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
            if(sd.Count > 0)
            {
                List<string> sites = new List<string>();

                foreach(var item in sd)
                {
                    sites.Add(item.SiteId);
                }

                string sqlQuery = "insert into t_Site_District values('"+sd[0].IdDistrict+"', '"+ String.Join(",", sites)+"')";

                connect.Connected();
                nRows = connect.ExcuteNonQuery(sqlQuery);

            }
            else
            {
                nRows = 0;
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

        return nRows;
    }

    public int Update(List<SiteDistrict> sd)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            if (sd.Count > 0)
            {
                List<string> sites = new List<string>();

                foreach (var item in sd)
                {
                    sites.Add(item.SiteId);
                }

                string sqlQuery = "update t_Site_District set = '" + String.Join(",", sites) + "' where IdDistrict = '"+ sd[0].IdDistrict+"'";

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