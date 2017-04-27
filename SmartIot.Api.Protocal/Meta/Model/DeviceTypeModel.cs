#region Code File Comment

// SOLUTION   ： SmartIot
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： DeviceTypeModel.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-31 11:44
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Model
{
    [XmlRoot("设备类型")]
    [JsonObject("设备类型", IsReference = false)]
    public class DeviceTypeModel
    {
        /// <summary>编码</summary>
        [XmlElement("编码")]
        [JsonProperty("编码", IsReference = false)]
        public String Serialnum { get; set; }

        /// <summary>名称</summary>
        [XmlElement("名称")]
        [JsonProperty("名称", IsReference = false)]
        public String Name { get; set; }

        /// <summary>上级类型编码</summary>
        [XmlElement("上级类型编码")]
        [JsonProperty("上级类型编码", IsReference = false)]
        public String ParentSerialnum { get; set; }

        /// <summary>形象图片</summary>
        [XmlElement("形象图片")]
        [JsonProperty("形象图片", IsReference = false)]
        public String PhotoUrl { get; set; }

        /// <summary>描述</summary>
        [XmlElement("描述")]
        [JsonProperty("描述", IsReference = false)]
        public String Introduce { get; set; }
    }
}