using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LevelAlarmBLL
/// </summary>
public class LevelAlarmBLL
{
    public List<LevelAlarm> GetLevelAlarms()
    {
        List<LevelAlarm> list = new List<LevelAlarm>();
        Connect connect = new Connect();

        // the character N for comparing Vietnamese language
        try
        {
            string sqlQuery = "select [Level], [Value] from [t_LevelAlarm] order by Value desc";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    LevelAlarm el = new LevelAlarm();
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

    public LevelAlarm GetLevelAlarmById(string id) // id is a level example: Cao, Rất cao
    {
        LevelAlarm la = new LevelAlarm();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select [Level], [Value] from [t_LevelAlarm] where [Level] = N'"+id+"'";

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

    public int Insert(LevelAlarm la )
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

    public int Update(LevelAlarm la)
    {
        Connect connect = new Connect();
        int nRows = 0;
        try
        {
            string sqlQuery = "update [t_LevelAlarm] set Value = '" + la.Value + "' where [Level] = N'" + la.Level + "'";

            connect.Connected();
            nRows = connect.ExcuteNonQuery(sqlQuery);
        }
        catch(SqlException ex)
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