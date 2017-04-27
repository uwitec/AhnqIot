#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.Core
// FILENAME   ： KDXF.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-08-06 1:19
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Tool.Core.Device.TtsDevice.KdxfProtocal;
using NewLife.Log;
using NewLife.Net;
using System;
using System.Linq;
using System.Text;

namespace SmartIot.Tool.Core.Device.TtsDevice
{
    public class KdxfDevice : ITtsDevice
    {
        private readonly ITransport _transport;

        public KdxfDevice(ITransport transport)
        {
            Name = "科大讯飞";
            this._transport = transport;
        }

        public string Name { get; set; }

        public bool Display(string message)
        {
            var sendText = new SpeechSynthesis {Data = Encoding.Default.GetBytes(message).ToList()};
            //string info = ttsFormat.Replace("{GreenhouseName}", ttsDevice.TtsNode.GreenHouse.GreenHouseName);
            //info = info.Replace("{DeviceName}", device.Name);
            //info = info.Replace("{LatestValue}", device.LatestValue.ToString());
            //info = info.Replace("{LatestProcessedValue}", device.LatestProcessedValue.ToString(CultureInfo.InvariantCulture));
            //info = info.Replace("{LatestTime}", device.LatestTime.ToString(CultureInfo.InvariantCulture));
            //info = info.Replace("{Unit}", device.Sensor.Unit);

            sendText.CalculateExtendData();
            var sendData = sendText.GetStream().ReadBytes();
            try
            {
                _transport.Send(sendData);
                //立即接收语音合成成功的回复
                var buffer = new byte[1];
                _transport.Receive(buffer, 0, 1);
                if (buffer[0] == 0x41)
                {
                    //语音合成成功
                    _transport.Receive(buffer, 0, 1);

                    if (buffer[0] == 0x4F)
                    {
                        //语音合成成功
                        return true;
                    }
                    //语音播报失败
#if DEBUG
                    XTrace.WriteLine("语音播报失败:{0} {1}", Name, message);
#endif
                }
                else
                {
                    //语音合成失败
#if DEBUG
                    XTrace.WriteLine("语音合成失败:{0} {1}", Name, message);
#endif
                }
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
            }
            return false;
        }
    }
}