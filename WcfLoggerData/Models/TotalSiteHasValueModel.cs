using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfLoggerData.Models
{
    public class TotalSiteHasValueModel
    {
        public string SiteId { get; set; }
        public string Location { get; set; }
        public string LoggerId { get; set; }
        public Nullable<int> Result { get; set; }
    }
}
