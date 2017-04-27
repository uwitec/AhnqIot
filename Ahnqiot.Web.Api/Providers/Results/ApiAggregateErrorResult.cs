//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： Ahnqiot.Web.Api
//  FILENAME   ： ApiAggregateErrorResult.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 2016-04-15 17:14
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using System.Linq;
using AhnqIot.Infrastructure.Log;

namespace Ahnqiot.Web.Api.Providers.Results
{
    public class ApiAggregateErrorResult : ApiResult
    {
        public ApiAggregateErrorResult(AggregateException ex) : base(ExceptionCode.InternalError, ex.InnerExceptions.Select(e => e.Message).Join(Environment.NewLine))
        {
            LogHelper.Fatal(ex.ToString());
        }
    }
}