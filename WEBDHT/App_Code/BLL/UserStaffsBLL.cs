using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn dữ liệu nhân viên xí nghiệp
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class UserStaffsBLL
{
	/// <summary>
	/// Object LINQ
	/// </summary>
    private FMM_SGWDCDataContext _dataContext = null;
    public FMM_SGWDCDataContext DataContext
    {
        get
        {
            if (_dataContext == null)
            {
                _dataContext = new FMM_SGWDCDataContext();
                _dataContext.CommandTimeout = 60 * 30;
            }
            return _dataContext;
        }
    }
    /// <summary>
    /// Lấy tất cả nhân viên
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<UserStaff> GetAll()
    {
        return DataContext.UserStaffs.OrderBy(s => s.Id);
    }
    /// <summary>
    /// Lấy thông tin một nhân viên theo mã nhân viên
    /// </summary>
    /// <param name="staffId"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public UserStaff GetById(string staffId)
    {
        return DataContext.UserStaffs.SingleOrDefault(s => s.Id == staffId);
    }

    [System.ComponentModel.DataObjectMethod
   (System.ComponentModel.DataObjectMethodType.Select)]
    public List<UserStaff> GetStaffSupervisor()
    {
        List<UserStaff> list = new List<UserStaff>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select [Id], [FirstName], [LastName] from [t_User_Staffs] s join [t_User_Users] u on s.[Id] = u.[StaffId] where u.Role = 'supervisor'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    UserStaff el = new UserStaff();
                    try
                    {
                        el.FirstName = reader["FirstName"].ToString();
                    }
                    catch(Exception ex)
                    {
                        el.FirstName = "";
                    }
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
                        el.LastName = reader["LastName"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LastName = "";
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

    [System.ComponentModel.DataObjectMethod
   (System.ComponentModel.DataObjectMethodType.Select)]
    public List<UserStaff> GetStaffDMA()
    {
        List<UserStaff> list = new List<UserStaff>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select [Id], [FirstName], [LastName] from [t_User_Staffs] s join [t_User_Users] u on s.[Id] = u.[StaffId] where u.Role = 'DMA'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserStaff el = new UserStaff();
                    try
                    {
                        el.FirstName = reader["FirstName"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.FirstName = "";
                    }
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
                        el.LastName = reader["LastName"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LastName = "";
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

    [System.ComponentModel.DataObjectMethod
   (System.ComponentModel.DataObjectMethodType.Select)]
    public List<UserStaff> GetStaffStaff()
    {
        List<UserStaff> list = new List<UserStaff>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select [Id], [FirstName], [LastName] from [t_User_Staffs] s join [t_User_Users] u on s.[Id] = u.[StaffId] where u.Role = 'staff'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserStaff el = new UserStaff();
                    try
                    {
                        el.FirstName = reader["FirstName"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.FirstName = "";
                    }
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
                        el.LastName = reader["LastName"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LastName = "";
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

    [System.ComponentModel.DataObjectMethod
   (System.ComponentModel.DataObjectMethodType.Select)]
    public List<UserStaff> GetStaffConsumer()
    {
        List<UserStaff> list = new List<UserStaff>();
        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select [Id], [FirstName], [LastName] from [t_User_Staffs] s join [t_User_Users] u on s.[Id] = u.[StaffId] where u.Role = 'consumer'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserStaff el = new UserStaff();
                    try
                    {
                        el.FirstName = reader["FirstName"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.FirstName = "";
                    }
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
                        el.LastName = reader["LastName"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LastName = "";
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
    /// <summary>
    /// Thêm mới nhân viên
    /// </summary>
    /// <param name="staff"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert)]
    public CommandStatus Insert(UserStaff staff)
    {
        CommandStatus status = new CommandStatus();
        DataContext.UserStaffs.InsertOnSubmit(staff);
        try
        {
            DataContext.SubmitChanges();
            status.Inserted = true;
        }
        catch (Exception e)
        {
            status.ErrorMessage = e.Message;
            status.Error = true;
        }
        return status;
    }
    /// <summary>
    /// Cập nhật thông tin nhân viên
    /// </summary>
    /// <param name="staff"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update)]
    public CommandStatus Update(UserStaff staff)
    {
        CommandStatus status = new CommandStatus();
        UserStaff dbStaff = DataContext.UserStaffs.SingleOrDefault(s => s.Id == staff.Id);
        if (dbStaff != null)
        {
            dbStaff.FirstName = staff.FirstName;
            dbStaff.LastName = staff.LastName;
        }
        try
        {
            DataContext.SubmitChanges();
            status.Updated = true;
        }
        catch (Exception e)
        {
            status.ErrorMessage = e.Message;
            status.Error = true;
        }
        return status;
    }
    /// <summary>
    /// Xóa nhân viên
    /// </summary>
    /// <param name="staffId"></param>
    /// <returns></returns>
    public CommandStatus Delete(string staffId)
    {
        CommandStatus status = new CommandStatus();
        UserStaff dbStaff = DataContext.UserStaffs.SingleOrDefault(s => s.Id == staffId);
        if (dbStaff != null)
        {
            DataContext.UserStaffs.DeleteOnSubmit(dbStaff);
        }
        try
        {
            DataContext.SubmitChanges();
            status.Deleted = true;
        }
        catch (Exception e)
        {
            status.ErrorMessage = e.Message;
            status.Error = true;
        }
        return status;
    }
}