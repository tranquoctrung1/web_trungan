using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class StatisticSiteDMAViewModel
    {
        Nullable<int> orderNumber;
        string siteId;
        string model;
        Nullable<int> size;
        string location;
        string level;
        string manager;
        string availability;
        string status;
        string usingLogger;
        string description;

        public int? OrderNumber { get => orderNumber; set => orderNumber = value; }
        public string SiteId { get => siteId; set => siteId = value; }
        public string Model { get => model; set => model = value; }
        public int? Size { get => size; set => size = value; }
        public string Location { get => location; set => location = value; }
        public string Level { get => level; set => level = value; }
        public string Manager { get => manager; set => manager = value; }
        public string Availability { get => availability; set => availability = value; }
        public string Status { get => status; set => status = value; }
        public string UsingLogger { get => usingLogger; set => usingLogger = value; }
        public string Description { get => description; set => description = value; }
    }
}