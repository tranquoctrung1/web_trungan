using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataRawBLL
/// </summary>
public class DataRawBLL
{
    public DataRawViewModel GetDataRaw(string id, DateTime timeStamp )
    {
        DataRawViewModel dr = new DataRawViewModel();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select SiteId, TimeStamp, Value, Description from t_Data_Raw where TimeStamp = '" + timeStamp.Year + "-" + timeStamp.Month + "-" + timeStamp.Day + "' and SiteId = '" + id + "'";
            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    try
                    {
                        dr.SiteId = reader["SiteId"].ToString();
                    }
                    catch(Exception ex)
                    {
                        dr.SiteId = "";
                    }
                    try
                    {
                        dr.TimeStamp =DateTime.Parse( reader["TimeStamp"].ToString());
                    }
                    catch (Exception ex)
                    {
                        dr.TimeStamp = null;
                    }
                    try
                    {
                        dr.Value = double.Parse(reader["Value"].ToString());
                    }
                    catch (Exception ex)
                    {
                        dr.Value = null;
                    }
                    try
                    {
                        dr.Description = reader["Description"].ToString();
                    }
                    catch (Exception ex)
                    {
                        dr.Description = "";
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

        return dr;
    }

    public int Insert(DataRawViewModel dr)
    {
        int nRows = 0;

        Connect connect = new Connect();
        try
        {
            string sqlQuery = "insert into t_Data_Raw values('" + dr.SiteId + "','"+dr.TimeStamp.Value.Year+"-"+dr.TimeStamp.Value.Month+"-"+dr.TimeStamp.Value.Day+"', '" + dr.Value + "', N'" + dr.Description + "')";

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

    public int Update(DataRawViewModel dr)
    {
        int nRows = 0;

        Connect connect = new Connect();
        try
        {
            string sqlQuery = "update t_Data_Raw set Value = '"+dr.Value+"', Description = N'"+dr.Description+ "' where TimeStamp = '" + dr.TimeStamp.Value.Year + "-" + dr.TimeStamp.Value.Month + "-" + dr.TimeStamp.Value.Day + "' and SiteId = '" + dr.SiteId+"'";

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

    public int Delete(DataRawViewModel dr)
    {
        int nRows = 0;

        Connect connect = new Connect();
        try
        {
            string sqlQuery = "delete from t_Data_Raw where SiteId = '"+dr.SiteId+ "' and TimeStamp = '" + dr.TimeStamp.Value.Year + "-" + dr.TimeStamp.Value.Month + "-" + dr.TimeStamp.Value.Day + "'";

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