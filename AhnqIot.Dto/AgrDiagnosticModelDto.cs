using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
   public class AgrDiagnosticModelDto:BaseDto
    {
        public string Advise { get; set; }
        public string AgrProductObjectGrowthInfoSerialnum { get; set; }
        public string DeviceTypeSerialnum { get; set; }
        public string DisplayColor { get; set; }
        public string Effect { get; set; }
        public bool IsNotice { get; set; }
        public decimal MaxValue { get; set; }
        public decimal MinValue { get; set; }
        public string Name { get; set; }
        public string TipInfo { get; set; }
    }
}
