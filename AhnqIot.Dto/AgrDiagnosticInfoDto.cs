using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
  public  class AgrDiagnosticInfoDto:BaseDto
    {
        public string AgrDiagnosticModelSerialnum { get; set; }
        public string Info { get; set; }
    }
}
