using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn dữ liệu điểm lắp đặt t_Site_Sites
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class SitesBLL
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
    /// Xóa dữ liệu một điểm lắp đặt
    /// </summary>
    /// <param name="siteId"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public CommandStatus Delete(string siteId)
    {
        CommandStatus status = new CommandStatus();
        var dbSite = DataContext.Sites.SingleOrDefault(s => s.Id == siteId);
        DataContext.Sites.DeleteOnSubmit(dbSite);
        try
        {
            DataContext.SubmitChanges();
            status.Deleted = true;
        }
        catch (ChangeConflictException)
        {
            foreach (ObjectChangeConflict conflict in DataContext.ChangeConflicts)
            {
                conflict.Resolve(RefreshMode.KeepChanges);
            }
           
            status.Error = true;
            status.ErrorMessage = "Concurrency conflict occurred.";
        }
        catch (Exception e)
        {
            status.Error = true;
            status.ErrorMessage = e.Message;
        }
        return status;
    }
    /// <summary>
    /// Lấy tất cả các quận
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllDistricts()
    {
        return DataContext.Sites.OrderBy(s => s.District).Select(s => s.District ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả mã vị trí
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllIds()
    {
        return DataContext.Sites.OrderBy(s => s.Id).Select(s => s.Id ?? string.Empty);
    }
    /// <summary>
    /// Lấy tất cả mã vị trí cũ
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllOldIds()
    {
        return DataContext.Sites.OrderBy(s => s.OldId).Select(s => s.OldId ?? string.Empty);
    }
    /// <summary>
    /// Lấy tất cả nhóm hiển thị
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllViewGroups()
    {
        return DataContext.Sites.OrderBy(s => s.ViewGroup).Select(s => s.ViewGroup ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả các cấp điểm lắp đặt
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllLevels()
    {
        return DataContext.Sites.OrderBy(s => s.Level).Select(s => s.Level ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả các nhóm điểm lắp đặt
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllGroups()
    {
        return DataContext.Sites.OrderBy(s => s.Group).Select(s => s.Group ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả các nhóm điểm lắp đặt 2
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllGroup2s()
    {
        return DataContext.Sites.OrderBy(s => s.Group2).Select(s => s.Group2 ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả các nhóm điểm lắp đặt 3
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllGroup3s()
    {
        return DataContext.Sites.OrderBy(s => s.Group3).Select(s => s.Group3 ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả các nhóm điểm lắp đặt 4
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllGroup4s()
    {
        return DataContext.Sites.OrderBy(s => s.Group4).Select(s => s.Group4 ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả các nhóm điểm lắp đặt 5
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllGroup5s()
    {
        return DataContext.Sites.OrderBy(s => s.Group5).Select(s => s.Group5 ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả mã nắp hầm
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllCoverIDs()
    {
        return DataContext.Sites.OrderBy(s => s.CoverID).Select(s => s.CoverID ?? string.Empty).Distinct();
    } 
    /// <summary>
    /// Lấy tất cả các đơn vị quản lý
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllCompanies()
    {
        return DataContext.Sites.OrderBy(s => s.Company).Select(s => s.Company ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả trạng thái
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllStatus()
    {
        return DataContext.Sites.OrderBy(s => s.Status).Select(s => s.Status ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả tình trạng
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllAvailabilities()
    {
        return DataContext.Sites.OrderBy(s => s.Availability).Select(s => s.Availability ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả công ty sản xuất
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllProductionCompanies()
    {
        return DataContext.Sites.OrderBy(s => s.ProductionCompany).Select(s => s.ProductionCompany ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả công ty cung cấp I
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllIstDistributionCompanies()
    {
        return DataContext.Sites.OrderBy(s => s.IstDistributionCompany).Select(s => s.IstDistributionCompany ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả các công ty cung cấp II
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllQndDistributionCompanies()
    {
        return DataContext.Sites.OrderBy(s => s.QndDistributionCompany).Select(s => s.QndDistributionCompany ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy vị trí theo số seri đồng hồ.
    /// </summary>
    /// <param name="meterSerial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public Site GetSiteByMeterSerial(string meterSerial)
    {
        return DataContext.Sites.FirstOrDefault(s => s.Meter == meterSerial);
    }
    /// <summary>
    /// Lấy vị trí theo số seri logger.
    /// </summary>
    /// <param name="loggerSerial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public Site GetSiteByLoggerSerial(string loggerSerial)
    {
        return DataContext.Sites.FirstOrDefault(s => s.Logger == loggerSerial);
    }
    /// <summary>
    /// Lấy vị trí theo số seri tran.
    /// </summary>
    /// <param name="tranSerial"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public Site GetSiteByTranSerial(string tranSerial)
    {
        return DataContext.Sites.FirstOrDefault(s => s.Transmitter == tranSerial);
    }
    /// <summary>
    /// List các vị trí lắp đặt theo tiêu chí về cấp, nhóm, quản lý, tình trạng, trạng thái, tính cho, ....
    /// </summary>
    /// <param name="listLevels"></param>
    /// <param name="listGroups"></param>
    /// <param name="listCompanies"></param>
    /// <param name="listStatus"></param>
    /// <param name="listAvailabilities"></param>
    /// <param name="listCalculate"></param>
    /// <param name="listTakeovered"></param>
    /// <param name="listProperty"></param>
    /// <param name="listUsingLogger"></param>
    /// <param name="listLoggerModels"></param>
    /// <param name="listAccreditationTypes"></param>
    /// <param name="listApproved"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByConds(List<string> listLevels, List<string> listGroups, List<string> listCompanies,
            List<string> listStatus, List<string> listAvailabilities, List<string> listCalculate, List<bool> listTakeovered,
            List<bool> listProperty, List<bool> listUsingLogger, List<string> listLoggerModels, List<string> listAccreditationTypes,
            List<bool> listApproved, List<string> listGroup2s, List<string>listMeterModels)
    {
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial
                                    join l in DataContext.Loggers on s.Logger equals l.Serial into sml
                                    where listLevels.Contains(s.Level ?? string.Empty)
                                    && listGroups.Contains(s.Group ?? string.Empty)
                                    && listCompanies.Contains(s.Company ?? string.Empty)
                                    && (listCalculate.Contains(s.ProductionCompany ?? string.Empty)
                                    || listCalculate.Contains(s.IstDistributionCompany ?? string.Empty)
                                    || listCalculate.Contains(s.QndDistributionCompany ?? string.Empty))
                                    && listStatus.Contains(s.Status ?? string.Empty)
                                    && listAvailabilities.Contains(s.Availability ?? string.Empty)
                                    && listTakeovered.Contains(s.Takeovered ?? false)
                                    && listProperty.Contains(s.Property ?? false)
                                    && listUsingLogger.Contains(s.UsingLogger ?? false)
                                    && listMeterModels.Contains(m.Model??string.Empty)
                                    && listAccreditationTypes.Contains(m.AccreditationType ?? string.Empty)
                                    && listApproved.Contains(m.Approved ?? false)
                                    && listGroup2s.Contains(s.Group2 ?? string.Empty)
                                    orderby s.Id
                                    from l in sml.DefaultIfEmpty()
                                    select new SiteViewModel
                                    {
                                        Id = s.Id,
                                        Provider = m.Provider ?? string.Empty,
                                        Marks = m.Marks ?? string.Empty,
                                        Size = m.Size,
                                        StaffId=s.StaffId,
                                        ApprovalDecision= m.ApprovalDecision,
                                        Model = m.Model ?? string.Empty,
                                        Location = s.Location ?? string.Empty,
                                        Level = s.Level ?? string.Empty,
                                        Group = s.Group ?? string.Empty,
                                        Group2 = s.Group2 ?? string.Empty,
                                        Company = s.Company ?? string.Empty,
                                        Status = s.Status ?? string.Empty,
                                        Availability = s.Availability ?? string.Empty,
                                        IstDistributionCompany = s.IstDistributionCompany ?? string.Empty,
                                        QndDistributionCompany = s.QndDistributionCompany ?? string.Empty,
                                        ProductionCompany = s.ProductionCompany ?? string.Empty,
                                        Property = s.Property,
                                        Takeovered = s.Takeovered,
                                        UsingLogger = s.UsingLogger,
                                        Description = s.Description ?? string.Empty,
                                        LoggerModel = l.Model,
                                        Meter = s.Meter,
                                        Transmitter = s.Transmitter,
                                        Logger = s.Logger,
                                        AccreditationDocument = m.AccreditationDocument,
                                        AccreditedDate = m.AccreditedDate,
                                        ExpiryDate = m.ExpiryDate,
                                        DateOfMeterChange = s.DateOfMeterChange ?? s.TakeoverDate
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Thống kê các vị trí lắp đặt xí nghiệp quản lý
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAll4SGWDC()
    {
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial into sm
                                    where (s.Company.Contains("XN") || s.Company.Contains("DA")) && s.Status.Contains("DSD")
                                    orderby s.Id
                                    from m in sm.DefaultIfEmpty()
                                    select new SiteViewModel
                                    {
                                        Id = s.Id,
                                        Provider = m.Provider ?? string.Empty,
                                        Marks = m.Marks ?? string.Empty,
                                        Size = m.Size,
                                        Model = m.Model ?? string.Empty,
                                        Location = s.Location ?? string.Empty,
                                        Level = s.Level ?? string.Empty,
                                        Group = s.Group ?? string.Empty,
                                        Company = s.Company ?? string.Empty,
                                        Status = s.Status ?? string.Empty,
                                        Availability = s.Availability ?? string.Empty,
                                        IstDistributionCompany = s.IstDistributionCompany ?? string.Empty,
                                        QndDistributionCompany = s.QndDistributionCompany ?? string.Empty,
                                        ProductionCompany = s.ProductionCompany ?? string.Empty,
                                        Property = s.Property,
                                        Takeovered = s.Takeovered,
                                        UsingLogger = s.UsingLogger,
                                        Description = s.Description ?? string.Empty
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả các điểm lắp đặt cho các nhân viên quản lý
    /// </summary>
    /// <param name="staffId"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAll4Staff(string staffId)
    {
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial into sm
                                    where s.StaffId == staffId
                                    orderby s.Id
                                    from m in sm.DefaultIfEmpty()
                                    select new SiteViewModel
                                    {
                                        Id = s.Id,
                                        Provider = m.Provider ?? string.Empty,
                                        Marks = m.Marks ?? string.Empty,
                                        Size = m.Size,
                                        Model = m.Model ?? string.Empty,
                                        Location = s.Location ?? string.Empty,
                                        Level = s.Level ?? string.Empty,
                                        Group = s.Group ?? string.Empty,
                                        Company = s.Company ?? string.Empty,
                                        Status = s.Status ?? string.Empty,
                                        Availability = s.Availability ?? string.Empty,
                                        IstDistributionCompany = s.IstDistributionCompany ?? string.Empty,
                                        QndDistributionCompany = s.QndDistributionCompany ?? string.Empty,
                                        ProductionCompany = s.ProductionCompany ?? string.Empty,
                                        Property = s.Property,
                                        Takeovered = s.Takeovered,
                                        UsingLogger = s.UsingLogger,
                                        Description = s.Description ?? string.Empty
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<Site> GetAll()
    {
        return DataContext.Sites.OrderBy(s => s.Id);
    }
    /// <summary>
    /// Lấy thông tin một điểm lắp đặt theo mã vị trí
    /// </summary>
    /// <param name="siteId"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public Site Get(string siteId)
    {
        return DataContext.Sites.SingleOrDefault(s => s.Id == siteId);
    }
    /// <summary>
    /// Lấy tất cả các công ty tính toán
    /// </summary>
    /// <param name="company"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByCalculatedCompany(string company)
    {
        return (from s in DataContext.Sites
                join c in DataContext.SiteConfigs on s.Id equals c.SiteId
                where (s.ProductionCompany == company
            || s.IstDistributionCompany == company || s.QndDistributionCompany == company)
            && s.Latitude != null && s.Longitude != null
                select new SiteViewModel
                {
                    Id = s.Id,
                    Latitude = s.Latitude,
                    Longitude = s.Longitude,
                    Location = s.Location,
                    ViewGroup = s.ViewGroup,
                    LoggerId = c.Id
                }).ToList();
    }
    /// <summary>
    /// Lấy tất cả các điểm lắp đặt cho các công ty tính toán
    /// </summary>
    /// <param name="company"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<Site> GetAllSitesByCalculatedCompany(string company)
    {
        return DataContext.Sites.Where(s => s.IstDistributionCompany == company || s.QndDistributionCompany == company || s.ProductionCompany == company).ToList();
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt theo ngày kiểm định đồng hồ
    /// </summary>
    /// <param name="endDate"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByAccreditedDate(DateTime endDate)
    {
        var list = (from s in DataContext.Sites
                    join m in DataContext.Meters on s.Meter equals m.Serial
                    where m.AccreditedDate != null && endDate >= m.ExpiryDate
                    orderby s.Id
                    select new SiteViewModel
                    {
                        Id = s.Id,
                        Location = s.Location,
                        Marks = m.Marks,
                        Size = m.Size,
                        DateOfChange = m.AccreditedDate,
                        DescriptionOfChange = s.DescriptionOfChange,
                        AccreditationDocument = m.AccreditationDocument,
                        ExpiryDate = m.ExpiryDate
                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt theo ngày thay đồng hồ
    /// </summary>
    /// <param name="endDate"></param>
    /// <param name="ut"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByMeterChanged(DateTime endDate, double ut, List<string> listCompanies, List<string> listStatus)
    {
        DateTime d = endDate.AddDays(-Convert.ToInt32(ut * 365.5));
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial
                                    where (s.DateOfMeterChange != null && d >= s.DateOfMeterChange && listCompanies.Contains(s.Company) && listStatus.Contains(s.Status))
                                    || (s.DateOfMeterChange == null && s.TakeoverDate != null && d >= s.TakeoverDate)
                                    orderby s.Id
                                    select new SiteViewModel
                                    {
                                        Id = s.Id,
                                        Location = s.Location,
                                        Marks = m.Marks,
                                        Size = m.Size,
                                        DateOfChange = s.DateOfMeterChange,
                                        DescriptionOfChange = s.DescriptionOfChange,
                                        Company = s.Company,
                                        Status = s.Status
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt theo ngày thay bộ hiển thị
    /// </summary>
    /// <param name="endDate"></param>
    /// <param name="ut"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByTransmitterChanged(DateTime endDate, double ut, List<string> listCompanies, List<string> listStatus)
    {
        DateTime d = endDate.AddDays(-Convert.ToInt32(ut * 365.5));
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial
                                    where s.DateOfTransmitterChange != null && d >= s.DateOfTransmitterChange
                                    && listCompanies.Contains(s.Company)
                                    && listStatus.Contains(s.Status)
                                    orderby s.Id
                                    select new SiteViewModel
                                    {
                                        Id = s.Id,
                                        Location = s.Location,
                                        Marks = m.Marks,
                                        Size = m.Size,
                                        DateOfChange = s.DateOfTransmitterChange,
                                        DescriptionOfChange = s.DescriptionOfChange,
                                        Company = s.Company,
                                        Status = s.Status
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt theo ngày thay logger
    /// </summary>
    /// <param name="endDate"></param>
    /// <param name="ut"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByLoggerChanged(DateTime endDate, double ut, List<string> listCompanies, List<string> listStatus)
    {
        DateTime d = endDate.AddDays(-Convert.ToInt32(ut * 365.5));
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial
                                    where s.DateOfLoggerChange != null && d >= s.DateOfLoggerChange
                                    && listCompanies.Contains(s.Company)
                                    && listStatus.Contains(s.Status)
                                    orderby s.Id
                                    select new SiteViewModel
                                    {
                                        Id = s.Id,
                                        Location = s.Location,
                                        Marks = m.Marks,
                                        Size = m.Size,
                                        DateOfChange = s.DateOfLoggerChange,
                                        DescriptionOfChange = s.DescriptionOfChange,
                                        Company = s.Company,
                                        Status = s.Status
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt theo ngày thay pin bộ hiển thị
    /// </summary>
    /// <param name="endDate"></param>
    /// <param name="ut"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByTransmitterBatteryChanged(DateTime endDate, double ut, List<string> listCompanies, List<string> listStatus)
    {
        DateTime d = endDate.AddDays(-Convert.ToInt32(ut * 365.5));
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial
                                    where s.DateOfTransmitterBatteryChange != null && d >= s.DateOfTransmitterBatteryChange
                                    && listCompanies.Contains(s.Company)
                                    && listStatus.Contains(s.Status)
                                    orderby s.Id
                                    select new SiteViewModel
                                    {
                                        Id = s.Id,
                                        Location = s.Location,
                                        Marks = m.Marks,
                                        Size = m.Size,
                                        DateOfChange = s.DateOfTransmitterBatteryChange,
                                        DescriptionOfChange = s.DescriptionOfChange,
                                        Company = s.Company,
                                        Status = s.Status
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt theo ngày thay pin logger
    /// </summary>
    /// <param name="endDate"></param>
    /// <param name="ut"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByLoggerBatteryChanged(DateTime endDate, double ut, List<string> listCompanies, List<string> listStatus)
    {
        DateTime d = endDate.AddDays(-Convert.ToInt32(ut * 365.5));
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial
                                    where s.DateOfLoggerBatteryChange != null && d >= s.DateOfLoggerBatteryChange
                                    && listCompanies.Contains(s.Company)
                                    && listStatus.Contains(s.Status)
                                    orderby s.Id
                                    select new SiteViewModel
                                    {
                                        Id = s.Id,
                                        Location = s.Location,
                                        Marks = m.Marks,
                                        Size = m.Size,
                                        DateOfChange = s.DateOfLoggerBatteryChange,
                                        DescriptionOfChange = s.DescriptionOfChange,
                                        Company = s.Company,
                                        Status = s.Status
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt theoo ngày thay bộ hiển thị
    /// </summary>
    /// <param name="endDate"></param>
    /// <param name="ut"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByBatteryChanged(DateTime endDate, double ut, List<string> listCompanies, List<string> listStatus)
    {
        DateTime d = endDate.AddDays(-Convert.ToInt32(ut * 365.5));
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial
                                    where s.DateOfBatteryChange != null && d >= s.DateOfBatteryChange
                                    && listCompanies.Contains(s.Company)
                                    && listStatus.Contains(s.Status)
                                    orderby s.Id
                                    select new SiteViewModel
                                    {
                                        Id = s.Id,
                                        Location = s.Location,
                                        Marks = m.Marks,
                                        Size = m.Size,
                                        DateOfChange = s.DateOfBatteryChange,
                                        DescriptionOfChange = s.DescriptionOfChange,
                                        Company = s.Company,
                                        Status = s.Status
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt vừa kiểm định đồng hồ
    /// </summary>
    /// <param name="startDate"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByHasAccredited(DateTime startDate)
    {
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial
                                    where m.AccreditedDate != null && startDate <= m.AccreditedDate
                                    orderby s.Id
                                    select new SiteViewModel
                                    {
                                        Id = s.Id,
                                        Location = s.Location,
                                        Marks = m.Marks,
                                        Size = m.Size,
                                        DateOfChange = m.AccreditedDate,
                                        DescriptionOfChange = s.DescriptionOfChange,
                                        AccreditationDocument = m.AccreditationDocument,
                                        ExpiryDate = m.ExpiryDate
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt vừa thay đồng hồ
    /// </summary>
    /// <param name="startDate"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByMeterHasChanged(DateTime startDate)
    {
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial
                                    join l in DataContext.SiteMeterHistories on s.Id equals l.SiteId

                                    where s.DateOfMeterChange != null && startDate <= s.DateOfMeterChange && l.DateChanged >= startDate
                                    orderby s.Id
                                    select new SiteViewModel
                                    {
                                     
                                        Meter = l.NewMeterSerial,
                                        Transmitter = "",
                                        Level =m.ApprovalDecision,
                                        Id = s.Id,
                                        Location = s.Location,
                                        Marks = m.Marks,
                                        Size = m.Size,
                                        OldMeter = l.OldMeterSerial,
                                        OldTran = "",
                                        DateOfChange = l.DateChanged,
                                        DescriptionOfChange = s.DescriptionOfChange,
                                        AccreditationDocument = m.AccreditationDocument,
                                        ExpiryDate = m.ExpiryDate
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt vừa thay bộ hiển thị
    /// </summary>
    /// <param name="startDate"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByTransmitterHasChanged(DateTime startDate)
    {
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial
                                    join t in DataContext.Transmitters on s.Transmitter equals t.Serial
                                    join k in DataContext.SiteTransmitterHistories on s.Id equals k.SiteId
                                    
                                    where s.DateOfTransmitterChange != null && startDate <= s.DateOfTransmitterChange && k.DateChanged >= startDate
                                    orderby s.Id
                                    select new SiteViewModel
                                    {
                                        Meter =  "",
                                        Transmitter = k.NewMeterSerial,
                                        Id = s.Id,
                                        Location = s.Location,
                                        Marks = m.Marks,
                                        Size = m.Size,
                                        Model= t.ApprovalDecision,
                                        OldMeter = "",
                                        OldTran = k.OldMeterSerial,
                                        DateOfChange = k.DateChanged,
                                        DescriptionOfChange = s.DescriptionOfChange,
                                        AccreditationDocument = m.AccreditationDocument,
                                        ExpiryDate = m.ExpiryDate
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt vừa thay logger
    /// </summary>
    /// <param name="startDate"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByLoggerHasChanged(DateTime startDate)
    {
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial
                                    where s.DateOfLoggerChange != null && startDate <= s.DateOfLoggerChange
                                    orderby s.Id
                                    select new SiteViewModel
                                    {
                                        Meter = s.Meter,
                                        Transmitter = s.Transmitter,
                                        Id = s.Id,
                                        Location = s.Location,
                                        Marks = m.Marks,
                                        Size = m.Size,
                                        DateOfChange = s.DateOfLoggerChange,
                                        DescriptionOfChange = s.DescriptionOfChange,
                                        AccreditationDocument = m.AccreditationDocument,
                                        ExpiryDate = m.ExpiryDate
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt vừa thay acquy
    /// </summary>
    /// <param name="startDate"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByBatteryHasChanged(DateTime startDate)
    {
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial
                                    where s.DateOfBatteryChange != null && startDate <= s.DateOfBatteryChange
                                    orderby s.Id
                                    select new SiteViewModel
                                    {
                                        Id = s.Id,
                                        Meter = s.Meter,
                                        Transmitter = s.Transmitter,
                                        Location = s.Location,
                                        Marks = m.Marks,
                                        Size = m.Size,
                                        DateOfChange = s.DateOfBatteryChange,
                                        DescriptionOfChange = s.DescriptionOfChange,
                                        AccreditationDocument = m.AccreditationDocument,
                                        ExpiryDate = m.ExpiryDate
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt vừa thay pin bộ hiển thị
    /// </summary>
    /// <param name="startDate"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByTransmitterBatteryHasChanged(DateTime startDate)
    {
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial
                                    where s.DateOfTransmitterBatteryChange != null && startDate <= s.DateOfTransmitterBatteryChange
                                    orderby s.Id
                                    select new SiteViewModel
                                    {
                                        Meter = s.Meter,
                                        Transmitter = s.Transmitter,
                                        Id = s.Id,
                                        Location = s.Location,
                                        Marks = m.Marks,
                                        Size = m.Size,
                                        DateOfChange = s.DateOfTransmitterBatteryChange,
                                        DescriptionOfChange = s.DescriptionOfChange,
                                        AccreditationDocument = m.AccreditationDocument,
                                        ExpiryDate = m.ExpiryDate
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy tất cả điểm lắp đặt vừa thay pin logger
    /// </summary>
    /// <param name="startDate"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByLoggerBatteryHasChanged(DateTime startDate)
    {
        List<SiteViewModel> list = (from s in DataContext.Sites
                                    join m in DataContext.Meters on s.Meter equals m.Serial
                                    where s.DateOfLoggerBatteryChange != null && startDate <= s.DateOfLoggerBatteryChange
                                    orderby s.Id
                                    select new SiteViewModel
                                    {
                                        Id = s.Id,
                                        Meter = s.Meter,
                                        Transmitter = s.Transmitter,
                                        Location = s.Location,
                                        Marks = m.Marks,
                                        Size = m.Size,
                                        DateOfChange = s.DateOfLoggerBatteryChange,
                                        DescriptionOfChange = s.DescriptionOfChange,
                                        AccreditationDocument = m.AccreditationDocument,
                                        ExpiryDate = m.ExpiryDate
                                    }).ToList();
        return list;
    }
    /// <summary>
    /// Lấy thông tin điểm lắp đặt theo mã vị trí
    /// </summary>
    /// <param name="siteId"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public Site GetById(string siteId)
    {
        return DataContext.Sites.SingleOrDefault(s => s.Id == siteId);
    }
    /// <summary>
    /// Thêm mới điểm lắp đặt
    /// </summary>
    /// <param name="site"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert, false)]
    public CommandStatus Insert(Site site)
    {
        CommandStatus status = new CommandStatus();
        DataContext.Sites.InsertOnSubmit(site);
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
    /// Cập nhật điểm lắp đặt
    /// </summary>
    /// <param name="site"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update, false)]
    public CommandStatus Update(Site site)
    {
        CommandStatus status = new CommandStatus();
        var dbSite = DataContext.Sites.SingleOrDefault(s => s.Id == site.Id);
        dbSite.Availability = site.Availability;
        dbSite.ChangeIndex = site.ChangeIndex;
        dbSite.Company = site.Company;
        dbSite.DateOfBatteryChange = site.DateOfBatteryChange;
        dbSite.DateOfLoggerBatteryChange = site.DateOfLoggerBatteryChange;
        dbSite.DateOfLoggerChange = site.DateOfLoggerChange;
        dbSite.DateOfMeterChange = site.DateOfMeterChange;
        dbSite.DateOfTransmitterBatteryChange = site.DateOfTransmitterBatteryChange;
        dbSite.DateOfTransmitterChange = site.DateOfTransmitterChange;
        dbSite.Description = site.Description;
        dbSite.DescriptionOfChange = site.DescriptionOfChange;
        dbSite.Display = site.Display;
        dbSite.Group = site.Group;
        dbSite.Id = site.Id;
        dbSite.IstDistributionCompany = site.IstDistributionCompany;
        dbSite.IstDoNotCalculateReverse = site.IstDoNotCalculateReverse;
        dbSite.Latitude = site.Latitude;
        dbSite.Level = site.Level;
        dbSite.Location = site.Location;
        dbSite.Logger = site.Logger;
        dbSite.Longitude = site.Longitude;
        dbSite.Meter = site.Meter;
        dbSite.MeterDirection = site.MeterDirection;
        dbSite.OldId = site.OldId;
        dbSite.ProductionCompany = site.ProductionCompany;
        dbSite.Property = site.Property;
        dbSite.QndDistributionCompany = site.QndDistributionCompany;
        dbSite.QndDoNotCalculateReverse = site.QndDoNotCalculateReverse;
        dbSite.StaffId = site.StaffId;
        dbSite.Status = site.Status;
        dbSite.TakeoverDate = site.TakeoverDate;
        dbSite.Takeovered = site.Takeovered;
        dbSite.Transmitter = site.Transmitter;
        dbSite.UsingLogger = site.UsingLogger;
        dbSite.ViewGroup = site.ViewGroup;
        dbSite.Group2 = site.Group2;
        dbSite.Group3 = site.Group3;
        dbSite.Group4 = site.Group4;
        dbSite.Group5 = site.Group5;
        dbSite.ChangeIndex1 = site.ChangeIndex1;
        dbSite.Address = site.Address;
        dbSite.CoverID = site.CoverID;
        dbSite.District = site.District;
        dbSite.DMAOut = site.DMAOut;
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

    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<SiteViewModel> GetAllByUserName()
    {

        UsersBLL usersBLL = new UsersBLL();

        var username = HttpContext.Current.User.Identity.Name;

        var u = usersBLL.GetByUid(username);

        string sqlQuery = "";

        if (u.Role == "supervisor")
        {
            sqlQuery = "select  s.Company, s.Latitude, s.Longitude, s.Id as SiteId, s.Location , t.Id as LoggerId from t_Site_Sites s join t_Devices_SitesConfigs t on t.SiteId = s.Id  join [t_Supervisor_District] sd on sd.IdDistrict = s.District where sd.IdStaff = '"+u.StaffId+"'";
        }
        else if (u.Role == "DMA")
        {
            sqlQuery = "select  s.Company, s.Latitude, s.Longitude, s.Id as SiteId, s.Location , t.Id as LoggerId from t_Site_Sites s join t_Devices_SitesConfigs t on t.SiteId = s.Id  join [t_DMA_DMA] dd on dd.IdDMA = s.Company where dd.IdStaff = '" + u.StaffId + "'";
        }
        else if (u.Role == "staff")
        {
            sqlQuery = "select  s.Company, s.Latitude, s.Longitude, s.Id as SiteId, s.Location , t.Id as LoggerId from t_Site_Sites s join t_Devices_SitesConfigs t on t.SiteId = s.Id  join [t_Staff_Site] ts on ts.IdSite = s.Id where ts.IdStaff = '" + u.StaffId + "'";
        }
        else if (u.Role == "consumer")
        {
            sqlQuery = "select  s.Company, s.Latitude, s.Longitude, s.Id as SiteId, s.Location , t.Id as LoggerId from t_Site_Sites s join t_Devices_SitesConfigs t on t.SiteId = s.Id  join [t_Site_Consumer] sc on sc.SiteId = s.Id where sc.ConsumerId = '" + u.StaffId + "'";
        }
        else
        {
            sqlQuery = "select  s.Company, s.Latitude, s.Longitude, s.Id as SiteId, s.Location , t.Id as LoggerId from t_Site_Sites s join t_Devices_SitesConfigs t on t.SiteId = s.Id "; //where exists (select * from t_Devices_ChannelsConfigs dc where dc.LoggerId = t.Id)
        }

        List<SiteViewModel> list = new List<SiteViewModel>();

        Connect connect = new Connect();

        try
        {
            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SiteViewModel el = new SiteViewModel();
                    try
                    {
                        el.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Latitude = null;
                    }
                    try
                    {
                        el.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        el.Longitude = null;
                    }
                    try
                    {
                        el.Id = reader["SiteId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Id = "";
                    }
                    try
                    {
                        el.Location = reader["Location"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.Location = "";
                    }
                    try
                    {
                        el.LoggerId = reader["LoggerId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el.LoggerId = "";
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
}