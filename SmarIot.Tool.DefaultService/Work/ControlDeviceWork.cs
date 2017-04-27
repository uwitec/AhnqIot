#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.DefaultService
// FILENAME   ： ControlWork.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-08-06 0:31
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Api.Protocal.Meta.Request.DataContent.ControlDataRequest;
using SmartIot.Tool.API.Common;
using SmartIot.Tool.API.Transport;
using SmartIot.Tool.Core.Device.ControlDevice;
using SmartIot.Tool.Core.Device.Transport;
using SmartIot.Tool.DefaultService.API;
using SmartIot.Tool.DefaultService.Core;
using SmartIot.Tool.DefaultService.DB;
using SmartIot.Service.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using AhnqIot.Infrastructure.Log;
using SmartIot.Tool.API.Core;
using SmartIot.Tool.Core.Common;

namespace SmartIot.Tool.DefaultService.Work
{
    public sealed class ControlDeviceWork : Job
    {
        private IApiTransport _transport;
        private readonly IFacilityApi _facilityApi = new FacilityApi();
#if DEBUG
        private Timer _controlTimer;
#else
        private Timer _controlTimer;
#endif

        /// <summary>
        /// 扫描控制指令间隔
        /// </summary>
        public int ControlCommandInterval { get; set; }

        public ControlDeviceWork(Timer controlTimer)
        {
            _controlTimer = controlTimer;
            DisplayName = "控制设备组件";
            Sort = 3;

            if (Setting.Current.ControlEnable)
            {
                JobInterval = Setting.Current.ControlCommandInterval;
            }
            else
            {
                JobInterval = -1; //禁用此组件
            }
            //ControlCommandInterval = Config.GetConfig<int>("ControlCommandInterval", 5);
            //JobInterval = ControlCommandInterval;
        }

        public override bool Start()
        {
            _transport = ApiTransportHelper.GetTransport();
            return base.Start();
        }

        public override bool Work()
        {
            GetControlCommand();

            return base.Work();
        }

        public override bool Stop()
        {
            if (_transport != null && !_transport.Disposed)
                _transport.Dispose();
            return base.Stop();
        }

        /// <summary>
        /// 获取控制指令
        /// </summary>
        private List<DeviceControlCommand> GetControlCommand()
        {
            var controlDevices = ControlDeviceUnit.FindAllWithCache().ToList();
            if (!controlDevices.Any() && controlDevices == null) return null;
            //查询出Code1不为空的基地
            var farms = Farm.FindAll().ToList().Where(f => !f.Code1.IsNullOrWhiteSpace());
            var devCommands = new List<DeviceControlCommand>();
            //校验所有编码
            var enumerable = farms as Farm[] ?? farms.ToArray();
            if (!CheckCode(enumerable)) return null;
            enumerable.ToList().ForEach(farm =>
            {
                //本地数据库中的设施
                var facilitysInDb = farm.Facilitys;
                ////从接口获存在的设施
                //var facs_platform = GetPlatformFacilitys(farm);
                if (facilitysInDb.Count > 0)
                {
                    facilitysInDb.ToList().ForEach(fInDb =>
                    {
                        var entity = AwEntityHelper.GetEntity(farm.Code1);
#if DEBUG
                        var sw = new Stopwatch();
                        var accessResult = false;
                        sw.Start();
#endif
                        var cmds = _facilityApi.GetControlCommand(entity, _transport, fInDb.Code1);

                        var controlCmds = cmds as IList<ControlCmd> ?? cmds.ToList();
                        if (controlCmds.Any())
                        {
                            accessResult = true;
                            controlCmds.ToList().ForEach(cmdDb =>
                            {
                                var devCommand = new DeviceControlCommand
                                {
                                    Code1 = cmdDb.Serialnum,
                                    Command = cmdDb.Command.ToString(),
                                    ControlContinueTime = cmdDb.ContinueTime,
                                    CreateTime = DateTime.Now,
                                    ControlDeviceUnitGroupNum =
                                        FacilityControlDeviceUnit.FindAllByCode1(cmdDb.DeviceCode)[0]
                                            .ControlDeviceUnitGroupNum
                                };
                                devCommand.Save(); //保存到本地数据库
                                devCommands.Add(devCommand);
                            });
                        }
                        else
                        {
                            accessResult = false;
                            //Debugger.Break();
                        }
                        LogHelper.Debug("{0}获取控制指令{1}条", fInDb.Name, controlCmds.Count());
#if DEBUG
                        sw.Stop();
                        var apiAccesslog = new ApiAccessLog
                        {
                            ApiName = "获取控制指令",
                            Result = accessResult,
                            CreateTime = DateTime.Now,
                            CostTime = Convert.ToInt32(sw.ElapsedMilliseconds)
                        };
                        apiAccesslog.Save();
                        LogHelper.Debug("获取控制指令花费的时间：{0}", sw.ElapsedMilliseconds.ToString());
#endif
                    });
                }
            });
            if (!devCommands.Any()) return devCommands;
            var sw1 = new Stopwatch();
            sw1.Start();
            devCommands.ForEach(cmd =>
            {
                LogHelper.Debug("正在执行控制指令");
                Control(
                    FacilityControlDeviceUnit.FindAllByControlDeviceUnitGroupNum(cmd.ControlDeviceUnitGroupNum)[0]
                        .ControlDeviceUnitGroupNum, Convert.ToInt32(cmd.Command));
                Thread.Sleep(50);
            });
            sw1.Stop();
            LogHelper.Debug("执行所有控制指令花费的时间：{0}", sw1.ElapsedMilliseconds.ToString());
            return devCommands;
        }

