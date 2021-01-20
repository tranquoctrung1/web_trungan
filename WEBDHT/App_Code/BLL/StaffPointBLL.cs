using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StaffPointBLL
/// </summary>
public class StaffPointBLL
{
    public List<StaffPoint> GetStaffPoint()
    {
        List<StaffPoint> list = new List<StaffPoint>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select IdStaff, IdSite from t_Staff_Site";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    StaffPoint el = new StaffPoint();

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
                        el.IdSite = reader["IdSite"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.IdSite = "";
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

    public List<StaffPoint> GetStaffPointById(string id)
    {
        List<StaffPoint> list = new List<StaffPoint>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select IdStaff, IdSite from t_Staff_Site where IdStaff = '" + id + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    StaffPoint el = new StaffPoint();

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
                        el.IdSite = reader["IdSite"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.IdSite = "";
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

    public int Insert(List<StaffPoint> sd)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            if (sd.Count > 0)
            {
                string sqlQuery = "insert into t_Staff_Site values";

                for (int i = 0; i < sd.Count - 1; i++)
                {
                    sqlQuery += "('" + sd[0].IdStaff + "', '" + sd[i].IdSite + "'),";
                }
                sqlQuery += "('" + sd[sd.Count - 1].IdStaff + "', '" + sd[sd.Count - 1].IdSite + "')";

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
            string sqlQuery = "update t_Staff_Site set IdStaff = '" + sd.IdStaff + "' where IdStaff = '" + sd.IdStaff + "'";

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
            string sqlQuery = "delete from t_Staff_Site where IdStaff = '" + id + "'";
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