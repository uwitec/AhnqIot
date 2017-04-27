using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartIot.Tool.Core.Device.LedDevice.LXLed
{
    /// <summary>
    /// 灵信LED设备
    /// </summary>
    public class LXDevice : ILedDevice
    {
        public LXDevice()
        {
            Name = "灵信LED显示屏";
        }

        /// <summary>
        /// LED屏IP地址，无需关注端口号
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 此参数不可用
        /// </summary>
        public int Args
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }

        public void Init(string host, int args = 0)
        {
            this.Host = host;
        }

        public bool Display(string message)
        {
            try
            {
                var ledHelper = new LedHelper();
                ledHelper.Start(this.Host);
                ledHelper.AddNeimaArea(true, message);
                ledHelper.Send();
                return true;
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
                return false;
            }
        }

        public bool Display(List<Tuple<int, string>> messageList)
        {
            try
            {
                var ledHelper = new LedHelper();
                ledHelper.Start(this.Host);
                messageList.OrderBy(item => item.Item1)
                    .ToList().ForEach(message => { ledHelper.AddNeimaArea(true, message.Item2); });
                ledHelper.Send();
                return true;
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
                return false;
            }
        }
    }
}