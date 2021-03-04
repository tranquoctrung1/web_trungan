using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataRawViewModel
/// </summary>
public class DataRawViewModel
{
    string siteId;
    Nullable<DateTime> timeStamp;
    Nullable<double> value;
    string description;

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

    public DateTime? TimeStamp
    {
        get
        {
            return timeStamp;
        }

        set
        {
            timeStamp = value;
        }
    }

    public double? Value
    {
        get
        {
            return value;
        }

        set
        {
            this.value = value;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }

        set
        {
            description = value;
        }
    }
}