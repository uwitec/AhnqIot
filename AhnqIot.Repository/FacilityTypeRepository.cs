using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;

namespace AhnqIot.Repository
{
  public  class FacilityTypeRepository
    {
        /// <summary>
        /// 获取所有设施类型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FacilityType> GetAll()
        {
            return FacilityType.FindAll();
        }
    }
}
