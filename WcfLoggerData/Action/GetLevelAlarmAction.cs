﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetLevelAlarmAction
    {
        public List<LevelAlarmViewModel> GetLevelAlarm()
        {
            List<LevelAlarmViewModel> list = new List<LevelAlarmViewModel>();
            Connect connect = new Connect();
            try
            {
                string sqlQuery = $"select [Level], [Value] from t_LevelAlarm order by [Value] desc";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        LevelAlarmViewModel el = new LevelAlarmViewModel();
                        try
                        {
                            el.Level = reader["Level"].ToString();
                        }
                        catch(Exception ex)
                        {
                            el.Level = "";
                        }
                        try
                        {
                            el.Value =double.Parse(reader["Value"].ToString());
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
                connect.DisConnected();
            }

            return list;
        }
    }
}