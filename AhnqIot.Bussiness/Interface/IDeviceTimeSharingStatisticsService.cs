using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;

namespace AhnqIot.Bussiness.Interface
{
 public  interface IDeviceTimeSharingStatisticsService:IService<DeviceTimeSharingStatisticsDto>
    {
        /// <summary>
        /// 根据设备编码，周期，起始时间和结束时间获取设备分时统计数据
        /// </summary>
        /// <param name="deviceId">设备编码</param>
        /// <param name="period">周期</param>
        /// <param name="begin">起始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        Task<IEnumerable<DeviceTimeSharingStatisticsDto>> GetDeviceTimeSharingStatisticsByArgsAsny(string deviceId, int period, DateTime begin, DateTime end);
        /// <summary>
        /// 添加设备分时统计数据
        /// </summary>
        /// <param name="dto">设备分时统计数据</param>
        /// <returns></returns>
        Task<bool> AddDeviceTimeSharingStatisticsAsny(DeviceTimeSharingStatisticsDto dto);

     Task<bool> ProcessDeviceTimeSharingStatisticsAsync(IEnumerable<DeviceTimeSharingStatisticsDto> dtos);
    }
}
