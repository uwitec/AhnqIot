//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： AhnqIot.Web
//  FILENAME   ： ResponseData.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 14:36
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

namespace Ahnqiot.Web.Api.Providers.Results
{
    /// <summary>
    /// 
    /// </summary>
    public class ResponseData
    {
        /// <summary>
        /// 
        /// </summary>
        public ExceptionCode Success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public dynamic Data { get; set; }
    }
}