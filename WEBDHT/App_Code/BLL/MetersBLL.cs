using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn dữ liệu thiết bị đồng hồ bảng t_Devices_Meters
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class MetersBLL
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
    /// Xóa dữ liệu một đồng hồ
    /// </summary>
    /// <param name="serial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Delete, false)]
    public CommandStatus Delete(string serial)
    {
        CommandStatus status = new CommandStatus();
        var dbMeter = DataContext.Meters.SingleOrDefault(m => m.Serial == serial);
        try
        {
            DataContext.Meters.DeleteOnSubmit(dbMeter);
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
    /// Xóa tất cả đồng hồ không sử dụng (không gắn ở vị trí nào và không tồn tại trong lịch sử)
    /// </summary>
    /// <param name="listSerial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Delete, false)]
    public CommandStatus DeleteUseless(List<string> listSerial)
    {
        CommandStatus status = new CommandStatus();
        var uselessMeters = DataContext.Meters.Where(m => listSerial.Contains(m.Serial));
        DataContext.Meters.DeleteAllOnSubmit(uselessMeters);
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
    /// Lấy tất cả các đồng hồ
    /// </summary>
    /// <returns></returns>
    /// 
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IOrderedQueryable<Meter> GetAll()
    {
        return DataContext.Meters.OrderBy(m => m.Serial);
    }
    /// <summary>
    /// Lấy tất cả các đồng hồ không sử dụng (không gắn ở vị trí nào và không tồn tại trong lịch sử)
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IOrderedQueryable<Meter> GetAllUseless()
    {
        SiteMeterHistoriesBLL _siteMeterHistoriesBLL = new SiteMeterHistoriesBLL();
        var list = _siteMeterHistoriesBLL.GetAllMeterSerial();
        var usingMeter = DataContext.Sites.Select(s => s.Meter).Distinct();
        return DataContext.Meters.Where(m => !usingMeter.Contains(m.Serial) && !list.Contains(m.Serial)).OrderBy(m => m.Serial);
    }
    /// <summary>
    /// Lấy tất cả các quốc gia sản xuất
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllNationalities()
    {
        return DataContext.Meters.OrderBy(m => m.Nationality).Select(m => m.Nationality ?? string.Empty).Distinct();
    }

    /// <summary>
    /// Lấy thông tin một đồng hồ theo số seri
    /// </summary>
    /// <param name="serial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public Meter Get(string serial)
    {
        return DataContext.Meters.SingleOrDefault(m => m.Serial == serial);
    }
    /// <summary>
    /// Lấy tất cả đồng hồ theo tình trạng lắp đặt
    /// </summary>
    /// <param name="installed"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<Meter> GetAllByInstalled(bool installed)
    {
        return DataContext.Meters.OrderBy(m => m.Serial).Where(m => m.Installed == installed);
    }
    /// <summary>
    /// Lấy tất cả số seri đồng hồ
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllSerials()
    {
        return DataContext.Meters.OrderBy(m => m.Serial).Select(m => m.Serial);
    }
    /// <summary>
    /// Lấy tất cả nhà sản xuất
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllProviders()
    {
        return DataContext.Meters.OrderBy(m => m.Provider).Select(m => m.Provider ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả hiệu
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllMarks()
    {
        return DataContext.Meters.OrderBy(m => m.Marks).Select(m => m.Marks ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả cỡ đồng hồ
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<short> GetAllSizes()
    {
        var t = DataContext.Meters.OrderBy(m => m.Size).Select(m => m.Size ?? 0).Distinct().ToList();
        t.Sort();
        return t;
    }
    /// <summary>
    /// Lấy tất cả model
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllModels()
    {
        return DataContext.Meters.OrderBy(m => m.Model).Select(m => m.Model ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả thông tin theo số seri
    /// </summary>
    /// <param name="serial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public Meter GetBySerial(string serial)
    {
        return DataContext.Meters.SingleOrDefault(m => m.Serial == serial);
    }
    /// <summary>
    /// Lấy đồng hồ theo số seri bộ hiển thị đi kèm
    /// </summary>
    /// <param name="transmitterSerial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public Meter GetByTransmitterSerial(string transmitterSerial)
    {
        return DataContext.Meters.SingleOrDefault(m => m.SerialTransmitter == transmitterSerial);
    }
    /// <summary>
    /// Thêm mới đồng hồ
    /// </summary>
    /// <param name="meter"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert, false)]
    public CommandStatus Insert(Meter meter)
    {
        CommandStatus status = new CommandStatus();
        DataContext.Meters.InsertOnSubmit(meter);
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
    /// Cập nhật đồng hồ
    /// </summary>
    /// <param name="meter"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update, false)]
    public CommandStatus Update(Meter meter)
    {
        CommandStatus status = new CommandStatus();
        var dbMeter = DataContext.Meters.SingleOrDefault(m => m.Serial == meter.Serial);
        dbMeter.AccreditationDocument = meter.AccreditationDocument;
        dbMeter.AccreditationType = meter.AccreditationType;
        dbMeter.AccreditedDate = meter.AccreditedDate;
        dbMeter.ApprovalDate = meter.ApprovalDate;
        dbMeter.ApprovalDecision = meter.ApprovalDecision;
        dbMeter.Approved = meter.Approved;
        dbMeter.Description = meter.Description;
        dbMeter.ExpiryDate = meter.ExpiryDate;
        dbMeter.InitialIndex = meter.InitialIndex;
        dbMeter.Installed = meter.Installed;
        dbMeter.Marks = meter.Marks;
        dbMeter.Model = meter.Model;
        dbMeter.Provider = meter.Provider;
        dbMeter.ReceiptDate = meter.ReceiptDate;
        dbMeter.Serial = meter.Serial;
        dbMeter.Size = meter.Size;
        dbMeter.Status = meter.Status;
        dbMeter.SerialTransmitter = meter.SerialTransmitter;
        dbMeter.Nationality = meter.Nationality;
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
    /// List các đồng hồ theo tiêu chí nhà sản xuất, hiệu, cỡ, model, trạng thái, tình trạng điểm lắp đặt, công ty quản lý
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
    public List<MeterViewModel> GetAllByConds(List<string> listProviders, List<string> listMarks,
        List<string> listModels, List<short> listSizes, List<string> listStatus, List<bool> listInstalled,
        List<string> listSiteStatus, List<string> listSiteCompanies, List<string>listNations)
    {
        return (from m in DataContext.Meters
                join s in DataContext.Sites on m.Serial equals s.Meter into ms
                where listProviders.Contains(m.Provider ?? "")
                && listMarks.Contains(m.Marks ?? "")
                && listModels.Contains(m.Model ?? "")
                && listSizes.Contains(m.Size ?? 0)
                && listStatus.Contains(m.Status ?? "")
                && listInstalled.Contains(m.Installed ?? false)
                orderby m.Serial
                from s in ms.DefaultIfEmpty()
                where m.Serial != string.Empty
                && listSiteStatus.Contains(s.Status ?? "")
                && listSiteCompanies.Contains(s.Company ?? "")
                && listNations.Contains(m.Nationality??"")
                select new MeterViewModel
                {
                    Serial = m.Serial,
                    ReceiptDate = m.ReceiptDate,
                    AccreditedDate = m.AccreditedDate,
                    ExpiryDate = m.ExpiryDate,
                    AccreditationDocument = m.AccreditationDocument,
                    AccreditationType = m.AccreditationType,
                    Provider = m.Provider,
                    Marks = m.Marks,
                    Size = m.Size,
                    Model = m.Model,
                    Status = m.Status,
                    Installed = m.Installed,
                    InitialIndex = m.InitialIndex,
                    Description = m.Description,
                    SiteId = s.Id,
                    Location = s.Location,
                    TransmitterSerial = m.SerialTransmitter,
                    SiteCompany = s.Company,
                    SiteStatus = s.Status,
                    Nationality = m.Nationality
                }).ToList();
    }
}