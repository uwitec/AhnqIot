#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.DefaultService
// FILENAME   ： ControlWork.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-08-06 0:31
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Tool.API.Common;
using SmartIot.Tool.API.Transport;
using SmartIot.Tool.Core.Common;
using SmartIot.Tool.Core.Device.ControlDevice;
using SmartIot.Tool.Core.Device.Transport;
using SmartIot.Tool.DefaultService.API;
using SmartIot.Tool.DefaultService.Core;
using SmartIot.Tool.DefaultService.DB;
using SmartIot.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using AhnqIot.Infrastructure.Log;

namespace SmartIot.Tool.DefaultService.Work
{
    public sealed class ControlCollectWork : Job
    {
        private readonly IFacilityApi _facilityApi = new FacilityApi();
        private IApiTransport _transport;

        public ControlCollectWork(IApiTransport transport)
        {
            _transport = transport;
            DisplayName = "控制设备状态检测组件";
            Sort = 2;

            if (Setting.Current.CollectEnable)
            {
                JobInterval = Setting.Current.ControlCollectInterval;
            }
            else
            {
                JobInterval = -1; //禁用此组件
            }
        }

        public override bool Work()
        {
            Collect();
            return base.Work();
        }

        /// <summary>
        /// 采集控制设备状态
        /// </summary>
        private static void Collect()
        {
            CommunicateDevice.FindAllWithCache().ForEach(com =>
            {
                var key = "{0}://{1}:{2}".F(com.CommunicateDeviceTypeName, com.Args1, com.Args2);
                TransportTypeEnum type;
                if (!Enum.TryParse(com.CommunicateDeviceTypeName, true, out type))
                {
                    type = TransportTypeEnum.Unknow;
                }
                var host = com.Args1;
                var e = Convert.ToInt32(com.Args2);
                var timeout = Convert.ToInt32(com.Args3);
                //获取Transport
                var transport = TransportFactory.GetTransport(type, host, e, timeout);

                if (transport != null)
                {
                    var modulars = com.ModularDevices;
                    if (modulars != null && modulars.Count > 0)
                    {
                        modulars.ForEach(modular =>
                        {
                            var controlDevices = modular.ControlDeviceUnits;
                            if (controlDevices != null && controlDevices.Count > 0)
                            {
                                var dataType = modular.ProtocalTypeName;
                                if (dataType.EqualIgnoreCase(ProtocalTypeEnum.MODBUS.ToString()))
                                {
                                    var modbusControlDevice = new ModbusControlDevice(transport,
                                        Convert.ToByte(modular.Address))
                                    {
                                        Registers = controlDevices.ToList().SelectMany(controlDeviceUnit =>
                                        {
                                            var addrs = new List<int>
                                            {
                                                Convert.ToInt32(controlDeviceUnit.RegisterAddress1)
                                            };
                                            //添加第一个
                                            //如果是组合设备添加第二个
                                            //if (controlDeviceUnit.IsComposite)
                                            //    addrs.Add(Convert.ToInt32(controlDeviceUnit.RegisterAddress2));
                                            return addrs;
                                        }).ToList()
                                    };

                                    //读数据，重试三次
                                    var result = false;
                                    for (var i = 0; i < 3; i++)
                                    {
                                        try
                                        {
                                            modbusControlDevice.EnsureTransport(transport);
                                            result = modbusControlDevice.Read();
                                            break;
                                        }
                                        catch (ObjectDisposedException odx)
                                        {
                                            LogHelper.Fatal(odx.ToString());

                                            //重新构建transport
                                            transport = TransportFactory.GetTransport(type, host, e, timeout);
                                        }
                                        catch (Exception ex)
                                        {
                                            LogHelper.Fatal(ex.ToString());
                                        }
                                        LogHelper.Debug("第{3}次读取{0}:{1}地址为{2}数据失败", host, e,
                                            modular.Address, (i + 1));
                                    }

                                    if (result)
                                    {
                                        //处理设备状态
                                        //保存到数据库
                                        var minReg = modbusControlDevice.Registers.Min();
                                        controlDevices.ForEach(controlDevice =>
                                        {
                                            var regAddr = Convert.ToInt32(controlDevice.RegisterAddress1);
                                            var value1 =
                                                modbusControlDevice.Values.Skip(regAddr - minReg).Take(1).ElementAt(0);
                                            var value = 0; //控制设备当前状态

                                            //if (controlDevice.IsComposite)
                                            //{
                                            //    var regAddr2 = Convert.ToInt32(controlDevice.RegisterAddress1);
                                            //    var value2 = modbusControlDevice.Values.Skip(regAddr2 - minReg).Take(1).ElementAt(0);
                                            //    //controlDevice.OriginalValue = (value1 << 8) + value2;
                                            //    if (value1 && !value2)
                                            //    {
                                            //        value = 0xFF00;
                                            //        controlDevice.ProcessedValue = "正转";
                                            //    }
                                            //    else if (!value1 && value2)
                                            //    {
                                            //        value = 0;
                                            //        controlDevice.ProcessedValue = "停止";
                                            //    }
                                            //    else if (!value1 && !value2)
                                            //    {
                                            //        value = 0X00FF;
                                            //        controlDevice.ProcessedValue = "反转";
                                            //    }
                                            //}
                                            //else
                                            //{
                                            value = value1 ? 1 : 0;
                                            //}
                                            controlDevice.OriginalValue = value;
                                            controlDevice.ProcessedValue =
                                                CalcControlDeviceValue.CalcProcessValue(
                                                    controlDevice.FacilityControlDeviceUnits[0]);
                                            controlDevice.UpdateTime = DateTime.Now;
                                            controlDevice.Save();
                                            //执行控制
                                            //bool success= control(value,controldevice.id);
                                            // if(success)
                                            // {
                                            //     servicelogger.current.writelog("设备控制成功");
                                            // }
                                            // else
                                            // {
                                            //     servicelogger.current.writeerror("设备控制失败");
                                            // }
                                        });
                                    }
                                    else
                                    {
                                        LogHelper.Error("读取设备控制数据失败");
                                    }
                                }
                            }
                        });
                    }
                }
                else
                {
                    //通讯对象创建失败
                    LogHelper.Error("无法创建通讯{0}", key);
                }
            });
        }
    }
}