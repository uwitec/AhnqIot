using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent.ControlDataRequest
{
    /// <summary>
    /// 请求控制
    /// </summary>
    [XmlRoot("请求控制")]
    [JsonObject("请求控制", IsReference = false)]
    public class ControlQuery : IRequest
    {
        /// <summary>
        /// 设施编码
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [XmlAttribute("设施编码")]
        [DisplayName("设施编码")]
        [JsonProperty("设施编码", Required = Required.Always, IsReference = false)]
        public string FacilityCode { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Required]
        [Range(typeof (DateTime), "2010-1-1", "2099-1-1")]
        [XmlAttribute("时间")]
        [DisplayName("时间")]
        [JsonProperty("时间", Required = Required.Always, IsReference = false)]
        public DateTime Time { get; set; }
    }
}