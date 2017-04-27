#region Code File Comment

// SOLUTION   ： SmartIot - DeviceCode
// PROJECT    ： SmartIot.API.Processor
// FILENAME   ： ManageDataProcessor.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-28 23:08
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

#region using namespace

using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using Autofac;
using NewLife.Log;
using Smart.Redis;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ManageDataRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#endregion using namespace

namespace SmartIot.API.Processor.DataObject
{
    /// <summary>
    /// 数据管理
    /// </summary>
    public class ManageDataProcessor
    {
        #region 字段

        private static IFacilityCameraService _facilityCameraService;
        private static IDeviceService _deviceService;
        private static IDeviceExceptionSetService _deviceExceptionSetService;
        private static IFacilityService _facilityService;
        private static RedisClient _redis;

        #endregion 字段

        static ManageDataProcessor()
        {
            _facilityCameraService = AhnqIotContainer.Container.Resolve<IFacilityCameraService>();
            _deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>();
            _deviceExceptionSetService = AhnqIotContainer.Container.Resolve<IDeviceExceptionSetService>();
            _facilityService = AhnqIotContainer.Container.Resolve<IFacilityService>();
            _redis = new RedisClient();
        }

        /// <summary>
        ///     处理传感器采集数据
        /// </summary>
        /// <param name="facilityAddDatas"></param>
        public static async Task<XResponseMessage> ProcessFacilityAddData(IEnumerable<FacilityAddData> facilityAddDatas)
        {
            if (facilityAddDatas == null) throw new ArgumentNullException("facilityAddDatas");

            var result = new XResponseMessage();

            var addDatas = facilityAddDatas as IList<FacilityAddData> ?? facilityAddDatas.ToList();
            if (addDatas.Count > 0 && addDatas != null)
            {
                try
                {
                    addDatas.ForEach(async item =>
                    {
                        // 添加设施
                        var facilityDb = await AddFacility(item);

                        // 添加设备
                        await AddDevice(item, facilityDb);

                        // 添加摄像机
                        await AddCamera(item, facilityDb);
                    });
                }
                catch (Exception ex)
                {
                    return ResultHelper.CreateExceptionMessage(ex, "添加设施、设备、摄像机出错");
                }
            }
            return ResultHelper.CreateMessage("", ErrorType.NoError);
        }

        /// <summary>
        ///     添加摄像机
        /// </summary>
        /// <param name="item"></param>
        /// <param name="facilityDb"></param>
        public static async Task AddCamera(FacilityAddData item, FacilityDto facilityDb)
        {
            var cameras = item.Cameras;
            List<FacilityCameraDto> cameraList = null;
            if (_redis.Exists("facilityCamera") == 1)
            {
                cameraList = _redis.Smember<FacilityCameraDto>("facilityCamera", DataType.Protobuf);
            }
            var camerasDb = cameraList != null ? cameraList : await _facilityCameraService.GetFacilityCamerasByFacilityIdAsny(facilityDb.Serialnum);
            if (cameras != null && cameras.Any())
            {
                cameras.ForEach(async c =>
                {
                    await CollectDataProcessor.AddCamera(c);
                });
            }
        }

