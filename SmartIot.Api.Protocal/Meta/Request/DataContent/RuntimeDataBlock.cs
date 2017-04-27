using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SmartIot.Api.Protocal.Meta.Request.DataContent.RuntimeDataRequest;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent
{
    /// <summary>
    /// 运行数据块
    /// </summary>
    [DisplayName("运行数据块")]
    [XmlRoot("运行")]
    [JsonObject("运行")]
    public class RuntimeDataBlock
    {
        /// <summary>上传示范点状态</summary>
        [DisplayName("上传示范点状态")]
        [XmlElement("示范点状态")]
        [JsonProperty("示范点状态")]
        public FarmStatus UploadFarmStatus { get; set; }
    }
}