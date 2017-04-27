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

namespace SmartIot.Tool.Core.Device.LedDevice.YXTD
{
    /// <summary>
    /// 圆心TW10-3
    /// </summary>
    public class YXTDNew : ILedDevice
    {
        private TransportTypeEnum _transportType;

        public YXTDNew()
        {
            Name = "圆心TDNEW显示屏";
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

            if (this.Host.StartsWith("COM"))
                _transportType = TransportTypeEnum.Rs232;
            else
                _transportType = TransportTypeEnum.Tcp;
        }

        public bool Display(string message)
        {
            try
            {
                TDLedAccess.SS_Open_Tcp(Host, this.Args, 3000);
                TDLedAccess.SS_Send_Buffer_Ex(0, 9, 5, 5, 24, 1, message, false);
                TDLedAccess.SS_Close();
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
                TDLedAccess.SS_Open_Tcp(Host, this.Args, 3000);
                XTrace.WriteLine("打开显示屏：{0}:{1}", this.Host, this.Args);

                var list = messageList.OrderBy(item => item.Item1);
                foreach (var message in list)
                {
                    var position = message.Item1;
                    TDLedAccess.SS_Send_Buffer_Ex(position, 9, 5, 5, 16, 1, message.Item2, false);
                    XTrace.WriteLine("发送内容：[{0}]{1}", position, message.Item2);
                }

                TDLedAccess.SS_Close();
                XTrace.WriteLine("关闭显示屏");
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