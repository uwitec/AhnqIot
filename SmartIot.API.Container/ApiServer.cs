#region Code File Comment
// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.Container
// FILENAME   ： ApiServer.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-25 15:08
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016
#endregion

using System;
using System.Runtime.Serialization;
using System.Threading;
using NewLife;
using NewLife.Model;
using NewLife.Net;
using NewLife.Threading;
using Smart.Redis;
using Smart.Redis.Config;
using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Formatter;
using SmartIot.API.Container.Core;
using SmartIot.API.Processor;

namespace SmartIot.API.Container
{
    public class ApiServer
    {
        #region field

        protected DataProtocalType ProtocalType;
        protected FormatterBase Formatter;

        /// <summary>
        /// 网络服务
        /// </summary>
        private TcpServer _server;
        /// <summary>
        /// 网络信息显示定时器
        /// </summary>
        private TimerX _showSessionTimer;
        ///// <summary>
        /////     启动消息处理
        ///// </summary>
        //private Boolean _enableProcessMessage = false;

        #region REDIS

        private string redisIP;

        private int redisPort;

        /// <summary>
        ///     实例化一个redis客户端
        /// </summary>
        private RedisClient _redisClient;

        #endregion

        #endregion

        #region ctor


        #endregion

        public ApiServer()
        {
            Formatter = new NotSupportFormatter();
            Formatter = ObjectContainer.Current.Resolve<FormatterBase>(ProtocalType.ToString());
        }

        public void Start(int port)
        {
            if (_server == null)
            {
                _server = new TcpServer { Log = ServiceLogger.Current.Logger, Port = port, MaxNotActive = 120 };
                _server.NewSession += server_NewSession;
                _server.Error += _server_Error;
                _server.OnDisposed += _server_OnDisposed;
            }
            try
            {
                _server.Start();
                WriteLog("网络服务开始接收数据");

                if (_showSessionTimer == null)
                    _showSessionTimer = new TimerX(ShowSessions, _server, 1000, 1000);
                NetHelper.ShowTcpParameters();
                //初始化RedisClient
                _redisClient = new RedisClient();
            }
            catch (Exception ex)
            {
                ServiceLogger.Current.WriteException(ex);
            }
        }

        private void ShowSessions(Object state)
        {
            var server = state as TcpServer;
            if (server == null) return;

            var count = server.Sessions.Count;
        }

        private void _server_OnDisposed(object sender, EventArgs e)
        {
            WriteLog("服务资源已释放");
        }

        private void _server_Error(object sender, ExceptionEventArgs e)
        {
            WriteLog("网络服务出现错误，{0}", e.Exception.Message);
        }

        public void Stop()
        {
            if (_server != null)
            {
                _server.Stop();
                _server.OnDisposed -= _server_OnDisposed;
                _server.Error -= _server_Error;
                _server.NewSession -= server_NewSession;
            }
        }

        private void server_NewSession(object sender, SessionEventArgs e)
        {
            var ip = e.Session.Remote.Address;
            WriteLog("{0,15} {1}", ip, ip.GetAddress());

            e.Session.Received += session_Received;
            e.Session.OnDisposed += (s, de) => { (s as ISocketSession).Received -= session_Received; };
        }

        private void session_Received(object sender, ReceivedEventArgs e)
        {
            Process(sender as ISocketSession, e);
        }


        public void Process(ISocketSession session, ReceivedEventArgs e)
        {
            string package = e.ToStr();
            var client = session;

            var id = Guid.NewGuid().ToString();
            //缓存客户端会话
            RemoteSessionHelper.RemoteSessionCache.AddOrUpdate(id,
                    key => null,
                    (key, oldValue) =>
                    {
                        if (!oldValue.Disposed)
                        {
                            oldValue.Dispose();
                        }
                        return client;
                    });
            //将数据包封装后放到redis中
            var dataPackage = new DataPacket { Id = id, Data = package, Date = DateTime.Now }; //对当前接受数据进行封装
            _redisClient.ListAdd(RedisKeyString.PackageList, dataPackage, DataType.Protobuf);
            //数据包处理结束
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        private void WriteLog(string format, params object[] args)
        {
            ServiceLogger.Current.WriteDebugLog(format, args);
        }
    }
}