using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.Repository.AhnqIot;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AutoMapper;


namespace AhnqIot.Bussiness
{
    public class FacilityProduceInfoService : ServiceBase<FacilityProduceInfo, FacilityProduceInfoDto>, IFacilityProduceInfoService
    {
        /// <summary>
        /// 根据设施编码获取设施农作物信息
        /// </summary>
        /// <param name="facilityId">设施编码</param>
        /// <returns></returns>
        public async Task<IEnumerable<FacilityProduceInfoDto>> GetFacilityProduceInfoByFacilityId(string facilityId)
        {
            return Mapper.Map<IEnumerable<FacilityProduceInfoDto>>(await GetManyAsync(fpi => fpi.FacilitySerialnum.Equals(facilityId)));
        }

    }
}
