#region Code File Comment

// SOLUTION   ： AWIOT - Device
// PROJECT    ： SmartIot.Tool.Core
// FILENAME   ： YXTW103Device.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-10-08 17:29
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Tool.Core.Device.Transport;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartIot.Tool.Core.Device.LedDevice.YXTW103
{
    /// <summary>
    /// 圆心TW10-3
    /// </summary>
    public class YXTW103Device : ILedDevice
    {
        private TransportTypeEnum transportType;

        public YXTW103Device()
        {
            Name = "圆心TW10-3显示屏";
        }

        public string Host { get; set; }

        public int Args { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }

        public void Init(string host, int args = 0)
        {
            this.Host = host;
            this.Args = args;

            transportType = this.Host.StartsWith("COM") ? TransportTypeEnum.Rs232 : TransportTypeEnum.Tcp;
        }

        public bool Display(string message)
        {
            try
            {
                var transport = TransportFactory.CreateTransport(transportType, this.Host, this.Args, 5000);
                var data = new SendRam().GetBytes(message);
                transport.Send(data);
                transport.Dispose();
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
                var transport = TransportFactory.CreateTransport(transportType, this.Host, this.Args, 5000);
                var data =
                    new SendRam().GetBytes(
                        messageList.OrderBy(item => item.Item1).Select(message => message.Item2).Join(" "));
                transport.Send(data);
                transport.Dispose();
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