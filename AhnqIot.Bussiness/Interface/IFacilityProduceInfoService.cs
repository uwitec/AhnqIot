using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
    public interface IFacilityProduceInfoService : IService<FacilityProduceInfoDto>
    {
        /// <summary>
        /// 根据设施编码获取设施农作物信息
        /// </summary>
        /// <param name="facilityId">设施编码</param>
        /// <returns></returns>
        Task<IEnumerable<FacilityProduceInfoDto>> GetFacilityProduceInfoByFacilityId(string facilityId);
    }
}
