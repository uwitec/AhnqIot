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
  public  class CameraStationPicsService :ServiceBase<CameraStationPics, CameraStationPicsDto> ,ICameraStationPicsService
    {
        //private readonly IAhnqIotRepository<CameraStationPics> _cameraStationPicsRep;

        public CameraStationPicsService(IAhnqIotRepository<CameraStationPics> cameraStationPicsRep)
        {
            //this._cameraStationPicsRep = cameraStationPicsRep;
        }
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> AddAsny(CameraStationPicsDto dto)
        {
            var pic = GetDbModel(dto);
            Repository.Add(pic);
            return await Repository.CommitAsync() > 0;
        }
    }
}
