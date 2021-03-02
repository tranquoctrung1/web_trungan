using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StatusDMABLL
/// </summary>
public class StatusDMABLL
{
   public List<StatusDMA> GetAll()
    {

        List<StatusDMA> list = new List<StatusDMA>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select [Status], [Description] from [t_Status_DMA]";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    StatusDMA el = new StatusDMA();

                    try
                    {
                        el.Status = reader["Status"].ToString();
                    }
                    catch(Exception ex)
                    {
                        el.Status = "";
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