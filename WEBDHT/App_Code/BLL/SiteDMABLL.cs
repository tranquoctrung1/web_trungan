using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SiteDMABLL
/// </summary>
public class SiteDMABLL
{
    public List<SiteDMA> GetSiteDMAs()
    {
        List<SiteDMA> list = new List<SiteDMA>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select IdDMA, IdSite from t_Site_DMA";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    SiteDMA el = new SiteDMA();

                    try
                    {
                        el.IdDMA = reader["IdDMA"].ToString();
                    }
                    catch(Exception ex)
                    {
                        el.IdDMA = "";
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

    public List<SiteDMA> GetSiteDMAById(string id)
    {
        List<SiteDMA> list = new List<SiteDMA>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select IdDMA, IdSite from t_Site_DMA where IdDMA = '" + id+"'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SiteDMA el = new SiteDMA();

                    try
                    {
                        el.IdDMA = reader["IdDMA"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.IdDMA = "";
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

    public int Insert (List<SiteDMA> sd)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            if (sd.Count > 0)
            {
                string sqlQuery = "insert into t_Site_DMA values";

                for (int i = 0; i < sd.Count - 1; i++)
                {
                    sqlQuery += "('" + sd[0].IdDMA + "', '" + sd[i].SiteId + "'),";
                }
                sqlQuery += "('" + sd[sd.Count - 1].IdDMA + "', '" + sd[sd.Count - 1].SiteId + "')";

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

    public int Update(SiteDMA sd)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            string sqlQuery = "update t_Site_DMA set IdSite = '" + sd.SiteId + "' where IdDMA = '" + sd.IdDMA + "'";

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
            string sqlQuery = "delete from t_Site_DMA where IdDMA = '" + id + "'";
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