using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Dto;
namespace AhnqIot.Bussiness.Interface
{
 public  interface IDeviceRunningStatisticsService : IService<DeviceRunningStatisticsDto>
    {
        /// <summary>
        /// 根据设备编码和时间获取设备运行统计
        /// </summary>
        /// <param name="deviceSerialnum">设备编码</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns></returns>
        Task<IEnumerable<DeviceRunningStatisticsDto>> GetStaticsByFarmSerialnumAndTimeAsny(string deviceSerialnum,int year, int month, int day);
        /// <summary>
        /// 添加设备运行统计数据
        /// </summary>
        /// <param name="dto">设备运行统计数据实体</param>
        /// <returns></returns>
        Task<bool> AddDeviceRunningStatisticsAsny(DeviceRunningStatisticsDto dto);
    }
}
