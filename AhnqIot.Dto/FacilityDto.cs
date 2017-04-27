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
    public class FacilityDto : BaseDto
    {
        [ProtoMember(1)]
        public string Address { get; set; }
        [ProtoMember(2)]
        public string ContactMan { get; set; }
        [ProtoMember(3)]
        public string ContactMobile { get; set; }
        [ProtoMember(4)]
        public string ContactPhone { get; set; }
        [ProtoMember(5)]
        public string FacilityTypeSerialnum { get; set; }
        [ProtoMember(6)]
        public string FarmSerialnum { get; set; }
        [ProtoMember(7)]
        public string Introduce { get; set; }
        [ProtoMember(8)]
        public string Name { get; set; }
        [ProtoMember(9)]
        public string PhotoUrl { get; set; }
        [ProtoMember(10)]
        public int Status { get; set; }

    }
}
