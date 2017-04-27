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
   public class CameraStationOnlineStatisticsService:ServiceBase<CameraStationOnlineStatistics,CameraStationOnlineStatisticsDto>, ICameraStationOnlineStatisticsService
    {
        //private readonly IAhnqIotRepository<CameraStationOnlineStatistics> _cameraStationOnlineStatisticsRep;

        public CameraStationOnlineStatisticsService(IAhnqIotRepository<CameraStationOnlineStatistics> cameraStationOnlineStatisticsRep)
        {
            //_cameraStationOnlineStatisticsRep = cameraStationOnlineStatisticsRep;
        }
        /// <summary>
        /// 添加实景监测点在线统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> AddAsny(CameraStationOnlineStatisticsDto dto)
       {
            var log = GetDbModel(dto);
            Repository.Add(log);
            return await Repository.CommitAsync() > 0;
        }

       /// <summary>
       /// 根据实景监测点编码和年月获取
       /// </summary>
       /// <param name="stationId"></param>
       /// <param name="year"></param>
       /// <param name="month"></param>
       /// <returns></returns>
     public async  Task<IEnumerable<CameraStationOnlineStatisticsDto>> GetByCameraStationIdAndYearAndMonthAsny(string stationId,
           int year, int month)
       {
           return
               GetDtoModels(
                   await
                       Repository.GetManyAsync(
                           statics =>
                               statics.CameraStationsSerialnum.Equals(stationId) && statics.Year.Equals(year) &&
                               statics.Month.Equals(month)));
       }
    }
}
