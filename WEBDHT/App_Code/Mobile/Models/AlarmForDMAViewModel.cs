using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AlarmForDMAViewModel
/// </summary>
public class AlarmForDMAViewModel
{

        string company;
        string description;
        Nullable<DateTime> startDate;
        Nullable<DateTime> endDate;
        Nullable<int> type;
        string content;
        string level;
        Nullable<bool> isFinish;

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

    public DateTime? StartDate
    {
        get
        {
            return startDate;
        }

        set
        {
            startDate = value;
        }
    }

    public DateTime? EndDate
    {
        get
        {
            return endDate;
        }

        set
        {
            endDate = value;
        }
    }

    public int? Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }

    public string Content
    {
        get
        {
            return content;
        }

        set
        {
            content = value;
        }
    }

    public string Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public bool? IsFinish
    {
        get
        {
            return isFinish;
        }

        set
        {
            isFinish = value;
        }
    }
}