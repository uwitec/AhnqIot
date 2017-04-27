//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： Ahnqiot.Web.Api
//  FILENAME   ： ApiArgumentErrorResult.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 19:06
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using AhnqIot.Infrastructure.Log;

namespace Ahnqiot.Web.Api.Providers.Results
{
    public class ApiArgumentErrorResult : ApiResult
    {
        /// <summary>
        /// 
        /// </summary>
        public ApiArgumentErrorResult(ArgumentException ex) : base(ExceptionCode.NotSupportedFormat, ex.Message)
        {
            LogHelper.Fatal(ex.ToString());
        }
    }
}