using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
  public class CompanyDto:BaseDto
    {
        public string Addr { get; set; }
        public DateTime? ApplyTime { get; set; }
        public string ContactMan { get; set; }
        public string ContactPhone { get; set; }
        public string Introduce { get; set; }
        public string Latitude { get; set; }
        public string Lontitude { get; set; }
        public string Name { get; set; }
        public string Pinyin { get; set; }
        public int Status { get; set; }
        public string SysDepartmentSerialnum { get; set; }
    }
}
