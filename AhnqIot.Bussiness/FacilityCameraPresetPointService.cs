using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Hxj.Repository.AhnqIot;
using AutoMapper;

namespace AhnqIot.Bussiness
{
  public  class FacilityCameraPresetPointService:ServiceBase<FacilityCameraPresetPoint,FacilityCameraPresetPointDto>, IFacilityCameraPresetPointService
    {
        /// <summary>
        /// 根据编码和预置点获取
        /// </summary>
        /// <param name="id">编码</param>
        /// <param name="point">预置点</param>
        /// <returns></returns>
        public async Task<FacilityCameraPresetPointDto> GetByPointAndIdAsny(string id, int point)
        {
            return GetDtoModel(await Repository.GetAsync(c => c.Serialnum.Equals(id) && c.PresetPoint.Equals(point)));
        }

        /// <summary>
        /// 根据编码和预置点获取
        /// </summary>
        /// <param name="id">编码</param>
        /// <param name="point">预置点</param>
        /// <returns></returns>
        public FacilityCameraPresetPointDto GetByPointAndId(string id, int point)
        {
            return GetDtoModel(Repository.Get(c => c.Serialnum.Equals(id) && c.PresetPoint.Equals(point)));
        }

        /// <summary>
        /// 根据摄像机编码获取预置点信息
        /// </summary>
        /// <param name="cameraId">设施摄像机编码</param>
        /// <returns></returns>
        public async Task<FacilityCameraPresetPointDto> GetByCameraIdAsny(string cameraId)
      {
          var dto = await Repository.GetAsync(p => p.FacilityCameraSerialnum.Equals(cameraId));
          return Mapper.Map<FacilityCameraPresetPointDto>(dto);
        }

        /// <summary>
        /// 根据摄像机编码获取预置点信息
        /// </summary>
        /// <param name="cameraId">设施摄像机编码</param>
        /// <returns></returns>
        public FacilityCameraPresetPointDto GetByCameraId(string cameraId)
        {
            var dto = Repository.Get(p => p.FacilityCameraSerialnum.Equals(cameraId));
            return Mapper.Map<FacilityCameraPresetPointDto>(dto);
        }
    }
}
