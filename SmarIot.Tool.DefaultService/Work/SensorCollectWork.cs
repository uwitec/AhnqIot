#region Code File Comment

// SOLUTION   ： AWIOT - Device
// PROJECT    ： SmartIot.Tool.DefaultService
// FILENAME   ： CollectWork.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-30 10:16
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

#region using namespace

using SmartIot.Tool.Core.Common;
using SmartIot.Tool.Core.Device.CollectDevice;
using SmartIot.Tool.Core.Device.Transport;
using SmartIot.Tool.DefaultService.Core;
using SmartIot.Tool.DefaultService.DB;
using SmartIot.Service.Core;
using NewLife.Net.Modbus;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using AhnqIot.Infrastructure.Log;
using NewLife.Threading;

#endregion using namespace

namespace SmartIot.Tool.DefaultService.Work
{
    /// <summary>
    /// 传感器数据采集
    /// </summary>
    public sealed class SensorCollectWork : Job
    {
        private TimerX _uploadDataTimer;

        public SensorCollectWork()
        {
            DisplayName = "传感器数据采集工作组件";
            Sort = 1;

            if (Setting.Current.CollectEnable)
            {
                JobInterval = Setting.Current.CollectInterval;
            }
            else
            {
                JobInterval = -1; //禁用此组件
            }
        }

        public override bool Work()
        {
            Collect();
            //上传设备历史数据
            if (Setting.Current.UploadDeviceDataEnable)
            {
                Console.WriteLine("上传设备数据组件启动...");
                var time = Setting.Current.UploadDeviceDataInterval*60;
                // 定时器一分钟后启动
                _uploadDataTimer = new TimerX(UploadClient.Upload, null, 5*1000, time*1000);
            }

            return base.Work();
        }

        public override bool Stop()
        {
            if (_uploadDataTimer != null)
            {
                _uploadDataTimer.Dispose();
            }
            return base.Stop();
        }

