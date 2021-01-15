using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SiteDistrict
/// </summary>
public class SiteDistrict
{
    string idDistrict;
    string siteId;

    public string IdDistrict
    {
        get
        {
            return idDistrict;
        }

        set
        {
            idDistrict = value;
        }
    }

    public string SiteId
    {
        get
        {
            return siteId;
        }

        set
        {
            siteId = value;
        }
    }
}