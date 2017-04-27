using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace SmartIot.Api.Protocal
{
    [Serializable]
    [ProtoContract]
    /// <summary>
    /// 封装数据包
    /// </summary>
    public class DataPacket
    {
        [ProtoMember(1)]
        /// <summary>
        /// 会话ID
        /// </summary>
        public string Id { get; set; }

        [ProtoMember(2)]
        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }

        [ProtoMember(3)]
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Date { get; set; }
    }
}