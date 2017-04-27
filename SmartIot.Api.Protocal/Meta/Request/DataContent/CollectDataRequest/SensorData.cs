using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest
{
    /// <summary>
    /// 监测数据包
    /// </summary>
    [XmlRoot("监测数据包")]
    [JsonObject("监测数据包", IsReference = false)]
    public class SensorData : IRequest
    {
        ///// <summary>
        ///// 设施编码
        ///// </summary>
        //[Required]
        //[StringLength(50, MinimumLength = 1)]
        //[XmlAttribute("设施编码")]
        //[JsonProperty("设施编码", Required = Required.Always, IsReference = false)]
        //public string FacilityCode { get; set; }

        /// <summary>
        /// 设备编码
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [XmlAttribute("设备编码")]
        [JsonProperty("设备编码", Required = Required.Always, IsReference = false)]
        public string DeviceCode { get; set; }

        ///// <summary>
        ///// 设备类型
        ///// </summary>
        //[XmlAttribute("设备类型")]
        //[JsonProperty("设备类型", Required = Required.Default, IsReference = false)]
        //public string DeviceType { get; set; }

        ///// <summary>
        ///// 单位
        ///// </summary>
        //[XmlAttribute("单位")]
        //[JsonProperty("单位", Required = Required.Default, IsReference = false)]
        //public string Unit { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Required]
        [Range(typeof (DateTime), "2010-1-1", "2099-1-1")]
        [XmlAttribute("时间")]
        [JsonProperty("时间", Required = Required.Always, IsReference = false)]
        public DateTime Time { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [Required]
        [XmlAttribute("数据")]
        [JsonProperty("数据", Required = Required.Always, IsReference = false)]
        public Decimal Value { get; set; }

        /// <summary>
        /// 数据。如风向、设备状态等
        /// </summary>
        [XmlAttribute("显示值")]
        [JsonProperty("显示值", Required = Required.Always, IsReference = false)]
        public string ShowValue { get; set; }


        /// <summary>
        /// 批号
        /// </summary>
        [XmlAttribute("批号")]
        [JsonProperty("批号", Required = Required.Always, IsReference = false)]
        public string BatchNum { get; set; }
    }
}