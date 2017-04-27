using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ahnqiot.Web.Api.Providers;
using Ahnqiot.Web.Api.Providers.Exception;
using Ahnqiot.Web.Api.Providers.Results;

namespace Ahnqiot.Web.Api.Controllers
{
    public class ZongbaoController : ApiController
    {
        /// <summary>
        /// 测试异常处理
        /// </summary>
        /// <returns>Exception</returns>
        [HttpGet]
        public IHttpActionResult e1()
        {
            throw new Exception("异常处理");
        }

        /// <summary>
        /// 测试异常处理
        /// </summary>
        /// <returns>BusinessException</returns>
        [HttpGet]
        public IHttpActionResult e2()
        {
            throw new BusinessException("BusinessException") {Code = ExceptionCode.Success};
        }

        /// <summary>
        /// 测试异常处理
        /// </summary>
        /// <returns>ArgumentException</returns>
        [HttpGet]
        public IHttpActionResult e3()
        {
            throw new ArgumentException("aaa");
        }

        /// <summary>
        /// 测试异常处理
        /// </summary>
        /// <returns>AggregateException</returns>
        [HttpGet]
        public IHttpActionResult e5()
        {
            throw new AggregateException(new Exception[]
            {
                new Exception("1111"),
                new Exception("22222"),
                new Exception("3333333333"),
                new Exception("444444444444"),
                new Exception("5555555555555"),
                new Exception("6666666666666666666"),
            });
        }

        /// <summary>
        /// 测试异常处理
        /// </summary>
        /// <returns>ModelState</returns>
        [HttpGet]
        public IHttpActionResult e4()
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("1", "1111");
                ModelState.AddModelError("2", "222222");
                ModelState.AddModelError("3", "3333333333333");
                ModelState.AddModelError("4", "44444444444444");
                ModelState.AddModelError("5", "555555555555555");
            }
            return new ApiResult(ModelState.IsValid ? ExceptionCode.Success : ExceptionCode.InternalError,
                ModelState.Select(e=>e.Value).SelectMany(e=>e.Errors).Select(e=>e.ErrorMessage).Join(Environment.NewLine), null);
        }
    }
}
