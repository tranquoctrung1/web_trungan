using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class StatisticSiteViewModel
    {
        public string Id { get; set; }
        public string OldId { get; set; }
        public string Location { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string ViewGroup { get; set; }
        public string StaffId { get; set; }
        public string Meter { get; set; }
        public string OldMeter { get; set; }
        public string OldTran { get; set; }
        public string Transmitter { get; set; }
        public string Logger { get; set; }
        public DateTime? DateOfMeterChange { get; set; }
        public DateTime? DateOfTransmitterChange { get; set; }
        public DateTime? DateOfLoggerChange { get; set; }
        public DateTime? DateOfBatteryChange { get; set; }
        public DateTime? DateOfTransmitterBatteryChange { get; set; }
        public DateTime? DateOfLoggerBatteryChange { get; set; }
        public string DescriptionOfChange { get; set; }
        public double? ChangeIndex { get; set; }
        public string Level { get; set; }
        public string Group { get; set; }
        public string Group2 { get; set; }
        public string Company { get; set; }
        public DateTime? TakeoverDate { get; set; }
        public bool? Takeovered { get; set; }
        public string Status { get; set; }
        public string Availability { get; set; }
        public bool? Display { get; set; }
        public bool? Property { get; set; }
        public bool? UsingLogger { get; set; }
        public string MeterDirection { get; set; }
        public string ProductionCompany { get; set; }
        public string IstDistributionCompany { get; set; }
        public string QndDistributionCompany { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfChange { get; set; }
        public string Provider { get; set; }
        public string Marks { get; set; }
        public int? Size { get; set; }
        public string Model { get; set; }
        public string LoggerModel { get; set; }
        public DateTime? AccreditedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string AccreditationDocument { get; set; }
        public string LoggerId { get; set; }
        public string District { get; set; }
        public string ApprovalDecision { get; set; }
    }
}