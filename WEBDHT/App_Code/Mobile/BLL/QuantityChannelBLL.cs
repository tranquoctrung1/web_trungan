using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuantityChannelBLL
/// </summary>
public class QuantityChannelBLL
{
    public List<DataQuantityAndChartViewModel> dataQuantityAndChartChannel(string channelid, string start, string end)
    {
        List<DataQuantityAndChartViewModel> list = new List<DataQuantityAndChartViewModel>();

        DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
        DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);

        Connect connect = new Connect();
        try
        {
            string sqlQuery = "select TimeStamp, Value from t_Data_" + channelid + " where TimeStamp between convert(nvarchar, '" + timeStart.ToString(@"yyyy/MM/dd hh:mm:ss tt", new CultureInfo("en-US")) + "', 120) and convert(nvarchar, '" + timeEnd.ToString(@"yyyy/MM/dd hh:mm:ss tt", new CultureInfo("en-US")) + "', 120) order by TimeStamp desc";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataQuantityAndChartViewModel el = new DataQuantityAndChartViewModel();

                    try
                    {
                        el.TimeStamp = DateTime.Parse(reader["TimeStamp"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.TimeStamp = null;
                    }
                    try
                    {
                        el.Value = double.Parse(reader["Value"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Value = null;
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