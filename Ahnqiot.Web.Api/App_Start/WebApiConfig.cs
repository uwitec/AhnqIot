using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Ahnqiot.Web.Api.Providers;
using Ahnqiot.Web.Api.Providers.Exception;
using AhnqIot.Infrastructure.DI;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace Ahnqiot.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //// Web API 配置和服务
            //// 将 Web API 配置为仅使用不记名令牌身份验证。
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.Filters.Add(new ActionTimeFilter());
            config.Filters.Add(new ExceptionHandlingAttribute());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            //注册api controller的依赖解析器
            config.DependencyResolver = new AutofacWebApiDependencyResolver(AhnqIotContainer.Container);//注册api容器需要使用HttpConfiguration对象

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
