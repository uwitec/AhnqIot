#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： Smart.Redis
// FILENAME   ： TcpClient.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-12-11 9:42
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

#endregion

namespace Smart.Redis
{
    public class TcpClient
    {
        private readonly string _host;

        private readonly int _port;

        private readonly SocketAsyncEventArgs _saea = new SocketAsyncEventArgs();

        public TcpClient(string host, int port)
        {
            _saea.SetBuffer(new byte[1024 * 2], 0, 1024 * 2);
            _host = host;
            _port = port;
            DB = 0;
        }

        public Exception LastError { get; private set; }

        public Socket Socket { get; private set; }

        public bool Connected { get; private set; } = false;

        public int DB { get; set; }

        public void DisConnect()
        {
            Connected = false;
            try
            {
                Socket?.Shutdown(SocketShutdown.Both);
            }
            catch
            {
            }
            try
            {
                Socket?.Close();
            }
            catch
            {
            }
            Socket = null;
        }

        public bool Connect()
        {
            if (Connected)
                return true;
            var ips = Dns.GetHostAddresses(_host);
            if (ips.Length == 0)
                throw new Exception("get host's IPAddress error");

            var address = ips[0];

            try
            {
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                {
                    ReceiveTimeout = 5000,
                    SendTimeout = 5000
                };
                Socket.Connect(address, _port);
                Connected = true;
                return true;
            }
            catch (Exception e_)
            {
                DisConnect();
                LastError = e_;
                return false;
            }
        }

        public TcpReceiveArgs Receive(int count)
        {
            try
            {
                var rcount = Socket.Receive(_saea.Buffer, count, SocketFlags.None);
                if (rcount == 0)
                    throw new Exception($"{_host} client disconnect!");
                return new TcpReceiveArgs() { Client = this, Count = rcount, Data = _saea.Buffer, Offset = 0 };
            }
            catch (Exception e_)
            {
                DisConnect();
                LastError = e_;
                throw e_;
            }
        }

        public TcpReceiveArgs Receive()
        {
            try
            {
                var count = Socket.Receive(_saea.Buffer, SocketFlags.None);
                if (count == 0)
                    throw new Exception($"{_host} client disconnect!");
                return new TcpReceiveArgs() { Client = this, Count = count, Data = _saea.Buffer, Offset = 0 };
            }
            catch (Exception e_)
            {
                DisConnect();
                LastError = e_;
                throw e_;
            }
        }
        /// <summary>
        /// 异步接收
        /// </summary>
        public void ReceiveAsync()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Send(string value)
        {
            return Send(value, Encoding.UTF8);
        }

        public bool Send(string value, Encoding coding)
        {
            return Send(coding.GetBytes(value));
        }

        public bool Send(byte[] data)
        {
            return Send(data, 0, data.Length);
        }

        public bool Send(byte[] data, int offset, int count)
        {
            if (Connect())
            {
                try
                {
                    while (count > 0)
                    {
                        var sends = Socket.Send(data, offset, count, SocketFlags.None);
                        count -= sends;
                        offset += sends;
                    }
                    return true;
                }
                catch (Exception e_)
                {
                    DisConnect();
                    LastError = e_;
                    return false;
                }
            }
            return false;
        }

        public bool Send(ArraySegment<byte> data)
        {
            return Send(data.Array, data.Offset, data.Count);
        }

        /// <summary>
        ///     发送
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        internal static Result Send(Command cmd, TcpClient client)
        {
            var sdata = BufferPool.Single.Pop();
            try
            {
                var count = cmd.ToData(sdata);
                if (!client.Send(sdata, 0, count))
                {
                    throw new Exception($"{client._host} client disconnect!");
                }
            }
            catch (Exception e_)
            {
                client.LastError = e_;

                throw new Exception($"send to {client._host} error!", e_);
            }
            finally
            {
                BufferPool.Single.Push(sdata);
            }
            var result = new Result();

            try
            {
                while (true)
                {
                    var res = client.Receive();
                    if (result.Import(res.Data, res.Offset, res.Count))
                    {
                        break;
                    }
                }
                if (result.mImportOffset > 0)
                {
                    client.Receive(result.mImportOffset);
                }
            }
            catch (Exception e_)
            {
                result.Dispose();
                client.LastError = e_;
                throw new Exception($"receive {client._host} error!", e_);
            }
            return result;
        }
    }
}