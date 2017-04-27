#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： StatisticsProcessor.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-29 17:26
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using System;
using System.Linq;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using Autofac;
using Smart.Redis;
using SmartIot.API.ProcessorV2.Common;

namespace SmartIot.API.ProcessorV2.TaskManager.Collect
{
    /// <summary>
    /// 设备统计数据分析
    /// </summary>
    public class Statistics60Job : ITaskJob
    {
        private readonly IDeviceTimeSharingStatisticsService _deviceTimeSharingStatisticsService;
        private readonly RedisClient _redisClient;

        public Statistics60Job()
        {
            JobName = "60分钟分时数据整理";
            Period = 60*60;

            _redisClient = RedisClient.DefaultDB;
            _deviceTimeSharingStatisticsService =
                AhnqIotContainer.Container.Resolve<IDeviceTimeSharingStatisticsService>();
        }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// 定时间隔,单位:秒
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// 获取启动等待时间
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetWaitForSecondsAsync()
        {
            return 10;
        }

        public async Task ProcessAsync()
        {
            //取出所有的统计的HASH,只存储上一个时间段的数据
            var list = _redisClient.HashGetAll<DeviceTimeSharingStatisticsDto>(RedisKeyString.DeviceTimeSharingStatistics,
                RedisSerializeType.DataType);

            if (list == null || !list.Any()) return;

            var dtos =
                list.Select(e => e.Value as DeviceTimeSharingStatisticsDto)
                    .Where(
                        e =>
                            e.Serialnum.Contains("[60]") &&
                            DateTime.Now.Subtract(e.UpdateTime).TotalMinutes < e.TimeSharing);
            await _deviceTimeSharingStatisticsService.ProcessDeviceTimeSharingStatisticsAsync(dtos.ToList());
        }
    }
}