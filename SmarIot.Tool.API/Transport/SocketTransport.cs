using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta;
using SmartIot.Tool.API.Core;
using NewLife.Log;
using NewLife.Net;

namespace SmartIot.Tool.API.Transport
{
    public class SocketTransport : ApiTransport, IApiTransport
    {
        private ISocketClient _session;

        public SocketTransport(DataProtocalType protocalType = DataProtocalType.Json)
        {
            ProtocalType = protocalType;
        }

        public void Init(string host, int port)
        {
            base.Host = host;
            base.Port = port;
            _session = new NetUri($"Tcp://{base.Host.ParseAddress()}:{base.Port}").CreateRemote();
            //if (_session.GetType() == typeof(TcpSession))
            //{
            //    var tcpSession = _session as TcpSession;
            //    tcpSession.Open();
            //    tcpSession.Client.ReceiveTimeout = 10000;
            //}
        }


        /// <summary>
        /// 发送数据到服务端，并接收数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public XResponseMessage Process(dynamic data)
        {
#if DEBUG
            var sw = new Stopwatch();
            sw.Start();
#endif
            string str = Serialize(data); //此处不可使用var，会导致调用_Send(dynamic)的函数，而ISocketSession中无此函数定义。
            //System.Threading.Thread.Sleep(5000);//等待服务器接口那边接受消息并上传完再发送新的数据包

            _session.Send(str);
            //XTrace.WriteLine(str);
            var buffer = new Byte[80*1024];
            //var receive = _session.ReceiveString();
            //System.Threading.Thread.Sleep(5000);
            var size = _session.Receive(buffer, 0, buffer.Length);
            if (size < 0)
            {
                return new XResponseMessage()
                {
                    Success = ErrorType.NoContent,
                    Message = "服务端未返回数据"
                };
            }
            var receive = Encoding.UTF8.GetString(buffer, 0, size);
            if (receive.IsNullOrWhiteSpace())
            {
                return new XResponseMessage()
                {
                    Success = ErrorType.NoContent,
                    Message = "服务端未返回数据"
                };
            }

            //XTrace.WriteLine(receive);
            var message = Deserialize<XResponseMessage>(receive);
#if DEBUG
            sw.Stop();
            XTrace.WriteLine("API访问耗时：{0}ms", sw.ElapsedMilliseconds);
#endif
            return message;
            //Dispose();
        }

        #region 释放资源

        public void Dispose()
        {
            _session.Dispose();
        }

        public bool Disposed
        {
            get { return _session.Disposed; }
        }

        public event EventHandler OnDisposed;

        #endregion
    }
}