using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NewLife.Log;
using NewLife.Net;
using NewLife.Threading;

namespace _88ipCheck
{
    class Program
    {
        public const string domain = "vc1474.88ip.org";
        private static Thread[] sendThreads;
        public static TimerX ShowTimerX;

        public static Server Server { get; private set; }

        static void Main(string[] args)
        {
            XTrace.UseConsole();

            WriteLine("输入1启动服务端，输入2启动客户端");
            var k = Console.ReadLine();
            var kk = Convert.ToInt32(k);
            if (kk == 1)
            {
                WriteLine("请输入监听端口号：");
                var str = Console.ReadLine();
                var port = Convert.ToInt32(str);
                Server = new Server(port);
                Server.Start();
                WriteLine("服务已启动");
            }
            else if (kk == 2)
            {
                StartClient();

                WriteLine("启动10线程发送");
                sendThreads = new Thread[10];

                for (int i = 0; i < sendThreads.Count(); i++)
                {
                    sendThreads[i] = new Thread(iar =>
                    {
                        while (true)
                        {
                            Thread.Sleep(5000);
                            TestSend();

                        }
                    })
                    {
                        Name = "线程" + i.ToString(),
                        IsBackground = true
                    };
                    sendThreads[i].Start();
                }
                WriteLine("客户端已启动");

                ShowTimerX = new TimerX(obj =>
                {
                    Console.Title = string.Format("共发送{0}包{1}字节，共接收{2}包{3}字节", SendCounts, SendBytes, ReceiveCounts, ReceiveBytes);
                    WriteLine(Console.Title);
                }, null, 500, 100);
            }
            Console.ReadLine();
        }

        #region 客户端
        public static Byte[] data = new byte[1024];
        public static long SendBytes;
        public static long ReceiveBytes;
        public static long SendCounts;
        public static long ReceiveCounts;

        public static String Host;
        public static Int32 Port;

        static void StartClient()
        {
            WriteLine("请输入主机地址(若不输入将使用" + domain + ")：");
            var host = Console.ReadLine();
            Host = host.IsNullOrWhiteSpace() ? domain : host;
            WriteLine("请输入监听端口号：");
            var str = Console.ReadLine();
            var port = Convert.ToInt32(str);
            Port = port;
        }

        static void TestSend()
        {
            var ip = NetHelper.ParseAddress(Host);
            ISocketSession session = NetService.CreateSession(new NetUri(string.Format("Tcp://{0}:{1}", ip, Port)));
            try
            {
                session.Send(data);
                Interlocked.Add(ref SendBytes, data.Length);
                Interlocked.Increment(ref SendCounts);
                //WriteLine(string.Format("{0} 发送{1}字节，共{2}字节", DateTime.Now, data.Length, SendBytes));
                var receive = session.Receive();
                if (receive != null)
                {
                    Interlocked.Add(ref ReceiveBytes, receive.Length);
                    Interlocked.Increment(ref ReceiveCounts);
                }

                //WriteLine(string.Format("共接收{0}字节", ReceiveBytes));
            }
            catch (Exception ex)
            {
                WriteLine(ex.ToString());
            }
            session.Dispose();
        }
        #endregion


        static void WriteLine(string message)
        {
            XTrace.WriteLine(message);
        }
    }
}
