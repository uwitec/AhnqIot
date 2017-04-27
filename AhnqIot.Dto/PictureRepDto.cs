using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [ProtoContract]
  public  class PictureRepDto:BaseDto
    {
        [ProtoMember(1)]
        public string Description { get; set; }
        [ProtoMember(2)]
        public string Href { get; set; }
        [ProtoMember(3)]
        public int Status { get; set; }
        [ProtoMember(4)]
        public string Title { get; set; }
        [ProtoMember(5)]
        public string Type { get; set; }
        [ProtoMember(6)]
        public string Url { get; set; }
    }
}
