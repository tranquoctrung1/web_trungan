using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DMADMABLL
/// </summary>
public class DMADMABLL
{
    public List<DMADMA> GetSiteDMAs()
    {
        List<DMADMA> list = new List<DMADMA>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select IdStaff, IdDMA from t_DMA_DMA";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DMADMA el = new DMADMA();

                    try
                    {
                        el.IdStaff = reader["IdStaff"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.IdStaff = "";
                    }
                    try
                    {
                        el.IdDMA = reader["IdDMA"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.IdDMA = "";
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

    public List<DMADMA> GetDMADMAById(string id)
    {
        List<DMADMA> list = new List<DMADMA>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select IdStaff, IdDMA from t_DMA_DMA where IdStaff = '" + id + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DMADMA el = new DMADMA();

                    try
                    {
                        el.IdStaff = reader["IdStaff"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.IdStaff = "";
                    }
                    try
                    {
                        el.IdDMA = reader["IdDMA"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.IdDMA = "";
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

    public int Insert(List<DMADMA> sd)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            if (sd.Count > 0)
            {
                string sqlQuery = "insert into t_DMA_DMA values";

                for (int i = 0; i < sd.Count - 1; i++)
                {
                    sqlQuery += "('" + sd[0].IdStaff + "', '" + sd[i].IdDMA + "'),";
                }
                sqlQuery += "('" + sd[sd.Count - 1].IdStaff + "', '" + sd[sd.Count - 1].IdDMA + "')";

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

    public int Update(DMADMA sd)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            string sqlQuery = "update t_DMA_DMA set IdStaff = '" + sd.IdStaff + "' where IdStaff = '" + sd.IdStaff + "'";

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
            string sqlQuery = "delete from t_DMA_DMA where IdStaff = '" + id + "'";
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