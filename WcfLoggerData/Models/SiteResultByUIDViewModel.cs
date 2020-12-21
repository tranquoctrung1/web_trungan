using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class SiteResultByUIDViewModel
    {
        string siteId;
        double? baseLine;
        string displayGroup;
        string location;
        string loggerId;
        double? latitude;
        double? longitude;
        int? labelAnchorX;
        int? labelAnchorY;
        double? index;
        string role;
        List<ChannelsViewModel> channels;

        public string SiteId { get => siteId; set => siteId = value; }
        public double? BaseLine { get => baseLine; set => baseLine = value; }
        public string DisplayGroup { get => displayGroup; set => displayGroup = value; }
        public string Location { get => location; set => location = value; }
        public string LoggerId { get => loggerId; set => loggerId = value; }
        public double? Latitude { get => latitude; set => latitude = value; }
        public double? Longitude { get => longitude; set => longitude = value; }
        public int? LabelAnchorX { get => labelAnchorX; set => labelAnchorX = value; }
        public int? LabelAnchorY { get => labelAnchorY; set => labelAnchorY = value; }
        public double? Index { get => index; set => index = value; }
        public string Role { get => role; set => role = value; }
        public List<ChannelsViewModel> Channels { get => channels; set => channels = value; }
    }
}