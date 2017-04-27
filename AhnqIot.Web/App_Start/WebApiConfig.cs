using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Web.Core;
using Autofac.Integration.WebApi;
using Newtonsoft.Json.Serialization;

namespace AhnqIot.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var json = config.Formatters.JsonFormatter;
            // 解决json序列化时的循环引用问题
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            // 干掉XML序列化器
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //// Web API 配置和服务
            //var suffix = typeof(DefaultHttpControllerSelector).GetField("ControllerSuffix",BindingFlags.Static | BindingFlags.Public);
            //if (suffix != null) suffix.SetValue(null, "ApiController");

            //支持命名空间
            //config.Services.Replace(typeof(IHttpControllerSelector),new NamespaceHttpControllerSelector(config));

            // Web API 路由
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
               "api_v1",
                "api/v1/{controller}/{action}/{id}",
                new
                {
                    action = RouteParameter.Optional,
                    id = RouteParameter.Optional,
                    namespaceName = new string[] { "WebApplication1.Controllers.api" }
                }//,
                //new
                //{
                //    action = new StartWithConstraint() //StartWithConstraint 必须是在当前项目中，真坑爹
                //}
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{area}/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //注册api controller的依赖解析器
            config.DependencyResolver = new AutofacWebApiDependencyResolver(AhnqIotContainer.Container);//注册api容器需要使用HttpConfiguration对象
        }
    }
}
