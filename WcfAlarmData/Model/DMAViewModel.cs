using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAlarmData.Model
{
    public class DMAViewModel
    {
        string company;
        Nullable<bool> production;
        string description;
        string status;
        string disctrict;
        string ward;
        Nullable<int> amountDHTKH;
        Nullable<int> amountValve;
        Nullable<int> amountPool;
        Nullable<int> amountTCH;
        Nullable<double> nRW;

        public string Company { get => company; set => company = value; }
        public bool? Production { get => production; set => production = value; }
        public string Description { get => description; set => description = value; }
        public string Status { get => status; set => status = value; }
        public string Disctrict { get => disctrict; set => disctrict = value; }
        public string Ward { get => ward; set => ward = value; }
        public int? AmountDHTKH { get => amountDHTKH; set => amountDHTKH = value; }
        public int? AmountValve { get => amountValve; set => amountValve = value; }
        public int? AmountPool { get => amountPool; set => amountPool = value; }
        public int? AmountTCH { get => amountTCH; set => amountTCH = value; }
        public double? NRW { get => nRW; set => nRW = value; }
    }
}
