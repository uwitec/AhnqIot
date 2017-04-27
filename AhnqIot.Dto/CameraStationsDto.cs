using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [ProtoContract]
  public  class CameraStationsDto:BaseDto
    {
        [ProtoMember(1)]
        public int Channel { get; set; }
        [ProtoMember(2)]
        public int DataPort { get; set; }
        [ProtoMember(3)]
        public int HttpPort { get; set; }
        [ProtoMember(4)]
        public string Introduce { get; set; }
        [ProtoMember(5)]
        public string IP { get; set; }
        [ProtoMember(6)]
        public string Latitude { get; set; }
        [ProtoMember(7)]
        public string Location { get; set; }
        [ProtoMember(8)]
        public string Lotitude { get; set; }
        [ProtoMember(9)]
        public string Name { get; set; }
        [ProtoMember(10)]
        public int RtspPort { get; set; }
        [ProtoMember(11)]
        public DateTime SetupTime { get; set; }
        [ProtoMember(12)]
        public string StreamMedia { get; set; }
        [ProtoMember(13)]
        public string SysDepartmentSerialnum { get; set; }
        [ProtoMember(14)]
        public string UserID { get; set; }
        [ProtoMember(15)]
        public string UserPwd { get; set; }
    }
}
