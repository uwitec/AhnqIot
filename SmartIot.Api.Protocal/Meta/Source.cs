#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： Source.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-28 11:19
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Newtonsoft.Json;

#endregion

namespace SmartIot.Api.Protocal.Meta
{
    /// <summary>
    ///     数据来源单位
    /// </summary>
    [XmlRoot("数据来源单位")]
    [JsonObject("数据来源单位", IsReference = true)]
    public class Source
    {
        /// <summary>
        ///     基地代码
        /// </summary>
        /// <remarks>不能为空</remarks>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [XmlAttribute("基地代码")]
        [JsonProperty("基地代码", Required = Required.Always, IsReference = false)]
        public string FarmCode { get; set; }

        /// <summary>
        ///     基地KEY
        /// </summary>
        [XmlElement("基地KEY")]
        [JsonProperty("基地KEY")]
        [Required]
        public string FarmKey { get; set; }

        /// <summary>
        ///     基地名称
        /// </summary>
        /// <remarks>不能为空</remarks>
        //[Required]
        [StringLength(50, MinimumLength = 1)]
        [XmlAttribute("基地名称")]
        [JsonProperty("基地名称", Required = Required.Always, IsReference = false)]
        public string FarmName { get; set; }

        /// <summary>
        ///     经度
        /// </summary>
        [XmlAttribute("经度")]
        [JsonProperty("经度", Required = Required.Default, IsReference = false)]
        public decimal Lontitude { get; set; }

        /// <summary>
        ///     纬度
        /// </summary>
        [XmlAttribute("纬度")]
        [JsonProperty("纬度", Required = Required.Default, IsReference = false)]
        public decimal Latitude { get; set; }
    }
}