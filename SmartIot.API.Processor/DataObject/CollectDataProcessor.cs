#region Code File Comment

// SOLUTION   ： SmartIot - DeviceCode
// PROJECT    ： SmartIot.API.Processor
// FILENAME   ： CollectDataProcessor.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-28 8:54
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

#region using namespace

using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;
using Smart.Redis;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#endregion using namespace

namespace SmartIot.API.Processor.DataObject
{
    /// <summary>
    ///     采集数据处理器
    /// </summary>
    public class CollectDataProcessor
    {
        #region 构造

        static CollectDataProcessor()
        {
            _deviceRunLogTypeService = AhnqIotContainer.Container.Resolve<IDeviceRunLogTypeService>();
            _deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>();
            _facilityCameraService = AhnqIotContainer.Container.Resolve<IFacilityCameraService>();
            _deviceExceptionSetService = AhnqIotContainer.Container.Resolve<IDeviceExceptionSetService>();
            _deviceTypeService = AhnqIotContainer.Container.Resolve<IDeviceTypeService>(); ;
            _deviceRunLogService = AhnqIotContainer.Container.Resolve<IDeviceRunLogService>(); ;
            _deviceDataInfoService = AhnqIotContainer.Container.Resolve<IDeviceDataInfoService>(); ;
            _deviceDataExceptionLogService = AhnqIotContainer.Container.Resolve<IDeviceDataExceptionLogService>(); ;
            _facilityService = AhnqIotContainer.Container.Resolve<IFacilityService>(); ;
            _facilityProduceInfoService = AhnqIotContainer.Container.Resolve<IFacilityProduceInfoService>(); ;
            _agrProductObjectGrowthInfoService = AhnqIotContainer.Container.Resolve<IAgrProductObjectGrowthInfoService>(); ;
            _agrDiagnosticModelService = AhnqIotContainer.Container.Resolve<IAgrDiagnosticModelService>(); ;
            _agrDiagnosticInfoService = AhnqIotContainer.Container.Resolve<IAgrDiagnosticInfoService>(); ;
            _deviceTimeSharingStatisticsService = AhnqIotContainer.Container.Resolve<IDeviceTimeSharingStatisticsService>(); ;
            _deviceRunningStatisticsService = AhnqIotContainer.Container.Resolve<IDeviceRunningStatisticsService>(); ;
            _redis = new RedisClient();

            Task.Factory.StartNew(() => ProcessDeviceRunLog());
            Task.Factory.StartNew(() => ProcessDeviceDataInfo());
            Task.Factory.StartNew(() => ProcessDeviceDataExceptionLog());
            Task.Factory.StartNew(() => ProcessDiagnotics());
            Task.Factory.StartNew(() => ProcessStatistics());
            Task.Factory.StartNew(() => DeviceRunningStatistics());
        }

        #endregion 构造

        #region 字段

        private static readonly ConcurrentQueue<DeviceDto> _deviceRunLogQueue = new ConcurrentQueue<DeviceDto>();
        private static readonly ConcurrentQueue<DeviceDto> _dataInfoQueue = new ConcurrentQueue<DeviceDto>();
        private static readonly ConcurrentQueue<DeviceDto> _deviceDataExceptionLogQueue = new ConcurrentQueue<DeviceDto>();
        private static readonly ConcurrentQueue<DeviceDto> _processDiagnoticsQueue = new ConcurrentQueue<DeviceDto>();
        private static readonly ConcurrentQueue<DeviceDto> _processStatisticsQueue = new ConcurrentQueue<DeviceDto>();
        private static readonly ConcurrentQueue<DeviceDto> _deviceRunningStatisticsQueue = new ConcurrentQueue<DeviceDto>();
        private static IEnumerable<DeviceRunLogTypeDto> _deviceRunLogTypes;

