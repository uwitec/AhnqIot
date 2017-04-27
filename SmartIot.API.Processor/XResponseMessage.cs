#region Code File Comment
// SOLUTION   ： SmartIot
// PROJECT    ： SmartIot.API.Processor
// FILENAME   ： XResponseMessage.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-31 14:26
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System;
using System.Xml.Serialization;
using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Common;
using NewLife.Model;
using Newtonsoft.Json;

namespace SmartIot.API.Processor
{
    /// <summary>
    /// 返回结果
    /// </summary>
    public class XResponseMessage
    {
        /// <summary>
        /// 消息状态
        /// </summary>
        public ErrorType Success { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 返回数据对象
        /// </summary>
        public dynamic Data { get; set; }
        /// <summary>
        /// 返回结果备用
        /// </summary>
        public bool IsTrue { get; set; }

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
            var formatter = ObjectContainer.Current.Resolve<Api.Protocal.Formatter.FormatterBase>(ProtocalType.ToString());
            return formatter.Serialize(this);
        }
    }
}