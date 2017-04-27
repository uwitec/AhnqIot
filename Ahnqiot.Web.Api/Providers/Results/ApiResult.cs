//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： AhnqIot.Web
//  FILENAME   ： ApiResult.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 14:20
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ahnqiot.Web.Api.Providers.Results
{
    /// <summary>
    /// API返回结果
    /// </summary>
    public class ApiResult : IHttpActionResult
    {
        /// <summary>
        /// 数据内容
        /// </summary>
        public ResponseData ResponseData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultMessageType"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public ApiResult(ExceptionCode resultMessageType, string message = "", dynamic data = null)
        {
            ResponseData = new ResponseData
            {
                Success = resultMessageType,
                Message = message,
                Data = data
            };
        }

        public override string ToString() => JsonHelper.Serialize(ResponseData);

        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(this.ToString()),
                //StatusCode = 
            };
            return response;
        }

        private HttpStatusCode GetStatusCode()
        {
            if(ResponseData.Success == ExceptionCode.Success)
                return HttpStatusCode.OK;
            else if(ResponseData.Success == ExceptionCode.InternalError)
                return HttpStatusCode.InternalServerError;
            else return HttpStatusCode.PartialContent;
        }
    }
}