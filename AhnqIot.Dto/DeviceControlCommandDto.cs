using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
   public class DeviceControlCommandDto : BaseDto
    {
        public string Command { get; set; }
        public int ControlContinueTime { get; set; }
        public string DeviceSerialnum { get; set; }
        public int Status { get; set; }
    }
}
