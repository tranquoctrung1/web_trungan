using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn dữ liệu thiết bị bộ hiển thị
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class TransmittersBLL
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
    /// Xóa bộ hiển thị
    /// </summary>
    /// <param name="serial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Delete, false)]
    public CommandStatus Delete(string serial)
    {
        CommandStatus status = new CommandStatus();
        var dbTransmitter = DataContext.Transmitters.SingleOrDefault(t => t.Serial == serial);
        if(dbTransmitter != null)
        {
            DataContext.Transmitters.DeleteOnSubmit(dbTransmitter);
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
        else
        {
            status.Error = true;
            status.ErrorMessage = "Không thể xóa";
            return status;
        }

        
    }
    /// <summary>
    /// Xóa các bộ hiển thị không sử dụng (không tồn tại trong lịch sử hoặc không lắp đặt)
    /// </summary>
    /// <param name="listSerial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Delete, false)]
    public CommandStatus DeleteUseless(List<string> listSerial)
    {
        CommandStatus status = new CommandStatus();
        var uselessTransmitters = DataContext.Transmitters.Where(t => listSerial.Contains(t.Serial));
        DataContext.Transmitters.DeleteAllOnSubmit(uselessTransmitters);
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
    /// <summary>
    /// Lấy tất cả bộ hiển thị
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IOrderedQueryable<Transmitter> GetAll()
    {
        return DataContext.Transmitters.OrderBy(t => t.Serial);
    }
    /// <summary>
    /// Lấy tất cả các bộ hiển thị không sử dụng
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IOrderedQueryable<Transmitter> GetAllUseless()
    {
        SiteTransmitterHistoriesBLL _siteTransmitterHistoriesBLL = new SiteTransmitterHistoriesBLL();
        var list = _siteTransmitterHistoriesBLL.GetAllTransmmiterSerial();
        var usingTransmitters = DataContext.Sites.Select(s => s.Transmitter).Distinct();
        return DataContext.Transmitters.Where(t => !usingTransmitters.Contains(t.Serial) && !list.Contains(t.Serial)).OrderBy(m => m.Serial);
    }
    /// <summary>
    /// Lấy tất cả bộ hiển thị theo tình trạng lắp đặt
    /// </summary>
    /// <param name="installed"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<Transmitter> GetAllByInstalled(bool installed)
    {
        return DataContext.Transmitters.OrderBy(t => t.Serial).Where(t => t.Installed == installed);
    }
    /// <summary>
    /// Lấy tất cả seri bộ hiển thị
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllSerials()
    {
        return DataContext.Transmitters.OrderBy(t => t.Serial).Select(t => t.Serial);
    }
    /// <summary>
    /// Lấy tất cả nhà sản xuất bộ hiển thị
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllProviders()
    {
        return DataContext.Transmitters.OrderBy(t => t.Provider).Select(t => t.Provider ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả hiệu 
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllMarks()
    {
        return DataContext.Transmitters.OrderBy(t => t.Marks).Select(t => t.Marks ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả cỡ
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<short> GetAllSizes()
    {
        return DataContext.Transmitters.OrderBy(t => t.Size).Select(t => t.Size ?? 0).Distinct();
    }
    /// <summary>
    /// Lấy tất cả model
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllModels()
    {
        return DataContext.Transmitters.OrderBy(t => t.Model).Select(t => t.Model ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy thông tin của một bộ hiển thị
    /// </summary>
    /// <param name="serial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public Transmitter GetBySerial(string serial)
    {
        return DataContext.Transmitters.SingleOrDefault(t => t.Serial == serial);
    }
    /// <summary>
    /// Thêm mới một bộ hiển thị
    /// </summary>
    /// <param name="transmitter"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert, false)]
    public CommandStatus Insert(Transmitter transmitter)
    {
        CommandStatus status = new CommandStatus();
        DataContext.Transmitters.InsertOnSubmit(transmitter);
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
    /// Cập nhật bộ hiển thị
    /// </summary>
    /// <param name="transmitter"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update, false)]
    public CommandStatus Update(Transmitter transmitter)
    {
        CommandStatus status = new CommandStatus();
        var dbTransmitter = DataContext.Transmitters.SingleOrDefault(t => t.Serial == transmitter.Serial);
        dbTransmitter.ApprovalDate = transmitter.ApprovalDate;
        dbTransmitter.ApprovalDecision = transmitter.ApprovalDecision;
        dbTransmitter.Approved = transmitter.Approved;
        dbTransmitter.Description = transmitter.Description;
        dbTransmitter.InitialIndex = transmitter.InitialIndex;
        dbTransmitter.Installed = transmitter.Installed;
        dbTransmitter.Marks = transmitter.Marks;
        dbTransmitter.Model = transmitter.Model;
        dbTransmitter.Provider = transmitter.Provider;
        dbTransmitter.ReceiptDate = transmitter.ReceiptDate;
        dbTransmitter.Serial = transmitter.Serial;
        dbTransmitter.Size = transmitter.Size;
        dbTransmitter.Status = transmitter.Status;
        dbTransmitter.AccreditationDocument = transmitter.AccreditationDocument;
        dbTransmitter.AccreditationType = transmitter.AccreditationType;
        dbTransmitter.AccreditedDate = transmitter.AccreditedDate;
        dbTransmitter.MeterSerial = transmitter.MeterSerial;
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
    /// List các bộ hiển thị theo tiêu chí
    /// </summary>
    /// <param name="listProviders"></param>
    /// <param name="listMarks"></param>
    /// <param name="listModels"></param>
    /// <param name="listSizes"></param>
    /// <param name="listStatus"></param>
    /// <param name="listInstalled"></param>
    /// <param name="listSiteStatus"></param>
    /// <param name="listSiteCompanies"></param>
    /// <returns></returns>
    public List<TransmitterViewModel> GetAllByConds(List<string> listProviders, List<string> listMarks,
        List<string> listModels, List<short> listSizes, List<string> listStatus, List<bool> listInstalled, 
        List<string>listSiteStatus, List<string>listSiteCompanies)
    {
        return (from t in DataContext.Transmitters
                join s in DataContext.Sites on t.Serial equals s.Transmitter into ts
                where listProviders.Contains(t.Provider ?? "")
                && listMarks.Contains(t.Marks ?? "")
                && listModels.Contains(t.Model ?? "")
                && listSizes.Contains(t.Size ?? 0)
                && listStatus.Contains(t.Status ?? "")
                && listInstalled.Contains(t.Installed ?? false)
                orderby t.Serial
                from s in ts.DefaultIfEmpty()
                where t.Serial != string.Empty
                && listSiteStatus.Contains(s.Status??"")
                && listSiteCompanies.Contains(s.Company??"")
                select new TransmitterViewModel
                {
                    Serial = t.Serial,
                    ReceiptDate = t.ReceiptDate,
                    Provider = t.Provider,
                    Marks = t.Marks,
                    Size = t.Size,
                    Model = t.Model,
                    Status = t.Status,
                    Installed = t.Installed,
                    InitialIndex = t.InitialIndex,
                    Description = t.Description,
                    SiteId = s.Id,
                    Location = s.Location,
                    SiteStatus=s.Status,
                    SiteCompany=s.Company
                    
                }).ToList();
    }
}