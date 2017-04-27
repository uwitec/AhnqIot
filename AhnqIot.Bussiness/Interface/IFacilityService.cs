using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
   public interface IFacilityService:IService<FacilityDto>
    {
        /// <summary>
        /// 根据编码获取设施
        /// </summary>
        /// <param name="id">设施编码</param>
        /// <returns></returns>
        Task<FacilityDto> GetFacilityByIdAsny(string id);

        /// <summary>
        /// 添加设施
        /// </summary>
        /// <param name="dto">设施实体</param>
        /// <returns></returns>
        Task<bool> AddFacility(FacilityDto dto);

        /// <summary>
        /// 更新设施
        /// </summary>
        /// <param name="dto">设施</param>
        /// <returns></returns>实体
        Task<bool> UpdateFacilityAsnyc(FacilityDto dto);
        /// <summary>
        /// 根据基地编码获取设施
        /// </summary>
        /// <param name="farmId">基地编码</param>
        /// <returns></returns>
        Task<IEnumerable<FacilityDto>> GetFacilitiesByFarmIdAsny(string farmId);
        /// <summary>
        /// 根据基地编码获取设施
        /// </summary>
        /// <param name="farmId">基地编码</param>
        /// <returns></returns>
      IEnumerable<FacilityDto> GetFacilitiesByFarmId(string farmId);

        /// <summary>
        /// 检验编码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool CheckCode(string code);
    }
}
