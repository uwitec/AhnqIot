using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Smart.Redis;
namespace RedisPubTest
{
    class Program
    {
        private static RedisClient client = RedisClient.DefaultDB;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region 
            //    Console.Title = "Redis发布、订阅服务";

            //    //发布服务
            //    //Pub();
            //    //Console.ReadLine();


            //    //订阅
            //    Subscription();

            //    RedisClient client = new RedisClient("172.16.16.65", 6379);
            //    while (true)
            //    {
            //        string input = Console.ReadLine();
            //        client.PublishMessage("channel-1", input);
            //    }
            //}

            //#region 发布/订阅·
            ///// 发布
            ///// </summary>
            //public static void Pub()
            //{
            //    //PooledRedisClientManager
            //    ServiceStack.Redis.IRedisClientsManager RedisClientManager = new ServiceStack.Redis.PooledRedisClientManager("172.16.16.65:6379");

            //    //发布、订阅服务 IRedisPubSubServer
            //    ServiceStack.Redis.RedisPubSubServer pubSubServer = new ServiceStack.Redis.RedisPubSubServer(RedisClientManager, "channel-1", "channel-2");

            //    //接收消息
            //    pubSubServer.OnMessage = (channel, msg) =>
            //    {
            //        Console.WriteLine(string.Format("服务端:频道{0}接收消息：{1}    时间：{2}", channel, msg, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
            //        Console.WriteLine("___________________________________________________________________");
            //    };
            //    pubSubServer.OnStart = () =>
            //    {
            //        Console.WriteLine("发布服务已启动");
            //        Console.WriteLine("___________________________________________________________________");
            //    };
            //    pubSubServer.OnStop = () => { Console.WriteLine("服务停止"); };
            //    pubSubServer.OnUnSubscribe = (channel) => { Console.WriteLine(channel); };
            //    pubSubServer.OnError = (e) => { Console.WriteLine(e.Message); };
            //    pubSubServer.OnFailover = (s) => { Console.WriteLine(s); };

            //    //pubSubServer.OnHeartbeatReceived = () => { Console.WriteLine("OnHeartbeatReceived"); };
            //    //pubSubServer.OnHeartbeatSent = () => { Console.WriteLine("OnHeartbeatSent"); };
            //    //pubSubServer.IsSentinelSubscription = true;
            //    pubSubServer.Start();


            //}


            ///// <summary>
            ///// 发送消息
            ///// </summary>
            //public static Task Send()
            //{
            //    return Task.Run(() =>
            //    {
            //        RedisClient client = new RedisClient("172.16.16.65", 6379);
            //        client.PublishMessage("channel-1", "这是我发送的消息！");
            //    });
            //}

            ///// <summary>
            ///// 订阅
            ///// </summary>
            //public static void Subscription()
            //{
            //    using (ServiceStack.Redis.RedisClient consumer = new RedisClient("172.16.16.65", 6379))
            //    {
            //        //创建订阅
            //        ServiceStack.Redis.IRedisSubscription subscription = consumer.CreateSubscription();

            //        //接收消息处理Action
            //        subscription.OnMessage = (channel, msg) =>
            //        {
            //            Console.WriteLine("频道【" + channel + "】订阅客户端接收消息：" + ":" + msg + "         [" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "]");
            //            Console.WriteLine("订阅数：" + subscription.SubscriptionCount);
            //            Console.WriteLine("___________________________________________________________________");

            //        };

            //        //订阅事件处理
            //        subscription.OnSubscribe = (channel) =>
            //        {
            //            Console.WriteLine("订阅客户端：开始订阅" + channel);
            //        };

            //        //取消订阅事件处理
            //        subscription.OnUnSubscribe = (a) => { Console.WriteLine("订阅客户端：取消订阅"); };

            //        //模拟：发送100条消息给服务
            //        Task.Run(() =>
            //        {
            //            using (ServiceStack.Redis.IRedisClient publisher = new ServiceStack.Redis.RedisClient("172.16.16.65", 6379))
            //            {
            //                for (int i = 1; i <= 100; i++)
            //                {
            //                    publisher.PublishMessage("channel-1", string.Format("这是我发送的第{0}消息!", i));
            //                    System.Threading.Thread.Sleep(200);
            //                }
            //            }
            //            subscription.UnSubscribeFromAllChannels();
            //        });

            //        //订阅频道
            //        subscription.SubscribeToChannels("channel-1");
            //    }

            //}


            //#endregion

            ///// <summary>
            ///// Example
            ///// </summary>
            //public static void Example()
            //{
            //    var messagesReceived = 0;
            //    var PublishMessageCount = 10;
            //    string MessagePrefix = "LCQ:", ChannelName = "channel-4";
            //    using (var redisConsumer = new RedisClient("172.16.16.65", 6379))
            //    using (var subscription = redisConsumer.CreateSubscription())
            //    {
            //        //订阅
            //        subscription.OnSubscribe = channel =>
            //        {
            //            Console.WriteLine("订阅频道'{0}'", channel);
            //            Console.WriteLine();
            //        };
            //        //取消订阅
            //        subscription.OnUnSubscribe = channel =>
            //        {
            //            Console.WriteLine("取消订阅 '{0}'", channel);
            //            Console.WriteLine();
            //        };

            //        //接收消息
            //        subscription.OnMessage = (channel, msg) =>
            //        {
            //            Console.WriteLine("接收消息 '{0}' from channel '{1}'", msg, channel);
            //            Console.WriteLine();
            //            //As soon as we've received all 5 messages, disconnect by unsubscribing to all channels
            //            if (++messagesReceived == PublishMessageCount)
            //            {
            //                subscription.UnSubscribeFromAllChannels();
            //            }
            //        };

            //        ThreadPool.QueueUserWorkItem(x =>
            //        {
            //            Thread.Sleep(200);
            //            Console.WriteLine("开始发送消息...");

            //            using (var redisPublisher = new RedisClient("172.16.16.65", 6379))
            //            {
            //                for (var i = 1; i <= PublishMessageCount; i++)
            //                {
            //                    var message = MessagePrefix + i;
            //                    Console.WriteLine("正在发布消息 '{0}' 到频道 '{1}'", message, ChannelName);
            //                    Console.WriteLine();
            //                    redisPublisher.PublishMessage(ChannelName, message);
            //                }
            //            }
            //        });

            //        Console.WriteLine("开始启动监听 '{0}'", ChannelName);
            //        subscription.SubscribeToChannels(ChannelName); //blocking
            //    }

            //    Console.WriteLine("EOF");
            #endregion

            while (true)
            {
                var str = Console.ReadLine();
                if (str.Equals("5"))
                {
                    client.Publish("bar", "hello world");
                }
                if (str.Equals("0"))
                {
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