        private static IDeviceRunLogTypeService _deviceRunLogTypeService;
        private static IDeviceService _deviceService;
        private static IFacilityCameraService _facilityCameraService;
        private static IDeviceExceptionSetService _deviceExceptionSetService;
        private static IDeviceTypeService _deviceTypeService;
        private static IDeviceRunLogService _deviceRunLogService;
        private static IDeviceDataInfoService _deviceDataInfoService;
        private static IDeviceDataExceptionLogService _deviceDataExceptionLogService;
        private static IFacilityService _facilityService;
        private static IFacilityProduceInfoService _facilityProduceInfoService;
        private static IAgrProductObjectGrowthInfoService _agrProductObjectGrowthInfoService;
        private static IAgrDiagnosticModelService _agrDiagnosticModelService;
        private static IAgrDiagnosticInfoService _agrDiagnosticInfoService;
        private static IDeviceTimeSharingStatisticsService _deviceTimeSharingStatisticsService;
        private static IDeviceRunningStatisticsService _deviceRunningStatisticsService;
        private static RedisClient _redis;

        #endregion 字段

        #region 业务

        #region 处理多媒体数据

        /// <summary>
        ///  处理多媒体数据
        /// </summary>
        /// <param name="mediaDatas"></param>
        public static XResponseMessage ProcessMediaData(IEnumerable<MediaData> mediaDatas)
        {
            if (mediaDatas == null) throw new ArgumentNullException("mediaDatas");

            var enumerable = mediaDatas as MediaData[] ?? mediaDatas.ToArray();
            if (enumerable.Any())
            {
                enumerable.ForEach(async m => { await AddCamera(m); });
            }

            return null;
        }

        #endregion 处理多媒体数据

        #region 处理图片数据

        /// <summary>
        ///     处理图片数据
        /// </summary>
        /// <param name="pictureDatas"></param>
        public static XResponseMessage ProcessPictureData(IEnumerable<PictureData> pictureDatas)
        {
            if (pictureDatas == null) throw new ArgumentNullException("pictureDatas");

            return null;
        }

        #endregion 处理图片数据

        #region 添加摄像机

        /// <summary>
        /// 添加摄像机
        /// </summary>
        /// <param name="mediaData"></param>
        public static async Task AddCamera(MediaData mediaData)
        {
            var camera = _redis.Smember<FacilityCameraDto>("facilityCamera", DataType.Protobuf).Find(c => c.Serialnum.EqualIgnoreCase(mediaData.DeviceCode));
            var camDb = camera != null ? camera : await _facilityCameraService.GetFacilityCameraByIdAsny(mediaData.DeviceCode);
            //FacilityCamera.FindAllWithCache().ToList().FirstOrDefault(c => c.Serialnum.Equals(mediaData.DeviceCode));
            if (camDb == null)
            {
                camDb = new FacilityCameraDto
                {
                    Serialnum = mediaData.DeviceCode,
                    Name = mediaData.DeviceName,
                    FacilitySerialnum = mediaData.FacilityCode,
                    IP = mediaData.Url,
                    HttpPort = mediaData.MediaPort,
                    DataPort = mediaData.ContrPort,
                    UserID = mediaData.User,
                    UserPwd = mediaData.Pwd,
                    Channel = mediaData.Channel
                };
                //await _facilityCameraService.AddFacilityCamera(camDb);
                ServiceLogger.Current.WriteDebugLog("添加设施摄像机 {0} {1}", camDb.FacilitySerialnum, camDb.IP);
            }
            else
            {
                camDb.Name = mediaData.DeviceName;
                camDb.FacilitySerialnum = mediaData.FacilityCode;
                camDb.IP = mediaData.Url;
                camDb.HttpPort = mediaData.MediaPort;
                camDb.DataPort = mediaData.ContrPort;
                camDb.UserID = mediaData.User;
                camDb.UserPwd = mediaData.Pwd;
                camDb.Channel = mediaData.Channel;
                //await _facilityCameraService.UpdateCamera(camDb);
                ServiceLogger.Current.WriteDebugLog("更新设施摄像机 {0} {1}", camDb.FacilitySerialnum, camDb.IP);
            }
            _redis.Sadd("facilityCamera", camDb, DataType.Protobuf);//加入到缓存中去
        }

        #endregion 添加摄像机

        #region 处理传感器采集数据

