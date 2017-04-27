#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： DeviceTimeSharingStatisticsService.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-28 11:19
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Hxj.Repository.AhnqIot;
using AutoMapper;
using System.Linq;
using System.Collections;
using AhnqIot.Bussiness.Core;

#endregion

namespace AhnqIot.Bussiness
{
    public class DeviceTimeSharingStatisticsService :ServiceBase<DeviceTimeSharingStatistics,DeviceTimeSharingStatisticsDto>, IDeviceTimeSharingStatisticsService
    {
        //private readonly IAhnqIotRepository<DeviceTimeSharingStatistics> _deviceTimeSharingStatisticsRep;

        public DeviceTimeSharingStatisticsService(
            IAhnqIotRepository<DeviceTimeSharingStatistics> deviceTimeSharingStatisticsRep)
        {
            //_deviceTimeSharingStatisticsRep = deviceTimeSharingStatisticsRep;
        }

        /// 根据设备编码，周期，起始时间和结束时间获取设备分时统计数据
        /// </summary>
        /// <param name="deviceId">设备编码</param>
        /// <param name="period">周期</param>
        /// <param name="begin">起始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        public async Task<IEnumerable<DeviceTimeSharingStatisticsDto>> GetDeviceTimeSharingStatisticsByArgsAsny(
            string deviceId, int period, DateTime begin, DateTime end)
        {
            return
                GetDtoModels(
                    await Repository.GetManyAsync
                        (dts => dts.DeviceSerialnum.Equals(deviceId) && dts.TimeSharing.Equals(period) &&
                                begin <= dts.UpdateTime && end >= dts.UpdateTime));
        }

        /// <summary>
        ///     添加设备分时统计数据
        /// </summary>
        /// <param name="dto">设备分时统计数据</param>
        /// <returns></returns>
        public async Task<bool> AddDeviceTimeSharingStatisticsAsny(DeviceTimeSharingStatisticsDto dto)
        {
            var deviceTimeSharingStatistics = GetDbModel(dto);
            Repository.Add(deviceTimeSharingStatistics);
            return await Repository.CommitAsync() > 0;
        }

        /// <summary>
        ///     处理设备的分时统计数据
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public async Task<bool> ProcessDeviceTimeSharingStatisticsAsync(IEnumerable<DeviceTimeSharingStatisticsDto> dtos)
        {
            try
            {
                //var dto = AutoMapperExtension.MapTo<DeviceTimeSharingStatistics>(dtos);
                var list = GetDbModels(dtos);
                if (list.Any())
                {
                    list.ToList().ForEach(e =>
                   {
                       Repository.Add(e);
                   });
                    return await Repository.CommitAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {

                return false;
            }

        }


    }

    /// <summary>
    /// AutoMapper扩展方法
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        /// 集合对集合
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static List<TResult> MapTo<TResult>(this IEnumerable self)
        {
            if (self == null)
                throw new ArgumentNullException();
            Mapper.CreateMap(self.GetType(), typeof(TResult));
            return (List<TResult>)Mapper.Map(self, self.GetType(), typeof(List<TResult>));
        }

    }
}