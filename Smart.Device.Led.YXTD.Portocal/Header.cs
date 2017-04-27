using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace Smart.Device.Led.YXTD.Portocal
{
    /// <summary>
    /// 协议头
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class Header
    {
        [ProtoMember(1)]
        public Byte Flag1 { get; set; }
        /// <summary>
        /// 地址	（0-255），其中255为广播地址 TCP通讯时采用广播地址通讯
        /// </summary>
        [ProtoMember(2)]
        public Byte Address { get; set; }
        [ProtoMember(3)]
        public Byte Flag2 { get; set; }
        [ProtoMember(4)]
        public DataType DataType { get; set; }
        [ProtoMember(5)]
        /// <summary>
        /// 序号	保留0
        /// </summary>
        public Byte Index { get; set; }
        /// <summary>
        /// 数据长度	注：(长度 = 数据+[CRC校验字节]) 长度高字节在前 长度低字节在后
        /// </summary>
        [ProtoMember(6)]
        public UInt16 Length { get; set; }

        public Header()
        {
            Flag1 = 0xAA;
            Flag2 = 0xBB;
            Index = 0;
            Address = 0XFF;
        }

        /// <summary>
        /// 是否需要CRC校验
        /// </summary>
        /// <returns></returns>
        public bool IsNeedCrc()
        {
            return DataType == DataType.CmdAndCrc || DataType == DataType.DataAndCrc;
        }
    }

    /// <summary>
    /// 类型
    /// </summary>
    [ProtoBuf.ProtoContract]
    public enum DataType : byte
    {
        CmdAndNoCrc = 0x00,
        CmdAndCrc = 0x01,
        DataAndNoCrc = 0x10,
        DataAndCrc = 0x11
    }
}
