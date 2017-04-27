using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
  public  class AgrProductObjectGrowthInfoDto:BaseDto
    {
        public string AgrProductObjectSerialnum { get; set; }
        public int DayCount { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
