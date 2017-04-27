#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： AWIOT.API.Processor.Container
// FILENAME   ： NetServer.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-31 14:19
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using NewLife.Model;
using NewLife.Net;
using NewLife.Threading;
using Smart.Redis;
using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Formatter;
using SmartIot.API.Processor;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AhnqIot.Infrastructure.Common;

namespace SmartIot.API.Container
{
    public class ApiNetServer
    {
        protected DataProtocalType ProtocalType;
        protected FormatterBase Formatter;

        public ApiNetServer()
        {
            Formatter = new NotSupportFormatter();
            Formatter = ObjectContainer.Current.Resolve<FormatterBase>(ProtocalType.ToString());
        }

        private TcpServer _server;

        private TimerX _timer;

        private TimerX _processRedisTimer;

        /// <summary>
        /// 启动消息处理
        /// </summary>
        private Boolean EnableProcessMessage = false;

        private Thread[] processThreads;

        /// <summary>
        /// 实例化一个redis客户端
        /// </summary>
        public RedisClient redis = new RedisClient();

        public void Start(int port)
        {
            if (_server == null)
            {
                _server = new TcpServer { Log = ServiceLogger.Current.Logger, Port = port, MaxNotActive = 120 };
                _server.NewSession += server_NewSession;
            }
            try
            {
                _server.Start();
                if (_timer == null)
                    _timer = new TimerX(ShowSessions, _server, 1000, 1000);
                NetHelper.ShowTcpParameters();

                EnableProcessMessage = true;
                //ProcessMessage();

                const int threadCount = 2;
                processThreads = new Thread[threadCount];
                for (int i = 0; i < threadCount; i++)
                {
                    //Task.Factory.StartNew(ProcessMessage);
                    Thread th = new Thread(ProcessMessage);
                    th.IsBackground = true;
                    th.Name = "解析数据线程" + i.ToString();
                    th.Priority = ThreadPriority.AboveNormal;
                    th.Start();
                    processThreads[i] = th;

                    Thread.Sleep(5000);
                }
            }
            catch (Exception ex) { ServiceLogger.Current.WriteException(ex); }
        }

        public void Stop()
        {
            EnableProcessMessage = false;
            if (_server != null) _server.Stop();
        }

        private readonly HashSet<String> _ips = new HashSet<string>();

        private void server_NewSession(object sender, SessionEventArgs e)
        {
            var ip = e.Session.Remote.Address;
            if (!_ips.Contains(ip.ToString()))
            {
                _ips.Add(ip.ToString());
                WriteLog("{0,15} {1}", ip, ip.GetAddress());
            }

            e.Session.Received += session_Received;
            e.Session.OnDisposed += (s, de) =>
            {
                (s as ISocketSession).Received -= session_Received;
            };
        }

        private Int32 _max = 0;

        private void ShowSessions(Object state)
        {
            var server = state as TcpServer;
            if (server == null) return;

            var count = server.Sessions.Count;
            if (count > _max) _max = count;

            if (processThreads == null)
                Console.Title = "会话数：{0} 最大：{1}，队列数：{2}".F(count, _max, _messageQueue.Count);
            else
                Console.Title = "会话数：{0} 最大：{1}，队列数：{2}，线程状态：{3} - {4}".F(count, _max, _messageQueue.Count,
                    processThreads[0] == null ? ThreadState.Unstarted : processThreads[0].ThreadState,
                    processThreads[1] == null ? ThreadState.Unstarted : processThreads[1].ThreadState);
        }

        private void session_Received(object sender, ReceivedEventArgs e)
        {
            _messageQueue.Enqueue(new Tuple<ISocketSession, ReceivedEventArgs>(sender as ISocketSession, e));
        }

        /// <summary>
        /// 消息队列
        /// </summary>
        private ConcurrentQueue<Tuple<ISocketSession, ReceivedEventArgs>> _messageQueue = new ConcurrentQueue<Tuple<ISocketSession, ReceivedEventArgs>>();

        /// <summary>
        /// 消息处理
        /// </summary>
        private async void ProcessMessage()
        {
            while (EnableProcessMessage)
            {
                Thread.Sleep(50);

                Tuple<ISocketSession, ReceivedEventArgs> e;
                try
                {
                    if (_messageQueue.TryDequeue(out e))
                    {
#if DEBUG
                        //System.Diagnostics.Stopwatch sp = new System.Diagnostics.Stopwatch();
                        //sp.Start();
#endif
                        var session = e.Item1;
                        if (session.Disposed) continue;

                        var id = Guid.NewGuid().ToString();//新会话ID
                        SmartIot.Service.Core.ServiceLogger._sessionDictionary.Add(id, session);//使用字典记录会话

                        var message = e.Item2.ToStr();
                        if (message.IsNullOrWhiteSpace()) continue;

                        var dataPackage = new DataPacket { Id = id, Data = message, Date = DateTime.Now };//对当前接受数据进行封装
                        //ProtocalType = DataProtocalType.Json;//json
                        //string packet = Formatter.Serialize(dataPackage);//序列化封装好的数据包
                        redis.Delete("packetKey");
                        //redis.Delete("facility");
                        //redis.Delete("device");
                        redis.Sadd("packetKey", dataPackage, DataType.Protobuf);//保存数据包(名为packetKey)

                        //var responseMessage = await ApiProcessor.Process(message);
                        //string str = responseMessage == null ? "" : responseMessage.ToString();
                        //session.Send(str);
                        Task.Factory.StartNew(() => AnalyticMessage(session));//开启新的线程执行对redis缓存中数据包的处理任务

#if DEBUG
                        //sp.Stop();
                        //if (sp.ElapsedMilliseconds > 100)
                        //    ServiceLogger.Current.WriteDebugLog("ProcessMessage: " + sp.ElapsedMilliseconds.ToString() + "ms" + "");
#endif
                    }
                }
                catch (ObjectDisposedException odex)
                {
                    ServiceLogger.Current.WriteException(odex);
                }
                catch (Exception ex)
                {
                    ServiceLogger.Current.WriteException(ex);
                }
            }

            WriteLog("处理数据线程退出：" + Thread.CurrentThread.Name);
        }

        /// <summary>
        /// 分析Redis缓存中packetKey的数据包并处理
        /// </summary>
        private void AnalyticMessage(ISocketSession session)
        {
            //StringLocker.Run("packetKey",)
            //{
                string str = "";
                //var packetList = redis.ListRange<string>("packetKey", 0, 10, DataType.Protobuf);//每次取10条数据
                var packetList = redis.Smember<DataPacket>("packetKey",DataType.Protobuf);
                packetList.ForEach(async p =>
                {
                    //var packet = Formatter.Deserialize<DataPacket>(p);//反序列化
                    var responseMessage = await ApiProcessor.Process(p.Data);
                    str = responseMessage == null ? "" : responseMessage.ToString();
                });

                session.Send(str);
            //StringLocker.Run("device", () => Task.Factory.StartNew(() => ApiProcessor.ProcessRedisCache()));
            //Thread.Sleep(50);//等待数据处理完毕后，在处理缓存
            if(_processRedisTimer==null)
                _processRedisTimer = new TimerX(obj=>ApiProcessor.ProcessRedisCache(), null, 1000, 5000);
            //Task.Factory.StartNew(() => ApiProcessor.ProcessRedisCache());//处理缓存
            //}        
        }

        private void WriteLog(string format, params object[] args)
        {
            ServiceLogger.Current.WriteDebugLog(format, args);
        }
    }
}