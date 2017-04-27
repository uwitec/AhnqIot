using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest
{
    /// <summary>
    /// 图像数据包
    /// </summary>
    [XmlRoot("图像数据包")]
    [JsonObject("图像数据包", IsReference = false)]
    public class PictureData : IRequest
    {
        /// <summary>
        /// 设施编码
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [XmlAttribute("设施编码")]
        [JsonProperty("设施编码", Required = Required.Always, IsReference = false)]
        public string FacilityCode { get; set; }

        /// <summary>
        /// 设备编码
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [XmlAttribute("设备编码")]
        [JsonProperty("设备编码", Required = Required.Always, IsReference = false)]
        public string DeviceCode { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Required]
        [Range(typeof (DateTime), "2010-1-1", "2099-1-1")]
        [XmlAttribute("时间")]
        [JsonProperty("时间", Required = Required.Always, IsReference = false)]
        public DateTime Time { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        [Required]
        [EnumDataType(typeof (PhotoType))]
        [XmlAttribute("设备类型")]
        [JsonProperty("设备类型", Required = Required.Always, IsReference = false)]
        public PhotoType Format { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [Required]
        [XmlAttribute("数据")]
        [JsonProperty("数据", Required = Required.Always, IsReference = false)]
        public string Value { get; set; }
    }

    /// <summary>
    /// 图像格式
    /// </summary>
    public enum PhotoType
    {
        JPG,
        BMP,
        PNG
    }
}