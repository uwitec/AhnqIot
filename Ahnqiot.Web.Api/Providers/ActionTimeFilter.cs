//  SOLUTION  ： 农业气象物联网V3
//  PROJECT     ： Ahnqiot.Web.Api
//  FILENAME   ： ActionTimeFilter.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 2016-04-19 8:49
//  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Ahnqiot.Web.Api.Providers.Results;
using AhnqIot.Infrastructure.Log;

namespace Ahnqiot.Web.Api.Providers
{
    public class ActionTimeFilter : ActionFilterAttribute
    {
        /*        
        不必针对异步模式进行处理，
        因为异步情况下也会对同步的代码进行调用
        */

        private Stopwatch _sw;

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            _sw = new Stopwatch();
            _sw.Start();
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
            var actionArguments = actionExecutedContext.ActionContext.ActionArguments;
            var controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            _sw.Stop();
            var str = JsonHelper.Serialize(new
            {
                controller = controllerName,
                action = actionName,
                args = actionArguments,
                elapsed = _sw.ElapsedMilliseconds,
                time = DateTime.Now
            });
            LogHelper.Trace($"[Action] [{_sw.ElapsedMilliseconds}] {str}");
        }
    }
}