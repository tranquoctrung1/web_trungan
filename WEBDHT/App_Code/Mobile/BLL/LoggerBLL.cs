using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoggerBLL
/// </summary>
public class LoggerBLL
{
    public Logger GetLoggerById(string loggerid)
    {
        Logger el = new Logger();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "SELECT d.[Serial], d.[ReceiptDate], d.[Provider], d.[Marks], d.[Model], d.[Status], d.[Installed], d.[Description], d.[DateAccreditation], d.[DateInstallBattery], d.[YearBattery] FROM [t_Devices_Loggers] d  order by [Serial]";

            connect.Connected();

           SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   
                    try
                    {
                        el.Serial = reader["Serial"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Serial = "";
                    }
                    try
                    {
                        el.ReceiptDate = DateTime.Parse(reader["ReceiptDate"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.ReceiptDate = null;
                    }
                    try
                    {
                        el.Provider = reader["Provider"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Provider = "";
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
                        el.Model = reader["Model"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Model = "";
                    }
                    try
                    {
                        el.Status = reader["Status"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Status = "";
                    }
                    try
                    {
                        el.Installed = bool.Parse(reader["Installed"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Installed = null;
                    }
                    try
                    {
                        el.Description = reader["Description"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Description = "";
                    }
                    try
                    {
                        el.DateAccreditation = DateTime.Parse(reader["DateAccreditation"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.DateAccreditation = null;
                    }
                    try
                    {
                        el.DateInstallBattery = DateTime.Parse(reader["DateInstallBattery"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.DateInstallBattery = null;
                    }
                    try
                    {
                        el.YearBattery = int.Parse(reader["YearBattery"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.YearBattery = null;
                    }
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

        return el;
    }

    public bool CheckExistsLogger(string loggerid)
    {
        bool check = false;

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select * from t_Devices_Loggers  where Serial = '" + loggerid + "'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                check = true;
            }
            else
            {
                check = false;
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

        return check;
    }


    public bool Insert(string loggerid , string receiptdate, string provider ,string marks, string model, string status, string install, string dateinstallbattery, string dateaccreditation, string yearbattery, string description)
    {
        LoggersBLL loggersBLL = new LoggersBLL();
        Logger l = new Logger();

        l.Serial = loggerid;
        try
        {
            l.ReceiptDate = new DateTime(1970, 01, 01).AddHours(7).AddSeconds(int.Parse(receiptdate));
        }
        catch
        {
            l.ReceiptDate = null;
        }
        l.Provider = provider;
        l.Marks = marks;
        l.Model = model;
        l.Status = status;
        try
        {
            l.Installed = bool.Parse(install);
        }
        catch
        {
            l.Installed = null;
        }
        try
        {
            l.DateInstallBattery = new DateTime(1970, 01, 01).AddHours(7).AddSeconds(int.Parse(dateinstallbattery));
        }
        catch
        {
            l.DateInstallBattery = null;
        }
        try
        {
            l.DateAccreditation = new DateTime(1970, 01, 01).AddHours(7).AddSeconds(int.Parse(dateaccreditation));
        }
        catch
        {
            l.DateAccreditation = null;
        }
        try
        {
            l.YearBattery = int.Parse(yearbattery);
        }
        catch
        {
            l.YearBattery = null;
        }
        l.Description = description;

        CommandStatus command = new CommandStatus();

        command = loggersBLL.Insert(l);

        return command.Inserted;
    }


    public bool Update(string loggerid, string receiptdate, string provider, string marks, string model, string status, string install, string dateinstallbattery, string dateaccreditation, string yearbattery, string description)
    {
        LoggersBLL loggersBLL = new LoggersBLL();
        Logger l = new Logger();

        l.Serial = loggerid;
        try
        {
            l.ReceiptDate = new DateTime(1970, 01, 01).AddHours(7).AddSeconds(int.Parse(receiptdate));
        }
        catch
        {
            l.ReceiptDate = null;
        }
        l.Provider = provider;
        l.Marks = marks;
        l.Model = model;
        l.Status = status;
        try
        {
            l.Installed = bool.Parse(install);
        }
        catch
        {
            l.Installed = null;
        }
        try
        {
            l.DateInstallBattery = new DateTime(1970, 01, 01).AddHours(7).AddSeconds(int.Parse(dateinstallbattery));
        }
        catch
        {
            l.DateInstallBattery = null;
        }
        try
        {
            l.DateAccreditation = new DateTime(1970, 01, 01).AddHours(7).AddSeconds(int.Parse(dateaccreditation));
        }
        catch
        {
            l.DateAccreditation = null;
        }
        try
        {
            l.YearBattery = int.Parse(yearbattery);
        }
        catch
        {
            l.YearBattery = null;
        }
        l.Description = description;

        CommandStatus command = new CommandStatus();

        command = loggersBLL.Update(l);

        return command.Updated;
    }

    public bool Delete(string loggerid)
    {
        LoggersBLL loggersBLL = new LoggersBLL();

        CommandStatus command = new CommandStatus();

        command = loggersBLL.Delete(loggerid);

        return command.Deleted;
    }
}