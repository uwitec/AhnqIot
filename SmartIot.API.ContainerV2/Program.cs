#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.Container
// FILENAME   ： Program.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-28 11:19
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using AhnqIot.Bussiness.Core;
using AhnqIot.Infrastructure.DI;
using Autofac;
using NewLife;
using NewLife.Log;
using NewLife.Threading;
using SmartIot.API.ProcessorV2;

#endregion

namespace SmartIot.API.ContainerV2
{
    public class Program
    {
        private static TimerX _releaseTimerX;

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            AhnqIotContainer.Builder = builder;
            BootStraper.Start();
            //Service层启动初始化
            BussinessBootStraper.Start();
            //Assembly asm = Assembly.ReflectionOnlyLoadFrom("SmartIot.API.Processor.dll");
            //Ioc.CurrentIoc.RegisterAssembly(asm);
            //Ioc.CurrentIoc.RegisterType<ManageDataProcessor, ManageDataProcessor>();
            //容器注册完成
            //Ioc.CurrentIoc.RegisterDone();

            //初始化数据库数据
            BussinessBootStraper.InitDatabaseData();

            //每10分钟自动释放存一次
            _releaseTimerX = new TimerX(obj => Runtime.ReleaseMemory(), null, 5* 60 * 1000, 10 * 60 * 1000);

            // ApiService.ServiceMain();
            var service = new ApiService();
            service.Start();
            Console.ReadLine();
        }
    }
}