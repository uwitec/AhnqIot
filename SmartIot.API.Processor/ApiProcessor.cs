using System;
using System.Diagnostics;
using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Formatter;
using SmartIot.Api.Protocal.Meta;
using NewLife.Log;
using System.Threading.Tasks;
using AhnqIot.Dto;
using Smart.Redis;
using AhnqIot.Infrastructure.DI;
using Autofac;
using AhnqIot.Bussiness.Interface;
using System.Collections.Generic;
using AhnqIot.Infrastructure.Common;
namespace SmartIot.API.Processor
{
    public class ApiProcessor
    {
        private static RedisClient _redis;
        private static IDeviceService _deviceService;
        private static IFacilityService _facilityService;
        static ApiProcessor()
        {
            _redis = new RedisClient();
            _facilityService = AhnqIotContainer.Container.Resolve<IFacilityService>();
            _deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>();
        }
        /// <summary>
        /// 农业物联网信息服务平台数据交换协议 处理
        /// </summary>
        /// <param name="str"></param>
        public static async Task<XResponseMessage> Process(string str)
        {
            if (str.IsNullOrWhiteSpace()) throw new ArgumentNullException("str");

            AwEntity obj;

            #region 反序列化为实体对象
            try
            {
                //obj = FormatterFactory.ProcessAsync(str).GetAwaiter().GetResult();
                obj = FormatterFactory.ProcessAsync(str);
            }
            catch (Exception ex)
            {
                ServiceLogger.Current.WriteError("反序列化失败," + str);
                return ResultHelper.CreateExceptionMessage(ex, "数据无法解析", ErrorType.NotSupportedProtocalType);
            }

            if (obj == null)
            {
                ServiceLogger.Current.WriteError("数据格式异常," + str);
                return ResultHelper.CreateMessage("数据格式异常", ErrorType.CanNotProcessRequestData);
            }
            #endregion

            #region 协议解析
            try
            {
                var awEntity = obj;
                //ServiceLogger.Current.WriteDebugLog("{0}", awEntity.Description);
                var result = await ProcessEntity(awEntity);
                //ServiceLogger.Current.WriteLine(result.ToString());
                return result ?? new XResponseMessage()
                {
                    Success = ErrorType.NoError
                };
                //return null;
            }
            catch (Exception ex)
            {
                //ServiceLogger.Current.WriteException(ex);
                ServiceLogger.Current.WriteException(ex);
                return ResultHelper.CreateMessage("协议解析错误", ErrorType.CanNotProcessRequestData, null, ex);
            }
            #endregion
        }

        /// <summary>
        /// 解析对象
        /// </summary>
        /// <param name="awEntity"></param>
        /// <returns></returns>
        private static async Task<XResponseMessage> ProcessEntity(AwEntity awEntity)
        {
#if DEBUG
            Stopwatch sw = new Stopwatch();
            sw.Start();
#endif
            var result = await AwEntityProcessor.Process(awEntity);
#if DEBUG
            sw.Stop();
            ServiceLogger.Current.WriteDebugLog("ProcessEntity:{0} \t{1} ms", awEntity.Description, sw.ElapsedMilliseconds);
#endif
            return result;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void WriteLog(string format, params object[] args)
        {
            //XTrace.WriteLine("[默认协议处理器]  " + format, args);
            ServiceLogger.Current.WriteLog(format, args);
        }

        /// <summary>
        /// 处理Redis缓存和操作DB
        /// </summary>
        public static void ProcessRedisCache()
        {
            ProcessDeviceCache();
            PorcessFacilityCache();
        }
        /// <summary>
        /// 处理设备缓存
        /// </summary>
        public static void ProcessDeviceCache()
        {
            if (_redis.Exists("device") == 1)
            {

                var deviceList = _redis.Smember<DeviceDto>("device", DataType.Protobuf);

                if (deviceList.Count > 0 && deviceList != null)
                {
                    deviceList.ForEach(async device =>
                    {
                        var result = await _deviceService.AddDevice(device);
                        if (result)
                        {
                            _redis.Srem("device", device, DataType.Protobuf);//操作完成后删除
                        }
                        ServiceLogger.Current.WriteDebugLog("设备：{0} 更新{1}", device.Serialnum, result);
                    });

                }

            }
        }
        /// <summary>
        /// 处理设施缓存
        /// </summary>
        public static void PorcessFacilityCache()
        {
            if (_redis.Exists("facility") == 1)
            {
                var facilityList = _redis.Smember<FacilityDto>("facility", DataType.Protobuf);
                if (facilityList.Count > 0 && facilityList != null)
                {
                    facilityList.ForEach(async facility =>
                    {
                        var result = await _facilityService.AddFacility(facility);
                        if (result)
                        {
                            _redis.Srem("facility", facility, DataType.Protobuf);//操作完成后删除
                        }
                        ServiceLogger.Current.WriteDebugLog("设施：{0} 更新{1}", facility.Serialnum, result);
                    });
                }
            }
        }
    }
}
