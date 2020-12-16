using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vấn bảng t_Site_Units
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class ChannelUnitsBLL
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
    /// Lấy tất cả các đơn vị của kênh logger
    /// </summary>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public IQueryable<ChannelUnit> GetAll()
    {
        return DataContext.ChannelUnits.OrderBy(cu => cu.Unit);
    }
}