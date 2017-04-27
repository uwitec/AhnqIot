using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [ProtoContract]
  public  class CompanyUserDto: BaseDto
    {
        [ProtoMember(1)]
        public string CompanySerialnum { get; set; }
        [ProtoMember(2)]
        public string FacilitySerialnum { get; set; }
        [ProtoMember(3)]
        public string FarmSerialnum { get; set; }
        [ProtoMember(4)]
        public string SysUserSerialnum { get; set; }
    }
}
