using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
namespace AhnqIot.Dto
{
    [ProtoContract]
  public  class DeviceTypeDto:BaseDto
    {
        [ProtoMember(1)]
        public string Introduce { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public string ParentSerialnum { get; set; }
        [ProtoMember(4)]
        public string PhotoUrl { get; set; }
        [ProtoMember(5)]
        public int ValueCount { get; set; }
    }
}
