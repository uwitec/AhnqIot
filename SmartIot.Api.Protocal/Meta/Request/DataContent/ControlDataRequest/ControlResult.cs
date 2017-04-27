using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent.ControlDataRequest
{
    /// <summary>
    /// 控制结果
    /// </summary>
    [XmlRoot("控制结果")]
    [JsonObject("控制结果", IsReference = false)]
    public class ControlResult : IRequest
    {
        /// <summary>
        /// 指令编码
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [XmlAttribute("指令编码")]
        [JsonProperty("指令编码")]
        public string Serialnum { get; set; }

        ///// <summary>
        ///// 设施编码
        ///// </summary>
        //[Required]
        //[StringLength(50, MinimumLength = 1)]
        //[XmlAttribute("设施编码")]
        //[JsonProperty("设施编码")]
        //public string FacilityCode { get; set; }

        ///// <summary>
        ///// 设备编码
        ///// </summary>
        //[Required]
        //[StringLength(50, MinimumLength = 1)]
        //[XmlAttribute("设备编码")]
        //[JsonProperty("设备编码")]
        //public string DeviceCode { get; set; }

        ///// <summary>
        ///// 指令内容
        ///// </summary>
        //[XmlAttribute("指令内容")]
        //[JsonProperty("指令内容")]
        //public int Command { get; set; }

        /// <summary>
        /// 控制时间
        /// </summary>
        [Required]
        [Range(typeof (DateTime), "2010-1-1", "2099-1-1")]
        [XmlAttribute("控制时间")]
        [JsonProperty("控制时间")]
        public DateTime Time { get; set; }

        ///// <summary>
        ///// 控制时长
        ///// </summary>
        //[Required]
        //[XmlAttribute("控制时长")]
        //[JsonProperty("控制时长")]
        //public int ContinueTime { get; set; }

        /// <summary>
        /// 控制结果
        /// </summary>
        [XmlAttribute("控制结果")]
        [JsonProperty("控制结果")]
        public bool Result { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        [XmlAttribute("失败原因")]
        [JsonProperty("失败原因")]
        public string FailReason { get; set; }
    }
}