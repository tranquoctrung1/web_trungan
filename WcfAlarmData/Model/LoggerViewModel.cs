using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAlarmData.Model
{
    public  class LoggerViewModel
    {
        string serial;
        Nullable<DateTime> receiptDate;
        string provider;
        string marks;
        string model;
        string status;
        Nullable<bool> installed;
        string description;
        Nullable<DateTime> dateAccreditation;
        Nullable<DateTime> dateInstallBattery;
        Nullable<int> yearBattery;

        public string Serial { get => serial; set => serial = value; }
        public DateTime? ReceiptDate { get => receiptDate; set => receiptDate = value; }
        public string Provider { get => provider; set => provider = value; }
        public string Marks { get => marks; set => marks = value; }
        public string Model { get => model; set => model = value; }
        public string Status { get => status; set => status = value; }
        public bool? Installed { get => installed; set => installed = value; }
        public string Description { get => description; set => description = value; }
        public DateTime? DateAccreditation { get => dateAccreditation; set => dateAccreditation = value; }
        public DateTime? DateInstallBattery { get => dateInstallBattery; set => dateInstallBattery = value; }
        public int? YearBattery { get => yearBattery; set => yearBattery = value; }
    }
}
