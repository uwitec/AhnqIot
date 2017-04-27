using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AWIOT.IOTClient.API.Transport;
using AWIOT.IOTClient.Core.Device.CollectDevice;
using AWIOT.IOTClient.Core.Device.Transport;
//using AWIOT.IOTClient.DefaultService.DataSynchronism;
using AWIOT.IOTClient.DefaultService.DB;
using AWIOT.IOTClient.DefaultService.Work;
using AWIOT.Service.Core;
using NewLife.Log;
using NewLife.Net;
using NewLife.Net.Modbus;
using NewLife.Reflection;

namespace AWIOT.IOTClient.DefaultService
{
    public class IotJob : Job
    {
        private IEnumerable<IWork> _works;

        public override string DisplayName { get { return "农气物联网--物联网监控系统默认插件"; } }

        public override bool Start()
        {
            base.Start();
            return false;
            try
            {
                //CreateAllTransport();

                var types = AssemblyX.FindAllPlugins(typeof(IWork), true);
                //var types1=AssemblyX.FindAllPlugins("typeof()")
                _works = types.Select(t => (IWork)TypeX.CreateInstance(t));
                int count = 0;
                foreach (var work in _works)
                    count++;
                ServiceLogger.Current.WriteDebugLog("加载工作IWork插件{0}个：{1}", count, _works.Select(iw => iw.GetType().Name).Join(","));
            }
            catch (Exception ex)
            {
                ServiceLogger.Current.WriteError("加载工作插件IWork失败");
                ServiceLogger.Current.WriteException(ex);
                return false;
            }

            if (_works != null && _works.Any())
            {
                _works.ForEach(iw =>
                {
                    iw.Start();
                    ServiceLogger.Current.WriteLog("{0}开始工作", iw.GetType().Name);
                });
            }
            return true;
        }

