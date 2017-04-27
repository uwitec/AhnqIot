using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
namespace AhnqIot.Dto
{
    [ProtoContract]
  public  class AreaStationDto:BaseDto
    {
        [ProtoMember(1)]
        public string Addr { get; set; }
        [ProtoMember(2)]
        public decimal Atmosphere { get; set; }
        [ProtoMember(3)]
        public decimal Humidity { get; set; }
        [ProtoMember(4)]
        public string Latitude { get; set; }
        [ProtoMember(5)]
        public string Lontitude { get; set; }
        [ProtoMember(6)]
        public decimal Rainfall { get; set; }
        [ProtoMember(7)]
        public string StationCode { get; set; }
        [ProtoMember(8)]
        public string SysDepartmentSerialnum { get; set; }
        [ProtoMember(9)]
        public decimal Temprature { get; set; }
        [ProtoMember(10)]
        public int WindDirection { get; set; }
        [ProtoMember(11)]
        public decimal WindSpeed { get; set; }
    }
}
