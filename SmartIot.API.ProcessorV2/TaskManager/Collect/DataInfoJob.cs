#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： DataInfoJob.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-29 14:36
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

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

#endregion

namespace SmartIot.API.ProcessorV2.TaskManager.Collect
{
    /// <summary>
    /// 设备历史记录处理
    /// </summary>
    public class DataInfoJob : ITaskJob
    {
        private readonly IDeviceDataInfoService _deviceDataInfoService;
        private readonly IDeviceExceptionSetService _deviceExceptionSetService;
        private readonly RedisClient _redisClient;


        public DataInfoJob()
        {
            JobName = "设备历史记录处理";
            Period = 60;

            _redisClient = RedisClient.DefaultDB;
            _deviceDataInfoService = AhnqIotContainer.Container.Resolve<IDeviceDataInfoService>();
            _deviceExceptionSetService = AhnqIotContainer.Container.Resolve<IDeviceExceptionSetService>();
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
            return await Task.FromResult<int>(10);
        }


        public async Task ProcessAsync()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                var dtos = GetDatainfoDto();
                if (dtos == null || !dtos.Any() || dtos.Count == 0) return;
                //复制一份，在从redis中删除时使用
                var ms = new MemoryStream();
                Serializer.Serialize(ms, dtos);
                ms.Position = 0;
                var cloneDtos =
                    Serializer.Deserialize<List<DeviceDataInfoDto>>(ms);
                ms.Dispose();

                //dto.IsException = false;
                dtos = ProcessDtoIsException(dtos).ToList();
                var result = await _deviceDataInfoService.AddDeviceDataInfos(dtos);
                if (result)
                {
                    cloneDtos.ForEach(
                        cloneDto =>
                        {
                            var i = _redisClient.Srem(RedisKeyString.DataInfoList, cloneDto, RedisSerializeType.DataType);
                        });

                    cloneDtos = null;
                }
                await ProcessExceptionLog(dtos);
                dtos.Clear();
            }
            catch (Exception ex)
            {
                throw;
            }
            sw.Stop();
            Console.WriteLine("历史记录处理时间花费：{0}ms", sw.ElapsedMilliseconds);
        }

        public List<DeviceDataInfoDto> GetDatainfoDto()
        {
            try
            {
                return _redisClient.Smember<DeviceDataInfoDto>(RedisKeyString.DataInfoList, RedisSerializeType.DataType);
            }
            catch (Exception ex)
            {
                throw;
            }
            //return RedisClient.LPop<DeviceDataInfoDto>(RedisKeyString.DataInfoList, RedisSerializeType.DataType);
        }

        /// <summary>
        ///     分析设备是否处理异常状态
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        private IEnumerable<DeviceDataInfoDto> ProcessDtoIsException(List<DeviceDataInfoDto> dtos)
        {
            var deviceDataInfos = new List<DeviceDataInfoDto>();
            dtos.ForEach(dto =>
            {
                var set = _deviceExceptionSetService.GetDeviceExceptionSetByDeviceId(dto.DeviceSerialnum);
                if (set != null)
                {
                    dto.Max = set.Max;
                    dto.Min = set.Min;
                    if (dto.ProcessedValue > set.Max || dto.ProcessedValue < set.Min)
                        dto.IsException = true;
                }
                deviceDataInfos.Add(dto);
            });
            return deviceDataInfos;
        }

        /// <summary>
        ///     增加异常记录
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        private async Task ProcessExceptionLog(List<DeviceDataInfoDto> dtos)
        {
            var logs = new List<DeviceDataExceptionLogDto>();
            if (dtos.Count == 0 || !dtos.Any()) return;
            dtos.ForEach(dto =>
            {
                if (!dto.IsException) return;
                var log = new DeviceDataExceptionLogDto
                {

                    Serialnum = Guid.NewGuid().ToString(),

                    DeviceSerialnum = dto.DeviceSerialnum,
                    Value = dto.ProcessedValue,
                    Max = dto.Max,
                    Min = dto.Min,
                    Sort = 0,
                    CreateTime = dto.UpdateTime,
                    UpdateTime = DateTime.Now
                };
                if (log.Value > log.Max)
                    log.Status = 1;
                else if (log.Value < log.Min)
                    log.Status = -1;
                else log.Status = 0;
                logs.Add(log);
            });
            try
            {
                if (logs.Any() && logs.Count > 0)
                {
                    await
                        Task.Factory.StartNew(
                            () =>
                                _redisClient.Sadd(RedisKeyString.DeviceDataExceptionLog, logs,
                                    RedisSerializeType.DataType));
                }
            }

            catch (Exception ex)
            {
                throw;
            }
        }
    }
}