using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MapDataBLL
/// </summary>
public class MapDataBLL
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

    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<MapSite> GetSite_ByCompany(string company)
    {
        return DataContext.p_Map_GetSites_ByCompany(company).ToList();
    }

    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public List<MapChannel> GetChannels_ByLoggerId(string id)
    {
        return DataContext.p_Map_GetChannels_ByLoggerId(id).ToList();
    }
}