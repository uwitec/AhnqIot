using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
  public  class AWProductDto:BaseDto
    {
        public string AWProductTypeSerialnum { get; set; }
        public string Description { get; set; }
        public int Hits { get; set; }
        public string Href { get; set; }
        public string PhotoUrl { get; set; }
        public string SysDepartmentSerialnum { get; set; }
        public string Title { get; set; }
    }
}
