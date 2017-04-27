#region Code File Comment

// SOLUTION   ： SmartIot
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： FacilityUpdateData.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-31 22:49
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent.ManageDataRequest
{
    /// <summary>
    /// 设施更新数据
    /// </summary>
    [XmlRoot("设施更新数据")]
    [JsonObject("设施更新数据")]
    public class FacilityUpdateData : IRequest
    {
        /// <summary>编码</summary>
        [XmlElement("编码")]
        [JsonProperty("编码")]
        public string Serialnum { get; set; }

        /// <summary>名称</summary>
        [XmlElement("名称")]
        [JsonProperty("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [XmlElement("类型")]
        [JsonProperty("类型")]
        public string Type { get; set; }
    }
}