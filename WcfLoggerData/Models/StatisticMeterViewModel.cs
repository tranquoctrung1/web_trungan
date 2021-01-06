using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class StatisticMeterViewModel
    {
        public int? NumberOrdered { get; set; }
        public string Serial { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string Provider { get; set; }
        public string Marks { get; set; }
        public int? Size { get; set; }
        public string Model { get; set; }
        public string Status { get; set; }
        public bool? Installed { get; set; }
        public double? InitialIndex { get; set; }
        public string Description { get; set; }
        public DateTime? AccreditedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string AccreditationDocument { get; set; }
        public string AccreditationType { get; set; }
        public string SiteId { get; set; }
        public string Location { get; set; }
        public string TransmitterSerial { get; set; }
        public string SiteStatus { get; set; }
        public string SiteCompany { get; set; }
        public string Nationality { get; set; }
    }
}