        /// <summary>
        /// 处理传感器采集数据
        /// </summary>
        /// <param name="sensorDatas"></param>
        public static XResponseMessage ProcessSensorData(IEnumerable<SensorData> sensorDatas)
        {
            if (sensorDatas == null) throw new ArgumentNullException("sensorDatas");

            var enumerable = sensorDatas as SensorData[] ?? sensorDatas.ToArray();
            if (enumerable.Any())
            {
                //首先检查是否有不在Redis缓存中的设备
                //  enumerable.Where(sd =>
                //       _redis.GetVals<DeviceDto>("device", DataType.Protobuf).Where(device =>
                //            device.Serialnum.EqualIgnoreCase(sd.DeviceCode)
                //           });
                //);
                //检查是否有不在数据库中的设备
                var deviceNotInDb = enumerable.Where(sd => _deviceService.GetDeviceByIdAsny(sd.DeviceCode) == null);
                var notInDb = deviceNotInDb as IList<SensorData> ?? deviceNotInDb.ToList();
                if (notInDb.Any())
                {
                    return ResultHelper.CreateMessage(notInDb.Select(sd => sd.DeviceCode).Join(","), ErrorType.DeviceNotExists);
                }
                enumerable.ForEach(async sd =>
                {
                    var device = _redis.Smember<DeviceDto>("device", DataType.Protobuf).Find(d => d.Serialnum.EqualIgnoreCase(sd.DeviceCode));
                    DeviceDto dev = device != null ? device : await _deviceService.GetDeviceByIdAsny(sd.DeviceCode);
                    dev.Remark = sd.BatchNum;
                    if (dev != null)
                    {
                        if (device == null)
                        {
                            _redis.Sadd("device", dev, DataType.Protobuf);//加入到缓存中去
                        }
                        //更新设备实时数据
                        ProcessDevice(sd.Value, sd.ShowValue, sd.Time);

                        //  数据分析、统计、存储

                        //实时数据处理
                        //dev.ProcessDeviceDataInfo();
                        _dataInfoQueue.Enqueue(dev);

                        //添加数据异常记录
                        //dev.ProcessDeviceDataExceptionLog();
                        _deviceDataExceptionLogQueue.Enqueue(dev);

                        //添加设备运行记录
                        _deviceRunLogQueue.Enqueue(dev);

                        //诊断信息
                        //dev.ProcessDiagnotics();
                        //_processDiagnoticsQueue.Enqueue(dev);

                        //分时数据处理
                        //dev.ProcessStatistics(15);
                        //dev.ProcessStatistics(60);
                        _processStatisticsQueue.Enqueue(dev);

                        //设备统计
                        _deviceRunningStatisticsQueue.Enqueue(dev);
                    }
                });
            }
            return ResultHelper.CreateMessage("无传感器数据需要处理", ErrorType.NoError);
        }

        //private static void InitProcess()
        //{
        //    ProcessDeviceRunLog();
        //    ProcessDeviceDataInfo();
        //    ProcessDeviceDataExceptionLog();
        //    ProcessDiagnotics();
        //    ProcessStatistics();
        //    DeviceRunningStatistics();
        //}

        /// <summary>
        ///     处理设备运行日志
        /// </summary>
        private static async Task ProcessDeviceRunLog()
        {
            while (true)
            {
                Thread.Sleep(10 * 1000);
                if (!_deviceRunLogQueue.IsEmpty)
                {
                    try
                    {
                        _deviceRunLogTypes = await _deviceRunLogTypeService.GetDeviceRunLogTypesAsny();//获取所有设备运行日志类型
                        var list = _deviceRunLogQueue.ToArray();

                        var logs = list.Select(e => new DeviceRunLogDto
                        {
                            DeviceSerialnum = e.Serialnum,
                            DeviceRunLogTypeSerialnum =
                              _deviceRunLogTypes.FirstOrDefault(d => d.Name == "正常").Serialnum
                        });
                        logs.ForEach(log =>
                        {
                            // await _deviceRunLogService.AddDeviceRunLog(log);
                        });//保存log
                        _redis.Sadd("deviceRunLog", logs.ToList(), DataType.Protobuf);
                        //清除刚取出来的数据
                        // ReSharper disable once TooWideLocalVariableScope
                        DeviceDto entityDevice = null;
                        for (var i = 0; i < list.Length; i++)
                        {
                            _deviceRunLogQueue.TryDequeue(out entityDevice);
                        }
                    }
                    catch (Exception ex)
                    {
                        ServiceLogger.Current.WriteException(ex);
                    }
                }
            }
        }

