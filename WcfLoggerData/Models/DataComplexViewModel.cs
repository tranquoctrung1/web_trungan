using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class DataComplexViewModel
    {
        private string siteID;
        private string location;
        private string oldID;
        private string loggerID;
        private List<ChannelViewModel> listChannel;

        public string SiteID { get => siteID; set => siteID = value; }
        public string Location { get => location; set => location = value; }
        public string OdlID { get => oldID; set => oldID = value; }
        public string LoggerID { get => loggerID; set => loggerID = value; }
        public List<ChannelViewModel> ListChannel { get => listChannel; set => listChannel = value; }
    }
}