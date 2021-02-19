using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAlarmData.Model
{
    public class DMAViewModel
    {
        string id;
        string siteId;
        string tel;
        Nullable<byte> pressure;
        Nullable<byte> forward;
        Nullable<byte> reverse;
        Nullable<Int16> interval;
        Nullable<DateTime> beginTime;
        Nullable<byte> zoomInit;
        Nullable<byte> zoomOn;
        Nullable<byte> pressure1;
        Nullable<int> delayTime;

        public string Id { get => id; set => id = value; }
        public string SiteId { get => siteId; set => siteId = value; }
        public string Tel { get => tel; set => tel = value; }
        public byte? Pressure { get => pressure; set => pressure = value; }
        public byte? Forward { get => forward; set => forward = value; }
        public byte? Reverse { get => reverse; set => reverse = value; }
        public short? Interval { get => interval; set => interval = value; }
        public DateTime? BeginTime { get => beginTime; set => beginTime = value; }
        public byte? ZoomInit { get => zoomInit; set => zoomInit = value; }
        public byte? ZoomOn { get => zoomOn; set => zoomOn = value; }
        public byte? Pressure1 { get => pressure1; set => pressure1 = value; }
        public int? DelayTime { get => delayTime; set => delayTime = value; }
    }
}
