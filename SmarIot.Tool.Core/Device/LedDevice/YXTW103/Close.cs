using System;
using System.Collections.Generic;

namespace SmartIot.Tool.Core.Device.LedDevice.YXTW103
{
    public class Close
    {
        public const ushort Command = (ushort) SubCmdType.关机;
        public const byte Response = 0x1B;

        /// <summary>
        /// 485地址
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public byte[] GetBytes(byte addr = 1)
        {
            var list = new List<byte> {0xAA, addr, 0xBB, Convert.ToByte(Command >> 8), Convert.ToByte(Command & 0xFF)};
            //功能码

            return list.ToArray();
        }
    }
}