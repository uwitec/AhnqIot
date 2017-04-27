using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Ahnqiot.Web.Api.Providers.Results;
using AhnqIot.Bussiness;
using AhnqIot.Bussiness.Interface;
using WebGrease.Css.Extensions;

namespace Ahnqiot.Web.Api.Controllers
{
    public class SysDepartController : ApiController
    {
        public ISysDepartmentService SysDepartService { get; set; }

        /// <summary>
        /// 获取所有机构
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return await  ResultFactory.Create(ModelState, async arg => await SysDepartService.GetAllWidthRedisAsync(), "", "success", "未知");
             
        }          

     /// <summary>
     /// 获取机构
     /// </summary>
     /// <param name="departId">机构编码</param>
     /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetBySerialNum(string departId)
        {
            return await  ResultFactory.Create(ModelState, async arg => await SysDepartService.GetByIdWithRedisAsync(arg), departId, "success", "请检查请求参数");

        }
    }
}