        /// <summary>
        ///     添加设备
        /// </summary>
        /// <param name="item"></param>
        /// <param name="facilityDb"></param>
        private static async Task AddDevice(FacilityAddData item, FacilityDto facilityDb)
        {
            TaskScheduler.UnobservedTaskException += (_, ev) => Console.WriteLine(ev.Exception);
            try
            {
                var devices = item.Devices;
                if (devices == null) return;
                devices.ForEach(async devModel =>
                {
                    if (devModel.FacilitySerialnum.EqualIgnoreCase(facilityDb.Serialnum))
                    {
                        DeviceDto dev = null;
                        if (_redis.Exists("device") == 1)
                        {
                            dev = _redis.Smember<DeviceDto>("device", DataType.Protobuf).Find(d => d.Serialnum.EqualIgnoreCase(devModel.Serialnum));
                        }

                        var devDb = dev != null ? dev : await _deviceService.GetDeviceByIdAsny(devModel.Serialnum);
                        if (devDb == null)
                        {
                            devDb = new DeviceDto()
                            {
                                Serialnum = devModel.Serialnum,
                                Name = devModel.Name,
                                FacilitySerialnum = facilityDb.Serialnum,
                                DeviceTypeSerialnum = devModel.DeviceTypeSerialnum,
                                Unit = devModel.Unit,
                                CreateTime = DateTime.Now,
                                UpdateTime = DateTime.Now,
                                OnlineStatus = true,
                                IsException = false,
                                Status = 1,
                                Sort = 0
                            };
                            XTrace.WriteLine("{0} {1}", DateTime.Now.ToShortTimeString(), devModel.Serialnum);
                            //await _deviceService.AddDevice(devDb);
                            //if (dev != null) _redis.Srem("device", dev, DataType.Protobuf);
                            _redis.Sadd("device", devDb, DataType.Protobuf);//加入到缓存中
                            /* ServiceLogger.Current.WriteDebugLog("添加设备 {0}", devDb.Name);0

                             var sets = await _deviceExceptionSetService.GetDeviceExceptionSetsByDeviceIdAsny(devDb.Serialnum);
                             if (sets == null || sets.Count() == 0)
                             {
                                 var set = new DeviceExceptionSetDto
                                 {
                                     Serialnum = devDb.Serialnum + "-" + DateTime.Now.ToLongTimeString(),
                                     DeviceSerialnum = devDb.Serialnum,
                                     Max = devModel.Max ?? 0,
                                     Min = devModel.Min ?? -1,
                                     CreateTime = DateTime.Now
                                 };
                                 await _deviceExceptionSetService.AddDeviceExceptionSet(set);//保存
                                 ServiceLogger.Current.WriteDebugLog("添加设备上下限 {0} [{1}-{2}]", devDb.Name, set.Min, set.Max);
                             }*/
                        }
#if DEBUG
                        else
                        {
                            devDb.UpdateTime = DateTime.Now;
                            if (dev != null) _redis.Srem("device", dev, DataType.Protobuf);
                            _redis.Sadd("device", devDb, DataType.Protobuf);//加入到缓存中
                            //await _deviceService.UpdateDevice(devDb);//保存
                        }
#endif
                    }

                    else
                    {
                        ServiceLogger.Current.WriteDebugLog("{0} 设备的设施编码不正确", devModel.Name);
                    }
                });
            }
            catch (NotSupportedException ex)
            {
            }
            catch (NotImplementedException ex)
            {
            }
            catch (AggregateException ex)
            {
            }
            catch (Exception ex)
            {
                throw;
            }

            //while (true)
            //{
            //    Thread.Sleep(1000);
            //    GC.Collect();
            //}
        }

