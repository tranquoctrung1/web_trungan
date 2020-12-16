using System;
using System.Collections.Generic;
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