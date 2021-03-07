using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class DistrictViewModel
    {
        string idDistrict;
        string name;
        string description;

        public string IdDistrict { get => idDistrict; set => idDistrict = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
    }
}