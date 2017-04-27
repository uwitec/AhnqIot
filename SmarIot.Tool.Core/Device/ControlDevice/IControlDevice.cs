using System.Collections.Generic;

namespace SmartIot.Tool.Core.Device.ControlDevice
{
    public interface IControlDevice
    {
        /// <summary>
        /// 主机地址。用于485编码
        /// </summary>
        byte Host { get; set; }

        List<int> Registers { get; set; }

        List<bool> Values { get; set; }

        bool Read();

        bool Write(int addr, bool status);

        bool Write(int addr, bool[] status);
    }
}