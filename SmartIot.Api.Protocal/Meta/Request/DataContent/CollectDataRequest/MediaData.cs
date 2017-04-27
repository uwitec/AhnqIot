using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest
{
    /// <summary>
    /// 音视频数据包
    /// </summary>
    [XmlRoot("音视频数据包")]
    [JsonObject("音视频数据包")]
    public class MediaData : IRequest
    {
        /// <summary>
        /// 设施编码
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [XmlAttribute("设施编码")]
        [JsonProperty("设施编码", Required = Required.Always)]
        public string FacilityCode { get; set; }

        /// <summary>
        /// 设备编码
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [XmlAttribute("设备编码")]
        [JsonProperty("设备编码", Required = Required.Always)]
        public string DeviceCode { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [XmlAttribute("设备名称")]
        [JsonProperty("设备名称", Required = Required.Always)]
        public string DeviceName { get; set; }

        /// <summary>
        /// URL地址
        /// </summary>
        [Required]
        [StringLength(200, MinimumLength = 1)]
        [XmlAttribute("URL地址")]
        [JsonProperty("URL地址", Required = Required.Always, IsReference = false)]
        public string Url { get; set; }

        /// <summary>
        /// 控制端口
        /// </summary>
        [Required]
        [Range(1, 65535)]
        [XmlAttribute("控制端口")]
        [JsonProperty("控制端口", Required = Required.Always)]
        public Int32 ContrPort { get; set; }

        /// <summary>
        /// 音视频端口
        /// </summary>
        [Required]
        [Range(1, 65535)]
        [XmlAttribute("音视频端口")]
        [JsonProperty("音视频端口", Required = Required.Always)]
        public Int32 MediaPort { get; set; }

        /// <summary>
        /// 音视频用户名
        /// </summary>
        [StringLength(50, MinimumLength = 0)]
        [XmlAttribute("音视频用户名")]
        [JsonProperty("音视频用户名", Required = Required.Default)]
        public String User { get; set; }

        /// <summary>
        /// 音视频密码
        /// </summary>
        [StringLength(50, MinimumLength = 0)]
        [XmlAttribute("音视频密码")]
        [JsonProperty("音视频密码", Required = Required.Default)]
        public String Pwd { get; set; }

        /// <summary>
        /// 通道号
        /// </summary>
        [Required]
        [Range(1, 32)]
        [XmlAttribute("通道号")]
        [JsonProperty("通道号", Required = Required.Always)]
        public Int32 Channel { get; set; }

        /// <summary>
        /// 音视频控件地址
        /// </summary>
        [StringLength(500, MinimumLength = 0)]
        [XmlAttribute("音视频控件地址")]
        [JsonProperty("音视频控件地址", Required = Required.Default)]
        public String ActiveX { get; set; }

        [XmlElement("创建时间")]
        [JsonProperty("创建时间", IsReference = false)]
        public DateTime CreateTime { get; set; }
    }
}