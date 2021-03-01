using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GetLastIndexValue
/// </summary>
public class GetLastIndexValue
{
   public double? GetLastIndexValueAction(string channelid)
    {
        double? value = null;
        Connect connect = new Connect();
        try
        {
            string sqlQuery = "select Sum(Value) as Sum from t_Data_" + channelid + "";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try
                    {
                        value = double.Parse(reader["Sum"].ToString());
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