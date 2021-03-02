using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StatusDMA
/// </summary>
public class StatusDMA
{
    string status;
    string description;

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