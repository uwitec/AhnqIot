using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahnqiot.Web.Api.Models
{
    public class DeviceModel
    {
        public string DeviceTypeSerialnum { get; set; }
        public string FacilitySerialnum { get; set; } 
        public bool IsException { get; set; }
        public string Name { get; set; }
        public bool OnlineStatus { get; set; }

    }
}