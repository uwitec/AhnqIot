using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart.Redis;

namespace RedisSubTest
{
    class Program
    {
        private static RedisClient client = RedisClient.DefaultDB;
        static void Main(string[] args)
        {
            client.Subscribe("bar");
            Console.ReadLine();
            Console.ReadKey();
            //System.Text.RegularExpressions.Regex.Replace("abcdefg", "a", "b");
        }
    }


    /// <summary>
    /// 单例模式（lazy模式，防止多线程的情况下，同时创建两个类的实例对象）
    /// </summary>
    public class Singleton
    {
        private static Singleton instance;
        private static object _lock = new object();

        private Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }
}
