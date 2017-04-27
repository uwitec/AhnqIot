using SmartIot.Api.Protocal.Meta.Model;
using SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ManageDataRequest;
using SmartIot.Tool.API.Common;
using SmartIot.Tool.API.Transport;
using SmartIot.Tool.Core.DataSync;
using SmartIot.Tool.DefaultService.API;
using SmartIot.Tool.DefaultService.Core;
using SmartIot.Tool.DefaultService.DB;
using SmartIot.Service.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SmartIot.Api.Protocal.Meta.Request.DataContent;
using SmartIot.Tool.API.Core;
using System.Threading.Tasks;
using AhnqIot.Infrastructure.Log;
using SmartIot.Tool.Core.Device.ControlDevice;

namespace SmartIot.Tool.DefaultService.DataSync
{
    public class Default : IDataSync
    {
        private readonly IDeviceApi _deviceApi;
        private readonly IFacilityApi _facilityApi;

        private readonly IFarmApi _farmApi;
        private readonly IApiTransport _transport;

        //private Timer _uploadTimer;
        private Stopwatch sw = new Stopwatch();

        public Default()
        {
            Name = "农业气象物联网数据同步插件";
            EnableDelete = true;

            _farmApi = new FarmApi();
            _facilityApi = new FacilityApi();
            _deviceApi = new DeviceApi();

            _transport = ApiTransportHelper.GetTransport();
            SyncAll();
        }

        /// <summary>
        /// 插件名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 启用删除
        /// </summary>
        public bool EnableDelete { get; set; }


        public bool Sync(DateTime dateTime)
        {
            // return SyncDeviceData(dateTime);
            return true;
        }

        private bool SyncAll()
        {
            LogHelper.Debug("同步设施及设备信息");
            return SyncFacility() && SyncCollectDevices() && SyncControlDevices() && SyncCameraDevices();
            //return SyncFacility() && SyncCollectDevices()&& SyncControlDevices();

            //SyncCollectDevices();
        }

        /// <summary>
        /// 同步设施
        /// </summary>
        /// <returns></returns>
        private bool SyncFacility()
        {
            var syncResult = false;
            //查询出Code1不为空的基地
            var farms = Farm.FindAllWithCache().ToList().Where(f => !f.Code1.IsNullOrWhiteSpace());

            //校验所有编码
            if (!CheckCode(farms)) return false;

            farms.ToList().ForEach(farm =>
            {
                //本地数据库中的设施
                var facilitysInDb = farm.Facilitys;
                if (facilitysInDb.Count > 0)
                {
                    facilitysInDb.ForEach(fInDb =>
                    {
                        var facility = new FacilityModel
                        {
                            Serialnum = fInDb.Code1,
                            Name = fInDb.Name,
                            Farm = fInDb.Farm.Code1,
                            FacilityType = fInDb.FacilityTypeSerialnum,
                            // Address = fInDb.Address,
                            CreateTime = DateTime.Now
                        };
                        var entity = AwEntityHelper.GetEntity(farm.Code1);
#if DEBUG
                        var sw = new Stopwatch();
                        sw.Start();
#endif
                        try
                        {
                            var trans = ApiTransportHelper.GetTransport();
                            var queryResponse = _facilityApi.QueryFacility(entity, trans, facility.Serialnum);
                            if (queryResponse.Data != null) //判断远程数据库中是否已经存在该设施
                            {
                                //var entity1 = AwEntityHelper.GetEntity(farm.Code1);
                                //var result = _facilityApi.UpdateFacility(entity1, trans, facility); //设施单个上传
                                //trans.Dispose();
                                //ServiceLogger.Current.WriteDebugLog("更新设施{0}:{1}", facility.Serialnum,
                                //    result ? "成功" : "失败");
                                //syncResult = result;
                            }
                            else
                            {
                                var entity2 = AwEntityHelper.GetEntity(farm.Code1);
                                var result = _facilityApi.AddFacility(entity2, trans, facility); //设施单个上传
                                trans.Dispose();
                                LogHelper.Debug("添加设施{0}:{1}", facility.Serialnum,
                                    result ? "成功" : "失败");
                                syncResult = result;
                            }
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Fatal(ex.ToString());
                        }
#if DEBUG
                        sw.Stop();
                        var apiAccesslog = new ApiAccessLog
                        {
                            ApiName = "同步设施",
                            Result = syncResult,
                            CreateTime = DateTime.Now,
                            CostTime = Convert.ToInt32(sw.ElapsedMilliseconds)
                        };
                        apiAccesslog.Save();
                        LogHelper.Debug("同步设施耗时" + sw.ElapsedMilliseconds.ToString() + "ms");
#endif
                    });
                }
            });
            //return syncResult;
            return true;
        }

