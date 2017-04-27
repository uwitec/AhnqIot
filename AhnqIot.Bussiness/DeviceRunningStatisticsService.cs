using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.Repository.AhnqIot;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AutoMapper;
using System.Linq.Expressions;
using AhnqIot.Bussiness.Core;

namespace AhnqIot.Bussiness
{
  public  class DeviceRunningStatisticsService:ServiceBase<DeviceRunningStatistics,DeviceRunningStatisticsDto>, IDeviceRunningStatisticsService
    {

        //private readonly IAhnqIotRepository<DeviceRunningStatistics> _deviceRunningStatisticsRep;
        public DeviceRunningStatisticsService(IAhnqIotRepository<DeviceRunningStatistics> deviceRunningStatisticsRep)
        {
            //_deviceRunningStatisticsRep = deviceRunningStatisticsRep;
        }
        /// <summary>
        /// 根据设备编码和时间获取设备运行统计
        /// </summary>
        /// <param name="deviceSerialnum">设备编码</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns></returns>
        public async  Task<IEnumerable<DeviceRunningStatisticsDto>> GetStaticsByFarmSerialnumAndTimeAsny(string deviceSerialnum, int year, int month, int day)
        {
            return GetDtoModels(await Repository.GetManyAsync(drs => drs.DeviceSerialnum.Equals(deviceSerialnum) && drs.Year.Equals(year) && drs.Month.Equals(month) && drs.Day.Equals(day)));
        }
        /// <summary>
        /// 添加设备运行统计数据
        /// </summary>
        /// <param name="dto">设备运行统计数据实体</param>
        /// <returns></returns>
      public async  Task<bool> AddDeviceRunningStatisticsAsny(DeviceRunningStatisticsDto dto)
        {
            var deviceRunningStatistics = GetDbModel(dto);
            Repository.Add(deviceRunningStatistics);
            return await Repository.CommitAsync() > 0;
        }

    }
}
