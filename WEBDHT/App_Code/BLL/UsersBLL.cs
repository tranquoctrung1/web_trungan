using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
/// <summary>
/// Truy vấn dữ liệu người dùng
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class UsersBLL
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
    /// Lấy tất cả dữ liệu người dùng
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public List<UserViewModel> Get4View()
    {
        DataContext.ExecuteCommand("UPDATE t_User_Users SET [Active] = 0 WHERE DATEDIFF(minute,ISNULL([TimeStamp],GETDATE()),GETDATE()) > 20");
        DataContext.SubmitChanges();
        return (from u in DataContext.Users
                join s in DataContext.UserStaffs on u.StaffId equals s.Id into us
                from s in us.DefaultIfEmpty()
                select new UserViewModel{Active = u.Active,
                    Ip = u.Ip,
                    LogCount = u.LogCount,
                    Pwd = u.Pwd,
                    Role = u.Role,
                    Salt = u.Salt,
                    StaffId = u.StaffId,
                    TimeStamp = u.TimeStamp,
                    Zoom = u.Zoom,
                    Uid = u.Uid,
                    FirstName = s.FirstName,
                    LastName = s.LastName}).ToList();
    }
    /// <summary>
    /// Lấy dữ liệu một người dùng theo user id
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public User GetByUid(string uid)
    {
        return DataContext.Users.SingleOrDefault(u => u.Uid == uid);
    }
    /// <summary>
    /// Thêm mới dữ liệu người dùng
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert)]
    public CommandStatus Insert(User user)
    {
        CommandStatus status = new CommandStatus();
        DataContext.Users.InsertOnSubmit(user);
        try
        {
            DataContext.SubmitChanges();
            status.Inserted = true;
        }
        catch (Exception e)
        {
            status.Error = true;
            status.ErrorMessage = e.Message;
        }
        return status;
    }
    /// <summary>
    /// Cập nhật dữ liệu người dùng
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update)]
    public CommandStatus Update(User user)
    {
        CommandStatus status = new CommandStatus();
        User dbUser = DataContext.Users.SingleOrDefault(u => u.Uid == user.Uid);
        if (dbUser != null)
        {
            dbUser.Active = user.Active ?? dbUser.Active;
            dbUser.Company = user.Company;
            dbUser.Ip = user.Ip ?? dbUser.Ip;
            dbUser.LogCount = user.LogCount ?? dbUser.LogCount;
            dbUser.Pwd = user.Pwd;
            dbUser.Role = user.Role;
            dbUser.Salt = user.Salt;
            dbUser.StaffId = user.StaffId;
            dbUser.TimeStamp = user.TimeStamp ?? dbUser.TimeStamp;
            dbUser.Zoom = user.Zoom ?? dbUser.Zoom;
        }
        try
        {
            DataContext.SubmitChanges();
            status.Updated = true;
        }
        catch (Exception e)
        {
            status.Error = true;
            status.ErrorMessage = e.Message;
        }
        return status;
    }
    /// <summary>
    /// Cập nhật trạng thái người dung
    /// </summary>
    /// <param name="uid"></param>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update, false)]
    public void UpdateUserStatus(string uid)
    {
        User user = DataContext.Users.SingleOrDefault(u => u.Uid == uid);
        user.TimeStamp = DateTime.Now;
        user.Active = true;
        string hostName = Dns.GetHostName();
        user.Ip = Dns.GetHostAddresses(hostName).GetValue(0).ToString();
        DataContext.SubmitChanges();
    }
    /// <summary>
    /// Xóa người dùng
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Delete)]
    public CommandStatus Delete(string uid)
    {
        CommandStatus status = new CommandStatus();
        User dbUser = DataContext.Users.SingleOrDefault(u => u.Uid == uid);
        if (dbUser != null)
        {
            DataContext.Users.DeleteOnSubmit(dbUser);
        }
        try
        {
            DataContext.SubmitChanges();
            status.Deleted = true;
        }
        catch (Exception e)
        {
            status.Error = true;
            status.ErrorMessage = e.Message;
        }
        return status;
    }
}