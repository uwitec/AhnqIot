using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;

namespace AhnqIot.Repository
{
   public class FacilityProduceInfoRepository
    {
        /// <summary>
        /// 根据设施编码获取设施摄种养殖信息
        /// </summary>
        /// <param name="facilitySerialnum">设施编码</param>
        /// <returns></returns>
        public IEnumerable<FacilityProduceInfo> GetByFacilitySerialnum(string facilitySerialnum)
        {
            if (string.IsNullOrWhiteSpace(facilitySerialnum)) throw new ArgumentNullException("facilitySerialnum");
            return FacilityProduceInfo.FindAllByFacilitySerialnum(facilitySerialnum);
        }
    }
}
