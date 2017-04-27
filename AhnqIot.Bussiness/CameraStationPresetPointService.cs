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
 public  class CameraStationPresetPointService:ServiceBase<CameraStationPresetPoint, CameraStationPresetPointDto>, ICameraStationPresetPointService
    {
        //private readonly IAhnqIotRepository<CameraStationPresetPoint> Repository;

        public CameraStationPresetPointService(IAhnqIotRepository<CameraStationPresetPoint> cameraStationPresetPointRep)
        {
            //Repository = cameraStationPresetPointRep;
        }

     /// <summary>
     /// 根据编码和预置点获取
     /// </summary>
     /// <param name="id">编码</param>
     /// <param name="point">预置点</param>
     /// <returns></returns>
     public async Task<CameraStationPresetPointDto> GetByPointAndIdAsny(string id, int point)
     {
         return GetDtoModel(await Repository.GetAsync(c => c.Serialnum.Equals(id)&&c.PresetPoint.Equals(point)));
     }
        /// <summary>
        /// 增加预置点
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> AddAsny(CameraStationPresetPointDto dto)
        {
            var preset = GetDbModel(dto);
            Repository.Add(preset);
            return await Repository.CommitAsync() > 0;
        }
        /// <summary>
        /// 更新预置点信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsny(CameraStationPresetPointDto dto)
        {
            var preset = GetDbModel(dto);
            Repository.Update(preset);
            return await Repository.CommitAsync() > 0;
        }

    }
}
