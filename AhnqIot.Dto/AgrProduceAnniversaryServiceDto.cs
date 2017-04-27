using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
  public  class AgrProduceAnniversaryServiceDto:BaseDto
    {
        public string AgrProductObjectSerialnum { get; set; }
        public string MainDevelopmentalStage { get; set; }
        public int Month { get; set; }
        public string PossibleDisasters { get; set; }
        public string ServiceContent { get; set; }
        public string ServiceFocus { get; set; }
        public string SysAreaSerialnum { get; set; }
        public string TakeMeasures { get; set; }
        public string Ten { get; set; }
    }
}
