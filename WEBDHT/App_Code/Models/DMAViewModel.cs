using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DMAViewModel
/// </summary>
public class DMAViewModel
{
    string company;
    Nullable<bool> production;
    string description;
    string status;
    string district;
    string ward;
    Nullable<int> amountDHTKH;
    Nullable<int> amountValve;
    Nullable<int> amountPool;
    Nullable<int> amountTCH;
    Nullable<double> nRW;

    public string Company
    {
        get
        {
            return company;
        }

        set
        {
            company = value;
        }
    }

    public bool? Production
    {
        get
        {
            return production;
        }

        set
        {
            production = value;
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

    public string Status
    {
        get
        {
            return status;
        }

        set
        {
            status = value;
        }
    }

    public string District
    {
        get
        {
            return district;
        }

        set
        {
            district = value;
        }
    }

    public string Ward
    {
        get
        {
            return ward;
        }

        set
        {
            ward = value;
        }
    }

    public int? AmountDHTKH
    {
        get
        {
            return amountDHTKH;
        }

        set
        {
            amountDHTKH = value;
        }
    }

    public int? AmountValve
    {
        get
        {
            return amountValve;
        }

        set
        {
            amountValve = value;
        }
    }

    public int? AmountPool
    {
        get
        {
            return amountPool;
        }

        set
        {
            amountPool = value;
        }
    }

    public int? AmountTCH
    {
        get
        {
            return amountTCH;
        }

        set
        {
            amountTCH = value;
        }
    }

    public double? NRW
    {
        get
        {
            return nRW;
        }

        set
        {
            nRW = value;
        }
    }
}