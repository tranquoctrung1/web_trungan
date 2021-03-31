using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MChannel
/// </summary>
public class MChannel
{
    public string ChannelId { get; set; }
    public string LoggerId { get; set; }
    public string ChannelName { get; set; }
    public string Unit { get; set; }
    public string Description { get; set; }
    public Nullable<bool> ForwardFlow { get; set; }
    public Nullable<bool> ReverseFlow { get; set; }
    public Nullable<bool> Pressure1 { get; set; }
    public Nullable<bool> Pressure2 { get; set; }
    public int Status { get; set; }
    public string TimeStamp { get; set; }
    public string LastValue { get; set; }
    public string IndexTimeStamp { get; set; }
    public string LastIndex { get; set; }
    public bool DisplayOnLabel { get; set; }
    public string StrTimeStamp { get; set; }

    public string yyyy { get; set; }
    public string MM { get; set; }
    public string dd { get; set; }
    public string HH { get; set; }
    public string mm { get; set; }

    public string GroupChannel { get; set; }
}