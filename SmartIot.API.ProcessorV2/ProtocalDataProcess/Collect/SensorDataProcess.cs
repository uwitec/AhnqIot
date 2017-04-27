#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： SensorDataProcess.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-29 13:32
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;
using NewLife.Log;
using Smart.Redis;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest;
using SmartIot.API.ProcessorV2.Common;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Collect.InnerProcess;

#endregion

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Collect
{
    public class SensorDataProcess
    {
        private readonly IDeviceService _deviceService;
        private readonly RedisClient _redisClient;

        public SensorDataProcess()
        {
            _redisClient = RedisClient.DefaultDB;
            _deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>();
        }

        public async Task<XResponseMessage> ProcessAsync(IEnumerable<SensorData> mdList)
        {
            if (mdList == null || !mdList.Any()) return ResultHelper.CreateMessage("设备数据为空", ErrorType.NoContent);
            var sensorDatas = mdList.Where(md => md != null);
            var result = true;
            //并行处理
            //Parallel.ForEach(sensorDatas, async sensorData =>
            //{
            var flg = await ProcessAsync1(sensorDatas);
            if (!flg)
                result = false;
            //});

            return ResultHelper.CreateMessage("上传设备数据", result ? ErrorType.NoError : ErrorType.InternalError);
        }

        public async Task<bool> ProcessAsync1(IEnumerable<SensorData> sds)
        {
            if (sds == null || !sds.Any()) return true;
            //更新Device数据
            // var result = await UpdateDeviceAsync(sds);
            //if (!result)
            //    return false;

            //添加DataInfo信息到Redis中
            //数据异常(用户设置上下限)分析:此过程放置到DataInfo中处理
            try
            {
#if DEBUG
                var codeTimer = CodeTimer.Time(1, async times =>
                 {
#endif
                    await InsertDataInfoIntoRedis(sds);
#if DEBUG
                });
                LogHelper.Trace($"await InsertDataInfoIntoRedis耗时{codeTimer.Elapsed.TotalMilliseconds}ms");
#endif
            }
            catch (AggregateException ex)
            {
                ex.InnerExceptions.ToList().ForEach(e =>
                {
                    LogHelper.Error("添加DataInfo信息到Redis出错：{0}", e.Message);
                    LogHelper.Fatal(e.ToString());
                });
                return false;
            }

            //todo 诊断模型分析

            //设备数据分时统计
            try
            {
#if DEBUG
                var codeTimer = CodeTimer.Time(1, times =>
                {
#endif
                    sds.ToList().ForEach(async sd => {
                        Debug.Assert(sd != null, "Sensor Data  is null"); await ProcessStatisticsAsync(sd); });
#if DEBUG
                });
                LogHelper.Trace($"await ProcessStatisticsAsync耗时{codeTimer.Elapsed.TotalMilliseconds}ms");
#endif
            }
            catch (AggregateException ex)
            {
                ex.InnerExceptions.ToList().ForEach(e =>
                {
                    LogHelper.Error("设备数据分时统计到redis出错：{0}", e.Message);
                    LogHelper.Fatal(e.ToString());
                });
                return false;
            }


            //添加设备运行记录
            try
            {
#if DEBUG
                var codeTimer = CodeTimer.Time(1, async times =>
                {
#endif
                    await InsertDeviceRunlogIntoRedis(sds);
#if DEBUG
                });
                LogHelper.Trace($"await InsertDeviceRunlogIntoRedis耗时{codeTimer.Elapsed.TotalMilliseconds}ms");
#endif
            }
            catch (AggregateException ex)
            {
                ex.InnerExceptions.ToList().ForEach(e =>
                {
                    LogHelper.Error("添加设备运行记录到redis出错：{0}", e.Message);
                    LogHelper.Fatal(e.ToString());
                });
                return false;
            }

            return true;
        }

        /// <summary>
        ///     将设备历史记录信息插入到Redis中
        /// </summary>
        /// <param name="sds"></param>
        private async Task<bool> InsertDataInfoIntoRedis(IEnumerable<SensorData> sds)
        {
            var dtos = new List<DeviceDataInfoDto>();
            sds.AsParallel().ToList().ForEach(sd =>
            {
                Debug.Assert(sd != null, "Sensor Data  is null");
                var dto = new DeviceDataInfoDto
                {
                    DeviceSerialnum = sd.DeviceCode,
                    ProcessedValue = sd.Value,
                    ShowValue = sd.ShowValue,
                    CreateTime = DateTime.Now,
                    UpdateTime = sd.Time,
                    Serialnum = Guid.NewGuid().ToString()
                };
                dtos.Add(dto);
            });
            return await Task.Factory.StartNew(() =>
                _redisClient.Sadd(RedisKeyString.DataInfoList, dtos, RedisSerializeType.DataType)) > 0;
        }

        /// <summary>
        ///     更新设备实时数据
        /// </summary>
        /// <param name="sds"></param>
        /// <returns></returns>
        private async Task<bool> UpdateDeviceAsync(IEnumerable<SensorData> sds)
        {
            var result = false;
            Parallel.ForEach(sds, async sd =>
            {
                var deviceSerialnum = sd.DeviceCode;
                var device = await _deviceService.GetDeviceByIdAsny(deviceSerialnum);
                if (device != null && sd.Time >= device.UpdateTime)
                {
                    device.ProcessedValue = sd.Value;
                    device.ShowValue = sd.ShowValue;
                    device.UpdateTime = sd.Time;

                    device.OnlineStatus = !(DateTime.Now.Subtract(sd.Time).TotalMinutes > 10);
                    result = await _deviceService.UpdateDevice(device);
                }
                else
                {
                    result = false;
                }
            });
            return result;
        }

        /// <summary>
        ///     将设备历史记录插入到Redis中,未设置类型信息
        /// </summary>
        /// <param name="sds"></param>
        /// <returns></returns>
        private async Task<bool> InsertDeviceRunlogIntoRedis(IEnumerable<SensorData> sds)
        {
            var runLogDtos = new List<DeviceRunLogDto>();
            Parallel.ForEach(sds, sd =>
            {
                Debug.Assert(sd != null, "Sensor Data  is null");
                var runLogDto = new DeviceRunLogDto
                {
                    Serialnum = Guid.NewGuid().ToString(),
                    DeviceSerialnum = sd.DeviceCode,
                    CreateTime = DateTime.Now,
                    UpdateTime = sd.Time
                };
                runLogDtos.Add(runLogDto);
            });

            return await
                Task.Factory.StartNew(
                    () => _redisClient.Sadd(RedisKeyString.DeviceRunLog, runLogDtos, RedisSerializeType.DataType) > 0);
        }

        #region 分时统计

        /// <summary>
        ///     分析设备的统计数据
        /// </summary>
        /// <param name="sd"></param>
        /// <returns></returns>
        private async Task<bool> ProcessStatisticsAsync(SensorData sd)
        {
            //处理15分钟数据
            var period = 15;
            try
            {
                await ProcessStatistics(sd, period);
            }
            catch (AggregateException ex)
            {
                ex.InnerExceptions.ToList().ForEach(e =>
                {
                    LogHelper.Error("处理15分钟统计数据到redis出错：{0}", e.Message);
                    LogHelper.Fatal(e.ToString());
                });
                return false;
            }

            //处理60分钟数据
            period = 60;
            try
            {
                await ProcessStatistics(sd, period);
            }
            catch (AggregateException ex)
            {
                ex.InnerExceptions.ToList().ForEach(e =>
                {
                    LogHelper.Error("处理60分钟统计数据到redis出错：{0}", e.Message);
                    LogHelper.Fatal(e.ToString());
                });
                return false;
            }

            return true;
        }

        /// <summary>
        ///     处理并计算统计数据
        /// </summary>
        /// <param name="sd"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        private async Task<bool> ProcessStatistics(SensorData sd, int period)
        {
            var key = StatisticsProcessor.GetStatisticsKey(sd.Time, period, sd.DeviceCode);
            var sts = _redisClient.HashGet<DeviceTimeSharingStatisticsDto>(RedisKeyString.DeviceTimeSharingStatistics,
                key, RedisSerializeType.DataType);
            if (sts == null)
            {
                sts = new DeviceTimeSharingStatisticsDto
                {
                    DeviceSerialnum = sd.DeviceCode,
                    Serialnum = key,
                    TimeSharing = period
                };
                sts.MaxValue = sts.MinValue = sts.StartValue = sts.EndValue = sts.AvgValue = sd.Value;
                sts.CreateTime = DateTime.Now;
            }
            else
            {
                if (sd.Value > sts.MaxValue)
                    sts.MaxValue = sd.Value;
                if (sd.Value < sts.MinValue)
                    sts.MinValue = sd.Value;

                sts.EndValue = sd.Value;
                sts.AvgValue = (sts.AvgValue + sd.Value) / 2;
            }
            sts.Count++;
            sts.UpdateTime = sd.Time;
            //取上下限
            var deviceExceptionSetService = AhnqIotContainer.Container.Resolve<IDeviceExceptionSetService>();
            var set = await deviceExceptionSetService.GetDeviceExceptionSetByDeviceIdAsny(sd.DeviceCode);
            if (set == null)
                return
                    _redisClient.HashSetFieldValue(RedisKeyString.DeviceTimeSharingStatistics, key, sts, RedisSerializeType.DataType) >
                    0;
            sts.Max = set.Max;
            sts.Min = set.Min;
            if (sd.Value > set.Max || sd.Value < set.Min)
            {
                sts.ExceptionCount++;
            }

            return
                _redisClient.HashSetFieldValue(RedisKeyString.DeviceTimeSharingStatistics, key, sts, RedisSerializeType.DataType) > 0;
        }

        #endregion
    }
}