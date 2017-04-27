//  SOLUTION  ： 农业气象物联网V3
//  PROJECT     ： Ahnqiot.Web.Api
//  FILENAME   ： ApiOkResult.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 19:05
//  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System.Dynamic;

namespace Ahnqiot.Web.Api.Providers.Results
{
    public class ApiOkResult : ApiResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public ApiOkResult(string message = "", dynamic data = null) : base(ExceptionCode.Success, message)
        {
            base.ResponseData.Data = data;
        }
    }
}