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
using SmartIot.Api.Protocal.Meta.Model;
using SmartIot.Api.Protocal.Common;
using AhnqIot.Infrastructure.Log;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Manage.InnerProcess
{
    public class DeviceUpdateProcess
    {
        private readonly IDeviceExceptionSetService _deviceExceptionSet;
        private readonly IDeviceService _deviceService;
        private readonly IDeviceTypeService _deviceTypeService;
        private readonly RedisClient _redisClient;

        public DeviceUpdateProcess()
        {
            _redisClient = RedisClient.DefaultDB;
            _deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>();
            _deviceTypeService = AhnqIotContainer.Container.Resolve<IDeviceTypeService>();
            _deviceExceptionSet = AhnqIotContainer.Container.Resolve<IDeviceExceptionSetService>();
        }

        /// <summary>
        /// 处理设备更新数据
        /// </summary>
        /// <param name="device">设备更新数据</param>
        /// <returns></returns>
        public async Task<XResponseMessage> ProcessAsync(DeviceModel device)
        {
            var d = await _deviceService.GetDeviceByIdAsny(device.Serialnum);
            if (d == null) return ResultHelper.CreateMessage("设备不存在", ErrorType.DeviceNotExists);
            var deviceType = await _deviceTypeService.GetByIdAsync(device.DeviceTypeSerialnum);
            if (deviceType == null) return ResultHelper.CreateMessage("设备类型不存在", ErrorType.DeviceTypeNotExists);
            var item = await _deviceService.GetDeviceByIdAsny(device.Serialnum);
            //数据库中不存在该设备并且更新时间大于最新的更新时间
            if (item == null || device.UpdateTime < item.UpdateTime) return null;
            item.Serialnum = device.Serialnum;
            item.Name = device.Name;
            item.DeviceTypeSerialnum = device.DeviceTypeSerialnum;
            item.FacilitySerialnum = device.FacilitySerialnum;
            item.UpdateTime = device.UpdateTime;
            item.Unit = device.Unit;
            item.ProcessedValue = device.ProcessedValue;
            item.ShowValue = device.ShowValue;
            item.RelayType = device.RelayType;

            var deviceset = await _deviceExceptionSet.GetDeviceExceptionSetByDeviceIdAsny(device.Serialnum);
            //创建设备异常区间
            var set = new DeviceExceptionSetDto
            {
                Max = device.Max,
                Min = device.Min,
                DeviceSerialnum = device.Serialnum,
                Status = true,
                CreateTime = device.UpdateTime,
                UpdateTime = device.UpdateTime
            };
            if (deviceset == null)
            {
                set.Serialnum = Guid.NewGuid().ToString();
                await _deviceExceptionSet.AddDeviceExceptionSet(set);
            }
            else
            {
                set.Serialnum = deviceset.Serialnum;
                await _deviceExceptionSet.UpdateAsny(set);
            }
            try
            {
                var result = await _deviceService.UpdateDevice(item);
                LogHelper.Trace("[设备]设备{0}{1}更新{2}", device.Name, device.Serialnum, result);
                return ResultHelper.CreateMessage($"更新设备{(result ? "成功" : "失败")}",
                    result ? ErrorType.NoError : ErrorType.InternalError);
            }
            catch (AggregateException ex)
            {
                LogHelper.Error(ex.ToString());
                return ResultHelper.CreateExceptionMessage(ex, "更新设备失败");
            }
        }
    }
}