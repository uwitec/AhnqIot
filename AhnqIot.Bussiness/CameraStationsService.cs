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
  public  class CameraStationsService: ServiceBase<CameraStations,CameraStationsDto>, ICameraStationsService
    {
        //private readonly IAhnqIotRepository<CameraStations> _cameraStationsRep;

      public CameraStationsService(IAhnqIotRepository<CameraStations> cameraStationsRep)
      {
            //_cameraStationsRep = cameraStationsRep;
      }
        /// <summary>
        /// 获取所有的实景检测点
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CameraStationsDto>> GetAllAsny()
      {
            return GetDtoModels(await Repository.GetAllAsync());
        }
    }
}
