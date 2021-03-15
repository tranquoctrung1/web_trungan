using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuantityDMABLL
/// </summary>
public class QuantityDMABLL
{
    public List<DataQuantityAndChartViewModel> GetDataQuantityAndChartDMA(string dmaid, string start, string end)
    {
        List<DataQuantityAndChartViewModel> list = new List<DataQuantityAndChartViewModel>();
        DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
        DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);

        Connect connect = new Connect();
        try
        {
            string store = "p_Calculate_Hourly_Data_DMA";

            connect.Connected();

            SqlCommand command = connect.ExcuteStoreProceduce(store);
            command.Parameters.Add(new SqlParameter("@dmaid", dmaid));
            command.Parameters.Add(new SqlParameter("@start", timeStart));
            command.Parameters.Add(new SqlParameter("@end", timeEnd));

            command.CommandTimeout = 3600;

            SqlDataReader reader = command.ExecuteReader();

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

    public List<DataQuantityAndChartViewModel> GetDataQuantityAndChartDMADaily(string dmaid, string start, string end)
    {
        List<DataQuantityAndChartViewModel> list = new List<DataQuantityAndChartViewModel>();
        DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
        DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);

        Connect connect = new Connect();
        try
        {
            string store = "p_Calculate_Daily_Data_DMA";

            connect.Connected();

            SqlCommand command = connect.ExcuteStoreProceduce(store);
            command.Parameters.Add(new SqlParameter("@dmaid", dmaid));
            command.Parameters.Add(new SqlParameter("@start", timeStart));
            command.Parameters.Add(new SqlParameter("@end", timeEnd));

            command.CommandTimeout = 3600;

            SqlDataReader reader = command.ExecuteReader();

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

    public List<DataQuantityAndChartViewModel> GetDataQuantityAndChartDMAMonthly(string dmaid, string start, string end)
    {
        List<DataQuantityAndChartViewModel> list = new List<DataQuantityAndChartViewModel>();
        DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
        DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);

        Connect connect = new Connect();
        try
        {
            string store = "p_Calculate_Monthly_Data_DMA";

            connect.Connected();

            SqlCommand command = connect.ExcuteStoreProceduce(store);
            command.Parameters.Add(new SqlParameter("@dmaid", dmaid));
            command.Parameters.Add(new SqlParameter("@start", timeStart));
            command.Parameters.Add(new SqlParameter("@end", timeEnd));

            command.CommandTimeout = 3600;

            SqlDataReader reader = command.ExecuteReader();

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