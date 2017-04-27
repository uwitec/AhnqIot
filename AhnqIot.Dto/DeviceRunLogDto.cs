using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [Serializable]
    [ProtoContract]
   public class DeviceRunLogDto:BaseDto
    {
        [ProtoMember(1)]
        public string Description { get; set; }
        [ProtoMember(2)]
        public string DeviceRunLogTypeSerialnum { get; set; }
        [ProtoMember(3)]
        public string DeviceSerialnum { get; set; }
    }
}
