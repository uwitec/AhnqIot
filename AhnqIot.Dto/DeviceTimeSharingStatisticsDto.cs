using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [Serializable]
    [ProtoContract]
  public  class DeviceTimeSharingStatisticsDto:BaseDto
    {
        [ProtoMember(1)]
        public decimal AvgValue { get; set; }
        [ProtoMember(2)]
        public int Count { get; set; }
        [ProtoMember(3)]
        public string DeviceSerialnum { get; set; }
        [ProtoMember(4)]
        public decimal EndValue { get; set; }
        [ProtoMember(5)]
        public int ExceptionCount { get; set; }
        [ProtoMember(6)]
        public decimal Max { get; set; }
        [ProtoMember(7)]
        public decimal MaxValue { get; set; }
        [ProtoMember(8)]
        public decimal Min { get; set; }
        [ProtoMember(9)]
        public decimal MinValue { get; set; }
        [ProtoMember(10)]
        public decimal StartValue { get; set; }
        [ProtoMember(11)]
        public int TimeSharing { get; set; }
    }
}
