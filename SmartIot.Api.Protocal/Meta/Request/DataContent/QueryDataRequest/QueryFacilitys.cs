#region Code File Comment

// SOLUTION   ： SmartIot
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： FarmCode.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-31 11:32
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent.QueryDataRequest
{
    /// <summary>
    /// 查询设施
    /// </summary>
    [XmlRoot("查询设施")]
    [JsonObject("查询设施")]
    public class QueryFacilitys : IRequest
    {
        /// <summary>
        /// 基地编码
        /// </summary>
        [XmlAttribute("基地编码")]
        [JsonProperty("基地编码")]
        public string Farm { get; set; }
    }
}