        /// <summary>
        /// 同步采集设备
        /// </summary>
        /// <returns></returns>
        private bool SyncCollectDevices()
        {
            //System.Threading.Thread.Sleep(50);
            var syncResult = false;

            //采集设备
            var collectDevices =
                FacilitySensorDeviceUnit.FindAllWithCache()
                    .ToList()
                    .Where(c => c.Code1.Substring(13, 1).EqualIgnoreCase("C"));
            var facilitySensorDeviceUnits = collectDevices as FacilitySensorDeviceUnit[] ?? collectDevices.ToArray();
            if (facilitySensorDeviceUnits.Any())
            {
                //逐个上传设备数据
                facilitySensorDeviceUnits.ToList().ForEach(cd =>
                {
                    var code = cd.Code1;
                    var dev = cd.SensorDeviceUnit;

                    #region 构建DeviceModel

                    var deviceModel = new DeviceModel
                    {
                        Serialnum = code,
                        Name = dev.Name,
                        DeviceTypeSerialnum = dev.Sensor.DeviceTypeSerialnum,
                        FacilitySerialnum = cd.Facility.Code1,
                        ProcessedValue = dev.ProcessedValue,
                        ShowValue = dev.ShowValue,
                        Unit = dev.Sensor.Unit,
                        Max = dev.Sensor.ExperienceMax,
                        Min = dev.Sensor.ExperienceMin,
                        UpdateTime = dev.UpdateTime
                    };

                    #endregion 构建DeviceModel

                    var entity = AwEntityHelper.GetEntity(cd.Facility.Farm.Code1);
#if DEBUG
                    var sw = new Stopwatch();
                    sw.Start();
#endif
                    try
                    {
                        var trans = ApiTransportHelper.GetTransport();
                        var responseResult = _deviceApi.QueryDevice(entity, trans, deviceModel.Serialnum);
                        if (responseResult.Data != null) //判断远程数据库中是否已经存在该设备
                        {
                            var entity1 = AwEntityHelper.GetEntity(cd.Facility.Farm.Code1);
                            var result = _deviceApi.UpdateDevice(entity1, trans, deviceModel); //设备单个上传
                            trans.Dispose();
                            LogHelper.Debug("更新设备{0}:{1}", deviceModel.Serialnum,
                                result ? "成功" : "失败");
                            syncResult = result;
                        }
                        else
                        {
                            var entity1 = AwEntityHelper.GetEntity(cd.Facility.Farm.Code1);
                            var result = _deviceApi.AddDevice(entity1, trans, deviceModel); //设备单个上传
                            trans.Dispose();
                            LogHelper.Debug("添加设备{0}:{1}", deviceModel.Serialnum,
                                result ? "成功" : "失败");
                            syncResult = result;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Fatal(ex.ToString());
                    }
#if DEBUG
                    sw.Stop();
                    var apiAccesslog = new ApiAccessLog
                    {
                        ApiName = "同步采集设备",
                        Result = syncResult,
                        CreateTime = DateTime.Now,
                        CostTime = Convert.ToInt32(sw.ElapsedMilliseconds)
                    };
                    apiAccesslog.Save();
                    LogHelper.Debug("同步采集设备耗时" + sw.ElapsedMilliseconds.ToString() + "ms");
#endif
                });
            }
            //return syncResult;
            return true;
        }

        /// <summary>
        /// 同步控制设备
        /// </summary>
        /// <returns></returns>
        private bool SyncControlDevices()
        {
            var syncResult = false;

            //控制设备
            var controlDevices =
                FacilityControlDeviceUnit.FindAllWithCache()
                    .ToList()
                    .Where(c => c.Code1.Substring(13, 1).EqualIgnoreCase("K"));
            var facilityControlDeviceUnits = controlDevices as FacilityControlDeviceUnit[] ?? controlDevices.ToArray();
            if (facilityControlDeviceUnits.Any())
            {
                //逐个上传
                facilityControlDeviceUnits.ToList().ForEach(cd =>
                {
                    #region 构建DeviceModel

                    var code = cd.Code1;
                    var devs = cd.ControlDeviceUnits; //改设施控制设备所拥有的所有控制设备继电器的集合                   
                    if (devs != null)
                    {
                        var originalValue = CalcControlDeviceValue.CalcOriginal(cd);
                        var processedValue = CalcControlDeviceValue.CalcProcessValue(cd);
                        var deviceModel = new DeviceModel
                        {
                            Serialnum = code,
                            Name = cd.Name,
                            DeviceTypeSerialnum = devs[0].DeviceTypeSerialnum,
                            FacilitySerialnum = cd.Facility.Code1,
                            ProcessedValue = originalValue,
                            ShowValue = processedValue,
                            UpdateTime = DateTime.Now,
                            RelayType = devs[0].RelayTypeName
                        };

                        #endregion 构建DeviceModel

                        var entity = AwEntityHelper.GetEntity(cd.Facility.Farm.Code1);
#if DEBUG
                        var sw = new Stopwatch();
                        sw.Start();
#endif
                        try
                        {
                            var trans = ApiTransportHelper.GetTransport();
                            var responseResult = _deviceApi.QueryDevice(entity, trans, deviceModel.Serialnum);
                            if (responseResult.Data != null)
                            {
                                var entity1 = AwEntityHelper.GetEntity(cd.Facility.Farm.Code1);
                                var result = _deviceApi.UpdateDevice(entity1, trans, deviceModel);
                                trans.Dispose();
                                LogHelper.Debug("更新控制设备{0}:{1}", deviceModel.Serialnum,
                                    result ? "成功" : "失败");
                                syncResult = result;
                            }
                            else
                            {
                                var entity1 = AwEntityHelper.GetEntity(cd.Facility.Farm.Code1);
                                var result = _deviceApi.AddDevice(entity1, trans, deviceModel);
                                trans.Dispose();
                                LogHelper.Debug("添加控制设备{0}:{1}", deviceModel.Serialnum,
                                    result ? "成功" : "失败");
                                syncResult = result;
                            }
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Fatal(ex.ToString());
                        }
#if DEBUG
                        sw.Stop();
                        var apiAccesslog = new ApiAccessLog
                        {
                            ApiName = "同步控制设备",
                            Result = syncResult,
                            CreateTime = DateTime.Now,
                            CostTime = Convert.ToInt32(sw.ElapsedMilliseconds)
                        };
                        apiAccesslog.Save();
                        LogHelper.Debug("同步控制设备耗时" + sw.ElapsedMilliseconds.ToString() + "ms");
#endif
                    }
                });
            }
            //return syncResult;
            return true;
        }

        /// <summary>
        /// 同步摄像机
        /// </summary>
        /// <returns></returns>
        private bool SyncCameraDevices()
        {
            var syncResult = false;

            //摄像机
            var cameraDevices =
                FacilityCamera.FindAllWithCache().ToList().Where(c => c.Code1.Substring(13, 1).EqualIgnoreCase("S"));

            IEnumerable<FacilityCamera> facilityCameras = cameraDevices as FacilityCamera[] ?? cameraDevices.ToArray();
            if (facilityCameras.Any())
            {
                facilityCameras.ToList().ForEach(cd =>
                {
                    #region 构建MediaData

                    var mediaData = new MediaData
                    {
                        DeviceCode = cd.Code1,
                        DeviceName = cd.CameraName,
                        FacilityCode = cd.Facility.Code1,
                        Url = cd.Camera.CameraHost,
                        MediaPort = cd.Camera.CameraHttpPort,
                        ContrPort = cd.Camera.CameraDataPort,
                        User = cd.Camera.UserID,
                        Pwd = cd.Camera.UserPwd,
                        Channel = cd.Camera.Channel,
                        CreateTime = DateTime.Now
                    };

                    #endregion 构建MediaData

                    var entity = AwEntityHelper.GetEntity(cd.Facility.Farm.Code1);
#if DEBUG
                    var sw = new Stopwatch();
                    sw.Start();
#endif
                    try
                    {
                        var trans = ApiTransportHelper.GetTransport();
                        var responseResult = _deviceApi.QueryMedia(entity, trans, mediaData.DeviceCode);
                        if (responseResult.Data != null)
                        {
                            //var entity1 = AwEntityHelper.GetEntity(cd.Facility.Farm.Code1);
                            //var result = _deviceApi.UpdateMedia(entity1, trans, mediaData);
                            //trans.Dispose();
                            //ServiceLogger.Current.WriteDebugLog("更新视频设备{0}:{1}", mediaData.DeviceCode,
                            //    result ? "成功" : "失败");
                            //syncResult = result;
                        }
                        else
                        {
                            var entity1 = AwEntityHelper.GetEntity(cd.Facility.Farm.Code1);
                            var result = _deviceApi.AddMedia(entity1, trans, mediaData);
                            trans.Dispose();
                            LogHelper.Debug("添加视频设备{0}:{1}", mediaData.DeviceCode,
                                result ? "成功" : "失败");
                            syncResult = result;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Fatal(ex.ToString());
                    }
#if DEBUG
                    sw.Stop();
                    var apiAccesslog = new ApiAccessLog
                    {
                        ApiName = "同步视频设备",
                        Result = syncResult,
                        CreateTime = DateTime.Now,
                        CostTime = Convert.ToInt32(sw.ElapsedMilliseconds)
                    };
                    apiAccesslog.Save();
                    LogHelper.Debug("同步视频设备耗时" + sw.ElapsedMilliseconds.ToString() + "ms");

#endif
                });
            }
            return syncResult;
        }

        /// <summary>
        /// 数据同步：调试模式
        /// </summary>
        /// <returns></returns>
        /// 
        /* private bool SyncDeviceData(DateTime dataTime)
        {
            var syncResult = false;
            string farmCode = null;
            var collectData = new CollectDataBlock();
            //采集数据
            var deviceUnits =
                FacilitySensorDeviceUnit.FindAllWithCache()
                    .ToList()
                    .Where(c => c.Code1.Substring(13, 1).EqualIgnoreCase("C"));
            //分批上传设备数据
            const int size = 10;
            var facilitySensorDeviceUnits = deviceUnits as FacilitySensorDeviceUnit[] ?? deviceUnits.ToArray();
            var count = facilitySensorDeviceUnits.Count()/size;
            if (facilitySensorDeviceUnits.Count()%size > 0)
                count++;
            for (var i = 0; i < count; i++)
            {
                var list = facilitySensorDeviceUnits.Skip(i*size).Take(size);

                var sendDatas = list.Select(fsd =>
                {
                    farmCode = fsd.Facility.Farm.Code1;
                    var code1 = fsd.Code1;
                    var sd = new SensorData
                    {
                        DeviceCode = code1,
                        Value = fsd.SensorDeviceUnit.ProcessedValue,
                        ShowValue = fsd.SensorDeviceUnit.ShowValue
                    };
                    //var mediaDatas = list.Select();
                    //sd.DeviceType = fsd.SensorDeviceUnit.Sensor.DeviceTypeSerialnum;
                    //sd.FacilityCode = fsd.Facility.Code1;
                    //sd.Unit = fsd.SensorDeviceUnit.Sensor.Unit;
                    //#if DEBUG
                    if (
                        DateTime.Now.Subtract(fsd.SensorDeviceUnit.UpdateTime)
                            .TotalMinutes > 10)
                    {
                        var ran = new Random(DateTime.Now.Minute);
                        var c = ran.Next(10, 100);
                        sd.Value = fsd.SensorDeviceUnit.ProcessedValue + c*0.01M;
                        sd.ShowValue = sd.Value + "";
                    }
                    sd.Time = dataTime;
                    //设施编码+更新时间//批次号
                    sd.BatchNum = fsd.Facility.Code1.Substring(0, 13) + "-" + sd.Time;
                    //#else
                    //                            sd.Time = fsd.SensorDeviceUnit.UpdateTime;
                    //#endif
                    return sd;
                }).ToList();
                collectData.SensorDatas = sendDatas;
                var entity = AwEntityHelper.GetEntity(farmCode, "上传设备数据");
#if DEBUG
                var sw = new Stopwatch();
                sw.Start();
#endif
                var trans = ApiTransportHelper.GetTransport();
                var result = _deviceApi.UploadDeviceData(entity, trans, collectData);
                trans.Dispose();
                syncResult = result;
                ServiceLogger.Current.WriteDebugLog("上传设备数据:{0}", result ? "成功" : "失败");
#if DEBUG
                sw.Stop();
                var apiAccesslog = new ApiAccessLog
                {
                    ApiName = "上传设备数据",
                    Result = result,
                    CreateTime = DateTime.Now,
                    CostTime = Convert.ToInt32(sw.ElapsedMilliseconds)
                };
                apiAccesslog.Save();
                ServiceLogger.Current.WriteDebugLog("上传设备数据耗时" + sw.ElapsedMilliseconds.ToString() + "ms");
            }
#endif
            //return syncResult;
            return true;
        }*/
        private IEnumerable<FacilityModel> GetPlatformFacilitys(Farm farm)
        {
            var entity = AwEntityHelper.GetEntity(farm.Code1);
            var facsPlatform = _farmApi.GetFacilities(entity, _transport);
            return facsPlatform;
        }

        private static bool CheckCode(IEnumerable<Farm> farms)
        {
            return true;
        }
    }
}