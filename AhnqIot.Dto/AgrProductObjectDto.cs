using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
   public class AgrProductObjectDto:BaseDto
    {
        public string Name { get; set; }
        public string CropUrl { get; set; }
        public string Introduce { get; set; }
        public string AgrProducationTypeSerialnum { get; set; }
    }
}
