using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class SiteByDisplayGroupViewModel
    {
        string siteID;
        string siteAliasName;
        string location;
        string loggerID;
        string displayGroup;
        string meterSerial;
        string displayGroupOut;

        public string SiteID { get => siteID; set => siteID = value; }
        public string SiteAliasName { get => siteAliasName; set => siteAliasName = value; }
        public string Location { get => location; set => location = value; }
        public string LoggerID { get => loggerID; set => loggerID = value; }
        public string DisplayGroup { get => displayGroup; set => displayGroup = value; }
        public string MeterSerial { get => meterSerial; set => meterSerial = value; }
        public string DisplayGroupOut { get => displayGroupOut; set => displayGroupOut = value; }
    }
}