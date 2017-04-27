#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： AWIOT.API.Processor
// FILENAME   ： XResponseMessage.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-31 14:26
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Api.Protocal.Common;
using System;

namespace SmartIot.Tool.API.Core
{
    /// <summary>
    /// 返回结果
    /// </summary>
    public class XResponseMessage
    {
        public ErrorType Success { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// 返回数据对象
        /// </summary>
        public dynamic Data { get; set; }

        public override string ToString()
        {
            return "{0} {1}".F(Success.GetDescription(), Message);
        }
    }
}