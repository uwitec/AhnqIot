#region Code File Comment

// SOLUTION   ： SmartIot - DeviceCode
// PROJECT    ： SmartIot.API.Processor
// FILENAME   ： QueryDataProcessor.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-28 23:08
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.Linq;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta.Model;
using SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest;
using AhnqIot.Dto;
using AhnqIot.Bussiness.Interface;
using System.Threading.Tasks;
using AhnqIot.Infrastructure.DI;
using Autofac;
using Smart.Redis;
#endregion

namespace SmartIot.API.Processor.DataObject
{
    public class QueryDataProcessor
    {
        static QueryDataProcessor()
        {
            _devcieTypeService = AhnqIotContainer.Container.Resolve<IDeviceTypeService>(); 
            _facilityTypeService = AhnqIotContainer.Container.Resolve<IFacilityTypeService>(); 
            _facilityService = AhnqIotContainer.Container.Resolve<IFacilityService>(); 
            _deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>(); 
            _deviceExceptionSetService = AhnqIotContainer.Container.Resolve<IDeviceExceptionSetService>(); 
            _facilityCameraService = AhnqIotContainer.Container.Resolve<IFacilityCameraService>();
            _redis = new RedisClient();
        }

        #region 字段
        private static IDeviceTypeService _devcieTypeService;
        private static IFacilityTypeService _facilityTypeService;
        private static IFacilityService _facilityService;
        private static IDeviceService _deviceService;
        private static IDeviceExceptionSetService _deviceExceptionSetService;
        private static IFacilityCameraService _facilityCameraService;
        private static RedisClient _redis;
        #endregion

        /// <summary>
        ///     处理获取设备类型
        /// </summary>
        /// <returns></returns>
        public static async Task<XResponseMessage> ProcessDeviceTypeGet()
        {
            try
            {
                var deviceTypeList = _redis.GetVals<DeviceTypeDto>("deviceType", DataType.Protobuf);
                var deviceTypes= deviceTypeList.Count > 0 ? deviceTypeList: await _devcieTypeService.GetAllAsny();
                var types =deviceTypes.Select(t => new DeviceTypeModel()
                {
                    Serialnum = t.Serialnum,
                    Name = t.Name,
                    ParentSerialnum = t.ParentSerialnum,
                    PhotoUrl = t.PhotoUrl,
                    Introduce = t.Introduce
                });
                return ResultHelper.CreateMessage("", ErrorType.NoError, types);
            }
            catch (Exception ex)
            {
                return ResultHelper.CreateMessage("", ErrorType.InternalError, null, ex);
            }
        }

        /// <summary>
        ///     处理获取设施类型
        /// </summary>
        /// <returns></returns>
        public static async Task<XResponseMessage> ProcessFacilityTypeGet()
        {
            try
            {
                var facilityTypeList = _redis.GetVals<FacilityTypeDto>("facilityType", DataType.Protobuf);
                var facilityTypes = facilityTypeList.Count>0 ? facilityTypeList : await _facilityTypeService.GetAllAsny();
                var types = facilityTypes.Select(t => new FacilityTypeModel()
                {
                    Serialnum = t.Serialnum,
                    Name = t.Name,
                    ParentSerialnum = t.ParentSerialnum,
                    PhotoUrl = t.PhotoUrl,
                    Introduce = t.Introduce
                });
                return ResultHelper.CreateMessage("", ErrorType.NoError, types);
            }
            catch (Exception ex)
            {
                return ResultHelper.CreateMessage("", ErrorType.InternalError, null, ex);
            }
        }

        /// <summary>
        ///     获取基地下所有设施
        /// </summary>
        /// <param name="farmSerialnum">基地编码</param>
        /// <returns></returns>
        public static async Task<XResponseMessage> ProcessGetFacilities(string farmSerialnum)
        {
            if (farmSerialnum == null) throw new ArgumentNullException("farmSerialnum");

            try
            {
                var types =(await _facilityService.GetFacilitiesByFarmIdAsny(farmSerialnum)).ToList().Select(t => new FacilityModel()
                {
                    Serialnum = t.Serialnum,
                    Name = t.Name,
                    Farm = farmSerialnum,
                    FacilityType = t.FacilityTypeSerialnum,
                    //Address = t.Address,
                    //PhotoUrl = t.PhotoUrl,
                    //ContactMan = t.ContactMan,
                    //ContactPhone = t.ContactPhone,
                    //ContactMobile = t.ContactMobile,
                    CreateTime = t.CreateTime
                });
                return ResultHelper.CreateMessage("", ErrorType.NoError, types);
            }
            catch (Exception ex)
            {
                return ResultHelper.CreateMessage("", ErrorType.InternalError, null, ex);
            }
        }

        /// <summary>
        ///     查询设施下所有设备
        /// </summary>
        /// <param name="facilitySerialnum"></param>
        /// <returns></returns>
        public static async Task<XResponseMessage> ProcessGetFacilityDevices(string facilitySerialnum)
        {
            if (facilitySerialnum == null) throw new ArgumentNullException("facilitySerialnum");
            decimal? nullValueDecimal = null;
            try
            {
                //查询设施下所有传感器采集和控制设备
                var devices =
                    _deviceService.GetDevicesByFacilityId(facilitySerialnum).ToList().Select(t => new DeviceModel()
                    {
                        Serialnum = t.Serialnum,
                        Name = t.Name,
                        FacilitySerialnum = facilitySerialnum,
                        DeviceTypeSerialnum = t.DeviceTypeSerialnum,
                        ProcessedValue = t.ProcessedValue,
                        ShowValue = t.ShowValue,
                        Unit = t.Unit,
                        UpdateTime = t.UpdateTime,
                        Max = _deviceExceptionSetService.GetDeviceExceptionSetByDeviceId(t.Serialnum) != null 
                        ? _deviceExceptionSetService.GetDeviceExceptionSetByDeviceId(t.Serialnum).Max : nullValueDecimal,
                        Min = _deviceExceptionSetService.GetDeviceExceptionSetByDeviceId(t.Serialnum) != null 
                        ? _deviceExceptionSetService.GetDeviceExceptionSetByDeviceId(t.Serialnum).Min : nullValueDecimal,
                    });
                //查询设施下所有音视频设备
                var cameras =
                    (await _facilityCameraService.GetFacilityCamerasByFacilityIdAsny(facilitySerialnum)).ToList().Select(cam => new MediaData()
                    {
                        DeviceCode = cam.Serialnum,
                        FacilityCode = cam.FacilitySerialnum,
                        Url = cam.IP,
                        MediaPort = cam.HttpPort,
                        ContrPort = cam.DataPort,
                        User = cam.UserID,
                        Pwd = cam.UserPwd,
                        Channel = cam.Channel
                    });


                var deviceModels = devices as IList<DeviceModel> ?? devices.ToList();
                return ResultHelper.CreateMessage("", ErrorType.NoError, new
                {
                    Collect = deviceModels.Where(d => d.DeviceTypeSerialnum.StartsWith("collect")),
                    Control = deviceModels.Where(d => d.DeviceTypeSerialnum.StartsWith("control")),
                    Camera = cameras
                });
            }
            catch (Exception ex)
            {
                return ResultHelper.CreateMessage("", ErrorType.InternalError, null, ex);
            }
        }
    }
}