        /// <summary>
        ///     处理设备历史数据
        /// </summary>
        private static async Task ProcessDeviceDataInfo()
        {
            while (true)
            {
                Thread.Sleep(10 * 1000);
                if (!_dataInfoQueue.IsEmpty)
                {
                    try
                    {
                        var list = _dataInfoQueue.ToArray();

                        var logs = list.Select(e =>
                            {
                                var cdi = new DeviceDataInfoDto
                                {
                                    DeviceSerialnum = e.Serialnum,
                                    ProcessedValue = e.ProcessedValue,
                                    CreateTime = e.UpdateTime,
                                    UpdateTime = e.UpdateTime,
                                    Remark = e.Remark
                                };
                                var set = _deviceExceptionSetService.GetDeviceExceptionSetByDeviceId(e.Serialnum);//查找异常区间
                                if (set != null)
                                {
                                    cdi.IsException = e.ProcessedValue > set.Max || e.ProcessedValue < set.Min;
                                    if (cdi.IsException)
                                    {
                                        cdi.Max = set.Max;
                                        cdi.Min = set.Min;
                                        cdi.CreateTime = cdi.UpdateTime = e.UpdateTime;
                                    }
                                }
                                return cdi;
                            });
                        await _deviceDataInfoService.AddDeviceDataInfo2(logs);//保存历史数据

                        //清除刚取出来的数据
                        DeviceDto entityDevice = null;
                        for (var i = 0; i < list.Length; i++)
                        {
                            _dataInfoQueue.TryDequeue(out entityDevice);
                        }
                    }
                    catch (Exception ex)
                    {
                        ServiceLogger.Current.WriteException(ex);
                    }
                }
            }
        }

        /// <summary>
        ///     处理设备异常数据
        /// </summary>
        private static async Task ProcessDeviceDataExceptionLog()
        {
            while (true)
            {
                Thread.Sleep(10 * 1000);
                if (!_deviceDataExceptionLogQueue.IsEmpty)
                {
                    try
                    {
                        var list = _deviceDataExceptionLogQueue.ToArray();

                        var logs = list.Select(e =>
                        {
                            var dataExceptionLog = new DeviceDataExceptionLogDto
                            {
                                DeviceSerialnum = e.Serialnum,
                                Value = e.ProcessedValue,
                                CreateTime = DateTime.Now
                            };
                            var set = _deviceExceptionSetService.GetDeviceExceptionSetByDeviceId(e.Serialnum);//查找异常区间
                            if (set != null)
                            {
                                dataExceptionLog.Status = e.ProcessedValue > set.Max ? 1 : -1;
                                dataExceptionLog.Max = set.Max;
                                dataExceptionLog.Min = set.Min;
                            }
                            return dataExceptionLog;
                        });
                        if (logs.Any())
                        {
                            foreach (var log in logs)
                            {
                                var result = await _deviceDataExceptionLogService.AddDeviceDataExceptionLog(log);//添加设备异常日志
                                if (!result) LogHelper.Debug("添加设备异常日志失败,编码：{0}", log.Serialnum);
                            }
                        }

                        //清除刚取出来的数据
                        DeviceDto entityDevice = null;
                        for (var i = 0; i < list.Length; i++)
                        {
                            _deviceDataExceptionLogQueue.TryDequeue(out entityDevice);
                        }
                    }
                    catch (Exception ex)
                    {
                        ServiceLogger.Current.WriteException(ex);
                    }
                }
            }
        }

        /// <summary>
        /// 处理诊断数据
        /// </summary>
        private static async Task ProcessDiagnotics()
        {
            DeviceDto dev = null;

            while (true)
            {
                Thread.Sleep(10);
                if (!_processDiagnoticsQueue.IsEmpty && _processDiagnoticsQueue.TryDequeue(out dev))
                {
                    try
                    {
                        await ProcessDiagnotics(dev);
                    }
                    catch (Exception ex)
                    {
                        ServiceLogger.Current.WriteException(ex);
                    }
                }
            }
        }

