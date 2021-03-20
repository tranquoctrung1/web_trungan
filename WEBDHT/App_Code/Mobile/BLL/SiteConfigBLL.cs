using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SiteConfigBLL
/// </summary>
public class SiteConfigBLL
{
   public int UpdateNumberTypeChannel(string loggerid, string number, string type)
    {
        int nRows = 0;

        Connect connect = new Connect();

        string sqlQuery = "";

        if(type  == "1")
        {
            sqlQuery = "update t_Devices_SitesConfigs set Pressure = '" + number + "' where Id = '" + loggerid + "'";
        }
        else if(type == "2")
        {
            sqlQuery = "update t_Devices_SitesConfigs set Pressure2 = '" + number + "' where Id = '" + loggerid + "'";
        }
        else if (type == "3")
        {
            sqlQuery = "update t_Devices_SitesConfigs set Forward = '" + number + "' where Id = '" + loggerid + "'";
        }
        else if (type == "4")
        {
            sqlQuery = "update t_Devices_SitesConfigs set Reverse = '" + number + "' where Id = '" + loggerid + "'";
        }


        if (sqlQuery != "")
        {

            try
            {
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
        }

        return nRows;
    }
}