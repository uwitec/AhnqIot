//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： Ahnqiot.Web.Api
//  FILENAME   ： ResultFactory.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 2016-04-15 18:03
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Ahnqiot.Web.Api.Providers.Results
{
    /// <summary>
    /// 
    /// </summary>
    public class ResultFactory
    {
        public static async Task<IHttpActionResult> Create(ModelStateDictionary ms, Func<Task> callback,
          string okInfo = "", string errorInfo = "")
        {
            if (ms.IsValid)
            {
                await callback();
                return new ApiOkResult(okInfo);
            }
            else
            {
                return new ApiResult(ExceptionCode.CanNotProcessRequestData, errorInfo);
            }
        }
        public static async Task<IHttpActionResult> Create<TResultType>(ModelStateDictionary ms, Func<Task<TResultType>> callback,
            string okInfo = "", string errorInfo = "")
        {
            if (ms.IsValid)
            {
                var result = await callback();
                if (result is ApiResult)
                    return result as ApiResult;
                return new ApiOkResult(okInfo, result);
            }
            else
            {
                return new ApiResult(ExceptionCode.CanNotProcessRequestData, errorInfo);
            }
        }
        //public static async Task<IHttpActionResult> Create<TResultType, TResult>(ModelStateDictionary ms, Func<TResult> callback,
        //    string okInfo = "", string errorInfo = "") where TResult : Task<TResultType>
        //{
        //    if (ms.IsValid)
        //    {
        //        var result = await callback();
        //        if (result is ApiResult)
        //            return result as ApiResult;
        //        return new ApiOkResult(okInfo, result);
        //    }
        //    else
        //    {
        //        return new ApiResult(ExceptionCode.CanNotProcessRequestData, errorInfo);
        //    }
        //}
        public static async Task<IHttpActionResult> Create<TArg, TResultType>(ModelStateDictionary ms, Func<TArg, Task<TResultType>> callback, TArg arg1,
           string okInfo = "", string errorInfo = "")
        {
            if (ms.IsValid)
            {
                var result = await callback(arg1);
                if (result is ApiResult)
                    return result as ApiResult;
                return new ApiOkResult(okInfo, result);
            }
            else
            {
                return new ApiResult(ExceptionCode.CanNotProcessRequestData, errorInfo);
            }
        }
        //public static async Task<IHttpActionResult> Create<TArg, TResultType, TResult>(ModelStateDictionary ms, Func<TArg, TResult> callback, TArg arg1,
        //   string okInfo = "", string errorInfo = "") where TResult : Task<TResultType>
        //{
        //    if (ms.IsValid)
        //    {
        //        var result = await callback(arg1);
        //        if (result is ApiResult)
        //            return result as ApiResult;
        //        return new ApiOkResult(okInfo, result);
        //    }
        //    else
        //    {
        //        return new ApiResult(ExceptionCode.CanNotProcessRequestData, errorInfo);
        //    }
        //}
        public static async Task<IHttpActionResult> Create<TArg1, TArg2, TResultType>(ModelStateDictionary ms, Func<TArg1, TArg2, Task<TResultType>> callback, TArg1 arg1, TArg2 arg2,
            string okInfo = "", string errorInfo = "")
        {
            if (ms.IsValid)
            {
                var result = await callback(arg1, arg2);
                if (result is ApiResult)
                    return result as ApiResult;
                return new ApiOkResult(okInfo, result);
            }
            else
            {
                return new ApiResult(ExceptionCode.CanNotProcessRequestData, errorInfo);
            }
        }
        //public static async Task<IHttpActionResult> Create<TArg1, TArg2, TResultType, TResult>(ModelStateDictionary ms, Func<TArg1, TArg2, TResult> callback, TArg1 arg1, TArg2 arg2,
        //    string okInfo = "", string errorInfo = "") where TResult : Task<TResultType>
        //{
        //    if (ms.IsValid)
        //    {
        //        var result = await callback(arg1, arg2);
        //        if (result is ApiResult)
        //            return result as ApiResult;
        //        return new ApiOkResult(okInfo, result);
        //    }
        //    else
        //    {
        //        return new ApiResult(ExceptionCode.CanNotProcessRequestData, errorInfo);
        //    }
        //}


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="U"></typeparam>
        ///// <param name="ms"></param>
        ///// <param name="callback"></param>
        ///// <param name="arg1"></param>
        ///// <param name="okInfo"></param>
        ///// <param name="errorInfo"></param>
        ///// <returns></returns>
        //public static IHttpActionResult Create<T, U>(ModelStateDictionary ms, Func<T, U> callback, T arg1,
        //    string okInfo = "", string errorInfo = "")
        //{
        //    if (ms.IsValid)
        //    {
        //        try
        //        {
        //            var result = callback(arg1);
        //            if (result is ApiResult)
        //                return result as ApiResult;
        //            return new ApiOkResult(okInfo, result);
        //        }
        //        catch (AggregateException)
        //        {
        //            throw;
        //        }
        //        catch (System.Exception)
        //        {
        //            throw;
        //        }
        //    }
        //    else
        //    {
        //        return new ApiResult(ExceptionCode.CanNotProcessRequestData, errorInfo);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T1"></typeparam>
        ///// <typeparam name="T2"></typeparam>
        ///// <typeparam name="U"></typeparam>
        ///// <param name="ms"></param>
        ///// <param name="callback"></param>
        ///// <param name="arg1"></param>
        ///// <param name="arg2"></param>
        ///// <param name="okInfo"></param>
        ///// <param name="errorInfo"></param>
        ///// <returns></returns>
        //public static IHttpActionResult Create<T1, T2, U>(ModelStateDictionary ms, Func<T1, T2, U> callback, T1 arg1,
        //    T2 arg2, string okInfo = "", string errorInfo = "") where U : IHttpActionResult
        //{
        //    if (ms.IsValid)
        //    {
        //        try
        //        {
        //            var result = callback(arg1, arg2);
        //            if (result is ApiResult)
        //                return result as ApiResult;
        //            return new ApiOkResult(okInfo, result);
        //        }
        //        catch (AggregateException)
        //        {
        //            throw;
        //        }
        //        catch (System.Exception)
        //        {
        //            throw;
        //        }
        //    }
        //    else
        //    {
        //        return new ApiResult(ExceptionCode.CanNotProcessRequestData, errorInfo);
        //    }
        //}
    }
}