        public override bool Stop()
        {
            base.Stop();

            try
            {

            }
            catch (Exception ex)
            {
                WriteLog("{0} 失败", "Stop");
                XTrace.WriteException(ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 创建所有的通讯会话
        /// </summary>
        private void CreateAllTransport()
        {
            var devices = CommunicateDevice.FindAll();
            devices.ForEach(dev =>
            {
                //dynamic args = new ExpandoObject();
                //args.Args1 = dev.Args1;
                //args.Args2 = dev.Args2;
                //var type = (TransportEnum)Enum.Parse(typeof(TransportEnum), dev.CommunicateDeviceTypeName);
                //TransportFactory.CreateTransport(args, type);

                string key = "{0}://{1}:{2}".F(dev.CommunicateDeviceTypeName, dev.Args1, dev.Args2);
                //string key = "{0}://{1}:{2}".F(dev.CommunicateDeviceTypeName, "192.168.0.233", "10001");
                TransportFactory.GetTransport(key);
                ServiceLogger.Current.WriteDebugLog("创建通讯 {0}", key);
            });
        }

        /*
        private bool Collect()
        {
            try
            {
                var netNodes = WsnNodes.FindAllByNodetype(ConstString.NetNodeType);
                if (netNodes != null && netNodes.Count > 0)
                {
                    netNodes.ToList().Where(node => !node.IP.IsNullOrWhiteSpace()).AsParallel().ForEach(node =>
                    {
                        var ip = NetHelper.ParseAddress(node.IP);
#if DEBUG
                        WriteLog("{0} {1}:{2}", node.Name, node.IP, node.Port);
#endif
                        ITransport transport;
                        dynamic obj = new ExpandoObject();
                        try
                        {
                            if (ip == null)
                            {
                                obj.Args1 = node.IP; //串口名
                                obj.Args2 = node.Port; //波特率
                                transport = TransportFactory.CreateTransport(obj, TransportEnum.Tcp);
                            }
                            else
                            {
                                obj.Args1 = ip + ""; //IP地址
                                obj.Args2 = node.Port; //端口号
                                transport = TransportFactory.CreateTransport(obj, TransportEnum.Tcp);
                                var open = transport.Open();
                                if (!open)
                                {
                                    WriteLog("连接打开失败");
                                }
                            }
                        }
                        catch (Exception transportException)
                        {
                            WriteLog("创建通讯异常：{0}", transportException.Message);
                            transport = null;
                        }

                        if (transport == null)
                        {
                            WriteLog("连接创建失败 {0} {1}", node.IP, node.Port);
                        }
                        else
                        {
                            //查询子设备
                            var childs = node.Childs.ToList();
                            var childsGroup = childs.GroupBy(c => c.Mac);
                            childsGroup.ForEach(childGroup =>
                            {
                                var mac = childGroup.Key;
                                if (childGroup.Any())
                                {
                                    childGroup.ForEach(child =>
                                    {
                                        var devices = child.Devices.ToList();
                                        if (devices != null && devices.Count > 0)
                                        {
                                            //按协议类型分组
                                            var protocalTypeGroups = devices.GroupBy(d => d.ProtocalTypeID);
                                            var typeGroups = protocalTypeGroups as IList<IGrouping<int, Device>> ?? protocalTypeGroups.ToList();
                                            if (typeGroups.Any())
                                            {
                                                typeGroups.ForEach(protocalTypeGroup =>
                                                {
                                                    var protocalType = ProtocalType.FindByID(protocalTypeGroup.Key);
                                                    if (protocalType == null)
                                                    {
                                                        //协议类型不存在
                                                        WriteLog("ID={0} 协议类型不存在", protocalTypeGroup.Key);
                                                    }
                                                    else
                                                    {
                                                        ProtocalTypeEnum protocalTypeEnum = ProtocalTypeEnum.UNKNOW;
                                                        protocalTypeEnum = (ProtocalTypeEnum)Enum.Parse(typeof(ProtocalTypeEnum), protocalType.Name, true);

                                                        //按功能码
                                                        var commandGroups = protocalTypeGroup.Where(d => d.Registers != null).GroupBy(d => d.Registers.Command);
                                                        commandGroups.ForEach(commandGroup =>
                                                        {
                                                            //MODBUS协议
                                                            if (protocalTypeEnum == ProtocalTypeEnum.MODBUS)
                                                            {
                                                                byte host = 0;
                                                                if (byte.TryParse(mac, out host))
                                                                {
                                                                    ICollectDevice collectDevice = new ModbusCollectDevice(transport, host, (MBFunction)commandGroup.Key);
                                                                    collectDevice.Registers =
                                                                        commandGroup.Select(d =>
                                                                        {
                                                                            var start = Convert.ToInt32(d.Registers.RegisterAddress);
                                                                            var count = d.Registers.Size;
                                                                            var addrs = Enumerable.Range(start, count);
                                                                            return addrs;
                                                                        }).SelectMany(col => col).ToList();
                                                                    //读数据
                                                                    bool result = false;
                                                                    for (int i = 0; i < 3; i++)
                                                                    {
                                                                        result = collectDevice.Read();
                                                                        if (result) break;
                                                                    }


                                                                    if (result)
                                                                    {
                                                                        //保存到数据库
                                                                        var minReg = collectDevice.Registers.Min();
                                                                        commandGroup.ForEach(d =>
                                                                        {
                                                                            var regAddr = Convert.ToInt32(d.Registers.RegisterAddress);
                                                                            var size = d.Registers.Size;
                                                                            //根据起始地址和数量计算出数值
                                                                            var value = collectDevice.Values.Skip(regAddr - minReg).Take(size).Sum(u => Convert.ToInt32(u));
                                                                            //根据传感器的计算公式，转换成实际值
                                                                            var sensor = d.Sensor;
                                                                            if (sensor != null)
                                                                            {
                                                                                var compute = sensor.ComputeString;

                                                                                var processValue = CalcValue(compute, value);

                                                                                d.LatestValue = value;
                                                                                d.LatestProcessedValue = Math.Round(processValue, 1);
                                                                                d.LatestTime = DateTime.Now;
                                                                                d.Save();

                                                                                WriteLog("更新传感器实时数据 {0} {1}", d.Name, d.LatestProcessedValue, 1);
                                                                            }
                                                                            else
                                                                            {
                                                                                WriteLog("ID ={0} {1} 未配置传感器", d.ID, d.Name);
                                                                            }
                                                                        });
                                                                    }
                                                                    else
                                                                    {
                                                                        WriteLog("读取设备 {0} 数据失败", node.Name);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    WriteLog("{0} 485地址配置错误", node.Name);
                                                                }
                                                            }
                                                        });
                                                    }
                                                });//typeGroups
                                            }
                                        }
                                        else
                                        {
                                            WriteLog("{0} 未配置传感器设备", child.Name);
                                        }
                                    });
                                }//childGroup
                                else
                                {
                                    WriteLog("{0} 未配置采集设备", node.Name);
                                }
                            });

                        }
                    });
                }
                else
                {
                    WriteLog("未找到网络设备");
                }

                return true;
            }
            catch (Exception ex)
            {
                WriteLog("{0} 失败", "Start");
                XTrace.WriteException(ex);
                return false;
            }
        }
        */

    }
}
