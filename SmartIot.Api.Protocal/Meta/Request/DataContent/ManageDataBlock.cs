#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： ManageDataBlock.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-28 11:19
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SmartIot.Api.Protocal.Meta.Model;
using SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ManageDataRequest;

#endregion

namespace SmartIot.Api.Protocal.Meta.Request.DataContent
{
    /// <summary>
    ///     管理数据块
    /// </summary>
    [DisplayName("管理数据块")]
    [XmlRoot("管理")]
    [JsonObject("管理")]
    public class ManageDataBlock
    {
        /// <summary>设施添加数据</summary>
        [DisplayName("设施添加数据V3")]
        [XmlElement("添加设施V3")]
        [JsonProperty("添加设施V3")]
        public FacilityModel FacilityAdd { get; set; }

        /// <summary>设施更新数据</summary>
        [DisplayName("设施更新数据V3")]
        [XmlElement("更新设施V3")]
        [JsonProperty("更新设施V3")]
        public FacilityModel FacilityUpdate { get; set; }

        /// <summary>设备添加数据</summary>
        [DisplayName("设备添加数据")]
        [XmlElement("添加设备")]
        [JsonProperty("添加设备")]
        public DeviceModel DeviceAdd { get; set; }

        /// <summary>设备更新数据</summary>
        [DisplayName("设备更新数据")]
        [XmlElement("更新设备")]
        [JsonProperty("更新设备")]
        public DeviceModel DeviceUpdate { get; set; }

        /// <summary>多媒体设备添加数据</summary>
        [DisplayName("多媒体设备添加数据")]
        [XmlElement("添加多媒体设备")]
        [JsonProperty("添加多媒体设备")]
        public MediaData MediaAdd { get; set; }

        /// <summary>多媒体设备更新数据</summary>
        [DisplayName("多媒体设备更新数据")]
        [XmlElement("更新多媒体设备")]
        [JsonProperty("更新多媒体设备")]
        public MediaData MediaUpdate { get; set; }


        /// <summary>设施添加数据</summary>
        [DisplayName("设施添加数据")]
        [Obsolete("协议升级,后续不再使用")]
        [XmlElement("添加设施")]
        [JsonProperty("添加设施")]
        public List<FacilityAddData> FacilityAddDatas { get; set; }

        /// <summary>设施更新数据</summary>
        [DisplayName("设施更新数据")]
        [Obsolete("协议升级,后续不再使用")]
        [XmlElement("更新设施")]
        [JsonProperty("更新设施")]
        public List<FacilityUpdateData> FacilityUpdateDatas { get; set; }

        /// <summary>设备更新数据</summary>
        [DisplayName("设备更新数据")]
        [Obsolete("协议升级,后续不再使用")]
        //[XmlElement("更新设备")]
        //[JsonProperty("更新设备")]
        public DeviceUpdateData DeviceUpdateData { get; set; }
    }
}