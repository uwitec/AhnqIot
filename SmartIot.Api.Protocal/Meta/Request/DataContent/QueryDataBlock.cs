#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： QueryDataBlock.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-28 11:19
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SmartIot.Api.Protocal.Meta.Request.DataContent.QueryDataRequest;

#endregion

namespace SmartIot.Api.Protocal.Meta.Request.DataContent
{
    /// <summary>
    ///     查询数据块
    /// </summary>
    [DisplayName("查询数据块")]
    [XmlRoot("查询")]
    [JsonObject("查询")]
    public class QueryDataBlock
    {
        /// <summary>
        ///     设施类型查询数据
        /// </summary>
        [DisplayName("设施类型查询数据")]
        [XmlElement("设施类型")]
        [JsonProperty("设施类型")]
        public bool FacilityType { get; set; }

        /// <summary>查询基地的设施</summary>
        [DisplayName("基地的设施查询数据")]
        [XmlElement("基地的设施")]
        [JsonProperty("基地的设施")]
        public QueryFacilitys FarmCode { get; set; }

        /// <summary>
        ///     查询设施信息
        /// </summary>
        [DisplayName("设施查询数据")]
        [XmlElement("设施")]
        [JsonProperty("设施")]
        public string FacilityCode { get; set; }

        /// <summary>
        ///     设备类型查询数据
        /// </summary>
        [DisplayName("设备类型查询数据")]
        [XmlElement("设备类型")]
        [JsonProperty("设备类型")]
        public bool DeviceType { get; set; }

        /// <summary>查询设施所有设备（包含采集设备、控制设备、音视频设备）数据</summary>
        [DisplayName("查询设施所有设备")]
        [XmlElement("设施的设备")]
        [JsonProperty("设施的设备")]
        public QueryFacilityDevices Facility { get; set; }

        [DisplayName("设备查询数据")]
        [XmlElement("设备")]
        [JsonProperty("设备")]
        public string DeviceCode { get; set; }

        [DisplayName("视频设备查询数据")]
        [XmlElement("视频设备")]
        [JsonProperty("视频设备")]
        public string MediaCode { get; set; }
    }
}