        /// <summary>
        /// 处理设备统计数据：60分钟统计
        /// </summary>
        private static async Task ProcessStatistics()
        {
            DeviceDto dev = null;

            while (true)
            {
                Thread.Sleep(10);
                if (!_processStatisticsQueue.IsEmpty && _processStatisticsQueue.TryDequeue(out dev))
                {
                    try
                    {
                        await ProcessStatistics(dev, 60);
                    }
                    catch (Exception ex)
                    {
                        ServiceLogger.Current.WriteException(ex);
                    }
                }
            }
        }

        private static async Task DeviceRunningStatistics()
        {
            DeviceDto dev = null;

            while (true)
            {
                Thread.Sleep(10);
                if (!_deviceRunningStatisticsQueue.IsEmpty &&
                    _deviceRunningStatisticsQueue.TryDequeue(out dev))
                {
                    try
                    {
                        var f = _redis.Smember<FacilityDto>("facility", DataType.Protobuf).Find(fac => fac.Serialnum.EqualIgnoreCase(dev.FacilitySerialnum));//从缓存中查找设施
                        var facility = f != null ? f : await _facilityService.GetFacilityByIdAsny(dev.FacilitySerialnum);//获取设施
                        if (facility != null)
                        {
                            if (f == null)
                            {
                                _redis.Sadd("facility", facility, DataType.Protobuf);//放入到缓存中
                            }
                            var list =
                            await _deviceRunningStatisticsService.GetStaticsByFarmSerialnumAndTimeAsny(
                                 facility.FarmSerialnum,
                                 dev.UpdateTime.Year,
                                 dev.UpdateTime.Month,
                                 dev.UpdateTime.Day
                                 );

                            DeviceRunningStatisticsDto statistics = null;
                            if (list == null || list.Count() == 0)
                            {
                                statistics = new DeviceRunningStatisticsDto();
                                statistics.DeviceSerialnum = dev.Serialnum;
                                statistics.Year = dev.UpdateTime.Year;
                                statistics.Month = dev.UpdateTime.Month;
                                statistics.Day = dev.UpdateTime.Day;
                            }
                            else
                            {
                                statistics = list.ToList()[0];
                            }
                            //应收次数，此处不作处理
                            statistics.AllCount++;
                            statistics.ReceiveCount++;
                            statistics.ReceivePercent = Math.Round((statistics.ReceiveCount * 1M) / (statistics.AllCount * 1M), 1) * 100M;

                            var set = _deviceExceptionSetService.GetDeviceExceptionSetByDeviceId(dev.Serialnum);//查找异常区间
                            //var isException = false;
                            if (set != null)
                            {
                                if (dev.ProcessedValue > set.Max || dev.ProcessedValue < set.Min)
                                {
                                    statistics.DataExceptionCount++;
                                    statistics.DataExceptionPercent = Math.Round((statistics.DataExceptionCount * 1M) / (statistics.AllCount * 1M), 1) * 100M;
                                }
                            }
                            await _deviceRunningStatisticsService.AddDeviceRunningStatisticsAsny(statistics);
                        }
                    }
                    catch (Exception ex)
                    {
                        ServiceLogger.Current.WriteException(ex);
                    }
                }
            }
        }

        #endregion 处理传感器采集数据

        #endregion 业务

        #region 扩展业务