        /// <summary>
        /// 控制设备
        /// </summary>
        /// <param name="deviceId">控制设备ID</param>
        /// <param name="status">设备状态</param>
        private void Control(int deviceId, int status)
        {
            const bool result = false;
            List<FacilityControlDeviceUnit> fac = FacilityControlDeviceUnit.FindAllByControlDeviceUnitGroupNum(deviceId);
            if (fac == null || !fac.Any()) return;
            var device = ControlDeviceUnit.FindByID(deviceId);
            if (device == null) return;
            string reason = null;
            TransportTypeEnum type;
            if (
                !Enum.TryParse(device.ModularDevice.CommunicateDevice.CommunicateDeviceTypeName,
                    true, out type))
            {
                type = TransportTypeEnum.Unknow;
            }
            var host = device.ModularDevice.CommunicateDevice.Args1;
            var e = Convert.ToInt32(device.ModularDevice.CommunicateDevice.Args2);
            var timeout = Convert.ToInt32(device.ModularDevice.CommunicateDevice.Args3);
            //获取Transport
            var transport = TransportFactory.GetTransport(type, host, e, timeout);
            var modbusControlDevice = new ModbusControlDevice(transport,
                Convert.ToByte(device.ModularDevice.Address));
            try
            {
                //待编写控制指令

                //if (device.IsComposite) //三态设备  正转  反转  停止
                //{
                //    if (status == -1)
                //    {
                //        result = modbusControlDevice.Write(device.RegisterAddress1, true);
                //    }
                //    else if (status == 0)
                //    {
                //        result = modbusControlDevice.Write(device.RegisterAddress1, false);
                //        result = modbusControlDevice.Write(device.RegisterAddress2, false);
                //    }
                //    else if (status == 1)
                //    {
                //        result = modbusControlDevice.Write(device.RegisterAddress2, true);
                //    }
                //}
                //else //两态设备 开 关
                //{
                //    result = modbusControlDevice.Write(device.RegisterAddress1, status == 1 ? true : false);
                //}
            }
            catch (Exception ex)
            {
                reason = ex.ToString();
            }
            LogHelper.Debug("指令执行" + (result ? "成功" : "失败"));

            DeviceControlCommand.FindAllByControlDeviceUnitID(deviceId).ToList().ForEach(deviceControlCommand =>
            {
                var controlResult = new ControlResult
                {
                    Serialnum = deviceControlCommand.Code1,
                    //Command = status,
                    //FacilityCode = fac[0].Facility.Code1,
                    //DeviceCode = fac[0].Code1,
                    //ContinueTime = 5,
                    Time = DateTime.Now,
                    Result = result,
                    FailReason = reason
                };
                var devControlLog = new DeviceControlLog
                {
                    Code1 = deviceControlCommand.Code1,
                    ControlDeviceUnitID = deviceControlCommand.ControlDeviceUnitGroupNum,
                    ControlResult = result,
                    CreateTime = DateTime.Now,
                    DeviceControlCommand = deviceControlCommand,
                    DeviceControlCommandID = deviceControlCommand.ID,
                    DeviceValue = Convert.ToInt32(CalcControlDeviceValue.CalcProcessValue(fac[0])),
                    ShowValue = CalcControlDeviceValue.CalcOriginal(fac[0]).ToString(),
                    FailReason = reason
                };
                devControlLog.Save();
                UploadControlCommand(controlResult, fac[0].Facility); //上传控制指令
                Thread.Sleep(50);
            });
        }

        /// <summary>
        /// 上传控制指令
        /// </summary>
        /// <returns></returns>
        private void UploadControlCommand(ControlResult controlResult, Facility fac)
        {
#if DEBUG
            var sw = new Stopwatch();
            var accessResult = false;
            sw.Start();
#endif
            try
            {
                var entity = AwEntityHelper.GetEntity(fac.Farm.Code1);
                var result = _facilityApi.UploadControlResult(entity, _transport, controlResult);
                LogHelper.Debug("上传控制结果成功 " + (result ? "成功" : "失败"));
                accessResult = result;
            }
            catch (Exception ex)
            {
                LogHelper.Debug("上传控制结果失败," + ex.Message);
            }
#if DEBUG
            sw.Stop();
            var apiAccesslog = new ApiAccessLog
            {
                ApiName = "上传控制结果",
                Result = accessResult,
                CreateTime = DateTime.Now,
                CostTime = Convert.ToInt32(sw.ElapsedMilliseconds)
            };
            apiAccesslog.Save();
            LogHelper.Debug("控制结果上传耗时：" + sw.ElapsedMilliseconds + "ms");
#endif
            //return true;
        }

        private static bool CheckCode(IEnumerable<Farm> farms)
        {
            return true;
        }
    }
}