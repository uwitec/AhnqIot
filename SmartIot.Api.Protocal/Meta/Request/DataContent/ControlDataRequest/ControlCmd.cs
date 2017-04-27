using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent.ControlDataRequest
{
    /// <summary>
    /// 控制指令
    /// </summary>
    [XmlRoot("控制指令")]
    [JsonObject("控制指令", IsReference = false)]
    public class ControlCmd : IRequest
    {
        /// <summary>
        /// 指令编码
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [XmlAttribute("指令编码")]
        [JsonProperty("指令编码", Required = Required.Always, IsReference = false)]
        public string Serialnum { get; set; }

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
        /// 指令内容
        /// </summary>
        [XmlAttribute("指令内容")]
        [JsonProperty("指令内容", Required = Required.Default, IsReference = false)]
        public int Command { get; set; }

        /// <summary>
        /// 控制时间
        /// </summary>
        [Required]
        [Range(typeof (DateTime), "2010-1-1", "2099-1-1")]
        [XmlAttribute("控制时间")]
        [JsonProperty("控制时间", Required = Required.Always, IsReference = false)]
        public DateTime Time { get; set; }

        /// <summary>
        /// 控制时长
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        [XmlAttribute("控制时长")]
        [JsonProperty("控制时长", Required = Required.Always, IsReference = false)]
        public int ContinueTime { get; set; }
    }
}