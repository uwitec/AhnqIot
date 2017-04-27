using System.Collections.Generic;
using System.Xml.Serialization;
using SmartIot.Api.Protocal.Meta.Request.DataContent.CollectDataRequest;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent
{
    /// <summary>
    /// 采集数据块
    /// </summary>
    [XmlRoot("采集数据块")]
    [JsonObject("采集数据块", IsReference = false)]
    public class CollectDataBlock
    {
        /// <summary>
        /// 监测数据包
        /// </summary>
        [XmlElement("监测数据包")]
        [JsonProperty("监测数据包", IsReference = false)]
        public List<SensorData> SensorDatas { get; set; }

        /// <summary>
        /// 音视频数据包
        /// </summary>
        [XmlElement("音视频数据包")]
        [JsonProperty("音视频数据包", IsReference = false)]
        public List<MediaData> MediaDatas { get; set; }

        /// <summary>
        /// 图像数据包
        /// </summary>
        [XmlElement("图像数据包")]
        [JsonProperty("图像数据包", IsReference = false)]
        public List<PictureData> PictureDatas { get; set; }
    }
}