using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GetLastValue
/// </summary>
public class GetLastValue
{
    public double? GetLastValueActon(string channelid)
    {
        double? value = null;
        Connect connect = new Connect();
        try
        {
            string sqlQuery = "select top(1) Value from t_Data_" + channelid + " order by TimeStamp desc";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try
                    {
                        value = double.Parse(reader["Value"].ToString());
                    }
                    catch (Exception ex)
                    {
                        value = null;
                    }
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

        return value;
    }
}