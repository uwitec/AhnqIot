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
   public class CameraStationRunLogService:ServiceBase<CameraStationRunLog, CameraStationRunLogDto> ,ICameraStationRunLogService
    {
       // private readonly IAhnqIotRepository<CameraStationRunLog> _cameraStationRunLogRep;

        public CameraStationRunLogService(IAhnqIotRepository<CameraStationRunLog> cameraStationRunLogRep)
        {
           // _cameraStationRunLogRep = cameraStationRunLogRep;
        }
        /// <summary>
        /// 添加实景监测点运行记录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> AddAsny(CameraStationRunLogDto dto)
       {
            var log = GetDbModel(dto);
            Repository.Add(log);
            return await Repository.CommitAsync() > 0;
        }
    }
}
