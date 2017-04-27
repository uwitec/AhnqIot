using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [ProtoContract]
   public class AreaStationDataInfoDto:BaseDto
    {
        [ProtoMember(1)]
        public string AreaStationSerialnum { get; set; }
        [ProtoMember(2)]
        public decimal Atmosphere { get; set; }
        [ProtoMember(3)]
        public decimal Humidity { get; set; }
        [ProtoMember(4)]
        public decimal Rainfall { get; set; }
        [ProtoMember(5)]
        public decimal Temprature { get; set; }
        [ProtoMember(6)]
        public int WindDirection { get; set; }
        [ProtoMember(7)]
        public decimal WindSpeed { get; set; }
    }
}
