using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
   public interface ICameraStationOnlineStatisticsService:IService<CameraStationOnlineStatisticsDto>
   {
        /// <summary>
        /// 添加实景监测点在线统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
       Task<bool> AddAsny(CameraStationOnlineStatisticsDto dto);
        /// <summary>
        /// 根据实景监测点编码和年月获取
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
       Task<IEnumerable<CameraStationOnlineStatisticsDto>> GetByCameraStationIdAndYearAndMonthAsny(string stationId,
           int year, int month);
   }
}
