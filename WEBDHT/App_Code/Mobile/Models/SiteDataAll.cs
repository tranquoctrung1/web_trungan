using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SiteDataAll
/// </summary>
public class SiteDataAll
{
    public string SiteId { get; set; }
    public string SiteAliasName { get; set; }
    public string Location { get; set; }
    public string DisplayGroup { get; set; }
    public string District { get; set; }
    public double Latitude { get; set; }
    public string LoggerId { get; set; }
    public double Longitude { get; set; }
    public double Index { get; set; }
    public List<MChannel> ListChannels { get; set; }
    public int DelayTime { get; set; }
}