#region Code File Comment

// SOLUTION   ： AWIOT - Device
// PROJECT    ： AWIOT.IOTClient.Core
// FILENAME   ： TransportFactory.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-30 10:16
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

#region using namespace

using NewLife;
using NewLife.Collections;
using NewLife.Log;
using NewLife.Net;
using System;
using System.Collections.Concurrent;
using System.Net;

#endregion using namespace

namespace Smart.Device.Transport
{
    public class TransportFactory
    {
        private static ConcurrentDictionary<string, IPAddress> _hostCache;

        /// <summary>
        ///     Transport缓存
        /// </summary>
        private static readonly DictionaryCache<string, ITransport> TransportsCache;

        static TransportFactory()
        {
            TransportsCache = new DictionaryCache<string, ITransport>();
            _hostCache = new ConcurrentDictionary<string, IPAddress>();
        }

        /// <summary>
        ///     创建Transport
        /// </summary>
        ///// <param name="args"></param>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public static ITransport CreateTransport(dynamic args, TransportTypeEnum type = TransportTypeEnum.Tcp)
        //{
        //    string args1 = args.Args1 + "";
        //    int args2 = Convert.ToInt32(args.Args2 + "");
        //    //读超时时间
        //    int timeout = Convert.ToInt32(args.Args3 + "");
        //    //try
        //    //{
        //    //    object outArgs3;
        //    //    if (args.TryGetValue("Args3", out outArgs3))
        //    //    {
        //    //        timeout = Convert.ToInt32(outArgs3 + "");
        //    //    }
        //    //}
        //    //catch (Exception)
        //    //{
        //    //}
        //    var key = string.Format("{0}://{1}:{2}", type.ToString(), args1, args2);

        //    var transport = TransportsCache.GetItem(key, type, args1, args2, timeout,
        //        (k, t, a1, a2, time) =>
        //        {
        //            if (t == TransportTypeEnum.Rs232)
        //            {
        //                var sp = new SerialTransport { PortName = a1, BaudRate = a2 };
        //                try
        //                {
        //                    sp.Open();
        //                    sp.Serial.ReadTimeout = time;
        //                    sp.Disconnected += (s, e) =>
        //                    {
        //                        if (TransportsCache.ContainsKey(key))
        //                        {
        //                            lock (TransportsCache)
        //                            {
        //                                if (TransportsCache.ContainsKey(key))
        //                                {
        //                                    TransportsCache.Remove(key);
        //                                }
        //                            }
        //                        }
        //                    };
        //                }
        //                catch (Exception ex)
        //                {
        //                    XTrace.WriteException(ex);
        //                }
        //                return sp;
        //            }
        //            else if (t == TransportTypeEnum.Tcp || t == TransportTypeEnum.Udp)
        //            {
        //                var session = NetService.CreateSession(
        //                    new NetUri(string.Format("{0}://{1}:{2}", t.ToString(), NetHelper.ParseAddress(a1), a2)),
        //                    timeout);
        //                session.Log = XTrace.Log;
        //                if (session.GetType() == typeof(TcpSession))
        //                {
        //                    var tcpSession = session as TcpSession;
        //                    tcpSession.Open();
        //                    tcpSession.Client.ReceiveTimeout = time;
        //                }
        //                session.Error += Session_Error;
        //                return session as ITransport;
        //            }
        //            return null;
        //        });

        //    if (transport == null)
        //    {
        //        TransportsCache.Remove(key);
        //    }
        //    // todo transport 释放空间时如何处理？

        //    return transport;
        //}

        public static ITransport CreateTransport(TransportTypeEnum type, string host, int e, int timeout)
        {
            if (type == TransportTypeEnum.Rs232)
            {
                return CreateRS232Transport(host, e, timeout);
            }
            else if (type == TransportTypeEnum.Tcp || type == TransportTypeEnum.Udp)
            {
                return CreateNetTransport(type, host, e, timeout);
            }
            return null;
        }

        private static ITransport CreateNetTransport(TransportTypeEnum type, string host, int e, int timeout)
        {
            IPAddress ip;
            lock (_hostCache)
            {
                if (_hostCache.ContainsKey(host))
                {
                    ip = _hostCache[host];
                }
                else
                {
                    try
                    {
                        ip = NetHelper.ParseAddress(host);
                        _hostCache.TryAdd(host, ip);
                    }
                    catch (Exception ex)
                    {
                        XTrace.WriteException(ex);
                        return null;
                    }
                }
            }

            var session = new NetUri(string.Format("{0}://{1}:{2}", type.ToString(), ip, e)).CreateRemote();
            session.Log = XTrace.Log;
            session.Error += Session_Error;
            //if (session.GetType() == typeof(TcpSession))
            //{
            //    var se = session as SessionBase;
            //    se.Timeout = timeout;
            //}
            return session as ITransport;
        }

