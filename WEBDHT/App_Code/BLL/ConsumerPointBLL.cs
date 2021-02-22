using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConusmerPointBLL
/// </summary>
public class ConsumerPointBLL
{
    public List<ConsumerPoint> GetConsumerPoint()
    {
        List<ConsumerPoint> list = new List<ConsumerPoint>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select ConsumerId, SiteId from t_Site_Consumer";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ConsumerPoint el = new ConsumerPoint();

                    try
                    {
                        el.ConsumerId = reader["ConsumerId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.ConsumerId = "";
                    }
                    try
                    {
                        el.SiteId = reader["SiteId"].ToString();
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

    public List<ConsumerPoint> GetConsumerPointById(string id)
    {
        List<ConsumerPoint> list = new List<ConsumerPoint>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select ConsumerId, SiteId from t_Site_Consumer where ConsumerId = '" + id + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ConsumerPoint el = new ConsumerPoint();

                    try
                    {
                        el.ConsumerId = reader["ConsumerId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.ConsumerId = "";
                    }
                    try
                    {
                        el.SiteId = reader["SiteId"].ToString();
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

    public int Insert(List<ConsumerPoint> sd)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            if (sd.Count > 0)
            {
                string sqlQuery = "insert into t_Site_Consumer values";

                for (int i = 0; i < sd.Count - 1; i++)
                {
                    sqlQuery += "('" + sd[0].ConsumerId + "', '" + sd[i].SiteId + "'),";
                }
                sqlQuery += "('" + sd[sd.Count - 1].ConsumerId + "', '" + sd[sd.Count - 1].SiteId + "')";

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

    public int Update(ConsumerPoint sd)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            string sqlQuery = "update t_Site_Consumer set ConsumerId = '" + sd.ConsumerId + "' where ConsumerId = '" + sd.ConsumerId + "'";

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
            string sqlQuery = "delete from t_Site_Consumer where ConsumerId = '" + id + "'";
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