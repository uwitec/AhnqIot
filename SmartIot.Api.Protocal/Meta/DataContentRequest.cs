#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： DataContentRequest.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-28 11:19
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SmartIot.Api.Protocal.Meta.Request.DataContent;

#endregion

namespace SmartIot.Api.Protocal.Meta
{
    /// <summary>
    ///     数据内容
    /// </summary>
    [DisplayName("数据内容块")]
    [XmlRoot("数据内容")]
    [JsonObject("数据内容")]
    public class DataContentRequest
    {
        /// <summary>
        ///     采集数据块
        /// </summary>
        [DisplayName("采集数据块")]
        [XmlElement("采集数据")]
        [JsonProperty("采集数据")]
        public CollectDataBlock CollectDataBlock { get; set; }

        /// <summary>
        ///     控制指令块
        /// </summary>
        [DisplayName("控制指令块")]
        [XmlElement("控制指令")]
        [JsonProperty("控制指令")]
        public ControlDataBlock ControlDataBlock { get; set; }

        /// <summary>
        ///     基础数据块
        /// </summary>
        [DisplayName("基础数据块")]
        [XmlElement("基础数据块")]
        [JsonProperty("基础数据块")]
        public CommonDataBlock CommonDataBlock { get; set; }

        /// <summary>
        ///     查询数据块
        /// </summary>
        [DisplayName("查询数据块")]
        [XmlElement("查询")]
        [JsonProperty("查询")]
        public QueryDataBlock QueryDataBlock { get; set; }

        /// <summary>
        ///     管理数据块
        /// </summary>
        [DisplayName("管理数据块")]
        [XmlElement("管理")]
        [JsonProperty("管理")]
        public ManageDataBlock ManageDataBlock { get; set; }

        /// <summary>
        ///     运行数据块
        /// </summary>
        [DisplayName("运行数据块")]
        [XmlElement("运行")]
        [JsonProperty("运行")]
        public RuntimeDataBlock RuntimeDataBlock { get; set; }
    }
}