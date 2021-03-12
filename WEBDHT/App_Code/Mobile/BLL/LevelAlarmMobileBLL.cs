using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LevelAlarmBLL
/// </summary>
public class LevelAlarmMobileBLL
{
    public List<LevelAlarmMobile> GetLevelAlarms()
    {
        List<LevelAlarmMobile> list = new List<LevelAlarmMobile>();
        Connect connect = new Connect();

        // the character N for comparing Vietnamese language
        try
        {
            string sqlQuery = "select [Level], [Value] from [t_LevelAlarm] order by Value desc";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LevelAlarmMobile el = new LevelAlarmMobile();
                    try
                    {
                        el.Level = reader["Level"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Level = "";
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

    public LevelAlarmMobile GetLevelAlarmById(string id) // id is a level example: Cao, Rất cao
    {
        LevelAlarmMobile la = new LevelAlarmMobile();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select [Level], [Value] from [t_LevelAlarm] where [Level] = N'" + id + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try
                    {
                        la.Level = reader["Level"].ToString();
                    }
                    catch (Exception ex)
                    {
                        la.Level = "";
                    }
                    try
                    {
                        la.Value = double.Parse(reader["Value"].ToString());
                    }
                    catch (Exception ex)
                    {
                        la.Value = null;
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
            connect.DisConnected();
        }

        return la;
    }

    public int Insert(LevelAlarmMobile la)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            string sqlQuery = "insert into [t_LevelAlarm] values(N'" + la.Level + "', '" + la.Value + "')";
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

        return nRows;
    }

    public int Update(LevelAlarmMobile la)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            string sqlQuery = "update [t_LevelAlarm] set Value = '" + la.Value + "' where [Level] = N'" + la.Level + "'";

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

        return nRows;
    }

    public int Delete(string id)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            string sqlQuery = "delete from [t_LevelAlarm] where [Level] = '" + id + "'";

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

        return nRows;
    }
}