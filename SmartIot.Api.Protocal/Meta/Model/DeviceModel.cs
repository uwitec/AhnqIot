using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Model
{
    /// <summary>
    /// 设施设备
    /// </summary>
    [XmlRoot("设施设备")]
    [JsonObject("设施设备", IsReference = false)]
    public class DeviceModel
    {
        /// <summary>编码</summary>
        [XmlElement("编码")]
        [JsonProperty("编码", IsReference = false)]
        public String Serialnum { get; set; }

        /// <summary>名称</summary>
        [XmlElement("名称")]
        [JsonProperty("名称", IsReference = false)]
        public String Name { get; set; }

        /// <summary>设施编码</summary>
        [XmlElement("设施编码")]
        [JsonProperty("设施编码", IsReference = false)]
        public String FacilitySerialnum { get; set; }

        /// <summary>设备类型</summary>
        [XmlElement("设备类型")]
        [JsonProperty("设备类型", IsReference = false)]
        public String DeviceTypeSerialnum { get; set; }

        /// <summary>继电器类型</summary>
        [XmlElement("继电器类型")]
        [JsonProperty("继电器类型", IsReference = false)]
        public String RelayType { get; set; }

        /// <summary>处理值</summary>
        [XmlElement("处理值")]
        [JsonProperty("处理值", IsReference = false)]
        public Decimal ProcessedValue { get; set; }

        /// <summary>显示值</summary>
        [XmlElement("显示值")]
        [JsonProperty("显示值", IsReference = false)]
        public String ShowValue { get; set; }

        /// <summary>上限</summary>
        [XmlElement("上限")]
        [JsonProperty("上限", IsReference = false)]
        public Decimal Max { get; set; }

        /// <summary>下限</summary>
        [XmlElement("下限")]
        [JsonProperty("下限", IsReference = false)]
        public Decimal Min { get; set; }

        /// <summary>单位</summary>
        [XmlElement("单位")]
        [JsonProperty("单位", IsReference = false)]
        public String Unit { get; set; }

        /// <summary> 更新时间 </summary>
        [XmlElement("更新时间")]
        [JsonProperty("更新时间", IsReference = false)]
        public DateTime UpdateTime { get; set; }
    }
}