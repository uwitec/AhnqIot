#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： ahnqiot.Ef.Test
// FILENAME   ： Program.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-26 16:46
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Core;
using AhnqIot.Infrastructure.DI;
using Autofac;
using Smart.Device.Led.YXTD.Portocal;
#endregion

namespace ahnqiot.Ef.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            AhnqIotContainer.Builder = new ContainerBuilder();
            //Service层启动初始化
            BussinessBootStraper.Start();
            AhnqIotContainer.Builder.RegisterType<SysUserTest>().AsSelf();

            var t = AhnqIotContainer.Container.Resolve<SysUserTest>();
            try
            {
                var task = Task.Factory.StartNew(async () =>
                   {
                       await t.Test();
                   });
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            //LedDevice.Test(Console.ReadLine());


            Console.ReadLine();
        }
    }
}