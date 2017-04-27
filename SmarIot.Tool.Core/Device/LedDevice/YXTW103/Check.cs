using System;
using System.Collections.Generic;

namespace SmartIot.Tool.Core.Device.LedDevice.YXTW103
{
    public class Check
    {
        public const ushort Command = (ushort) SubCmdType.探测指令;

        /// <summary>
        /// 485地址
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public byte[] GetBytes(byte addr = 1)
        {
            var list = new List<byte> {0xAA, addr, Convert.ToByte(Command & 0xFF)};
            //功能码
            /*
                        if (Command > 0xFF)
                        {
                            list.Add(Convert.ToByte(Command >> 8));
                        }
            */

            return list.ToArray();
        }
    }
}