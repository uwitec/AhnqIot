#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： DeviceRunLogJob.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-29 14:36
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using Autofac;
using ProtoBuf;
using Smart.Redis;
using SmartIot.API.ProcessorV2.Common;

namespace SmartIot.API.ProcessorV2.TaskManager.Collect
{
    public class DeviceRunLogJob : ITaskJob
    {
        private readonly IDeviceRunLogService _deviceRunLogService;
        private readonly RedisClient _redisClient;

        public DeviceRunLogJob()
        {
            JobName = "设备运行记录";
            Period = 5*60;

            _redisClient = RedisClient.DefaultDB;
            _deviceRunLogService = AhnqIotContainer.Container.Resolve<IDeviceRunLogService>();
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
            return await Task.FromResult<int>(60);
        }

        ///// <summary>
        ///// 日志类型
        ///// </summary>
        //internal enum LogTypeEnum
        //{
        //    正常 = 0,
        //    离线 = 1,
        //    故障 = 2
        //}

        public async Task ProcessAsync()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var logDtos = _redisClient.Smember<DeviceRunLogDto>(RedisKeyString.DeviceRunLog, RedisSerializeType.DataType);
            if (logDtos == null || !logDtos.Any()) return;
            //复制一份，在从redis中删除时使用
            var ms = new MemoryStream();
            Serializer.Serialize(ms, logDtos);
            ms.Position = 0;
            var cloneDtos =
                Serializer.Deserialize<List<DeviceRunLogDto>>(ms);
            ms.Dispose();
            var result = await _deviceRunLogService.ProcessDeviceRunLogAsync(logDtos);
            if (result)
            {
                cloneDtos.ForEach(
                    log => { var i = _redisClient.Srem(RedisKeyString.DeviceRunLog, log, RedisSerializeType.DataType); });
            }
            sw.Stop();
            Console.WriteLine("运行日志处理时间花费：{0}ms", sw.ElapsedMilliseconds);
        }
    }
}