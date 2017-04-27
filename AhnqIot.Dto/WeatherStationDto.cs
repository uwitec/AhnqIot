using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [ProtoContract]
  public  class WeatherStationDto:BaseDto
    {
        [ProtoMember(1)]
        public string Introduce { get; set; }
        [ProtoMember(2)]
        public string Latitude { get; set; }
        [ProtoMember(3)]
        public string Location { get; set; }
        [ProtoMember(4)]
        public string Lotitude { get; set; }
        [ProtoMember(5)]
        public DateTime? SetupTime { get; set; }
        [ProtoMember(6)]
        public string SysDepartmentSerialnum { get; set; }
        [ProtoMember(7)]
        public int? UploadExperiod { get; set; }
    }
}
