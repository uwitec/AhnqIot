using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [ProtoContract]
  public  class FacilityPicsDto:BaseDto
    {
        [ProtoMember(1)]
        public string FacilityCameraPresetSerialnum { get; set; }
        [ProtoMember(2)]
        public string FacilitySerialnum { get; set; }
        [ProtoMember(3)]
        public string PicSerialnum { get; set; }
     
    }
}
