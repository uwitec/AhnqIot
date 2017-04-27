using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
 public  interface IFacilityCameraPresetPointService:IService<FacilityCameraPresetPointDto>
    {
        /// <summary>
        /// 根据编码和预置点获取
        /// </summary>
        /// <param name="id">编码</param>
        /// <param name="point">预置点</param>
        /// <returns></returns>
        Task<FacilityCameraPresetPointDto> GetByPointAndIdAsny(string id, int point);
        /// <summary>
        /// 根据编码和预置点获取
        /// </summary>
        /// <param name="id">编码</param>
        /// <param name="point">预置点</param>
        /// <returns></returns>
        FacilityCameraPresetPointDto GetByPointAndId(string id, int point);
        
        /// <summary>
        /// 根据摄像机编码获取预置点信息
        /// </summary>
        /// <param name="cameraId">设施摄像机编码</param>
        /// <returns></returns>
        Task<FacilityCameraPresetPointDto>GetByCameraIdAsny(string cameraId);
        /// <summary>
        /// 根据摄像机编码获取预置点信息
        /// </summary>
        /// <param name="cameraId">设施摄像机编码</param>
        /// <returns></returns>
        FacilityCameraPresetPointDto GetByCameraId(string cameraId);
    }
}
