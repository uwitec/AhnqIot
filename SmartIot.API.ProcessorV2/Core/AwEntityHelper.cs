#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： AwEntityHelper.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-26 9:24
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using System;
using AhnqIot.Infrastructure.Log;
using SmartIot.Api.Protocal.Formatter;
using SmartIot.Api.Protocal.Meta;

namespace SmartIot.API.ProcessorV2.Core
{
    public class AwEntityHelper
    {
        /// <summary>
        /// 协议版本号
        /// </summary>
        public const int Version = 2013;

        public static AwEntity GetAwEntity(string str)
        {
            try
            {
                return FormatterFactory.ProcessAsync(str);
            }
            catch (Exception ex)
            {
                LogHelper.Fatal("反序列化失败," + str);
            }
            return null;
        }

        /// <summary>
        /// 检测协议版本号
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static bool CheckVersion(int version)
        {
            return version == Version;
        }
    }
}