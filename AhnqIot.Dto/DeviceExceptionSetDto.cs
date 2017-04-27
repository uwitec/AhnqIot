using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [ProtoContract]
   public class DeviceExceptionSetDto : BaseDto
    {
        [ProtoMember(1)]
        public string DeviceSerialnum { get; set; }
        [ProtoMember(2)]
        public decimal Max { get; set; }
        [ProtoMember(3)]
        public decimal Min { get; set; }
        [ProtoMember(4)]
        public bool Status { get; set; }
    }
}
