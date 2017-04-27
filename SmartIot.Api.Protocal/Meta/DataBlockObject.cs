using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta
{
    /// <summary>
    /// 数据块对象
    /// </summary>
    [DisplayName("数据块对象")]
    [XmlRoot("数据块")]
    [JsonObject("数据块", IsReference = false)]
    public class DataBlockObject
    {
        /// <summary>
        /// 数据来源单位
        /// </summary>
        [DisplayName("数据块对象")]
        [XmlElement("来源")]
        [JsonProperty("来源", Required = Required.Default, IsReference = false)]
        public Source Source { get; set; }

        /// <summary>
        /// 数据创建时间
        /// </summary>
        [DisplayName("数据创建时间")]
        [XmlElement("创建时间")]
        [JsonProperty("创建时间", Required = Required.Default, IsReference = false)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 数据内容
        /// </summary>
        [DisplayName("数据内容")]
        [XmlElement("内容")]
        [JsonProperty("内容", Required = Required.Default, IsReference = false)]
        public DataContentRequest DataContentRequest { get; set; }
    }
}