using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AlarmForLoggerViewModel
/// </summary>
public class AlarmForLoggerViewModel
{
    string serial;
    Nullable<int> type;
    Nullable<DateTime> startDate;
    Nullable<DateTime> endDate;
    Nullable<bool> isFinish;
    string content;

    public string Serial
    {
        get
        {
            return serial;
        }

        set
        {
            serial = value;
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
}