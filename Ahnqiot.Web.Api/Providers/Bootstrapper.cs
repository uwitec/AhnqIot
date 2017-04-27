#region Code File Comment
// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Web
// FILENAME   ： Bootstrapper.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-18 16:00
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System.Reflection;
using System.Web.Mvc;
using AhnqIot.Bussiness.Core;
using AhnqIot.Infrastructure.DI;
using Autofac;
using Autofac.Integration.WebApi;

namespace Ahnqiot.Web.Api.Providers
{
    public class Bootstrapper
    {
        static Bootstrapper()
        {
            Work();
            //Init();
        }
        /// <summary>
        /// 初始化工作
        /// </summary>
        public static void Init()
        {
            //具体工作放到静态构造函数
        }

        static void Work()
        {
            var builder = new ContainerBuilder();
            AhnqIotContainer.Builder = builder;
            //Service层启动初始化
            AhnqIot.Bussiness.Core.BussinessBootStraper.Start();
            //注册MVC和WEB API的controller
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();//注册api容器的实现
            //容器注册完成
            
            //注册api controller的依赖解析器

            //此部分实现在appstart里面WebApiConfig里面已实现

            //初始化数据库数据
            BussinessBootStraper.InitDatabaseData();
        }
    }
}