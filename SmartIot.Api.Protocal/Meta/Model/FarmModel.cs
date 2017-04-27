using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Model
{
    /// <summary>
    /// 基地
    /// </summary>
    [XmlRoot("基地")]
    [JsonObject("基地", IsReference = false)]
    public class FarmModel
    {
        #region 属性

        /// <summary>编码</summary>
        [XmlElement("编码")]
        [JsonProperty("编码", IsReference = false)]
        String Serialnum { get; set; }

        /// <summary>名称</summary>
        [XmlElement("名称")]
        [JsonProperty("名称", IsReference = false)]
        String Name { get; set; }

        /// <summary>地址</summary>
        [XmlElement("地址")]
        [JsonProperty("地址", IsReference = false)]
        String Address { get; set; }

        /// <summary>形象图片</summary>
        [XmlElement("形象图片")]
        [JsonProperty("形象图片", IsReference = false)]
        String PhotoUrl { get; set; }

        /// <summary>经度</summary>
        [XmlElement("经度")]
        [JsonProperty("经度", IsReference = false)]
        String Lotitude { get; set; }

        /// <summary>纬度</summary>
        [XmlElement("纬度")]
        [JsonProperty("纬度", IsReference = false)]
        String Latitude { get; set; }

        /// <summary>面积</summary>
        [XmlElement("面积")]
        [JsonProperty("面积", IsReference = false)]
        Int32 Area { get; set; }

        /// <summary>联系人</summary>
        [XmlElement("联系人")]
        [JsonProperty("联系人", IsReference = false)]
        String ContactMan { get; set; }

        /// <summary>联系电话</summary>
        [XmlElement("联系电话")]
        [JsonProperty("联系电话", IsReference = false)]
        String ContactPhone { get; set; }

        /// <summary>手机</summary>
        [XmlElement("手机")]
        [JsonProperty("手机", IsReference = false)]
        String ContactMobile { get; set; }

        /// <summary>状态</summary>
        [XmlElement("状态")]
        [JsonProperty("状态", IsReference = false)]
        Boolean Status { get; set; }

        /// <summary>创建时间</summary>
        [XmlElement("创建时间")]
        [JsonProperty("创建时间", IsReference = false)]
        DateTime CreateTime { get; set; }

        #endregion
    }
}