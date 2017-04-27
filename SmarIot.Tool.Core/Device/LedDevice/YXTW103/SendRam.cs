using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIot.Tool.Core.Device.LedDevice.YXTW103
{
    public class SendRam
    {
        public const ushort Command = (ushort) SubCmdType.发送不保存文字;
        public const byte Response = 0x1B;

        public SendRam()
        {
            Address = 1;
            ShowType = ShowType.左移;
            Speed = 5;
            Delay = 0;
            FontColor = LedFontColor.Red;
            ValidTime = 63;
        }

        /// <summary>
        /// 485地址
        /// </summary>
        public byte Address { get; set; }

        /// <summary>
        /// 播放方式
        /// </summary>
        public ShowType ShowType { get; set; }

        /// <summary>
        /// 速度 0-7
        /// </summary>
        public byte Speed { get; set; }

        /// <summary>
        /// 停留时间 0-99
        /// </summary>
        public byte Delay { get; set; }

        /// <summary>
        /// 字体颜色
        /// </summary>
        public LedFontColor FontColor { get; set; }

        /// <summary>
        /// 有效时间
        /// </summary>
        public byte ValidTime { get; set; }

        /// <summary>
        /// 获取协议内容
        /// </summary>
        /// <param name="text">文字内容</param>
        /// <param name="addr">485地址，默认为1</param>
        /// <returns></returns>
        public byte[] GetBytes(string text, byte addr = 1)
        {
            Address = addr;
            var list = new List<byte>
            {
                0xAA,
                Address,
                0xBB,
                Convert.ToByte(Command >> 8),
                Convert.ToByte(Command & 0xFF)
            };
            //功能码
            //右移8位
            //取低8位,这两步操作实际上是取command的高8位

            //数据区
            var data = new List<byte> {(byte) ShowType, Speed, Delay, (byte) FontColor, ValidTime};
            data.AddRange(Encoding.Default.GetBytes(text));
            list.AddRange(data);
            var xor = Helper.Xor(data.ToArray());
            list.Add(xor);
            list.Add(0xFF);
            return list.ToArray();
        }
    }
}