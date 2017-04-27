using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using Autofac;
using Smart.Redis;
using SmartIot.API.ProcessorV2.Common;
using RedisSerializeType = AhnqIot.Bussiness.Core.RedisSerializeType;

namespace SmartIot.API.ProcessorV2.TaskManager.Collect
{
    public class DeviceDataExceptionLogJob : ITaskJob
    {
        private readonly IDeviceDataExceptionLogService _deviceDataExceptionLogService;
        private readonly RedisClient _redisClient;

        public DeviceDataExceptionLogJob()
        {
            JobName = "设备数据异常记录";
            Period = 5*60;

            _redisClient = RedisClient.DefaultDB;
            _deviceDataExceptionLogService = AhnqIotContainer.Container.Resolve<IDeviceDataExceptionLogService>();
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
            return await Task.FromResult<int>(30);
        }

        public async Task ProcessAsync()
        {
            var logDtos = _redisClient.Smember<DeviceDataExceptionLogDto>(RedisKeyString.DeviceDataExceptionLog,
                RedisSerializeType.DataType);
            if (logDtos == null || !logDtos.Any()) return;

            var result = await _deviceDataExceptionLogService.AddDeviceDataExceptionLog(logDtos);
            if (result)
            {
                logDtos.ForEach(
                    log =>
                    {
                        _redisClient.Srem(RedisKeyString.DeviceDataExceptionLog, log, RedisSerializeType.DataType);
                    });
            }
        }
    }
}