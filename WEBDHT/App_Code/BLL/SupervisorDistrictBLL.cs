using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupervisorDistrictBLL
/// </summary>
public class SupervisorDistrictBLL
{
    public List<SupervisorDistrict> GetSiteDMAs()
    {
        List<SupervisorDistrict> list = new List<SupervisorDistrict>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select IdStaff, IdDistrict from t_Supervisor_District";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SupervisorDistrict el = new SupervisorDistrict();

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
                        el.IdDistrict = reader["IdDistrict"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.IdDistrict = "";
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

    public List<SupervisorDistrict> GetSupervisorDistrictById(string id)
    {
        List<SupervisorDistrict> list = new List<SupervisorDistrict>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select IdStaff, IdDistrict from t_Supervisor_District where IdStaff = '" + id + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SupervisorDistrict el = new SupervisorDistrict();

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
                        el.IdDistrict = reader["IdDistrict"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.IdDistrict = "";
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

    public int Insert(List<SupervisorDistrict> sd)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            if (sd.Count > 0)
            {
                string sqlQuery = "insert into t_Supervisor_District values";

                for (int i = 0; i < sd.Count - 1; i++)
                {
                    sqlQuery += "('" + sd[0].IdStaff + "', '" + sd[i].IdDistrict + "'),";
                }
                sqlQuery += "('" + sd[sd.Count - 1].IdStaff + "', '" + sd[sd.Count - 1].IdDistrict + "')";

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

    public int Update(SupervisorDistrict sd)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            string sqlQuery = "update t_Supervisor_District set IdStaff = '" + sd.IdStaff + "' where IdStaff = '" + sd.IdDistrict + "'";

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
            string sqlQuery = "delete from t_Supervisor_District where IdStaff = '" + id + "'";
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