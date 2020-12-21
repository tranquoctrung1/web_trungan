using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class DataChannelChartAction
    {
        public List<DataChannelChartViewModel> GetDataChannelChart(string channelid, string start, string end)
        {
            List<DataChannelChartViewModel> list = new List<DataChannelChartViewModel>();
            DateTime startDate = new DateTime(1970, 01, 01).AddSeconds(Convert.ToInt32(double.Parse(start))).AddHours(7);
            DateTime endDate = new DateTime(1970, 01, 01).AddSeconds(Convert.ToInt32(double.Parse(end))).AddHours(7);

            try
            {
                string sqlQuery = $"select TimeStamp, Value from t_Data_{channelid} where TimeStamp between convert(nvarchar, '{startDate}', 120) and convert(nvarchar, '{endDate}', 120)";

                Connect.ConnectToDataBase();

                SqlDataReader reader = Connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        DataChannelChartViewModel el = new DataChannelChartViewModel();
                        try
                        {
                            el.Timestamp = DateTime.Parse(reader["TimeSTamp"].ToString());
                        }
                        catch(Exception ex)
                        {
                            el.Timestamp = null;
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
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //Connect.DisconnectToDataBase();
            }

            return list;
        }
    }
}