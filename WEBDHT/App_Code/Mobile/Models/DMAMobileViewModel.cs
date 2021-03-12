using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DMAViewModel
/// </summary>
public class DMAMobileViewModel
{

    public string DMA { get; set; }
    public Nullable<bool> Production { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string District { get; set; }
    public string Ward { get; set; }

    public Nullable<int> AmountDHTKH { get; set; }
    public Nullable<int> AmountValve { get; set; }
    public Nullable<int> AmountPool { get; set; }
    public Nullable<int> AmountTCH { get; set; }

    public Nullable<double> NRW { get; set; }
}