using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDataHistoryAction
    {
        public List<DataGraphViewModel> GetDataHistory(string channelID, string start, string end)
        {
            DateTime timeStart = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);
            DateTime timeEnd = new DateTime(1970, 01, 01).AddSeconds(int.Parse(end)).AddHours(7);

            List<DataGraphViewModel> list = new List<DataGraphViewModel>();

            try
            {
                string sqlQuery = $"select TimeStamp, Value from t_Data_{channelID} where TimeStamp >= convert(nvarchar, '{timeStart}', 120) and TimeStamp <= convert(nvarchar, '{timeEnd}', 120) order by TimeStamp desc";

                Connect.ConnectToDataBase();

                SqlDataReader reader = Connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        DataGraphViewModel el = new DataGraphViewModel();
                        try
                        {
                            el.TimeStamp = DateTime.Parse(reader["TimeStamp"].ToString());
                        }
                        catch(Exception ex)
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
                        try
                        {
                            el.ChannelName = channelID;
                        }
                        catch(Exception ex)
                        {
                            el.ChannelName = "";
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
                Connect.DisconnectToDataBase();
            }

            return list;
        }
        
        public int GetCountDataHistory(string channelID)
        {
            int count = 0;

            try
            {
                string sqlQuery = $"select Count(*) as Count from t_Data_{channelID} ";

                Connect.ConnectToDataBase();

                SqlDataReader reader = Connect.Select(sqlQuery);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            count = int.Parse(reader["Count"].ToString());
                        }
                        catch (Exception ex)
                        {
                            count = 0;
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
                Connect.DisconnectToDataBase();
            }

            return count;
        }
    }    
}
