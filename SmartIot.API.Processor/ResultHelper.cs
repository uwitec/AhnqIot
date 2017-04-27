#region Code File Comment
// SOLUTION   ： SmartIot
// PROJECT    ： SmartIot.API.Processor
// FILENAME   ： ResultHelper.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-31 15:56
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System;
using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Common;
using NewLife.Log;

namespace SmartIot.API.Processor
{
    public class ResultHelper
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //public static XResponseMessage ProcessNull()
        //{
        //    return CreateMessage("无法处理请求的数据", ErrorType.CanNotProcessRequestData);
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static XResponseMessage CreateExceptionMessage(Exception ex, string message = null, ErrorType error = ErrorType.InternalError)
        {
            ServiceLogger.Current.WriteException(ex);
            return CreateMessage(message ?? ex.Message, error, null, ex);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="success"></param>
        /// <param name="obj"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static XResponseMessage CreateMessage(string str, ErrorType success = ErrorType.NoError, dynamic obj = null, Exception ex = null)
        {
            return new XResponseMessage()
            {
                Success = success,
                Message = str,
                Data = obj,
                Exception = ex
            };
        }
    }
}