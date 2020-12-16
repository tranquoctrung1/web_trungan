using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn dữ liệu loại kiểm định t_Meter_AccreditationTypes
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class MeterAccreditationTypesBLL
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
    /// Lấy tất cả loại kiểm định
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<MeterAccreditationType> GetAll()
    {
        return DataContext.MeterAccreditationTypes.OrderBy(t => t.AccreditationType);
    }
    /// <summary>
    /// Lấy một loại kiểm định theo mã
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public MeterAccreditationType GetByAccreditationType(string type)
    {
        return DataContext.MeterAccreditationTypes.SingleOrDefault(t => t.AccreditationType == type);
    }
    /// <summary>
    /// Thêm mới một loại kiểm định
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert)]
    public CommandStatus Insert(MeterAccreditationType type)
    {
        CommandStatus status = new CommandStatus();
        DataContext.MeterAccreditationTypes.InsertOnSubmit(type);
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
    /// Cập nhật một loại kiểm định
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update)]
    public CommandStatus Update(MeterAccreditationType type)
    {
        CommandStatus status = new CommandStatus();
        MeterAccreditationType dbType = DataContext.MeterAccreditationTypes.SingleOrDefault(t => t.AccreditationType == type.AccreditationType);
        if (dbType != null)
        {
            dbType.Description = type.Description;
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
    /// Xóa một loại kiểm định
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public CommandStatus Delete(string type)
    {
        CommandStatus status = new CommandStatus();
        MeterAccreditationType dbType = DataContext.MeterAccreditationTypes.SingleOrDefault(t => t.AccreditationType == type);
        if (dbType != null)
        {
            DataContext.MeterAccreditationTypes.DeleteOnSubmit(dbType);
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