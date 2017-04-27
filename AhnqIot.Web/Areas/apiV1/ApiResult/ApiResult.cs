//  SOLUTION  ： 农业气象物联网V3
//  PROJECT     ： AhnqIot.Web
//  FILENAME   ： ApiResult.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 14:20
//  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace AhnqIot.Web.Areas.apiV1.ApiResult
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiV1Result : IHttpActionResult
    {
        private readonly ResponseData _responseData;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="responseData"></param>
        public ApiV1Result(ResponseData responseData)
        {
            _responseData = responseData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultMessageType"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public ApiV1Result(ResultMessageType resultMessageType, string message = "", dynamic data = null)
        {
            _responseData = new ResponseData
            {
                Success = resultMessageType,
                Message = message,
                Data = data
            };
        }

        Task<HttpResponseMessage> IHttpActionResult.ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(this.ToString()),
            };
            return Task.FromResult(response);
        }

        public override string ToString() => JsonHelper.Serialize(_responseData);
    }
}