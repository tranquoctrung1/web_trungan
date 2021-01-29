using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetChannelDataDailyAction
    {
        public List<ChannelDataDailyViewModel> GetChannelDataDaily(string siteid, string start, string end)
        {
            List<ChannelDataDailyViewModel> list = new List<ChannelDataDailyViewModel>();
            DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
            DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);
            Connect connect = new Connect();

            try
            {
                string store = "p_Calculate_One_Site_Daily_Output";

                connect.Connected();

                SqlCommand command = connect.ExcuteStoreProceduce(store);
                command.Parameters.Add(new SqlParameter("@SiteId", siteid));
                command.Parameters.Add(new SqlParameter("@Start", timeStart));
                command.Parameters.Add(new SqlParameter("@End", timeEnd));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ChannelDataDailyViewModel el = new ChannelDataDailyViewModel();
                        try
                        {
                            el.Timestamp = DateTime.Parse(reader["TimeStamp"].ToString());
                        }
                        catch (Exception ex)
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
}