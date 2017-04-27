using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public  class SysAreaDto:BaseDto
    {
        public string AwCode { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ParentSerialnum { get; set; }
        public int Status { get; set; }
    }
}
