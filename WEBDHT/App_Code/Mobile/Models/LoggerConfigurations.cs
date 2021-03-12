using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoggerConfigurations
/// </summary>
public class LoggerConfigurations
{
    public string LoggerId { get; set; }
    public string SiteId { get; set; }
    public Nullable<byte> Pressure1 { get; set; }
    public Nullable<byte> Pressure2 { get; set; }
    public Nullable<byte> ForwardFlow { get; set; }
    public Nullable<byte> ReverseFlow { get; set; }
    public Nullable<int> TimeDelayAlarm { get; set; }
    public Nullable<byte> Interval { get; set; }

}