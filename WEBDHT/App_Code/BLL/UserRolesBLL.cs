using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn dữ liệu quyền sử dụng
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class UserRolesBLL
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
    /// Lấy tất cả các quyền
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public IQueryable<UserRole> GetAll()
    {
        return DataContext.UserRoles;
    }
    /// <summary>
    /// Lấy thông tin một quyền
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public UserRole GetByRole(string role)
    {
        return DataContext.UserRoles.SingleOrDefault(r => r.Role == role);
    }
    /// <summary>
    /// Thêm mới quyền sử dụng
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert)]
    public CommandStatus Insert(UserRole role)
    {
        CommandStatus status = new CommandStatus();
        DataContext.UserRoles.InsertOnSubmit(role);
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
    /// Cập nhật quyền sử dụng
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update)]
    public CommandStatus Update(UserRole role)
    {
        CommandStatus status = new CommandStatus();
        UserRole dbRole = DataContext.UserRoles.SingleOrDefault(r => r.Role == role.Role);
        if (dbRole != null)
        {
            dbRole.Description = role.Description;
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
    /// Xóa quyền sử dụng
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public CommandStatus Delete(string role)
    {
        CommandStatus status = new CommandStatus();
        UserRole dbRole = DataContext.UserRoles.SingleOrDefault(r => r.Role == role);
        if (dbRole != null)
        {
            DataContext.UserRoles.DeleteOnSubmit(dbRole);
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