        /// <summary>
        /// 更新设备数据设备实时数据
        /// </summary>
        public static async void ProcessDevice(decimal value, string show, DateTime updateTime)
        {
            DeviceDto dto = new DeviceDto
            {
                ProcessedValue = value,
                ShowValue = show,
                UpdateTime = updateTime
            };
            //查询设备异常范围
            DeviceExceptionSetDto set = await _deviceExceptionSetService.GetDeviceExceptionSetByDeviceIdAsny(dto.Serialnum);
            var isException = false;
            if (set != null)
            {
                if (dto.ProcessedValue > set.Max || dto.ProcessedValue < set.Min)
                    isException = true;
            }
            var dType = _redis.Smember<DeviceTypeDto>("deviceType", DataType.Protobuf).Find(dt => dt.Serialnum.EqualIgnoreCase(dto.DeviceTypeSerialnum));
            var deviceType = dType != null ? dType : await _deviceTypeService.GetDeviceTypeByIdAsny(dto.DeviceTypeSerialnum);//根据设备类型编码获取设备类型
            if (dType == null && deviceType != null)
            {
                _redis.Sadd("deviceType", deviceType, DataType.Protobuf);//加入到redis缓存中去
            }

            // device show value
            if (dto.ShowValue.IsNullOrWhiteSpace() && dto.Serialnum.Contains("control"))
            {
                if (deviceType.ValueCount == 1)
                {
                    dto.ShowValue = dto.ProcessedValue + "";
                }
                if (deviceType.ValueCount == 2)
                {
                    if (dto.ProcessedValue == 1)
                        dto.ShowValue = "开";
                    else if (dto.ProcessedValue == 0)
                        dto.ShowValue = "关";
                }
                else if (deviceType.ValueCount == 3)
                {
                    if (dto.ProcessedValue == 0xFF00)
                        dto.ShowValue = "开";
                    else if (dto.ProcessedValue == 0)
                        dto.ShowValue = "停";
                    else if (dto.ProcessedValue == 0x00FF)
                        dto.ShowValue = "关";
                }
            }
            dto.OnlineStatus = true;
            dto.IsException = isException;
            DeviceDto dev = null;
            if(_redis.Exists("device")==1)
            {
                dev = _redis.Smember<DeviceDto>("device", DataType.Protobuf).Find(d => d.Serialnum.EqualIgnoreCase(dto.DeviceTypeSerialnum));
            }
            if(dev!=null) _redis.Srem("device", dev, DataType.Protobuf);
            _redis.Sadd("device", dto, DataType.Protobuf);//放入redis缓存
            //await _deviceService.UpdateDevice(dto);//更新设备
            LogHelper.Debug("更新设备数据 {0}:{1} {2} {3}", dto.Name, dto.ProcessedValue, dto.Unit, dto.UpdateTime);
        }