        private static ITransport CreateRS232Transport(string host, int e, int timeout)
        {
            string key = "RS232://{0}:{1}".F(host, e);
            var sp = new SerialTransport
            {
                PortName = host,
                BaudRate = e
            };
            try
            {
                sp.Open();
                sp.Serial.ReadTimeout = timeout;
                sp.Disconnected += (s, de) =>
                {
                    if (TransportsCache.ContainsKey(key))
                    {
                        lock (TransportsCache)
                        {
                            if (TransportsCache.ContainsKey(key))
                            {
                                TransportsCache.Remove(key);
                            }
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
            }
            return sp;
        }

        /// <summary>
        /// 网络通讯会话错误的处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Session_Error(object sender, ExceptionEventArgs e)
        {
            var session = sender as TcpSession;
            var key = session.Remote.ToString();
            if (TransportsCache.ContainsKey(key))
            {
                lock (TransportsCache)
                {
                    if (TransportsCache.ContainsKey(key))
                    {
                        TransportsCache.Remove(key);
                    }
                }
            }
        }

        public static ITransport GetTransport(TransportTypeEnum type, string host, int e, int timeout)
        {
            string key = "{0}://{1}:{2}".F(type.ToString(), host, e);
            ITransport trans = null;

            lock (TransportsCache)
            {
                if (TransportsCache.ContainsKey(key))
                {
                    trans = TransportsCache.GetItem(key, null);
                    if (trans == null)
                    {
                        TransportsCache.Remove(key);
                    }
                    else
                    {
                        if (type == TransportTypeEnum.Rs232)
                        {
                            var sp = trans as SerialTransport;
                            if (sp == null || sp.Disposed)
                            {
                                TransportsCache.Remove(key);

                                trans = CreateRS232Transport(host, e, timeout);
                                TransportsCache.Add(key, trans);
                            }
                        }
                        else if (type == TransportTypeEnum.Tcp || type == TransportTypeEnum.Udp)
                        {
                            var session = trans as SessionBase;
                            if (session == null || session.Disposed || !session.Active)
                            {
                                TransportsCache.Remove(key);

                                trans = CreateNetTransport(type, host, e, timeout);
                                TransportsCache.Add(key, trans);
                            }
                        }
                    }
                }
                else
                {
                    if (type == TransportTypeEnum.Rs232)
                    {
                        trans = CreateRS232Transport(host, e, timeout);
                        TransportsCache.Add(key, trans);
                    }
                    else if (type == TransportTypeEnum.Tcp || type == TransportTypeEnum.Udp)
                    {
                        trans = CreateNetTransport(type, host, e, timeout);
                        TransportsCache.Add(key, trans);
                    }
                }
            }
            return trans;
        }

        ///// <summary>
        /////     创建通讯
        ///// </summary>
        ///// <param name="key"></param>
        ///// <remarks>
        /////     格式说明
        /////     以下共四个参数
        /////     通讯方式 + 通讯连接信息 + 超时时间
        /////     1. Tcp://192.168.1.55:1024-5000
        /////     2. Udp://192.168.1.55:1024-5000
        /////     3. RS232://COM1:9600-5000
        ///// </remarks>
        ///// <returns></returns>
        //public static ITransport GetTransport(string key)
        //{
        //    if (TransportsCache.ContainsKey(key))
        //    {
        //        if (key.StartsWithIgnoreCase("RS232"))
        //        {
        //        }
        //        else
        //        {
        //            var transport = TransportsCache[key];

        //            var disposable2 = transport as IDisposable2;
        //            if (disposable2 != null && disposable2.Disposed)
        //            {
        //                var session = transport as TcpSession;
        //                //检查Session
        //                if (session == null || session.Disposed)
        //                {
        //                    session = null;
        //                    //移除key
        //                    TransportsCache.Remove(key);
        //                }
        //                else
        //                {
        //                    return transport;
        //                }
        //            }
        //        }
        //    }

        //    var t = TransportsCache.GetItem(key, k =>
        //    {
        //        var arr = key.Split(new string[] { ":", "//", "-" }, StringSplitOptions.RemoveEmptyEntries);
        //        //var type = (TransportEnum)Enum.Parse(typeof(TransportEnum), arr[0]);
        //        var type = (TransportTypeEnum)Enum.Parse(typeof(TransportTypeEnum), arr[0], true);
        //        dynamic args = new ExpandoObject();
        //        //args.Args1 = "192.168.0.233";
        //        //args.Args2 ="10001";
        //        //args.Args3 = 5000;
        //        args.Args1 = arr[1];
        //        args.Args2 = arr[2];
        //        if (arr.Length > 3)
        //            args.Args3 = arr[3];
        //        else args.Args3 = 5000;

        //        return CreateTransport(args, type);
        //    });
        //    return t;
        //}
    }
}