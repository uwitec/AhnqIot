using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
   public interface IAreaStationDataInfoService:IService<AreaStationDataInfoDto>
   {
        /// <summary>
        /// 根据设备编码获取
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
       Task<AreaStationDataInfoDto> GetByIdAsny(string deviceId);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
       Task<bool> AddAsny(AreaStationDataInfoDto dto);
   }
}
