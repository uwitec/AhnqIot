using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
   public class DeviceControlLogDto : BaseDto
    {
        public string CommandSerialnum { get; set; }
        public bool ControlResult { get; set; }
        public string DeviceSerialnum { get; set; }
        public string DeviceShowValue { get; set; }
        public decimal DeviceValue { get; set; }
        public string FailReason { get; set; }
    }
}
