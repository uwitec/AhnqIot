using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
  public  class SysRoleMenuDto:BaseDto
    {
        public string Name { get; set; }
        public int Status { get; set; }
        public string SysMenuSerialnum { get; set; }
        public string SysRoleSerialnum { get; set; }
    }
}
