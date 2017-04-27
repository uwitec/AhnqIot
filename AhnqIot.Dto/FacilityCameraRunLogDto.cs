using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [ProtoContract]
  public  class FacilityCameraRunLogDto:BaseDto
    {
        [ProtoMember(1)]
        public string Description { get; set; }
        [ProtoMember(2)]
        public string FacilityCameraSerialnum { get; set; }
        [ProtoMember(3)]
        public bool Status { get; set; }
    }
}
