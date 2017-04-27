using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Common;
using SmartIot.Tool.API.Core;
using NewLife.Log;
using System;
using System.Net.Http;
using System.Text;

namespace SmartIot.Tool.API.Transport
{
    public class HttpTransport : ApiTransport, IApiTransport
    {
        private HttpClient _client;

        public HttpTransport(DataProtocalType protocalType = DataProtocalType.Json)
        {
            ProtocalType = protocalType;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        public void Init(string host, int port)
        {
            this.Host = host;
            this.Port = port;

            InitHttpClient();
        }

        /// <summary>
        /// 发送数据到服务端，并接收数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public XResponseMessage Process(dynamic data)
        {
            string method = data.Method.ToString();
            string api = data.ApiAddress.ToString();
            var entity = data.Entity;

            HttpResponseMessage responseMessage;
            switch (method.ToUpper())
            {
                case "POST":
                    responseMessage =
                        _client.PostAsync(api, new StringContent(Serialize(entity), Encoding.UTF8, "")).Result;
                    break;

                case "PUT":
                    responseMessage =
                        _client.PutAsync(api, new StringContent(Serialize(entity), Encoding.UTF8, "")).Result;
                    break;

                case "DELETE":
                    responseMessage = _client.DeleteAsync(api).Result;
                    break;

                case "GET":
                default:
                    responseMessage = _client.GetAsync(api).Result;
                    break;
            }

            try
            {
                responseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
                return new XResponseMessage()
                {
                    Success = ErrorType.NoContent,
                    Message = "状态码错误"
                };
            }

            var str = responseMessage.Content.ReadAsStringAsync().Result;
            return Deserialize<XResponseMessage>(str);
        }

        /// <summary>
        /// 初始化_client
        /// </summary>
        private void InitHttpClient()
        {
            var url = string.Format("http://{0}:{1}", this.Host, this.Port);
            _client = new HttpClient
            {
                BaseAddress =
                    new Uri(Host, Host.Contains("http://localhost") ? UriKind.Relative : UriKind.Absolute)
            };
            _client.DefaultRequestHeaders.Add("user-agent",
                "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
        }

        #region 释放资源

        public void Dispose()
        {
            _client.Dispose();
            _client = null;
        }

        public bool Disposed
        {
            get { return _client == null; }
        }

        public event EventHandler OnDisposed;

        #endregion 释放资源
    }
}