#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.Container
// FILENAME   ： Program.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-28 11:19
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using AhnqIot.Bussiness.Core;
using AhnqIot.Infrastructure.DI;
using Autofac;
using NewLife.Log;

#endregion

namespace SmartIot.API.Container
{
    public class Program
    {
        static void Main(string[] args)
        {
            XTrace.UseConsole();


            var builder = new ContainerBuilder();
            AhnqIotContainer.Builder = builder;
            //Service层启动初始化
            BussinessBootStraper.Start();
            //Assembly asm = Assembly.ReflectionOnlyLoadFrom("SmartIot.API.Processor.dll");
            //Ioc.CurrentIoc.RegisterAssembly(asm);
            //Ioc.CurrentIoc.RegisterType<ManageDataProcessor, ManageDataProcessor>();
            //容器注册完成
            //Ioc.CurrentIoc.RegisterDone();


            ApiService.ServiceMain();
        }
    }
}