using System.Collections.Generic;
using System.Xml.Serialization;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ControlDataRequest;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent
{
    /// <summary>
    /// 控制指令块
    /// </summary>
    [XmlRoot("控制指令块")]
    [JsonObject("控制指令块")]
    public class ControlDataBlock
    {
        /// <summary>
        /// 请求控制
        /// </summary>
        [XmlElement("请求控制")]
        [JsonProperty("请求控制")]
        public List<ControlQuery> ControlQueries { get; set; }

        /// <summary>
        /// 控制指令
        /// </summary>
        [XmlElement("控制指令")]
        [JsonProperty("控制指令")]
        public List<ControlCmd> ControlCmds { get; set; }

        /// <summary>
        /// 控制结果
        /// </summary>
        [XmlElement("控制结果")]
        [JsonProperty("控制结果")]
        public List<ControlResult> ControlResults { get; set; }
    }
}