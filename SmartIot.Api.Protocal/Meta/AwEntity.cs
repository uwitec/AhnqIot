using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta
{
    /// <summary>
    /// 农气物联网数据封装包
    /// </summary>
    [DisplayName("农气物联网数据封装包")]
    [XmlRoot("农气物联网数据包")]
    [JsonObject("农气物联网数据包")]
    public class AwEntity
    {
        public AwEntity()
        {
            Version = 2013;
        }

        /// <summary>
        /// 封装包格式描述
        /// </summary>
        [DisplayName("封装包格式描述")]
        [XmlElement("描述")]
        [JsonProperty("描述")]
        public String Description { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [DisplayName("版本")]
        [XmlElement("版本")]
        [JsonProperty("版本")]
        public int Version { get; set; }

        /// <summary>
        /// 数据块对象
        /// </summary>
        [DisplayName("数据块对象")]
        [XmlElement("数据块")]
        [JsonProperty("数据块", Required = Required.Default)]
        public DataBlockObject DataBlockObject { get; set; }

        /// <summary>
        /// 验证块
        /// </summary>
        [DisplayName("验证块")]
        [XmlElement("验证块")]
        [JsonProperty("验证块", Required = Required.Default)]
        public ValidationBlock ValidationBlock { get; set; }
    }
}