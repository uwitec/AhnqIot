using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
  public  class SysMenuDto:BaseDto
    {
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public bool Necessary { get; set; }
        public string ParentSerialnum { get; set; }
        public int Status { get; set; }
        public string SysFunctionSerialnum { get; set; }
        public bool Visiable { get; set; }
    }
}
