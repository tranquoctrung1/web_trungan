using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Lấy các trạng thái thiết bị trong bảng t_Devices_Configs
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class DeviceStatusBLL
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
    /// Lấy tất cả các trạng thái thiết bị
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<DeviceStatus> GetAll()
    {
        return DataContext.DeviceStatus.OrderBy(d => d.Status);
    }
    /// <summary>
    /// Lấy mô tả trạng thái
    /// </summary>
    /// <param name="deviceStatus"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public DeviceStatus GetByStatus(string deviceStatus)
    {
        return DataContext.DeviceStatus.SingleOrDefault(a => a.Status == deviceStatus);
    }
    /// <summary>
    /// Thêm mới một trạng thái
    /// </summary>
    /// <param name="deviceStatus"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert)]
    public CommandStatus Insert(DeviceStatus deviceStatus)
    {
        CommandStatus status = new CommandStatus();
        DataContext.DeviceStatus.InsertOnSubmit(deviceStatus);
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
    /// Cập nhật một trạng thái thiết bị
    /// </summary>
    /// <param name="deviceStatus"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update)]
    public CommandStatus Update(DeviceStatus deviceStatus)
    {
        CommandStatus status = new CommandStatus();
        DeviceStatus dbStatus = DataContext.DeviceStatus.SingleOrDefault(s => s.Status == deviceStatus.Status);
        if (dbStatus != null)
        {
            dbStatus.Description = deviceStatus.Description;
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
    /// Xóa một trạng thái thiết bị
    /// </summary>
    /// <param name="deviceStatus"></param>
    /// <returns></returns>
    public CommandStatus Delete(string deviceStatus)
    {
        CommandStatus status = new CommandStatus();
        DeviceStatus dbStatus = DataContext.DeviceStatus.SingleOrDefault(s => s.Status == deviceStatus);
        if (dbStatus != null)
        {
            DataContext.DeviceStatus.DeleteOnSubmit(dbStatus);
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