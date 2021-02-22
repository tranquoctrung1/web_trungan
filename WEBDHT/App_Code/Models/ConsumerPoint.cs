using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConsumerPoint
/// </summary>
public class ConsumerPoint
{
    string consumerId;
    string siteId;

    public string ConsumerId
    {
        get
        {
            return consumerId;
        }

        set
        {
            consumerId = value;
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