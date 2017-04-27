using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Ahnqiot.Web.Api.Providers.Results;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.Log;
using WebGrease.Css.Extensions;

namespace Ahnqiot.Web.Api.Controllers
{
    public class SysAreaController : ApiController
    {
        public ISysAreaService SysAreaService { get; set; }

        /// <summary>
        /// 获取所有区域
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return await ResultFactory.Create(ModelState, async () => await SysAreaService.GetAllWidthRedisAsync(), "success", "未知错误");
        }

        /// <summary>
        /// 获取区域
        /// </summary>
        /// <param name="id">区域编码</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(string id)
        {
            return await ResultFactory.Create(ModelState, async arg => await SysAreaService.GetByIdWithRedisAsync(arg), id, "success", "请检查请求参数");
        }

        /// <summary>
        /// 获取区域
        /// </summary>
        /// <param name="id">区域编码</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetByName(string name)
        {
            return await ResultFactory.Create(ModelState, async arg => await SysAreaService.GetAsync(e=>e.Name==arg), name, "success", "请检查请求参数");
        }

    }
}
