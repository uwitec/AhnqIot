#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： Smart.Redis
// FILENAME   ： RedisHost.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-12-11 9:42
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

#endregion

namespace Smart.Redis
{
    public class RedisHost
    {
        private bool _detecting;

        private readonly ConcurrentStack<TcpClient> _mClients = new ConcurrentStack<TcpClient>();

        public RedisHost(string host, int count)
        {
            Port = 6379;
            Available = true;
            var ps = host.Split(':');
            Host = ps[0];
            if (ps.Length > 1)
                Port = int.Parse(ps[1]);
            for (var i = 0; i < count; i++)
            {
                Push(CreateClient());
            }
        }

        public string Host { get; set; }

        public int Port { get; set; }

        public bool Available { get; set; }

        public int LastCheckTime { get; set; }

        public Exception LastError { get; set; }

        private TcpClient CreateClient()
        {
            return new TcpClient(Host, Port);
        }

        public IList<string> Info()
        {
            IList<string> result = new List<string>();
            using (var c = Pop())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_INFO);
                    using (var r = TcpClient.Send(cmd, c.Client))
                    {
                        foreach (var item in r.ResultDataBlock)
                        {
                            result.Add(item.GetString());
                        }
                    }
                }
            }
            return result;
        }

        private void OnDetect(object state)
        {
            try
            {
                var client = CreateClient();
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_PING);
                    using (TcpClient.Send(cmd, client))
                    {
                    }
                }
                Push(client);
                Available = true;
            }
            catch (Exception e)
            {
                LastError = e;
                Available = false;
            }
            _detecting = false;
        }

        public void Detect()
        {
            lock (this)
            {
                if (!Available && !_detecting && (Math.Abs(Environment.TickCount) - LastCheckTime) > 10000)
                {
                    _detecting = true;
                    LastCheckTime = Math.Abs(Environment.TickCount);
                    ThreadPool.QueueUserWorkItem(OnDetect, null);
                }
            }
        }

        public void Push(TcpClient client)
        {
            if (client != null)
            {
                if (client.Connected)
                {
                    _mClients.Push(client);
                }
                else
                {
                    Detect();
                }
            }
        }

        internal ClientItem Pop()
        {
            TcpClient client;
            if (_mClients.TryPop(out client))
            {
                return new ClientItem(this, client);
            }
            return new ClientItem(this, CreateClient());
        }

        public class ClientItem : IDisposable
        {
            private RedisHost _mHost;

            public ClientItem(RedisHost host, TcpClient client)
            {
                _mHost = host;
                Client = client;
            }

            public TcpClient Client { get; private set; }

            public void Dispose()
            {
                _mHost.Push(Client);
                Client = null;
                _mHost = null;
            }
        }
    }
}