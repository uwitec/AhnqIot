using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
namespace AhnqIot.Dto
{
    [ProtoContract]
    public class SysRoleDto : BaseDto
    {
        [ProtoMember(1)]
        public String Name { get; set; }
        [ProtoMember(2)]
        public String Url { get; set; }
        
    }
}
