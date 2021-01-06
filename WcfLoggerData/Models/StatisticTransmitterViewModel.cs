using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class StatisticTransmitterViewModel
    {
        int? numberOrdered;
        string serial;
        DateTime? receiptDate;
        string provider;
        string marks;
        int? size;
        string model;
        string status;
        bool? installed;
        double? initialIndex;
        string description;
        DateTime? approvalDate;
        string approvalDecision;
        bool? approved;
        DateTime? accreditedDate;
        DateTime? expiryDate;
        string accreditationType;
        string accreditationDocument;
        string siteId;
        string location;
        string siteCompany;
        string siteStatus;

        public string Serial { get => serial; set => serial = value; }
        public DateTime? ReceiptDate { get => receiptDate; set => receiptDate = value; }
        public string Provider { get => provider; set => provider = value; }
        public string Marks { get => marks; set => marks = value; }
        public int? Size { get => size; set => size = value; }
        public string Model { get => model; set => model = value; }
        public string Status { get => status; set => status = value; }
        public bool? Installed { get => installed; set => installed = value; }
        public double? InitialIndex { get => initialIndex; set => initialIndex = value; }
        public string Description { get => description; set => description = value; }
        public DateTime? ApprovalDate { get => approvalDate; set => approvalDate = value; }
        public string ApprovalDecision { get => approvalDecision; set => approvalDecision = value; }
        public bool? Approved { get => approved; set => approved = value; }
        public DateTime? AccreditedDate { get => accreditedDate; set => accreditedDate = value; }
        public DateTime? ExpiryDate { get => expiryDate; set => expiryDate = value; }
        public string AccreditationType { get => accreditationType; set => accreditationType = value; }
        public string AccreditationDocument { get => accreditationDocument; set => accreditationDocument = value; }
        public string SiteId { get => siteId; set => siteId = value; }
        public string Location { get => location; set => location = value; }
        public int? NumberOrdered { get => numberOrdered; set => numberOrdered = value; }
        public string SiteCompany { get => siteCompany; set => siteCompany = value; }
        public string SiteStatus { get => siteStatus; set => siteStatus = value; }
    }
}