using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [ProtoContract]
   public class WeatherStationOnlineStatisticsDto:BaseDto
    {
        [ProtoMember(1)]
        public int AllCount { get; set; }
        [ProtoMember(2)]
        public int Day { get; set; }
        [ProtoMember(3)]
        public int Month { get; set; }
        [ProtoMember(4)]
        public int ReceiveCount { get; set; }
        [ProtoMember(5)]
        public decimal ReceivePercent { get; set; }
        [ProtoMember(6)]
        public DateTime SetupTime { get; set; }
        [ProtoMember(7)]
        public string WeatherDeviceSerialnum { get; set; }
        [ProtoMember(8)]
        public int Year { get; set; }
    }
}
