using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahnqiot.Web.Api.Models
{
    public class DeviceControlLogModel
    {
        public string CommandSerialnum { get; set; }
        public bool ControlResult { get; set; }
        public string DeviceSerialnum { get; set; }
        public decimal DeviceValue { get; set; }
    }
}