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
  public  class DeviceDataInfoDto : BaseDto
    {
        [ProtoMember(1)]
        public string DeviceSerialnum { get; set; }
        [ProtoMember(2)]
        public bool IsException { get; set; }
        [ProtoMember(3)]
        public decimal Max { get; set; }
        [ProtoMember(4)]
        public decimal Min { get; set; }
        [ProtoMember(5)]
        public int OriginalData { get; set; }
        [ProtoMember(6)]
        public decimal ProcessedValue { get; set; }
        [ProtoMember(7)]
        public string ShowValue { get; set; }
    }
}
