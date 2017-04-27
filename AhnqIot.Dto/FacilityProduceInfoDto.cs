using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
  public  class FacilityProduceInfoDto:BaseDto
    {
        public string AgrProductObjectSerialnum { get; set; }
        public string Description { get; set; }
        public DateTime? EndTime { get; set; }
        public string FacilitySerialnum { get; set; }
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public bool Status { get; set; }
    }
}
