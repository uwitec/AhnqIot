using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NewLife;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta
{
    /// <summary>
    /// 验证块
    /// </summary>
    [XmlRoot("验证块")]
    [JsonObject("验证块")]
    public class ValidationBlock
    {
        [XmlElement("加密")]
        [JsonProperty("加密")]
        public Encrypt Encrypt { get; set; }

        [XmlElement("校验")]
        [JsonProperty("校验")]
        public Verify Verify { get; set; }
    }

    /// <summary>
    /// 加密方式
    /// </summary>
    public enum EncryptWay
    {
        None,
        [EnumMember(Value = "3DES")] _3DES,
        DES,
        AES,
        RSA
    }

    /// <summary>
    /// 加密
    /// </summary>
    [XmlRoot("加密")]
    [JsonObject("加密")]
    public class Encrypt
    {
        [XmlElement("数据格式")]
        [JsonProperty("数据格式")]
        public EncryptWay Way { get; set; }

        [XmlElement("数据值")]
        [JsonProperty("数据值")]
        public string Content { get; set; }
    }

    /// <summary>
    /// 校验
    /// </summary>
    [XmlRoot("校验")]
    [JsonObject("校验")]
    public class Verify
    {
        [XmlElement("数据格式")]
        [JsonProperty("数据格式")]
        public string Key { get; set; }

        [XmlElement("数据值")]
        [JsonProperty("数据值")]
        public string Content { get; set; }
    }
}