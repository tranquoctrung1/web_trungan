using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SiteCoversBLL
/// </summary>

[System.ComponentModel.DataObject]

public class SiteCoversBLL
{
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
    /// Lấy tất cả mã nắp hầm
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllCoverIDs()
    {
        return DataContext.Covers.OrderBy(c => c.CoverID).Select(c => c.CoverID ?? string.Empty).Distinct();
    } 

    /// <summary>
    /// Lấy tất cả vật liệu hầm
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<string> GetAllCoverMaterials()
    {
        return DataContext.Covers.OrderBy(c => c.CoverMaterial).Select(c => c.CoverMaterial ?? string.Empty).Distinct();
    }
    /// <summary>
    /// Lấy tất cả chiều dài nắp hầm
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<int> GetAllCoverLs()
    {
        var l = DataContext.Covers.OrderBy(c => c.CoverL).Select(c => c.CoverL ?? 0).Distinct().ToList();
        l.Sort();
        return l;
    }
    /// <summary>
    /// Lấy tất cẩ chiều rộng nắp hầm
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<int> GetAllCoverWs()
    {
        var w =  DataContext.Covers.OrderBy(c => c.CoverW).Select(c => c.CoverW ?? 0).Distinct().ToList();
        w.Sort();
        return w;
    }
    /// <summary>
    /// Lấy tất cả chiều cao nắp hầm
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<int> GetAllCoverHs()
    {
        var h = DataContext.Covers.OrderBy(c => c.CoverH).Select(c => c.CoverH ?? 0).Distinct().ToList();
        h.Sort();
        return h;
    }

    /// <summary>
    /// Lấy tất cả số tấm nắp hầm
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<int> GetAllCoverNLs()
    {
        var n =  DataContext.Covers.OrderBy(c => c.CoverNL).Select(c => c.CoverNL ?? 0).Distinct().ToList();
        n.Sort();
        return n;
    }

    /// <summary>
    /// Lấy thông tin qua mã nắp hầm
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public Cover GetCoverByID(string ID)
    {
        return DataContext.Covers.SingleOrDefault(c => c.CoverID == ID);
    }

    /// <summary>
    /// Insert
    /// </summary>
    /// <param name="cover"></param>
    /// <returns></returns>
    public CommandStatus Insert(Cover cover)
    {
        CommandStatus status = new CommandStatus();
        DataContext.Covers.InsertOnSubmit(cover);

        try
        {
            DataContext.SubmitChanges();
            status.Inserted = true;
        }
        catch (Exception ex)
        {
            status.Error = true;
            status.ErrorMessage = ex.Message;
            //throw;
        }
        return status;
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="cover"></param>
    /// <returns></returns>
    public CommandStatus Update(Cover cover)
    {
        var dbCover = DataContext.Covers.SingleOrDefault(c => c.CoverID == cover.CoverID);
        CommandStatus status = new CommandStatus();
        if (dbCover != null)
        {
            dbCover.CoverH = cover.CoverH;
            dbCover.CoverL = cover.CoverL;
            dbCover.CoverMaterial = cover.CoverMaterial;
            dbCover.CoverNL = cover.CoverNL;
            dbCover.CoverW = cover.CoverW;
        }
        try
        {
            DataContext.SubmitChanges();
            status.Updated = true;
        }
        catch (Exception ex)
        {
            status.Error = true;
            status.ErrorMessage = ex.Message;
            //throw;
        }
        return status;
    }

    public CommandStatus Delete(string ID)
    {
        CommandStatus status = new CommandStatus();
        var dbCover = DataContext.Covers.SingleOrDefault(c => c.CoverID == ID);
        if (dbCover != null)
        {
            DataContext.Covers.DeleteOnSubmit(dbCover);
        }
        try
        {
            DataContext.SubmitChanges();
            status.Deleted = true;
        }
        catch (Exception ex)
        {
            status.Error = true;
            status.ErrorMessage = ex.Message;
            //throw;
        }
        return status;
    }
}