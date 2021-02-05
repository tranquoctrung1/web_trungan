using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class CheckYearBatteryAction
    {
        public bool CheckYearBattery(string id)
        {
            // comparing time now is not into 7 days alarm of battery year
            bool isUpdate = false;

            Nullable<DateTime> dateInstallBattery = null;
            Nullable<int> yearBattery =  null;

            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select DateInstallBattery, YearBattery from t_Devices_Loggers where Serial = '{id}'";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        try
                        {
                            dateInstallBattery = DateTime.Parse(reader["DateInstallBattery"].ToString());
                        }
                        catch(Exception ex)
                        {
                            dateInstallBattery = null;
                        }
                        try
                        {
                            yearBattery = int.Parse(reader["YearBattery"].ToString());
                        }
                        catch (Exception ex)
                        {
                            yearBattery = null;
                        }
                    }
                }

                if(dateInstallBattery != null && yearBattery != null)
                {
                    if(Math.Abs((dateInstallBattery.Value.AddMonths(yearBattery.Value)  -  DateTime.Now).TotalDays) > 7)
                    {
                        isUpdate = true;
                    }
                    else
                    {
                        isUpdate = false;
                    }
                }
                else
                {
                    isUpdate = false;
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

            return isUpdate;
        }
    }
}