using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [ProtoContract]
  public  class CameraStationPicsDto:BaseDto
    {
        [ProtoMember(1)]
        public string CameraStationsPresetSerialnum { get; set; }
        [ProtoMember(2)]
        public string PicSerialnum { get; set; }
    }
}
