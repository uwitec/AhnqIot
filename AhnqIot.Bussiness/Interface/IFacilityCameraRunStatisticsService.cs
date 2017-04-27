using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
   public interface IFacilityCameraRunStatisticsService:IService<FacilityCameraRunStatisticsDto>
    {
        /// <summary>
        /// 添加设施摄像机运行统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> AddAsny(FacilityCameraRunStatisticsDto dto);
        /// <summary>
        /// 添加设施摄像机运行统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool Add(FacilityCameraRunStatisticsDto dto);
        /// <summary>
        /// 更新设施摄像机运行统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool Update(FacilityCameraRunStatisticsDto dto);
        /// <summary>
        /// 根据设施摄像机编码和年月获取
        /// </summary>
        /// <param name="facilityCameraId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        Task<IEnumerable<FacilityCameraRunStatisticsDto>> GetByFacilityCameraIdAndYearAndMonthAsny(string facilityCameraId,
            int year, int month);
        /// <summary>
        /// 根据设施摄像机编码和年月获取
        /// </summary>
        /// <param name="facilityCameraId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        IEnumerable<FacilityCameraRunStatisticsDto> GetByFacilityCameraIdAndYearAndMonth(string facilityCameraId,
            int year, int month);
    }
}
