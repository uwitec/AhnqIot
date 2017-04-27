#region Code File Comment

// SOLUTION   ： SmartIot - DeviceCode
// PROJECT    ： SmartIot.API.Processor
// FILENAME   ： ControlDataProcessor.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-10 1:30
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

#region using namespace

using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using Autofac;
using Smart.Redis;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ControlDataRequest;
using SmartIot.API.Processor.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#endregion using namespace

namespace SmartIot.API.Processor.DataObject
{
    public class ControlDataProcessor
    {
        #region 字段

        private static IDeviceControlCommandService _deviceControlCommandService;
        private static IDeviceService _deviceService;
        private static IDeviceControlLogService _deviceControlLogService;
        private static RedisClient _redis;

        #endregion 字段

        static ControlDataProcessor()
        {
            _deviceControlCommandService = AhnqIotContainer.Container.Resolve<IDeviceControlCommandService>();
            _deviceService = AhnqIotContainer.Container.Resolve<IDeviceService>();
            _deviceControlLogService = AhnqIotContainer.Container.Resolve<IDeviceControlLogService>();
            _redis = new RedisClient();
        }

        /// <summary>
        ///  查询控制指令
        /// </summary>
        /// <param name="controlQueries"></param>
        public static XResponseMessage ProcessControlQueries(IEnumerable<ControlQuery> controlQueries)
        {
            var sw = new Stopwatch();
            sw.Start();
            if (controlQueries == null) throw new ArgumentNullException("controlQueries");
            var enumerable = controlQueries as ControlQuery[] ?? controlQueries.ToArray();
            if (enumerable.Any())
            {
                var facCodes = controlQueries.Select(que => que.FacilityCode);
                //var devCmds = _redis.GetVals<DeviceControlCommandDto>("deviceControlCommand", DataType.Protobuf).FindAll(cmd=>cmd.DeviceSerialnum.EqualIgnoreCase());
                var devControlCmds = facCodes.SelectMany(facCode =>
                _deviceControlCommandService.GetDeviceControlCmdsByFacilityId(facCode));

                var cmds = new List<ControlCmd>();
                if (devControlCmds != null && devControlCmds.Count() > 0)
                {
                    devControlCmds.ForEach(async cmdDb =>
                                    {
                                        if (cmdDb.Status == (int)DeviceCommandTypeEnum.Created)
                                        {
                                            //if (cmdDb != null)
                                            //{
                                            var devControlConmand = await _deviceControlCommandService.GetControlCommandByDeviceIdAsny(cmdDb.Serialnum);
                                            devControlConmand.Status = (int)DeviceCommandTypeEnum.Getted; //接收到来自客户端的控制指令请求的时候，状态变为1
                                            devControlConmand.UpdateTime = DateTime.Now;
                                            await _deviceControlCommandService.AddControlCommandAsny(devControlConmand);//添加控制指令
                                                                                                                        //}

                                            var cmd = new ControlCmd
                                            {
                                                Serialnum = cmdDb.Serialnum,
                                                FacilityCode = (await _deviceService.GetDeviceByIdAsny(cmdDb.DeviceSerialnum)).FacilitySerialnum,
                                                DeviceCode = cmdDb.DeviceSerialnum,
                                                Command = Convert.ToInt32(cmdDb.Command),
                                                Time = cmdDb.CreateTime,
                                                ContinueTime = cmdDb.ControlContinueTime,
                                            };
                                            cmds.Add(cmd);
                                        }
                                    });
                }

                sw.Stop();
                ServiceLogger.Current.WriteDebugLog("处理控制指令花费的时间为：{0}", sw.ElapsedMilliseconds);
                return ResultHelper.CreateMessage("", ErrorType.NoError, cmds);
            }
            return ResultHelper.CreateMessage("无控制指令", ErrorType.NoError);
        }

        /// <summary>
        /// 上传控制结果
        /// </summary>
        /// <param name="controlQueries"></param>
        public static XResponseMessage ProcessControlResults(IEnumerable<ControlResult> controlResults)
        {
            if (!controlResults.Any()) throw new ArgumentNullException("controlResults");
            try
            {
                controlResults.ForEach(async controlResult =>
                {
                    var devCommand = await _deviceControlCommandService.GetDeviceControlCmdByIdAsny(controlResult.Serialnum);
                    var device = await _deviceService.GetDeviceByIdAsny(devCommand.DeviceSerialnum);

                    if (devCommand != null)
                    {
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

                        await _deviceControlLogService.AddControlLog(devControlLog);

                        var devControlConmand = await _deviceControlCommandService.GetDeviceControlCmdByIdAsny(devCommand.Serialnum);
                        if (devControlConmand.Status == (int)DeviceCommandTypeEnum.Getted)
                        {
                            if (controlResult.Result)
                            {
                                devControlConmand.Status = (int)DeviceCommandTypeEnum.ActionSuccess;
                                //接收到来自客户端的上传控制指令的时候，控制成功状态变为2
                            }
                            else
                            {
                                devControlConmand.Status = (int)DeviceCommandTypeEnum.ActionError;
                                //接收到来自客户端的上传控制指令的时候，控制失败状态变为3
                            }
                            devControlConmand.UpdateTime = DateTime.Now;
                            await _deviceControlCommandService.UpdateControlCommandAsny(devControlConmand);
                        }
                    }
                });

                return ResultHelper.CreateMessage("", ErrorType.NoError);
            }
            catch (Exception ex)
            {
                return ResultHelper.CreateMessage("", ErrorType.InternalError, null, ex);
            }
        }
    }
}