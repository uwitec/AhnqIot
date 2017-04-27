#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.DefaultService
// FILENAME   ： LedDisplayWork.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-08-06 1:13
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Tool.Core.Device.LedDevice;
using SmartIot.Tool.DefaultService.DB;
using SmartIot.Service.Core;
using System;
using System.Linq;
using SmartIot.Tool.Core.Common;

namespace SmartIot.Tool.DefaultService.Work
{
    public class LedDisplayWork : Job
    {
        public LedDisplayWork()
        {
            DisplayName = "LED展示工作组件";
            Sort = 6;
            if (Setting.Current.LedEnable)
            {
                JobInterval = Setting.Current.LedShowInterval * 60;
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
                com.ShowDevices.ForEach(showDevice =>
                {
                    var cardType = showDevice.ShowDeviceType;
                    var ledType = LedDeviceFactory.GetLedDeviceType(cardType.Name);
                    ILedDevice ledDevice = LedDeviceFactory.CreateLedDevice(ledType);
                    if (ledDevice != null)
                        try
                        {
                            var host = com.Args1;
                            var args = Convert.ToInt32(com.Args2);
                            ledDevice.Init(host, args);
                            var maxPosition = 0;
                            var messageList = showDevice.ShowDatas.ToList()
                                .Select(sd =>
                                {
                                    var dev = sd.SensorDeviceUnit;
                                    var position = sd.Position;
                                    var info = dev.ShowValue;
                                    if (info == "负无穷大")
                                    {
                                        info = "";
                                    }
                                    if (dev.Sensor.Name.Contains("雨雪"))
                                    {
                                        info = dev.ProcessedValue == 1M ? "有" : "无";
                                    }
                                    if (dev.Sensor.Name.Contains("风向"))
                                    {
                                        info = JudgWindDirection(dev.ProcessedValue);
                                        dev.Sensor.Unit = "";//发送到屏幕上去除风向的单位
                                    }
                                    if (position > maxPosition)
                                    {
                                        maxPosition = position;
                                    }
                                    return new Tuple<int, string>(position, string.Format("{0}:{1}{2}", dev.Name, info, dev.Sensor.Unit));
                                }).ToList();

                            if (!Setting.Current.LedAttactInfo.IsNullOrWhiteSpace())
                            {
                                messageList.Add(new Tuple<int, string>(maxPosition + 1, Setting.Current.LedAttactInfo));
                            }
                            ledDevice.Display(messageList);
                            ServiceLogger.Current.WriteDebugLog("LED发送成功，{0}:{1}", com.Args1, com.Args2);
                        }
                        catch (Exception ex)
                        {
                            ServiceLogger.Current.WriteError("发送LED失败，" + ex.Message);
                            ServiceLogger.Current.WriteException(ex);
                        }
                });
            });
        }
        /// <summary>
        /// 判断风向
        /// </summary>
        /// <returns></returns>
        private string JudgWindDirection(decimal value)
        {
            string info="";
            if (value < 10 && value > 350)
            {
                info = "正北";
            }
            if (value >= 10 && value <= 80)
            {
                info = "东北";
            }
            if (value > 80 && value < 100)
            {
                info = "正东";
            }
            if (value >= 100 && value <= 170)
            {
                info = "东南";
            }
            if (value > 170 && value < 190)
            {
                info = "正南";
            }
            if (value >= 190 && value <= 260)
            {
                info = "西南";
            }
            if (value > 260 && value < 280)
            {
                info = "正西";
            }
            if (value >= 280 && value <= 350)
            {
                info = "西北";
            }
            return info;
        }
    }
}