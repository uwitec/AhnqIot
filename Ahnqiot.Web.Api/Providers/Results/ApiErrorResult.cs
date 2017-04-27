//  SOLUTION  ： 农业气象物联网V3
//  PROJECT     ： Ahnqiot.Web.Api
//  FILENAME   ： ApiErrorResult.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 2016-04-15 16:48
//  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using AhnqIot.Infrastructure.Log;

namespace Ahnqiot.Web.Api.Providers.Results
{
    public class ApiErrorResult : ApiResult
    {
        /// <summary>
        /// 
        /// </summary>
        public ApiErrorResult(System.Exception ex, string message="") : base(ExceptionCode.InternalError, message)
        {
            LogHelper.Fatal(ex.ToString());
        }
    }
}