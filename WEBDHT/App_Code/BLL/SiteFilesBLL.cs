using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn thông tin các file điểm lắp đặt đã upload t_Site_Files
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class SiteFilesBLL
{
	/// <summary>
	/// LINQ Object
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
    /// Xóa tất cả thông tin của các file đã chọn
    /// </summary>
    /// <param name="listFiles"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Delete, false)]
    public CommandStatus Delete(List<string> listFiles)
    {
        CommandStatus status = new CommandStatus();
        foreach (var fileName in listFiles)
        {
            var dbFile = DataContext.SiteFiles.SingleOrDefault(f => f.FileName == fileName);
            if (dbFile != null)
            {
                DataContext.SiteFiles.DeleteOnSubmit(dbFile);
            }
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
    /// <summary>
    /// Lấy thông tin một file theo tên file
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public SiteFile GetByFileName(string fileName)
    {
        return DataContext.SiteFiles.SingleOrDefault(f => f.FileName == fileName);
    }
    /// <summary>
    /// Lấy tất cả thông tin file theo mã vị trí
    /// </summary>
    /// <param name="siteId"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<SiteFile> GetAllBySiteId(string siteId)
    {
        return DataContext.SiteFiles.OrderBy(f => f.FileName).Where(f => f.SiteId == siteId);
    }
    /// <summary>
    /// Thêm mới một thông tin file khi upload
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Insert, false)]
    public CommandStatus Insert(SiteFile file)
    {
        CommandStatus status = new CommandStatus();
        DataContext.SiteFiles.InsertOnSubmit(file);
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
    /// Cập nhật thông tin file
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Update, false)]
    public CommandStatus Update(SiteFile file)
    {
        CommandStatus status = new CommandStatus();
        var dbFile = DataContext.SiteFiles.SingleOrDefault(f => f.FileName == file.FileName && f.SiteId == file.SiteId);
        if (dbFile != null)
        {
            dbFile.MIMEType = file.MIMEType;
            dbFile.FileName = file.FileName;
            dbFile.Path = file.Path;
            dbFile.SiteId = file.SiteId;
            dbFile.Size = file.Size;
            dbFile.UploadDate = file.UploadDate;
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
}