        /// <summary>
        /// 生成诊断信息（这个函数有点问题）
        /// </summary>
        /// <param name="dto">设备</param>
        public static async Task ProcessDiagnotics(DeviceDto dto)
        {
            //var diagModel1 =await _agrDiagnosticModelService.GetAgrDiagnosticModelByDevieTypeIdAsny(dto.DeviceTypeSerialnum);
            var f = _redis.Smember<FacilityDto>("facility", DataType.Protobuf).Find(fac => fac.Serialnum.EqualIgnoreCase(dto.FacilitySerialnum));
            var facility = f != null ? f : await _facilityService.GetFacilityByIdAsny(dto.FacilitySerialnum);
            if (facility != null)
            {
                if (f == null)
                {
                    _redis.Sadd("facility", facility, DataType.Protobuf);//加入到缓存中去
                }
                var facilityProduceInfos = await _facilityProduceInfoService.GetFacilityProduceInfoByFacilityId(facility.Serialnum);//获取设施农作物信息
                if (facilityProduceInfos != null && facilityProduceInfos.Count() > 0)
                {
                    var produceInfo = facilityProduceInfos.ToList()[0];
                    if (produceInfo != null)
                    {
                        var agrProductObjectGrowthInfo = await _agrProductObjectGrowthInfoService.GetAgrProductObjectGrowthInfoByAgrProductObjectSerialnum(produceInfo.AgrProductObjectSerialnum);//获取农作生长信息
                        var diagnosticModels = await _agrDiagnosticModelService.GetAgrDiagnosticModelByAgrProductObjectGrowthInfoIdAsny(agrProductObjectGrowthInfo.Serialnum);//获取诊断模型
                        if (diagnosticModels != null && diagnosticModels.Count() > 0)
                        {
                            foreach (var diagModel in diagnosticModels)
                            {
                                if (diagModel != null)
                                {
                                    var result = dto.ProcessedValue > diagModel.MaxValue || dto.ProcessedValue < diagModel.MinValue;//环境异常
                                    var exception = "";
                                    if (result) exception = "超出";
                                    exception = "在";
                                    //  生成诊断信息
                                    var info = new AgrDiagnosticInfoDto()
                                    {
                                        AgrDiagnosticModelSerialnum = diagModel.Serialnum,
                                        Info = string.Format("当前{0}的{1}环境参数{2}诊断适宜{3}-{4}范围，为{5}{6}",
                                        agrProductObjectGrowthInfo.Name, dto.Name, exception, diagModel.MinValue, diagModel.MaxValue, dto.ProcessedValue, dto.Unit)
                                    };
                                    await _agrDiagnosticInfoService.AddAgrDiagnosticInfoAsny(info);//保存
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 处理分时数据
        /// </summary>
        /// <param name="period">时间间隔</param>
        public static async Task ProcessStatistics(DeviceDto dev, int period = 15)
        {
            var deviceExceptionSet = await _deviceExceptionSetService.GetDeviceExceptionSetByDeviceIdAsny(dev.Serialnum);
            var timeRange = GetTimeRange(dev.UpdateTime, period);
            var timeSharingDatas = await _deviceTimeSharingStatisticsService.GetDeviceTimeSharingStatisticsByArgsAsny(dev.Serialnum, period, timeRange.Item1, timeRange.Item2);//获取设备分时统计数据

            DeviceTimeSharingStatisticsDto statistics;
            if (timeSharingDatas == null || timeSharingDatas.Count() == 0)
            {
                statistics = new DeviceTimeSharingStatisticsDto
                {
                    DeviceSerialnum = dev.Serialnum,
                    TimeSharing = period,
                    Count = 1,
                    StartValue = dev.ProcessedValue,
                    EndValue = dev.ProcessedValue,
                    MaxValue = dev.ProcessedValue,
                    MinValue = dev.ProcessedValue,
                    AvgValue = dev.ProcessedValue,
                    CreateTime = dev.UpdateTime,
                    UpdateTime = dev.UpdateTime
                };

                if (deviceExceptionSet != null)
                {
                    if (dev.ProcessedValue > deviceExceptionSet.Max || dev.ProcessedValue < deviceExceptionSet.Min)
                        statistics.ExceptionCount = 1;
                }
            }
            else
            {
                statistics = timeSharingDatas.ToList()[timeSharingDatas.Count() - 1];
                statistics.Count++;
                statistics.EndValue = dev.ProcessedValue;
                if (dev.ProcessedValue > statistics.MaxValue)
                    statistics.MaxValue = dev.ProcessedValue;
                if (dev.ProcessedValue < statistics.MinValue)
                    statistics.MinValue = dev.ProcessedValue;
                statistics.AvgValue = (statistics.AvgValue + dev.ProcessedValue) / 2;
                statistics.UpdateTime = dev.UpdateTime;

                if (deviceExceptionSet != null)
                {
                    if (dev.ProcessedValue > deviceExceptionSet.Max || dev.ProcessedValue < deviceExceptionSet.Min)
                        statistics.ExceptionCount++;
                }
            }

            await _deviceTimeSharingStatisticsService.AddDeviceTimeSharingStatisticsAsny(statistics);//保存
        }

        /// <summary>
        /// 获取时间间隔的开始时间和结束时间
        /// </summary>
        /// <param name="dt">时间</param>
        /// <param name="period">时间间隔</param>
        /// <returns></returns>
        public static Tuple<DateTime, DateTime> GetTimeRange(DateTime dt, int period = 15)
        {
            var today = new DateTime(dt.Year, dt.Month, dt.Day);
            var span = dt.Subtract(today);
            var count = Convert.ToInt32(Math.Floor(span.TotalMinutes / period));
            var begin = today.AddMinutes(count * period);
            var end = today.AddMinutes((count + 1) * period).AddMilliseconds(-1);

            return new Tuple<DateTime, DateTime>(begin, end);
        }

        #endregion 扩展业务
    }
}