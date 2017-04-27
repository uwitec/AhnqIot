using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;
using Smart.Redis;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Manage.InnerProcess
{
    public class DeviceAddProcess
    {
        private readonly IDeviceExceptionSetService _deviceExceptionSet;
        private readonly IDeviceService _deviceService;
        private readonly IDeviceTypeService _deviceTypeService;
        private readonly IFacilityService _facilityService;
        private readonly IFarmService _farmService;
        private readonly RedisClient _redisClient;

        public DeviceAddProcess()
        {
            _redisClient = RedisClient.DefaultDB;
            _deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>();
            _deviceTypeService = AhnqIotContainer.Container.Resolve<IDeviceTypeService>();
            _deviceExceptionSet = AhnqIotContainer.Container.Resolve<IDeviceExceptionSetService>();
            _farmService = AhnqIotContainer.Container.Resolve<IFarmService>();
            _facilityService = AhnqIotContainer.Container.Resolve<IFacilityService>();
        }

        /// <summary>
        /// 处理设备添加数据
        /// </summary>
        /// <param name="device">设备添加数据</param>
        /// <returns></returns>
        public async Task<XResponseMessage> ProcessAsync(DeviceModel device)
        {
            var faccility = await _facilityService.GetFacilityByIdAsny(device.FacilitySerialnum);
            if (faccility == null) return ResultHelper.CreateMessage("设施不存在", ErrorType.FacilityNotExists);
            //if (!_deviceService.CheckCode(device.Serialnum)) return;
            //if (!await _farmService.ExistsAsync(device.FacilitySerialnum)) return ResultHelper.CreateMessage("基地不存在", ErrorType.FarmNotExists);
            var deviceType = await _deviceTypeService.GetByIdAsync(device.DeviceTypeSerialnum); //不存在的设备类型无法添加
            if (deviceType == null) return ResultHelper.CreateMessage("设备类型不存在", ErrorType.DeviceTypeNotExists);
            var item = await _deviceService.GetDeviceByIdAsny(device.Serialnum);
            //数据库中不存在该设备(有必要吗？)
            if (item != null) return null;
            item = new DeviceDto
            {
                Serialnum = device.Serialnum,
                Name = device.Name,
                DeviceTypeSerialnum = device.DeviceTypeSerialnum,
                FacilitySerialnum = device.FacilitySerialnum,
                CreateTime = device.UpdateTime,
                UpdateTime = device.UpdateTime,
                Status = 1,
                Sort = 0,
                Unit = device.Unit,
                ProcessedValue = device.ProcessedValue,
                ShowValue = device.ShowValue,
                RelayType = device.RelayType,
            };

            try
            {
                var result = await _deviceService.AddDevice(item);
                LogHelper.Info("[设备]设备{0}{1}添加{2}", device.Name, device.Serialnum, result);
                return ResultHelper.CreateMessage($"添加设备{(result ? "成功" : "失败")}",
                    result ? ErrorType.NoError : ErrorType.InternalError);
            }
            catch (AggregateException ex)
            {
                return ResultHelper.CreateExceptionMessage(ex, "添加设备失败");
            }
        }
    }
}