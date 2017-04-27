#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.DefaultService
// FILENAME   ： LedDisplayWork.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-08-06 1:13
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Tool.Core.Common;
using SmartIot.Tool.Core.Device.Transport;
using SmartIot.Tool.Core.Device.TtsDevice;
using SmartIot.Tool.DefaultService.DB;
using SmartIot.Service.Core;
using System;
using System.Linq;

namespace SmartIot.Tool.DefaultService.Work
{
    public class TtsDisplayWork : Job
    {
        public TtsDisplayWork()
        {
            DisplayName = "TTS展示工作组件";
            Sort = 7;
            if (Setting.Current.TtsEnable)
            {
                JobInterval = Setting.Current.TtsShowInterval * 60;
            }
            else
            {
                JobInterval = -1; //禁用此组件
            }
        }

        public override bool Work()
        {
            Display();

            return base.Work();
        }
        private void Display()
        {
            CommunicateDevice.FindAllWithCache().ForEach(com =>
            {

                ///判断一下是否为TTS设备。。。
                TransportTypeEnum type;
                if (!TransportTypeEnum.TryParse(com.CommunicateDeviceTypeName, true, out type))
                {
                    type = TransportTypeEnum.Unknow;
                }
                var host = com.Args1;
                var e = Convert.ToInt32(com.Args2);
                var timeout = Convert.ToInt32(com.Args3);
                //获取Transport
                var transport = TransportFactory.GetTransport(type, host, e, timeout);

                var kdxf = new KdxfDevice(transport);
                com.ShowDevices.ForEach(showDevice =>
                {
                    var devices = showDevice.ShowDatas.ToList().Select(sd => sd.SensorDeviceUnit);
                    devices.ForEach(dev =>
                    {
                        var message = "{0} {1} {2} {3}".F("", dev.Name, dev.ShowValue, dev.Sensor.Unit);
                        var result = kdxf.Display(message);
                        if (result)
                        {
                            ServiceLogger.Current.WriteDebugLog("播报成功");
                        }
                        else
                        {
                            ServiceLogger.Current.WriteError("语音播报失败：{0}", message);
                        }
                    });
                });
            });
        }
    }
}