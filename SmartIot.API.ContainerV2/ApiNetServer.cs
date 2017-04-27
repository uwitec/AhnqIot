//  SOLUTION  ： 农业气象物联网V3
//  PROJECT     ： SmartIot.API.ContainerV2
//  FILENAME   ： ApiNetServer.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 17:07
//  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using AhnqIot.Infrastructure.Log;
using NewLife;
using NewLife.Model;
using NewLife.Net;
using NewLife.Threading;
using Smart.Redis;
using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Formatter;
using SmartIot.API.ProcessorV2.Common;
using SmartIot.API.ProcessorV2.Core;
using SmartIot.Service.Core;
using DataPacket = SmartIot.API.ProcessorV2.Core.DataPacket;

namespace SmartIot.API.ContainerV2
{
    /// <summary>
    /// API网络服务
    /// </summary>
    public class ApiNetServer
    {
        public ApiNetServer()
        {
            Formatter = new NotSupportFormatter();
            Formatter = ObjectContainer.Current.Resolve<FormatterBase>(ProtocalType.ToString());
        }

        public void Start(int port)
        {
            if (_server == null)
            {
                _server = new TcpServer
                {
                    //Log = new NewlifeLogger(),
                    Port = port,
                    MaxNotActive = 120
                };
                _server.NewSession += server_NewSession;
                _server.Error += _server_Error;
                _server.OnDisposed += _server_OnDisposed;
            }
            try
            {
                //初始化RedisClient
                if (_redisClient == null)
                    _redisClient = RedisClient.DefaultDB;

                _server.Start();
                LogHelper.Info("API网络服务启动成功");

                if (_showSessionTimer == null)
                    _showSessionTimer = new TimerX(ShowSessions, _server, 1000, 3000);
                NetHelper.ShowTcpParameters();
            }
            catch (Exception ex)
            {
                LogHelper.Fatal(ex.ToString());
            }
        }

        private static void ShowSessions(object state)
        {
            var server = state as TcpServer;
            if (server == null) return;
            var count = server.Sessions.Count;
            LogHelper.Debug($"当前活动会话数：{count}");
        }

        private void _server_OnDisposed(object sender, EventArgs e)
        {
            LogHelper.Debug("API网络服务资源已释放");
        }

        private void _server_Error(object sender, ExceptionEventArgs e)
        {
            LogHelper.Error("API网络服务出现错误，{0}", e.Exception.Message);
        }

        public void Stop()
        {
            if (_server == null) return;
            _server.Stop();
            _server.OnDisposed -= _server_OnDisposed;
            _server.Error -= _server_Error;
            _server.NewSession -= server_NewSession;
        }

        private void server_NewSession(object sender, SessionEventArgs e)
        {
            var ip = e.Session.Remote.Address;
            //LogHelper.Debug("{0,15} {1}", ip, ip.GetAddress());
            //var id = (e.Session as TcpSession).ID;
            e.Session.Log = null;
            e.Session.Received += session_Received;
            e.Session.OnDisposed += (s, de) =>
            {
                var socketSession = s as ISocketSession;
                if (socketSession != null)
                    socketSession.Received -= session_Received;
            };
        }

        private void session_Received(object sender, ReceivedEventArgs e)
        {
            Process(sender as ISocketSession, e);
        }


        public void Process(ISocketSession session, ReceivedEventArgs e)
        {
            var package = e.ToStr();
            var client = session;

            var id = Guid.NewGuid().ToString();
            //缓存客户端会话
            RemoteSessionHelper.RemoteSessionCache.AddOrUpdate(id,
                key => client,
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
            _redisClient.Sadd(RedisKeyString.PackageList, dataPackage, RedisSerializeType.DataType);
            //数据包处理结束
        }

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

        /// <summary>
        ///     实例化一个redis客户端
        /// </summary>
        private RedisClient _redisClient;

        #endregion

        #endregion
    }
}