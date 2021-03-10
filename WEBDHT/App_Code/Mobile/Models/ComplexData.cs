using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ComplexData
/// </summary>
public class ComplexData
{
    public Nullable<int> Nr { get; set; }
    public string SiteId { get; set; }
    public string SiteAliasName { get; set; }
    public string LoggerId { get; set; }
    public string Location { get; set; }
    public Nullable<System.DateTime> TimeStamp { get; set; }
    public Nullable<double> Pressure1 { get; set; }
    public Nullable<double> Pressure2 { get; set; }
    public Nullable<double> ForwardFlow { get; set; }
    public Nullable<double> ReverseFlow { get; set; }
    public Nullable<double> ForwardIndex { get; set; }
    public Nullable<double> ReverseIndex { get; set; }
    public string Alarm { get; set; }
    public Nullable<double> NetIndex { get; set; }
    public string Pressure1Unit { get; set; }
    public string Pressure2Unit { get; set; }
    public string ForwardFlowUnit { get; set; }
    public string ReverseFlowUnit { get; set; }
}