        private static void Collect()
        {
#if DEBUG
            var sw = new Stopwatch();
            sw.Start();
#endif
            var batchNo = DateTime.Now.ToString("yyyyMMddHHmm");
            CommunicateDevice.FindAll().ForEach(com =>
            {
                //var key = "{0}://{1}:{2}-{3}".F(com.CommunicateDeviceTypeName, com.Args1, com.Args2, com.Args3);
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

                var modulars = com.ModularDevices;
                if (modulars != null && modulars.Count > 0)
                {
                    modulars.ForEach(modular =>
                    {
                        var deviceUnits = modular.SensorDeviceUnits;
                        if (deviceUnits != null && deviceUnits.Count > 0)
                        {
                            //按Function分组
                            deviceUnits.ToList().GroupBy(s => s.Function).ToList().ForEach(functionGp =>
                            {
                                var function = functionGp.Key;

                                var dataType = modular.ProtocalTypeName;
                                if (!dataType.EqualIgnoreCase(ProtocalTypeEnum.MODBUS.ToString())) return;
                                var modbusFunction = (MBFunction) Convert.ToByte(function);
                                var collectDevice = new ModbusCollectDevice(transport,
                                    Convert.ToByte(modular.Address), modbusFunction)
                                {
                                    Registers = functionGp.ToList().SelectMany(deviceUnit =>
                                    {
                                        var start = Convert.ToInt32(deviceUnit.RegisterAddress);
                                        var count = deviceUnit.RegisterSize;
                                        var addrs = Enumerable.Range(start, count);
                                        return addrs;
                                    }).ToList()
                                };

                                var result = false;
                                try
                                {
                                    collectDevice.EnsureTransport(transport);
                                    result = collectDevice.Read();
                                    while (!result)
                                    {
                                        collectDevice.EnsureTransport(transport);
                                        result = collectDevice.Read();
                                        if (result == true)
                                        {
                                            break;
                                        }
                                    }
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
                                //读数据，重试三次
                                //for (var i = 0; i < 3; i++)
                                //{
                                //    try
                                //    {
                                //        collectDevice.EnsureTransport(transport);
                                //        result = collectDevice.Read();
                                //        break;
                                //    }
                                //    catch (ObjectDisposedException odx)
                                //    {
                                //        ServiceLogger.Current.WriteException(odx);

                                //        //重新构建transport
                                //        transport = TransportFactory.GetTransport(type, host, e, timeout);
                                //    }
                                //    catch (Exception ex)
                                //    {
                                //        ServiceLogger.Current.WriteException(ex);
                                //    }
                                //    ServiceLogger.Current.WriteWarn("第{3}次读取{0}:{1}地址为{2}数据失败", host, e, modular.Address, (i + 1));
                                //}

                                if (result)
                                {
                                    //保存到数据库
                                    var minReg = collectDevice.Registers.Min();
                                    functionGp.ToList().ForEach(deviceUnit =>
                                    {
                                        var regAddr = Convert.ToInt32(deviceUnit.RegisterAddress);
                                        var size = deviceUnit.RegisterSize;
                                        //根据起始地址和数量计算出数值
                                        var value =
                                            collectDevice.Values.Skip(regAddr - minReg)
                                                .Take(size)
                                                .Sum(Convert.ToInt32);

                                        //判断是否为负数，负数取反+1，气象站温度使用
                                        if ((value & 0x8000) > 0)
                                        {
                                            //此传感器值为负数，需特殊处理
                                            var val = ~(Convert.ToInt16(value & 0x7fff)) & 0x7fff;
                                            value = Convert.ToInt16(val + 1)*(-1);
                                        }
                                        //根据传感器的计算公式，转换成实际值
                                        var sensor = deviceUnit.Sensor;
                                        if (sensor != null)
                                        {
                                            var compute = sensor.ValueComputeString;
                                            var processValue = ComputeHelper.CalcValue(compute, value,
                                                sensor.Accuracy);

                                            deviceUnit.OriginalValue = value;
                                            //异常数据显示处理
                                            //Random random = new Random(DateTime.Now.Millisecond);
                                            //if(processValue>deviceUnit.Sensor.ExperienceMax&&
                                            //    processValue<deviceUnit.Sensor.ExperienceMin)
                                            //{
                                            //    //deviceUnit.ProcessedValue = random.Next(Convert.ToInt32(processValue), Convert.ToInt32(processValue +2));//随机范围为上次处理值左右
                                            //    deviceUnit.ProcessedValue = processValue;
                                            //    deviceUnit.ShowValue = sensor.ValueComputeString.IsNullOrWhiteSpace()
                                            //    ? deviceUnit.ProcessedValue.ToString()
                                            //    : ComputeHelper.CalcString(sensor.ValueComputeString, value);
                                            //}
                                            deviceUnit.ProcessedValue = processValue;
                                            deviceUnit.ShowValue = sensor.ValueComputeString.IsNullOrWhiteSpace()
                                                ? deviceUnit.ProcessedValue.ToString(CultureInfo.InvariantCulture)
                                                : ComputeHelper.CalcString(sensor.ValueComputeString, value);
                                            deviceUnit.UpdateTime = DateTime.Now;
                                            deviceUnit.Save();
                                            LogHelper.Debug("更新传感器实时数据 {0} {1}", deviceUnit.Name,
                                                deviceUnit.ProcessedValue);

                                            var dd = new DeviceData
                                            {
                                                Code1 = deviceUnit.FacilitySensorDeviceUnits[0].Code1,
                                                //暂时设定一个传感器设备只属于一个设施
                                                SensorDeviceUnitID = deviceUnit.ID,
                                                OriginalValue = deviceUnit.OriginalValue,
                                                ProcessedValue = deviceUnit.ProcessedValue,
                                                ShowValue = deviceUnit.ShowValue,
                                                Max = sensor.ExperienceMax,
                                                Min = sensor.ExperienceMin,
                                                Upload = false,
                                                CreateTime = DateTime.Now,
                                                Remark = batchNo
                                            };
                                            //测量值
                                            //if (dd.ProcessedValue > sensor.MaxValue || dd.ProcessedValue < sensor.MinValue)
                                            //    dd.IsException = true;
                                            //经验值:超过经验值即为超出设定上下限
                                            if (dd.ProcessedValue > sensor.ExperienceMax ||
                                                dd.ProcessedValue < sensor.ExperienceMin)
                                                dd.IsException = true;
                                            dd.Save();
                                            //ServiceLogger.Current.WriteDebugLog("添加历史数据 {0} {1}", deviceUnit.Name,
                                            //    deviceUnit.ProcessedValue);
                                        }
                                        else
                                        {
                                            LogHelper.Error("ID ={0} {1} 未配置传感器", deviceUnit.ID,
                                                deviceUnit.Name);
                                        }
                                    });
                                }
                                else
                                {
                                    LogHelper.Error("读取设备数据失败");
                                }
                            });
                        }
                    });
                }
            });

#if DEBUG
            sw.Stop();
            LogHelper.Debug("传感器采集耗时" + sw.ElapsedMilliseconds.ToString() + "ms");
#endif
        }
    }
}