        /// <summary>
        ///     添加设施
        /// </summary>
        /// <param name="item">
        ///     <see cref="FacilityAddData" />
        /// </param>
        /// <returns></returns>
        public static async Task<FacilityDto> AddFacility(FacilityAddData item)
        {
            try
            {
                var facilityModel = item.Facility;
                //_redis.Delete("facility");
                FacilityDto facility = null;
                if (_redis.Exists("facility") == 1)
                {
                    facility = _redis.Smember<FacilityDto>("facility", DataType.Protobuf).Find(f => f.Serialnum.EqualIgnoreCase(facilityModel.Serialnum));
                }

                var facilityDb = facility != null ? facility : await _facilityService.GetFacilityByIdAsny(facilityModel.Serialnum);
                if (facilityDb == null && _facilityService.CheckCode(facilityModel.Serialnum)) //添加设施
                {
                    facilityDb = new FacilityDto
                    {
                        Serialnum = facilityModel.Serialnum,
                        Name = facilityModel.Name,
                        FarmSerialnum = facilityModel.Farm,
                        FacilityTypeSerialnum = facilityModel.FacilityType,
                        Status = 1,
                        Sort = 0,
                        //Address = facilityModel.Address,
                        //PhotoUrl = facilityModel.PhotoUrl,
                        //ContactMan = facilityModel.ContactMan,
                        //ContactMobile = facilityModel.ContactMobile,
                        //ContactPhone = facilityModel.ContactPhone,
                        CreateTime = facilityModel.CreateTime ?? DateTime.Now
                    };
                    _redis.Sadd("facility", facilityDb, DataType.Protobuf);//将facilityDb加入到缓冲facility集合
                    //await _facilityService.AddFacility(facilityDb);
                    ServiceLogger.Current.WriteDebugLog("添加设施 {0}", facilityDb.Name);
                }
                return facilityDb;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///     处理设施更新数据
        /// </summary>
        /// <param name="updates"></param>
        /// <returns></returns>
        public static async Task<XResponseMessage> ProcessFacilityUpdate(List<FacilityUpdateData> updates)
        {
            if (updates == null) throw new ArgumentNullException("updates");

            if (!updates.Any())
            {
                return ResultHelper.CreateMessage("无任何设施更新数据", ErrorType.NoContent);
            }
            foreach (var update in updates)
            {
                var facilitySerialnum = update.Serialnum;
                if (facilitySerialnum.IsNullOrWhiteSpace())
                {
                    return ResultHelper.CreateMessage("设施编码不能为空", ErrorType.CanNotProcessRequestData);
                }

                try
                {
                    var facility = _redis.Smember<FacilityDto>("facility", DataType.Protobuf).Find(f => f.Serialnum.EqualIgnoreCase(facilitySerialnum));
                    var fac = facility != null ? facility : await _facilityService.GetFacilityByIdAsny(facilitySerialnum);
                    if (fac == null)
                    {
                        return ResultHelper.CreateMessage(facilitySerialnum, ErrorType.NoContent);
                    }

                    fac.Name = update.Name;
                    fac.FacilityTypeSerialnum = update.Type;
                    //await _facilityService.AddFacility(fac);
                    if(facility!=null) _redis.Srem("facility", facility, DataType.Protobuf);
                    _redis.Sadd("facility", fac, DataType.Protobuf);//加入到缓冲
                }
                catch (Exception ex)
                {
                    return ResultHelper.CreateMessage("", ErrorType.InternalError, null, ex);
                }
            }
            return null;
        }

        /// <summary>
        ///     更新设备数据
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        public static async Task<XResponseMessage> ProcessDeviceUpdate(DeviceUpdateData update)
        {
            if (update == null) throw new ArgumentNullException("update");

            //更新设备
            if (update.Devices != null && update.Devices.Any())
            {
                var updateList = new List<DeviceDto>();
                var setList = new List<DeviceExceptionSetDto>();

                //foreach (var deviceModel in update.Facility.Where(d => d != null))
                update.Devices.Where(d => d != null).ForEach(async deviceModel =>
                    {
                        var devDb = await _deviceService.GetDeviceByIdAsny(deviceModel.Serialnum);
                        //if (devDb == null)
                        //{
                        devDb.Serialnum = deviceModel.Serialnum;
                        devDb.Name = deviceModel.Name;
                        devDb.FacilitySerialnum = deviceModel.FacilitySerialnum;
                        devDb.DeviceTypeSerialnum = deviceModel.DeviceTypeSerialnum;
                        devDb.Unit = deviceModel.Unit;
                        devDb.ProcessedValue = deviceModel.ProcessedValue;
                        devDb.ShowValue = deviceModel.ShowValue;
                        devDb.CreateTime = devDb.UpdateTime = deviceModel.UpdateTime;
                        //devDb.Save();
                        updateList.Add(devDb);
                        var set = await _deviceExceptionSetService.GetDeviceExceptionSetByDeviceIdAsny(devDb.Serialnum) ??
                            new DeviceExceptionSetDto() { DeviceSerialnum = devDb.Serialnum };
                        if (deviceModel.Max != null)
                            set.Max = deviceModel.Max.Value;
                        if (deviceModel.Min != null)
                            set.Min = deviceModel.Min.Value;
                        setList.Add(set);
                        //}           
                    });

                try
                {
                    if (updateList.Count() > 0 && updateList != null)
                    {
                        updateList.ForEach(dev =>
                       {
                           DeviceDto device = null;
                           if (_redis.Exists("device") == 1)
                           {
                               device = _redis.Smember<DeviceDto>("device", DataType.Protobuf).Find(d => d.Serialnum.EqualIgnoreCase(dev.Serialnum));
                           }
                           if (device != null) _redis.Srem("device", dev, DataType.Protobuf);
                           //await _deviceService.AddDevice(dev);//保存设备                           
                           _redis.Sadd("device", dev, DataType.Protobuf);
                       });
                    }
                    if (setList.Count() > 0 && setList != null)
                    {
                        setList.ForEach(async set =>
                        {
                            await _deviceExceptionSetService.AddDeviceExceptionSet(set); //保存设备异常区间
                        });
                    }
                }
                catch (Exception ex)
                {
                    return ResultHelper.CreateMessage("", ErrorType.InternalError, null, ex);
                }
            }

            //更新音视频设备
            //var cameraDb = FacilityCamera.FindAllWithCache().ToList();
            if (update.Cameras != null && update.Cameras.Any())
            {
                var cameraDb = new List<FacilityCameraDto>();
                update.Cameras.ForEach(async mediaData =>
                {
                    if (mediaData != null)
                    {
                        var cam =await _facilityCameraService.GetFacilityCameraByIdAsny(mediaData.DeviceCode);
                        if (cam != null)
                        {
                            cam.FacilitySerialnum = mediaData.FacilityCode;
                            cam.IP = mediaData.Url;
                            cam.HttpPort = mediaData.MediaPort;
                            cam.DataPort = mediaData.ContrPort;
                            cam.UserID = mediaData.User;
                            cam.UserPwd = mediaData.Pwd;
                            cam.Channel = mediaData.Channel;
                            cameraDb.Add(cam);
                        }
                    }
                });
                try
                {
                    //保存设施摄像机
                    cameraDb.ForEach(c =>
                    {
                        //await _facilityCameraService.AddFacilityCamera(c);
                        FacilityCameraDto camera = null;
                        if (_redis.Exists("facilityCamera")==1)
                        {
                             camera = _redis.Smember<FacilityCameraDto>("facilityCamera", DataType.Protobuf).Find(fc => fc.Serialnum.EqualIgnoreCase(c.Serialnum));
                        }
                        if (camera != null) _redis.Srem("facilityCamera",camera,DataType.Protobuf);
                        _redis.Sadd("facilityCamera", camera, DataType.Protobuf);
                    });
                }
                catch (Exception ex)
                {
                    return ResultHelper.CreateMessage("", ErrorType.InternalError, null, ex);
                }
            }

            return null;
        }
    }
}