using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetMultipleDataAction
    {
        public List<ChannelMultipleDataViewModel> GetChannelMultipleData(string listChannelId, string start, string end)
        {
            DateTime dStart = new DateTime(1970, 01, 01).AddSeconds(Convert.ToInt32(double.Parse(start))).AddHours(7);
            DateTime dEnd = new DateTime(1970, 01, 01).AddSeconds(Convert.ToInt32(double.Parse(end))).AddHours(7);

            string[] channels = listChannelId.Split('|');

            List<ChannelMultipleDataViewModel> lst = new List<ChannelMultipleDataViewModel>();
            Connect connect = new Connect();
            try
            {
                connect.Connected();

                string temp = "";
                string tempi = "";
                for (int i = 0; i < channels.Length; i++)
                {
                    if (i != channels.Length - 1)
                    {
                        temp += "SELECT *, " + i.ToString() + " as col FROM [t_Data_" + channels[i] + "] where [Timestamp] between "
                            + "convert(nvarchar, '" + dStart+"', 120)"
                            + " and "
                            + "convert(nvarchar, '" + dEnd + "', 120)" + " UNION ";

                        tempi += "[" + i.ToString() + "],";
                    }
                    else
                    {
                        temp += "SELECT *, " + i.ToString() + " as col FROM [t_Data_" + channels[i] + "] where [Timestamp] between "
                            + "convert(nvarchar, '" + dStart + "', 120)"
                            + " and "
                            + "convert(nvarchar, '" + dEnd + "', 120)" + "";

                        tempi += "[" + i.ToString() + "]";
                    }
                }
                string cmdText = "SELECT * FROM (";
                cmdText += temp;
                cmdText += ") AS myTBL ";
                cmdText += "PIVOT(sum(Value) ";
                cmdText += "FOR col IN (" + tempi + ")";
                cmdText += ") AS myTable order by [Timestamp]";


                SqlDataReader rd = connect.Select(cmdText);

                if(rd.HasRows)
                {
                    while(rd.Read())
                    {
                        ChannelMultipleDataViewModel d = new ChannelMultipleDataViewModel();
                        List<double?> vals = new List<double?>();

                        d.Timestamp = (DateTime)rd["timestamp"];
                        for (int i = 0; i < channels.Length; i++)
                        {
                            if (rd[i.ToString()] != DBNull.Value)
                                vals.Add((double)rd[i.ToString()]);
                            else vals.Add(null);
                        }
                        d.Values = vals;
                        lst.Add(d);
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

            return lst;
        }
    }
}