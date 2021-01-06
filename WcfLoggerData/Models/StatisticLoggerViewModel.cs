using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class StatisticLoggerViewModel
    {

        public int NumberOrdered { get; set; }
        public string Serial { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string Provider { get; set; }
        public string Marks { get; set; }
        public string Model { get; set; }
        public string Status { get; set; }
        public bool? Installed { get; set; }
        public string Description { get; set; }
        public string SiteId { get; set; }
        public string Location { get; set; }
        public string SiteStatus { get; set; }
        public string SiteCompany { get; set; }
        public string LoggerId { get; set; }
    }
}