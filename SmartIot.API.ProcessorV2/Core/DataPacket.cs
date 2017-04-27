using System;
using ProtoBuf;

namespace SmartIot.API.ProcessorV2.Core
{
    /// <summary>
    /// 封装数据包
    /// </summary>
    [Serializable]
    [ProtoContract]
    public class DataPacket
    {
        /// <summary>
        /// 会话ID
        /// </summary>
        [ProtoMember(1)]
        public string Id { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [ProtoMember(2)]
        public DateTime Date { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [ProtoMember(3)]
        public string Data { get; set; }
    }
}