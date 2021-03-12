using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AlarmForPointViewModel
/// </summary>
public class AlarmForPointViewModel
{
    string channelId;
    string location;
    DateTime? startDateAlarm;
    DateTime? endDateAlarm;
    int? typeAlarm;
    string level;
    bool? isFinish;
    string content;

    public string ChannelId
    {
        get
        {
            return channelId;
        }

        set
        {
            channelId = value;
        }
    }

    public string Location
    {
        get
        {
            return location;
        }

        set
        {
            location = value;
        }
    }

    public DateTime? StartDateAlarm
    {
        get
        {
            return startDateAlarm;
        }

        set
        {
            startDateAlarm = value;
        }
    }

    public DateTime? EndDateAlarm
    {
        get
        {
            return endDateAlarm;
        }

        set
        {
            endDateAlarm = value;
        }
    }

    public int? TypeAlarm
    { 
        get
        {
            return typeAlarm;
        }

        set
        {
            typeAlarm = value;
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