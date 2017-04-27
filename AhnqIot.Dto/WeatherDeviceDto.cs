using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [ProtoContract]
  public class WeatherDeviceDto:BaseDto
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public decimal Value { get; set; }
        [ProtoMember(3)]
        public string WeatherDeviceTypeSerialnum { get; set; }
        [ProtoMember(4)]
        public string WeatherStationSerialnum { get; set; }
    }
}
