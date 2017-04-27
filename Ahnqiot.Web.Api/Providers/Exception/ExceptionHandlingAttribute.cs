//  SOLUTION  ： 农业气象物联网V3
//  PROJECT     ： Ahnqiot.Web.Api
//  FILENAME   ： ExceptionHandlingAttribute.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 2016-04-14 16:05
//  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Ahnqiot.Web.Api.Providers.Results;
using AhnqIot.Infrastructure.Log;

namespace Ahnqiot.Web.Api.Providers.Exception
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            //var type = context.Exception.GetType();

            //switch (type.Name)
            //{
            //    case "ArgumentException":
            //        break;
            //    case "BusinessException":
            //        break;
            //    case "AggregateException":
            //        break;
            //    case "Exception":
            //        break;
            //}

            //业务异常
            if (context.Exception is BusinessException)
            {
                context.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.ExpectationFailed
#if DEBUG
                    ,
                    Content = new StringContent(JsonHelper.Serialize(
                        new ApiResult(((BusinessException)context.Exception).Code,
                            context.Exception.Message)))
#endif
                };

#if DEBUG
                var exception = (BusinessException)context.Exception;
                context.Response.Headers.Add("BusinessExceptionCode", exception.Code.GetDescription());
                context.Response.Headers.Add("BusinessExceptionMessage", exception.Message);
#endif
                LogHelper.Error(context.Exception.ToString());
            }
            else if (context.Exception is ArgumentNullException)
            {
                var ex = (ArgumentNullException)context.Exception;
                context.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(JsonHelper.Serialize(new ApiArgumentErrorResult(ex)))
                };
                LogHelper.Error(ex.ToString());
            }
            else if (context.Exception is AggregateException)
            {
                var ex = (AggregateException)context.Exception;
                if (ex.InnerExceptions.Any())
                {
                    context.Response = new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent(JsonHelper.Serialize(new ApiAggregateErrorResult(ex)))
                    };
                    foreach (var innerException in ex.InnerExceptions)
                    {
                        LogHelper.Error(innerException.ToString());
                    }
                }
            }
            //其它异常
            else if (context.Exception != null)
            {
                context.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(JsonHelper.Serialize(new ApiErrorResult(context.Exception, "系统错误，请联系管理员")))
                };
                LogHelper.Fatal(context.Exception.ToString());
            }
        }
    }
}