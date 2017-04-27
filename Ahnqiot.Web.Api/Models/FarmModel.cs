using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahnqiot.Web.Api.Models
{
    public class FarmModel
    {
        public string APIKey { get; set; }
        public string AreaStationSerialnum { get; set; }
        public string CompanySerialnum { get; set; }    
        public string Name { get; set; }
        public string SysDepartmentSerialnum { get; set; }
        public string UploadPassword { get; set; }
    }
}