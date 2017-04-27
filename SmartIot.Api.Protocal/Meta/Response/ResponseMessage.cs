#region Code File Comment

// SOLUTION   ： SmartIot - DeviceCode
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： ResponseMessage.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-28 21:18
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using SmartIot.Api.Protocal.Common;
using NewLife.Model;
using Newtonsoft.Json;
using SmartIot.Api.Protocal.Formatter;

namespace SmartIot.Api.Protocal.Meta.Response
{
    /// <summary>
    /// 回复消息
    /// </summary>
    [DisplayName("回复消息")]
    [XmlRoot("回复消息")]
    [JsonObject("回复消息")]
    public class ResponseMessage : IResponse
    {
        /// <summary>
        /// 消息状态
        /// </summary>
        [DisplayName("消息状态")]
        [XmlElement("消息状态")]
        [JsonProperty("消息状态")]
        public ErrorType Success { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        [DisplayName("提示信息")]
        [XmlElement("提示信息")]
        [JsonProperty("提示信息")]
        public string Message { get; set; }

        /// <summary>
        /// 返回数据对象
        /// </summary>
        [DisplayName("数据对象")]
        [XmlElement("数据对象")]
        [JsonProperty("数据对象")]
        public dynamic Data { get; set; }

        /// <summary>
        /// 协议类型
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public DataProtocalType ProtocalType { get; set; }

        /// <summary>
        /// 异常内容
        /// </summary>
        [XmlIgnore]
        [JsonIgnore]
        public Exception Exception { get; set; }

        public override string ToString()
        {
            var formatter = ObjectContainer.Current.Resolve<FormatterBase>(ProtocalType.ToString());
            return formatter.Serialize(this);
        }
    }
}