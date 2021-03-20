using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoggerViewModel
/// </summary>
public class LoggerMobileViewModel
{
    public string Serial { get; set; }
    public Nullable<DateTime> ReceiptDate { get; set; }
    public string Provider { get; set; }
    public string Marks { get; set; }
    public string Model { get; set; }
    public string Status { get; set; }
    public Nullable<bool> Installed { get; set; }
    public string Description { get; set; }
    public Nullable<DateTime> DateAccreditation { get; set; }
    public Nullable<DateTime> DateInstallBattery { get; set; }
    public Nullable<int> YearBattery { get; set; }
}