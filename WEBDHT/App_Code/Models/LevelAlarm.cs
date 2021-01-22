using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LevelAlarm
/// </summary>
public class LevelAlarm
{
    string level;
    double? value;

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
}