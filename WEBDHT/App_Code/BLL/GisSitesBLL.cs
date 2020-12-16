using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Truy vẫn lấy dữ liệu tọa độ mặc định của các công ty cổ phần
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class GisSitesBLL
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
    /// Lấy dữ liệu gis theo mã công ty
    /// </summary>
    /// <param name="company"></param>
    /// <returns></returns>
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public GisSite GetByCompany(string company)
    {
        return DataContext.GisSites.SingleOrDefault(g => g.Company == company);
    }
}