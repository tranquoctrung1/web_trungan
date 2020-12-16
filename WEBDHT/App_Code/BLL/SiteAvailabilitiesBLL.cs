using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn dữ liệu tình trạng điểm lắp đặt t_Site_Availabilities
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class SiteAvailabilitiesBLL
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
    /// Lấy tất cả tình trạng điểm lắp đặt
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public IQueryable<SiteAvailability> GetAll()
    {
        return DataContext.SiteAvailabilities.OrderBy(s => s.Availability);
    }
    /// <summary>
    /// Lấy mô tả môt tình trạng
    /// </summary>
    /// <param name="availability"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select)]
    public SiteAvailability GetByAvailability(string availability)
    {
        return DataContext.SiteAvailabilities.SingleOrDefault(a => a.Availability == availability);
    }
    /// <summary>
    /// Thêm mới tình trạng điểm lắp đặt
    /// </summary>
    /// <param name="availability"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert)]
    public CommandStatus Insert(SiteAvailability availability)
    {
        CommandStatus status = new CommandStatus();
        DataContext.SiteAvailabilities.InsertOnSubmit(availability);
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
    /// Cập nhật tình trạng điểm lắp đặt
    /// </summary>
    /// <param name="availability"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update)]
    public CommandStatus Update(SiteAvailability availability)
    {
        CommandStatus status = new CommandStatus();
        SiteAvailability dbAvailability = DataContext.SiteAvailabilities.SingleOrDefault(a => a.Availability == availability.Availability);
        if (dbAvailability != null)
        {
            dbAvailability.Description = availability.Description;
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
    /// Xóa tình trạng điểm lắp đặt
    /// </summary>
    /// <param name="availability"></param>
    /// <returns></returns>
    public CommandStatus Delete(string availability)
    {
        CommandStatus status = new CommandStatus();
        SiteAvailability dbAvailability = DataContext.SiteAvailabilities.SingleOrDefault(a => a.Availability == availability);
        if (dbAvailability != null)
        {
            DataContext.SiteAvailabilities.DeleteOnSubmit(dbAvailability);
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