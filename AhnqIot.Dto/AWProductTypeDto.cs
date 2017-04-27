using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
  public  class AWProductTypeDto:BaseDto
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string ParentSerialnum { get; set; }
    }
}
