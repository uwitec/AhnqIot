using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahnqiot.Web.Api.Models
{
    public class AgrDiagnosticModel
    {
        public string AgrProductObjectGrowthInfoSerialnum { get; set; }
        public string DeviceTypeSerialnum { get; set; }
        public string DisplayColor { get; set; }
        public bool IsNotice { get; set; }
        public decimal MaxValue { get; set; }
        public decimal MinValue { get; set; }
        public string Name { get; set; }
    }
}