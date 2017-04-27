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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartIot.API.ProcessorV2.ProtocalDataProcess.Control.InnerProcess
{
    public class ControlQueryProcess
    {
        private readonly IDeviceControlCommandService _controlCommandService;
        private readonly IDeviceService _deviceService;

        public ControlQueryProcess()
        {
            _controlCommandService = AhnqIotContainer.Container.Resolve<IDeviceControlCommandService>();
            _deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>();
        }

        public async Task<IEnumerable<ControlCmd>> ProcessAsync(IEnumerable<ControlQuery> controlQueries)
        {
            try
            {
                //var sw = new Stopwatch();
                //sw.Start();
                if (controlQueries == null) throw new ArgumentNullException(nameof(controlQueries));
                var queries = controlQueries as ControlQuery[] ?? controlQueries.ToArray();
                var enumerable = controlQueries as ControlQuery[] ?? queries.ToArray();
                if (!enumerable.Any()) return null;
                var facCodes = queries.Select(que => que.FacilityCode);
                var devControlCmds = new List<DeviceControlCommandDto>();
                var codes = facCodes as string[] ?? facCodes.ToArray();
                if (codes.Any())
                {
                    codes.ToList().ForEach(facCode =>
                    {
                        var devCmd = _controlCommandService.GetDeviceControlCmdsByFacilityId(facCode);
                        if (devCmd != null && devCmd.Count > 0)
                        {
                            devControlCmds.AddRange(devCmd);
                        }
                    });
                }
                //var devControlCmds =
                //    facCodes.SelectMany(facCode => _controlCommandService.GetDeviceControlCmdsByFacilityId(facCode).ToList());
                var cmds = new List<ControlCmd>();
                if (!devControlCmds.Any() || devControlCmds.Count <= 0) return null;
                devControlCmds.ForEach(async cmdDb =>
                {
                    if (cmdDb.Status != (int) DeviceCommandTypeEnum.Created) return;
                    var devControlConmand =
                        await _controlCommandService.GetDeviceControlCmdByIdAsny(cmdDb.Serialnum);
                    devControlConmand.Status = (int) DeviceCommandTypeEnum.Getted;
                    //接收到来自客户端的控制指令请求的时候，状态变为1
                    devControlConmand.UpdateTime = DateTime.Now;
                    var result = _controlCommandService.UpdateControlCommandAsny(devControlConmand);
                    var device = await _deviceService.GetDeviceByIdAsny(cmdDb.DeviceSerialnum);
                    //根据设备编码获取控制设备
                    var cmd = new ControlCmd
                    {
                        Serialnum = cmdDb.Serialnum,
                        FacilityCode = device.FacilitySerialnum,
                        DeviceCode = cmdDb.DeviceSerialnum,
                        Command = Convert.ToInt32(cmdDb.Command),
                        Time = cmdDb.CreateTime,
                        ContinueTime = cmdDb.ControlContinueTime,
                    };
                    cmds.Add(cmd);
                    LogHelper.Info("[查询控制指令]设备{0}指令：{1}", cmd.DeviceCode, cmd.Command);
                });
                //sw.Stop();
                //ServiceLogger.Current.WriteDebugLog("处理控制指令花费的时间为：{0}", sw.ElapsedMilliseconds);
                return cmds;
            }
            catch (Exception ex)
            {
                LogHelper.Error("查询控制指令出错,错误内容：{0}", ex.ToString());

                return null;
            }
        }
    }
}