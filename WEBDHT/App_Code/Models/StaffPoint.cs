using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StaffPoint
/// </summary>
public class StaffPoint
{
    string idStaff;
    string idSite;

    public string IdStaff
    {
        get
        {
            return idStaff;
        }

        set
        {
            idStaff = value;
        }
    }

    public string IdSite
    {
        get
        {
            return idSite;
        }

        set
        {
            idSite = value;
        }
    }
}