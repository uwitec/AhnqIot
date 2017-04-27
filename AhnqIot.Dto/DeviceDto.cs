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
    public class DeviceDto : BaseDto
    {
        [ProtoMember(1)]
        public string DeviceTypeSerialnum { get; set; }
        [ProtoMember(2)]
        public string FacilitySerialnum { get; set; }
        [ProtoMember(3)]
        public bool IsException { get; set; }
        [ProtoMember(4)]
        public string Location { get; set; }
        [ProtoMember(5)]
        public string Name { get; set; }
        [ProtoMember(6)]
        public bool OnlineStatus { get; set; }
        [ProtoMember(7)]
        public string PhotoUrl { get; set; }
        [ProtoMember(8)]
        public decimal ProcessedValue { get; set; }
        [ProtoMember(9)]
        public string ShowValue { get; set; }
        [ProtoMember(10)]
        public int Status { get; set; }
        [ProtoMember(11)]
        public string Unit { get; set; }
        [ProtoMember(12)]
        public string RelayType { get; set; }
    }
}
