using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [ProtoContract]
  public  class FacilityCameraDto : BaseDto
    {
        [ProtoMember(1)]
        public int Channel { get; set; }
        [ProtoMember(2)]
        public int DataPort { get; set; }
        [ProtoMember(3)]
        public string FacilitySerialnum { get; set; }
        [ProtoMember(4)]
        public int HttpPort { get; set; }
        [ProtoMember(5)]
        public string IP { get; set; }
        [ProtoMember(6)]
        public string Location { get; set; }
        [ProtoMember(7)]
        public string Name { get; set; }
        [ProtoMember(8)]
        public int RtspPort { get; set; }
        [ProtoMember(9)]
        public bool Status { get; set; }
        [ProtoMember(10)]
        public string UserID { get; set; }
        [ProtoMember(11)]
        public string UserPwd { get; set; }
    }
}
