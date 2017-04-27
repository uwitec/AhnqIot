using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
   public interface ICameraStationPresetPointService:IService<CameraStationPresetPointDto>
   {
        /// <summary>
        /// 根据编码和预置点获取
        /// </summary>
        /// <param name="id">编码</param>
        /// <param name="point">预置点</param>
        /// <returns></returns>
       Task<CameraStationPresetPointDto> GetByPointAndIdAsny(string id,int point);

       /// <summary>
       /// 增加预置点
       /// </summary>
       /// <param name="dto"></param>
       /// <returns></returns>
       Task<bool> AddAsny(CameraStationPresetPointDto dto);

       /// <summary>
       /// 更新预置点信息
       /// </summary>
       /// <param name="dto"></param>
       /// <returns></returns>
       Task<bool> UpdateAsny(CameraStationPresetPointDto dto);
   }
}
