using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;
using System.Linq.Expressions;

namespace AhnqIot.Bussiness.Interface
{
   public interface IFacilityCameraService:IService<FacilityCameraDto>
    {
        /// <summary>
        /// 获取设施摄像机
        /// </summary>
        /// <returns></returns>
        Task<FacilityCameraDto> GetByWhereAsny(Expression<Func<FacilityCameraDto, bool>> where);
        /// <summary>
        /// 根据设备编码获取设施摄像机
        /// </summary>
        /// <param name="deviceId">设备编码</param>
        /// <returns></returns>
        Task<FacilityCameraDto> GetFacilityCameraByIdAsny(string deviceId);
        /// <summary>
        /// 添加设施摄像机
        /// </summary>
        /// <param name="dto">设施摄像机实体</param>
        /// <returns></returns>
        Task<bool> AddFacilityCamera(FacilityCameraDto dto);
        /// <summary>
        /// 更新设施摄像机
        /// </summary>
        /// <param name="dto">摄像机实体</param>
        /// <returns></returns>
        Task<bool> UpdateCamera(FacilityCameraDto dto);
        /// <summary>
        /// 根据设施编码获取设施摄像机
        /// </summary>
        /// <param name="facilityId">设施编码</param>
        /// <returns></returns>
        Task<IEnumerable<FacilityCameraDto>> GetFacilityCamerasByFacilityIdAsny(string facilityId);
        /// <summary>
        /// 根据设施编码获取设施摄像机
        /// </summary>
        /// <param name="facilityId">设施编码</param>
        /// <returns></returns>
        IEnumerable<FacilityCameraDto> GetFacilityCamerasByFacilityId(string facilityId);

        /// <summary>
        /// 检验编码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool CheckCode(string code);
    }
}
