using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NewLife;
using Smart.Redis;

namespace SmartIot.API.Tool
{
    class Program
    {
        private static string processName = "SmartIot.API.ContainerV2";

        private static RedisClient client;

        private static Timer printTimer;

        static void Main(string[] args)
        {
            client = RedisClient.DefaultDB;

            printTimer = new Timer(obj =>
            {
                Console.Clear();
                PrintRuntimeInfo();
            }, null, 1000, 3 * 1000);
           // PrintRuntimeInfo();


            Console.ReadLine();
        }

        private static void PrintRuntimeInfo()
        {
            PrintIntro();
            WriteLine("操作系统：{0} {1}  物理内存：{2}", Runtime.OSName, Runtime.Is64BitProcess ? "x64" : "x86", Runtime.PhysicalMemory);
            //1.计算机资源的使用监测
            WriteLine("/**************************************************/");
            PrintAppUseage();
            //2.redis的使用监测
            WriteLine("/**************************************************/");
            PrintRedisUsage();
            //
            WriteLine("");
            WriteLine("/**************************************************/");
            WriteLine("/***\t{0}\t***/", DateTime.Now.ToLongTimeString());
        }

        static void PrintIntro()
        {
            WriteLine("本程序用于实时监视接口服务对于资源的使用情况");
        }

        static void PrintAppUseage()
        {
            WriteLine("监测进程：{0}", processName);
            WriteLine("CPU：{0}%    内存：{1}MB", 50, 50);
        }

        #region redis
        static void PrintRedisUsage()
        {
            PrintRedisServerInfo();
            PrintRedisClientsInfo();
            PrintRedisMemoryInfo();
            WriteLine("---------------------------------");
            Write($"PACKAGE-LIST:  {client.Scard(RedisKeyString.PackageList)}\t");
            Write("    ");
            Write($"SensorData-LIST:  {client.Scard(RedisKeyString.SensorDataList)}\t");
            Write("    ");
            Write($"DataInfo-LIST:  {client.Scard(RedisKeyString.DataInfoList)}");
            WriteLine("");
            Write($"DeviceDataExceptionLog-LIST:  {client.Scard(RedisKeyString.DeviceDataExceptionLog)}\t");
            Write("    ");
            Write($"DeviceRunLog-LIST:  {client.Scard(RedisKeyString.DeviceRunLog)}\t");
            Write("    ");
            Write($"CameraRunLog-LIST:  {client.Scard(RedisKeyString.CameraRunLog)}");
        }

        static void PrintRedisServerInfo()
        {
            var serverInfo = client.Info("server", DataType.String);
            var arr = serverInfo.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in arr)
            {
                if (s.StartsWith("redis_version:") || s.StartsWith("os:") || s.StartsWith("tcp_port:"))
                {
                    Write(s);
                    Write("\t");
                }
            }
            WriteLine("");
        }

        static void PrintRedisClientsInfo()
        {
            var serverInfo = client.Info("clients", DataType.String);
            var arr = serverInfo.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in arr)
            {
                if (s.StartsWith("connected_clients:") || s.StartsWith("blocked_clients:"))
                {
                    Write(s);
                    Write("\t");
                }
            }
            WriteLine("");
        }

        static void PrintRedisMemoryInfo()
        {
            var serverInfo = client.Info("memory", DataType.String);
            var arr = serverInfo.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in arr)
            {
                if (s.StartsWith("used_memory_human:") || s.StartsWith("used_memory_peak_human:"))
                {
                    Write(s);
                    Write("\t");
                }
            }
            WriteLine("");
        }
        #endregion

        static void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        static void Write(string format, params object[] args)
        {
            Console.Write(format, args);
        }
    }
}
