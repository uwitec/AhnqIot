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
    public class FacilityCameraRunStatisticsService :ServiceBase<FacilityCameraRunStatistics, FacilityCameraRunStatisticsDto> ,IFacilityCameraRunStatisticsService
    {
        //private readonly IAhnqIotRepository<FacilityCameraRunStatistics> _cameraRunStatisticsRep;

        public FacilityCameraRunStatisticsService(IAhnqIotRepository<FacilityCameraRunStatistics> cameraRunStatisticsRep)
        {
            //_cameraRunStatisticsRep = cameraRunStatisticsRep;
        }

        /// <summary>
        /// 添加设施摄像机运行统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> AddAsny(FacilityCameraRunStatisticsDto dto)
        {
            var log = GetDbModel(dto);
            Repository.Add(log);
            return await Repository.CommitAsync() > 0;
        }
        /// <summary>
        /// 添加设施摄像机运行统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool Add(FacilityCameraRunStatisticsDto dto)
        {
            var log = GetDbModel(dto);
            Repository.Add(log);
            return Repository.Commit() > 0;
        }

        /// <summary>
        /// 更新设施摄像机运行统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool Update(FacilityCameraRunStatisticsDto dto)
        {
            var log = GetDbModel(dto);
            Repository.Update(log);
            return Repository.Commit() > 0;
        }
        /// <summary>
        /// 根据设施摄像机编码和年月获取
        /// </summary>
        /// <param name="facilityCameraId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<IEnumerable<FacilityCameraRunStatisticsDto>> GetByFacilityCameraIdAndYearAndMonthAsny(string facilityCameraId,
           int year, int month)
        {
            return
             GetDtoModels(
                  await
                      Repository.GetManyAsync(
                          statics =>
                              statics.FacilityCameraSerialnum.Equals(facilityCameraId) && statics.Year.Equals(year) &&
                              statics.Month.Equals(month)));
        }
        /// <summary>
        /// 根据设施摄像机编码和年月获取
        /// </summary>
        /// <param name="facilityCameraId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public IEnumerable<FacilityCameraRunStatisticsDto> GetByFacilityCameraIdAndYearAndMonth(string facilityCameraId,
           int year, int month)
        {
            try
            {
                return
  GetDtoModels(
          Repository.GetMany(
              statics =>
                  statics.FacilityCameraSerialnum.Equals(facilityCameraId) && statics.Year.Equals(year) &&
                  statics.Month.Equals(month)));
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
