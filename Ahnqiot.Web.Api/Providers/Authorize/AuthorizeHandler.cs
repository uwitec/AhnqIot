////  SOLUTION  ： 农业气象物联网V3
////  PROJECT     ： Ahnqiot.Web.Api
////  FILENAME   ： AuthorizeHandler.cs
////  AUTHOR     ： soft-cq
////  CREATE TIME： 16:06
////  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Web;

//namespace Ahnqiot.Web.Api.Providers
//{
//    public class AuthorizeHandler : DelegatingHandler
//    {
//        private static IAuthorizer _authorizer = null;

//        static AuthorizeHandler()
//        { }

//        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//        {
//            if (request.Method == HttpMethod.Post)
//            {
//                var querystring = HttpUtility.ParseQueryString(request.RequestUri.Query);
//                var formdata = request.Content.ReadAsFormDataAsync().Result;
//                if (querystring.AllKeys.Intersect(formdata.AllKeys).Count() > 0)
//                {
//                    return SendError("请求参数有重复.", HttpStatusCode.BadRequest);
//                }
//            }
//            //请求方身份验证
//            AuthResult result = _authorizer.AuthRequest(request);
//            if (!result.Flag)
//            {
//                return SendError(result.Message, HttpStatusCode.Unauthorized);
//            }
//            request.Properties.Add("shumi_userid", result.UserID);
//            return base.SendAsync(request, cancellationToken);
//        }

//        private Task<HttpResponseMessage> SendError(string error, HttpStatusCode code)
//        {
//            var response = new HttpResponseMessage();
//            response.Content = new StringContent(error);
//            response.StatusCode = code;

//            return Task<HttpResponseMessage>.Factory.StartNew(() => response);
//        }
//    }
//}