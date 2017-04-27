using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
   public class FacilityTypeDto:BaseDto
    {
        public string Css { get; set; }
        public string Introduce { get; set; }
        public bool IsSystem { get; set; }
        public string Name { get; set; }
        public string ParentSerialnum { get; set; }
        public string PhotoUrl { get; set; }
    }
}
