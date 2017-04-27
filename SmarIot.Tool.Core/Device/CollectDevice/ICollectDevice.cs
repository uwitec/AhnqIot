using NewLife.Net.Modbus;
using System;
using System.Collections.Generic;

namespace SmartIot.Tool.Core.Device.CollectDevice
{
    public interface ICollectDevice
    {
        /// <summary>
        /// 主机地址。用于485编码
        /// </summary>
        byte Host { get; set; }

        MBFunction Function { get; set; }

        List<int> Registers { get; set; }

        List<UInt16> Values { get; set; }

        bool Read();
    }
}