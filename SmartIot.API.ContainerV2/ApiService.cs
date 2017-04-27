#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ContainerV2
// FILENAME   ： ApiService.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-25 22:00
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;
using NewLife.Configuration;
using NewLife.Threading;
using Smart.Redis;
using SmartIot.API.ProcessorV2.Common;
using SmartIot.API.ProcessorV2.Core;
using SmartIot.API.ProcessorV2.TaskManager.Core;
using XAgent;

#endregion

namespace SmartIot.API.ContainerV2
{
    public class ApiService : AgentServiceBase<ApiService>
    {
        #region 数据包分析

        /// <summary>
        ///     分析数据包，并将数据放到Redis中
        /// </summary>
        /// <returns></returns>
        private void ProcessPackageAsync()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                var redisClient = RedisClient.DefaultDB;
                var packetList = redisClient.Smember<DataPacket>(RedisKeyString.PackageList, RedisSerializeType.DataType);
                if (packetList != null && packetList.Any())
                {
                    Parallel.ForEach(packetList, async package =>
                    {
                        var app =
                            AhnqIotContainer.Container.Resolve<AwApplication>(new NamedParameter("package", package));
                        var r = redisClient.Srem(RedisKeyString.PackageList, package, RedisSerializeType.DataType);
                        if (r > 0)
                        {
                            try
                            {
                                await app.ProcessAsync();
                            }
                            catch (Exception ex)
                            {
                                LogHelper.Error(ex.ToString());
                                // throw;
                            }
                            //var task = app.ProcessAsync();
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
            sw.Stop();
            Console.WriteLine("数据包处理时间花费：{0}ms", sw.ElapsedMilliseconds);
        }

        #endregion

        #region field

        /// <summary>
        ///     网络服务监听端口
        /// </summary>
        private const int ListenPort = 65510;

        /// <summary>
        ///     网络服务
        /// </summary>
        private ApiNetServer _netNetServer;

        /// <summary>
        ///     分析数据包定时器
        /// </summary>
        private TimerX _processPackageTimerX;

        private TaskManager _taskManager;

        #endregion

        #region windows service 控制

        /// <summary>显示名字</summary>
        public override string DisplayName => "农气物联网数据中心服务";

        //    protected override void OnStart(string[] args)

        public void Start()
        {
            if (_netNetServer == null)
                _netNetServer = new ApiNetServer();

            try
            {
                var port = Config.GetConfig("Port", ListenPort);
                _netNetServer.Start(port);

                //启动数据包处理定时器
                _processPackageTimerX = new TimerX(obj => ProcessPackageAsync(), null, 500, 50);

                //启动计划任务
                _taskManager = new TaskManager();
                _taskManager.Start();

                //   base.OnStart(args);
                WriteLine("{0}启动", DisplayName);
            }
            catch (Exception ex)
            {
                WriteLine("服务启动失败，{0}", ex.Message);
                WriteLine("XXXXXXXXXXXXXXXXXXXXXXX");
                WriteLine(ex.ToString());
                WriteLine("XXXXXXXXXXXXXXXXXXXXXXX");
            }
        }

        /// <summary>停止</summary>
        protected override void OnStop()
        {
            if (_netNetServer == null) return;
            try
            {
                _netNetServer.Stop();
                _processPackageTimerX?.Dispose();

                StopWork();
                WriteLine("{0}停止", DisplayName);
            }
            catch (Exception ex)
            {
                WriteLine("服务停止失败，{0}", ex.Message);
                WriteLine("XXXXXXXXXXXXXXXXXXXXXXX");
                WriteLine(ex.ToString());
                WriteLine("XXXXXXXXXXXXXXXXXXXXXXX");
            }
        }

        #endregion
    }
}