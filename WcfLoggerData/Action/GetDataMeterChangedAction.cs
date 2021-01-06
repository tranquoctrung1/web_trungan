﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDataMeterChangedAction
    {
        public List<StatisticSiteViewModel> GetDataMeterChanged(string start)
        {
            List<StatisticSiteViewModel> list = new List<StatisticSiteViewModel>();
            DateTime startDate = new DateTime(1970, 01, 01).AddSeconds(int.Parse(start)).AddHours(7);

            try
            {
                string sqlQuery = $"select s.Id,th.NewMeterSerial ,s.Location, m.Marks, m.Size, th.DateChanged, s.DescriptionOfChange, m.AccreditationDocument, m.ExpiryDate, m.ApprovalDecision, th.OldMeterSerial from t_Site_Sites s join t_Devices_Meters m on s.Meter = m.Serial  join t_History_Site_Meters th on th.SiteId = s.Id where s.DateOfMeterChange is not null and convert(nvarchar, '{startDate}', 120) <= s.DateOfMeterChange and th.DateChanged >= convert(nvarchar, '{startDate}', 120)";

                Connect.ConnectToDataBase();

                SqlDataReader reader = Connect.Select(sqlQuery);
                int numberOrdered = 1;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StatisticSiteViewModel el = new StatisticSiteViewModel();
                        try
                        {
                            el.NumberOrdered = numberOrdered++;
                        }
                        catch (Exception ex)
                        {
                            el.NumberOrdered = numberOrdered;
                        }

                        try
                        {
                            el.Meter = reader["NewMeterSerial"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.Meter = "";
                        }
                        el.Transmitter = "";
                        try
                        {
                            el.Level = reader["ApprovalDecision"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Level = "";
                        }
                        try
                        {
                            el.OldMeter = reader["OldMeterSerial"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.OldMeter = "";
                        }
                        el.OldTran = "";
                        try
                        {
                            el.Id = reader["Id"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Id = "";
                        }
                        try
                        {
                            el.Location = reader["Location"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Location = "";
                        }
                        try
                        {
                            el.Marks = reader["Marks"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.Marks = "";
                        }
                        try
                        {
                            el.Size = int.Parse(reader["Size"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.Size = null;
                        }
                        try
                        {
                            el.DateOfChange = DateTime.Parse(reader["DateChanged"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.DateOfChange = null;
                        }
                        try
                        {
                            el.DescriptionOfChange = reader["DescriptionOfChange"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.DescriptionOfChange = "";
                        }
                        try
                        {
                            el.AccreditationDocument = reader["AccreditationDocument"].ToString();
                        }
                        catch (Exception ex)
                        {
                            el.AccreditationDocument = "";
                        }
                        try
                        {
                            el.ExpiryDate = DateTime.Parse(reader["ExpiryDate"].ToString());
                        }
                        catch (Exception ex)
                        {
                            el.ExpiryDate = null;
                        }

                        list.Add(el);
                    }
                }

            }
            catch (SqlException ex)
            {

            }
            finally
            {
                Connect.DisconnectToDataBase();
            }

            return list;
        }
    }
}
