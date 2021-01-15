using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DistrictBLL
/// </summary>
public class DistrictBLL
{
    public List<District> GetDistricts()
    {
        List<District> list = new List<District>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select IdDistrict, Name, Description from t_District";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    District el = new District();

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
                        el.Name = reader["Name"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Name = "";
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
    
    public District GetDistrictById(string id)
    {
        District d = new District();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select IdDistrict, Name, Description from t_District where IdDistrict = '" + id + "'";
            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try
                    {
                        d.IdDistrict = reader["IdDistrict"].ToString();
                    }
                    catch (Exception ex)
                    {
                        d.IdDistrict = "";
                    }
                    try
                    {
                        d.Name = reader["Name"].ToString();
                    }
                    catch (Exception ex)
                    {
                        d.Name = "";
                    }
                    try
                    {
                        d.Description = reader["Description"].ToString();
                    }
                    catch (Exception ex)
                    {
                        d.Description = "";
                    }

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

        return d;
    }

    public int Insert(District d)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            string sqlQuery = "insert into t_District values(N'" + d.IdDistrict + "', N'" + d.Name + "', N'" + d.Description + "')";
            connect.Connected();

            nRows = connect.ExcuteNonQuery(sqlQuery);
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

    public int Update(District d)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            string sqlQuery = "update t_District set  Name = N'"+d.Name+ "', Description = N'" +d.Description+ "' where IdDistrict = '" + d.IdDistrict+"'";
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
            string sqlQuery = "delete from  t_District where IdDistrict = '" + id+ "'";
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