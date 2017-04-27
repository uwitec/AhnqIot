#region Code File Comment

// SOLUTION   ： SmartIot
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： QueryFacilityControlDevices.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-31 11:33
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent.QueryDataRequest
{
    /// <summary>
    /// 查询设施设备
    /// </summary>
    [XmlRoot("查询设施设备")]
    [JsonObject("查询设施设备")]
    public class QueryFacilityDevices : IRequest
    {
        /// <summary>
        /// 设施编码
        /// </summary>
        [XmlAttribute("设施编码")]
        [JsonProperty("设施编码")]
        public string Facility { get; set; }
    }
}