#region Code File Comment

// SOLUTION   ： SmartIot
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： DeviceUpdateData.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-31 22:40
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

using System.Collections.Generic;
using System.Xml.Serialization;
using SmartIot.Api.Protocal.Meta.Model;
using SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent.ManageDataRequest
{
    /// <summary>
    /// 设备更新数据
    /// </summary>
    [XmlRoot("设备更新数据")]
    [JsonObject("设备更新数据", IsReference = false)]
    public class DeviceUpdateData : IRequest
    {
        /// <summary>传感器设备</summary>
        [XmlElement("传感器设备")]
        [JsonProperty("传感器设备", IsReference = false)]
        public List<DeviceModel> Devices { get; set; }

        /// <summary>多媒体设备</summary>
        [XmlElement("多媒体设备")]
        [JsonProperty("多媒体设备", IsReference = false)]
        public List<MediaData> Cameras { get; set; }
    }
}