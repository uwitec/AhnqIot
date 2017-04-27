//  SOLUTION  ： 农业气象物联网V3
//  PROJECT     ： AhnqIot.Web
//  FILENAME   ： ResponseData.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 14:36
//  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

namespace AhnqIot.Web.Areas.apiV1.ApiResult
{
    /// <summary>
    /// 
    /// </summary>
    public class ResponseData
    {
        /// <summary>
        /// 
        /// </summary>
        public ResultMessageType Success { get; set; }

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