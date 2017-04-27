using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Model
{
    /// <summary>
    /// 设施
    /// </summary>
    [XmlRoot("设施")]
    [JsonObject("设施", IsReference = false)]
    public class FacilityModel
    {
        #region 属性

        /// <summary>编码</summary>
        [XmlElement("编码")]
        [JsonProperty("编码", IsReference = false)]
        public String Serialnum { get; set; }

        /// <summary>名称</summary>
        [XmlElement("名称")]
        [JsonProperty("名称", IsReference = false)]
        public String Name { get; set; }

        /// <summary>基地</summary>
        [XmlElement("基地")]
        [JsonProperty("基地", IsReference = false)]
        public String Farm { get; set; }

        /// <summary>设施类型</summary>
        [XmlElement("设施类型")]
        [JsonProperty("设施类型", IsReference = false)]
        public String FacilityType { get; set; }

        ///// <summary>地址</summary>
        //[XmlElement("地址")]
        //[JsonProperty("地址", IsReference = false)]
        //public String Address { get; set; }

        ///// <summary>形象图片</summary>
        //[XmlElement("形象图片")]
        //[JsonProperty("形象图片", IsReference = false)]
        //public String PhotoUrl { get; set; }

        ///// <summary>联系人</summary>
        //[XmlElement("联系人")]
        //[JsonProperty("联系人", IsReference = false)]
        //public String ContactMan { get; set; }

        ///// <summary>联系电话</summary>
        //[XmlElement("联系电话")]
        //[JsonProperty("联系电话", IsReference = false)]
        //public String ContactPhone { get; set; }

        ///// <summary>手机</summary>
        //[XmlElement("手机")]
        //[JsonProperty("手机", IsReference = false)]
        //public String ContactMobile { get; set; }

        /// <summary>创建时间</summary>
        [XmlElement("创建时间")]
        [JsonProperty("创建时间", IsReference = false)]
        public DateTime? CreateTime { get; set; }

        #endregion
    }
}