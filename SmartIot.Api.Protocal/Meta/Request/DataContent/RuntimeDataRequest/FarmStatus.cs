#region Code File Comment

// SOLUTION   ： SmartIot
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： FarmStatus.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-08-06 14:28
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

using System;
using System.Xml.Serialization;
using SmartIot.Api.Protocal.Common;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent.RuntimeDataRequest
{
    [XmlRoot("基地状态")]
    [JsonObject("基地状态")]
    public class FarmStatus : IRequest
    {
        /// <summary>
        /// 基地编码
        /// </summary>
        [XmlElement("基地编码")]
        [JsonProperty("基地编码")]
        public string FarmSerialnum { get; set; }

        /// <summary>
        /// CPU使用
        /// </summary>
        [XmlElement("CPU使用")]
        [JsonProperty("CPU使用")]
        public Decimal CpuUsage { get; set; }

        /// <summary>
        /// 内存使用
        /// </summary>
        [XmlElement("内存使用")]
        [JsonProperty("内存使用")]
        public Decimal MemoryUsage { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [XmlElement("类型")]
        [JsonProperty("类型")]
        public FarmLogTypeEnum InfoType { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Required]
        [Range(typeof (DateTime), "2010-1-1", "2099-1-1")]
        [XmlAttribute("时间")]
        [JsonProperty("时间", Required = Required.Always, IsReference = false)]
        public DateTime Time { get; set; }

        /// <summary>
        /// 异常原因
        /// </summary>
        [XmlElement("描述")]
        [JsonProperty("描述")]
        public string Description { get; set; }
    }
}