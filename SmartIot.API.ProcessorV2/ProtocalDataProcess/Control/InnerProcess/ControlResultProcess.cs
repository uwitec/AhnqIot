using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ControlDataRequest;
using SmartIot.API.ProcessorV2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Control.InnerProcess
{
    public class ControlResultProcess
    {
        private readonly IDeviceControlCommandService _controlCommandService;
        private readonly IDeviceControlLogService _deviceControlLogService;
        private readonly IDeviceService _deviceService;

        public ControlResultProcess()
        {
            _controlCommandService = AhnqIotContainer.Container.Resolve<IDeviceControlCommandService>();
            _deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>();
            _deviceControlLogService = AhnqIotContainer.Container.Resolve<IDeviceControlLogService>();
        }

        public async Task<bool> ProcessAsync(IEnumerable<ControlResult> controlResults)
        {
            var enumerable = controlResults as ControlResult[] ?? controlResults.ToArray();
            if (!enumerable.Any()) throw new ArgumentNullException(nameof(controlResults));
            try
            {
                enumerable.ToList().ForEach(async controlResult =>
                {
                    var devCommand = await _controlCommandService.GetDeviceControlCmdByIdAsny(controlResult.Serialnum);


                    if (devCommand == null) return;
                    var device = await _deviceService.GetDeviceByIdAsny(devCommand.DeviceSerialnum);
                    var devControlLog = new DeviceControlLogDto
                    {
                        Serialnum = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "-" + devCommand.DeviceSerialnum,
                        DeviceSerialnum = devCommand.DeviceSerialnum,
                        CommandSerialnum = controlResult.Serialnum,
                        ControlResult = controlResult.Result,
                        CreateTime = DateTime.Now,
                        DeviceShowValue = device.ShowValue,
                        DeviceValue = device.ProcessedValue,
                        FailReason = controlResult.FailReason,
                        Remark = ""
                    };
                    var result = await _deviceControlLogService.AddControlLog(devControlLog);

                    var devControlConmand =
                        await _controlCommandService.GetDeviceControlCmdByIdAsny(devCommand.Serialnum);
                    if (devControlConmand.Status != (int) DeviceCommandTypeEnum.Getted) return;
                    if (controlResult.Result)
                    {
                        devControlConmand.Status = (int) DeviceCommandTypeEnum.ActionSuccess;
                        //接收到来自客户端的上传控制指令的时候，控制成功状态变为2
                    }
                    else
                    {
                        devControlConmand.Status = (int) DeviceCommandTypeEnum.ActionError;
                        //接收到来自客户端的上传控制指令的时候，控制失败状态变为3
                    }
                    devControlConmand.UpdateTime = DateTime.Now;
                    var rlt = await _controlCommandService.UpdateControlCommandAsny(devCommand);
                    LogHelper.Info("[上传控制结果]设备{0}指令：{1}上传{2}", devControlConmand.DeviceSerialnum,
                        devControlConmand.Command, rlt);
                });

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error("上传控制指令出错,错误内容：{0}", ex.ToString());
                return false;
            }
        }
    }
}